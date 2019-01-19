using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ProjetMobileB3.Models;
using Xamarin.Forms;

namespace ProjetMobileB3.ViewModels
{
	public class ProfilViewModel : ViewModelBase, INotifyPropertyChanged
	{
	    private INavigationService _navigationService;
	    private const String NAVIGATE_TO_PUBLIC_PROFILE_PAGE = "PublicProfile";
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
	            //NavigateToYoutuberDetail(_selectedYoutuber);
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
	            //NavigateToYoutuberDetail(_selectedYoutuber);
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

        private Opinion _opinion;
	    public Opinion Opinion
	    {
	        get { return _opinion; }
	        set
	        {
	            _opinion = value;
	            RaisePropertyChanged(nameof(Opinion));
	        }

	    }
        public List<String> Arnaques { get; set; }
	    public List<int> Ages { get; set; }

	    public List<int> Notes { get; set; }

        public ProfilViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            NavigateToPublicProfilePageCommand = new DelegateCommand(NavigateToPublicProfilePage);

            Arnaques = new List<string>();
            Arnaques.Add("Dropshipping");
            Arnaques.Add("Incitation aux jeux d'argent");
            Arnaques.Add("Pornographie");
            Arnaques.Add("Vulgarité");

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

	    private void NavigateToPublicProfilePage()
	    {
            UpdateSelectedYoutuber();
            var parameter = new NavigationParameters();
	        parameter.Add("youtuber", SelectedYoutuber);
	        _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE, parameter);
	    }

	    public override void OnNavigatedTo(INavigationParameters parameters)
	    {
	        var youtubeur = parameters["youtuber"] as Youtuber;
	        SelectedYoutuber = youtubeur;
	    }

    }
}
