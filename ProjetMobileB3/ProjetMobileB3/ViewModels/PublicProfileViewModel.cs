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

namespace ProjetMobileB3.ViewModels
{
	public class PublicProfileViewModel : ViewModelBase, INotifyPropertyChanged
	{
	    public SQLiteConnection db { get; set; }

        private const String NAVIGATE_TO_PROFIL_PAGE = "Profil";
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


        public PublicProfileViewModel(INavigationService navigationService): base(navigationService)
        {
            _navigationService = navigationService;
            NavigateToProfilCommand = new DelegateCommand(NavigateToProfilPage);
            EnableButtonOpinion = true;
        }

	    private void NavigateToProfilPage()
	    {
	        //EnableButtonOpinion = false;
	        var parameter = new NavigationParameters();
	        parameter.Add("youtuber", SelectedYoutuber);
	        parameter.Add("db", db);
            _navigationService.NavigateAsync(NAVIGATE_TO_PROFIL_PAGE, parameter);
	    }

	    public override void OnNavigatedTo(INavigationParameters parameters)
	    {
	        var youtubeur = parameters["youtuber"] as Youtuber;
            db = parameters["db"] as SQLiteConnection;
            SelectedYoutuber = youtubeur;
	        //Task.Delay(1);
	    }
    }
}
