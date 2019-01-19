using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetMobileB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProjetMobileB3.ViewModels
{
    public class AddYoutuberViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        private const String NAVIGATE_TO_MAIN_PAGE = "MainPage";

        public DelegateCommand NavigateToMainPageCommand { get; private set; }

        public List<String> Logo { get; set; }

        public List<String> Categories { get; set; }

        private List<String> _logos;
        public List<String> Logos
        {
            get { return _logos; }
            set
            {
                _logos = value; RaisePropertyChanged(nameof(Logos));
            }
        }

        public List<Youtuber> _youtubers;
        public List<Youtuber> Youtubers
        {
            get { return _youtubers; }
            set { _youtubers = value; RaisePropertyChanged(nameof(Youtubers)); }
        }

        private Youtuber _newYoutuber;
        public Youtuber NewYoutuber
        {
            get
            {
                return _newYoutuber;
            }
            set
            {
                _newYoutuber = value;
                RaisePropertyChanged(nameof(NewYoutuber));
                //NavigateToYoutuberDetail(_selectedYoutuber);
            }
        }

        private String _choiceCategorie;
        public String ChoiceCategorie
        {
            get
            {
                return _choiceCategorie;
            }
            set
            {
                _choiceCategorie = value;
                RaisePropertyChanged(nameof(ChoiceCategorie));
                
                NewYoutuber.Categorie = ChoiceCategorie;
                //NavigateToYoutuberDetail(_selectedYoutuber);
            }
        }

        private string _choiceNickname;
        public string ChoiceNickname
        {
            get { return _choiceNickname; }
            set
            {
                _choiceNickname = value; RaisePropertyChanged(nameof(ChoiceNickname));
                NewYoutuber.Nickname = ChoiceNickname;
            }
        }

        private string _choiceLogo;
        public string ChoiceLogo
        {
            get { return _choiceLogo; }
            set
            {
                _choiceLogo = value; RaisePropertyChanged(nameof(ChoiceLogo));
                if (ChoiceLogo == "Homme")
                    NewYoutuber.Logo = "emptyLogoMan.jpg";
                else if (ChoiceLogo == "Femme")
                    NewYoutuber.Logo = "emptyLogoWoman.png";
                else
                {
                    NewYoutuber.Logo = "emptyLogo.png";
                }
            }
        }

        public AddYoutuberViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            NavigateToMainPageCommand = new DelegateCommand(NavigateToMainPage);

            NewYoutuber = new Youtuber();
            Youtubers = new List<Youtuber>();

            Logos = new List<string>();
            //Logos.Add("emptyLogoMan.jpg");
            //Logos.Add("emptyLogoWoman.png");
            Logos.Add("Femme");
            Logos.Add("Homme");
            

            Categories = new List<string>();
            Categories.Add("Musculation");
            Categories.Add("Podcast");
            Categories.Add("Lifestyle");
            Categories.Add("Jeux-vidéos");
            Categories.Add("Culture");
            Categories.Add("Sport");
        }

        private void NavigateToMainPage()
        {
            Youtubers.Add(NewYoutuber);
            var parameter = new NavigationParameters();
            parameter.Add("youtuber", Youtubers);
            _navigationService.NavigateAsync(NAVIGATE_TO_MAIN_PAGE, parameter);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var ayoutubeur = parameters["youtuber"] as List<Youtuber>;
            Youtubers = ayoutubeur;
        }


    }
}