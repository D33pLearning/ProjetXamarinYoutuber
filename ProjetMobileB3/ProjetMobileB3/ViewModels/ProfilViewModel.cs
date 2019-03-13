using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjetMobileB3.Models;
using Xamarin.Forms;
using SQLite;
using Unity.ObjectBuilder.Policies;
using ProjetMobileB3.Interfaces;

namespace ProjetMobileB3.ViewModels
{
	public class ProfilViewModel : ViewModelBase, INotifyPropertyChanged
	{
        private INavigationService _navigationService;
	    public DelegateCommand NavigateToPublicProfilePageCommand { get; private set; }

	    private Youtuber _selectedYoutuber;
        public Youtuber SelectedYoutuber
	    {
	        get
	        {
	            return _selectedYoutuber;
	        }
	        set
	        {
	            _selectedYoutuber = value;
	            RaisePropertyChanged(nameof(SelectedYoutuber));
	        }
	    }

	    private String _choice;
	    public String Choice
	    {
	        get
	        {
	            return _choice;
	        }
	        set
	        {
	            _choice = value;
	            RaisePropertyChanged(nameof(Choice));
	            SelectedYoutuber.Scam = Choice;
	        }
	    }

	    private int _choiceAverageRate;
	    public int ChoiceAverageRate
        {
	        get
	        {
	            return _choiceAverageRate;
	        }
	        set
	        {
                _choiceAverageRate = value;
	            RaisePropertyChanged(nameof(ChoiceAverageRate));
	          
            }
	    }
	    private int _choiceAdvisedAge;
        public int ChoiceAdvisedAge
	    {
	        get
	        {
	            return _choiceAdvisedAge;
	        }
	        set
	        {
	            _choiceAdvisedAge = value;
	            RaisePropertyChanged(nameof(ChoiceAdvisedAge));

	        }
	    }

        private List<String> _scams;
        public List<String> Scams
        {
            get { return _scams; }
            set { SetProperty(ref _scams, value); }
        }
        public List<int> Ages { get; set; }

	    public List<int> Notes { get; set; }

	    private bool _isFieldEmpty;
	    public bool IsFieldEmpty
	    {
	        get { return _isFieldEmpty; }
	        set
	        {
	            SetProperty(ref _isFieldEmpty, value);
	            RaisePropertyChanged(nameof(IsFieldEmpty));
	        }
	    }

        public ProfilViewModel(INavigationService navigationService, IMyDBService myDB) : base(navigationService, myDB)
        {
            _navigationService = navigationService;
            NavigateToPublicProfilePageCommand = new DelegateCommand(NavigateToPublicProfilePage);

            IsFieldEmpty = false;

            Scams = new List<string>();
            Scams.Add("Aucune");
            Scams.Add("Dropshipping");
            Scams.Add("Incitation aux jeux d'argent");
            Scams.Add("Pornographie");
            Scams.Add("Vulgarité");
            Scams.Add("Violence");
            Scams.Add("Pédophilie");

            Ages = new List<int>();
            Ages.Add(3);
            Ages.Add(7);
            Ages.Add(12);
            Ages.Add(16);
            Ages.Add(18);

            Notes = new List<int>();
            Notes.Add(1);
            Notes.Add(2);
            Notes.Add(3);
            Notes.Add(4);
            Notes.Add(5);

           
        }
	    public void UpdateSelectedYoutuber()
	    {
            if (Choice != null)
	            SelectedYoutuber.Scam = Choice;


	        SelectedYoutuber.AverageRate = ChoiceAverageRate;
            SelectedYoutuber.AdvisedAge = ChoiceAdvisedAge;

	        if (SelectedYoutuber != null)
	        {
	            if (SelectedYoutuber.AverageRate <= 2)
	                SelectedYoutuber.EmojiRate = "sad.png";
	            if (SelectedYoutuber.AverageRate == 3)
	                SelectedYoutuber.EmojiRate = "neutre.png";
	            if (SelectedYoutuber.AverageRate >= 4)
	                SelectedYoutuber.EmojiRate = "happy.png";

	            if (SelectedYoutuber.AverageRate == 1)
	                SelectedYoutuber.EmojiStars = "star1.PNG";
	            if (SelectedYoutuber.AverageRate == 2)
	                SelectedYoutuber.EmojiStars = "star2.PNG";
	            if (SelectedYoutuber.AverageRate == 3)
	                SelectedYoutuber.EmojiStars = "star3.PNG";
	            if (SelectedYoutuber.AverageRate == 4)
	                SelectedYoutuber.EmojiStars = "star4.PNG";
	            if (SelectedYoutuber.AverageRate == 5)
	                SelectedYoutuber.EmojiStars = "star5.PNG";
	        }
	    }
	    /*
         * NAVIGATION
         */
        private void NavigateToPublicProfilePage()
	    {
	        if (ChoiceAdvisedAge != 0 && ChoiceAverageRate != 0 && Choice != null)
	        {
	            UpdateSelectedYoutuber();
	            MyDBService.UpdateYoutubeur(SelectedYoutuber);
	            var parameter = new NavigationParameters();
	            parameter.Add("youtuber", SelectedYoutuber);
                parameter.Add("refresh", true);
	            _navigationService.GoBackAsync(parameter);
	        }
	        else
	        {
	            IsFieldEmpty = true;
	        }
	    }

	    public override void OnNavigatedTo(INavigationParameters parameters)
	    {
	        var youtubeur = parameters["youtuber"] as Youtuber;
            SelectedYoutuber = youtubeur;
	    }
    }
}
