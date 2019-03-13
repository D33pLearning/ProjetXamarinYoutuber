using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ProjetMobileB3.Models;
using SQLite;
using ProjetMobileB3.Interfaces;
using ProjetMobileB3.Views;

namespace ProjetMobileB3.ViewModels
{
	public class PublicProfileViewModel : ViewModelBase, INotifyPropertyChanged
	{
	    private INavigationService _navigationService;
	    public DelegateCommand NavigateToProfilCommand { get; private set; }

	    private Youtuber _selectedYoutuber;

	    public Youtuber SelectedYoutuber
	    {
	        get { return _selectedYoutuber; }
	        set {
	            _selectedYoutuber = value;
	            RaisePropertyChanged(nameof(SelectedYoutuber));
	        }

	    }

	    private bool _enableButtonOpinion;
	    public bool EnableButtonOpinion
        {
	        get { return _enableButtonOpinion; }
	        set
	        {
	            _enableButtonOpinion = value;
	            RaisePropertyChanged(nameof(EnableButtonOpinion));
	        }

	    }


        public PublicProfileViewModel(INavigationService navigationService, IMyDBService myDB) : base(navigationService, myDB)
        {
            _navigationService = navigationService;
            NavigateToProfilCommand = new DelegateCommand(NavigateToProfilPage);
            EnableButtonOpinion = true;
        }

	    /*
         * NAVIGATION
         */
        private void NavigateToProfilPage()
	    {
	        var parameter = new NavigationParameters();
	        parameter.Add("youtuber", SelectedYoutuber);
            _navigationService.NavigateAsync(nameof(Profil), parameter);
	    }

	    public override void OnNavigatedTo(INavigationParameters parameters)
	    {
	        var youtubeur = parameters["youtuber"] as Youtuber;
	        if (youtubeur != null)
	        {
	            SelectedYoutuber = youtubeur;
	        }
	        var refresh = parameters["refresh"];
	        if (refresh != null)
	        {
	            SelectedYoutuber = MyDBService.SelectYoutubeurById(youtubeur.Id);
	        }
        }
    }
}
