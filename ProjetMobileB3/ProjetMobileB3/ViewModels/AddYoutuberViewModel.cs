using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetMobileB3.Interfaces;
using ProjetMobileB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ProjetMobileB3.Views;


namespace ProjetMobileB3.ViewModels
{
    public class AddYoutuberViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

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

        public AddYoutuberViewModel(INavigationService navigationService, IMyDBService myDB) 
            : base(navigationService, myDB )
        {
            _navigationService = navigationService;
            NavigateToMainPageCommand = new DelegateCommand(NavigateToMainPage);

            NewYoutuber = new Youtuber();
            Youtubers = new List<Youtuber>();

            IsFieldEmpty = false;

            Logos = new List<string>();
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

        private bool _isFieldEmpty;
        public bool IsFieldEmpty
        {
            get { return _isFieldEmpty; }
            set { SetProperty(ref _isFieldEmpty, value);
                RaisePropertyChanged(nameof(IsFieldEmpty));
            }
        }

        private void NavigateToMainPage()
        {
            if (ChoiceCategorie != null && ChoiceLogo != null && ChoiceNickname != null)
            {

                Youtubers.Add(NewYoutuber);
                var parameter = new NavigationParameters();
                parameter.Add("youtuber", Youtubers);
                parameter.Add("new", NewYoutuber);
                _navigationService.NavigateAsync(nameof(MainPage), parameter);
                
            }
            else
            {
              IsFieldEmpty = true;
            }
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var ayoutubeur = parameters["youtuber"] as List<Youtuber>;
            Youtubers = ayoutubeur;
        }
    }
}