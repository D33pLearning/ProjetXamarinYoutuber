using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetMobileB3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ProjetMobileB3.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private const String NAVIGATE_TO_PUBLIC_PROFILE_PAGE = "PublicProfile";  
        public INavigationService _navigationService;
        public DelegateCommand NavigateToPublicProfilePageCommand { get; private set; }
        public DelegateCommand NavigateToAddYoutuberCommand { get; private set; }

        public List<Youtuber> Youtubers { get; set; }

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


        public void NavigateToYoutuberDetail(Youtuber selectedYoutuber)
        {
            var parameter = new NavigationParameters();
            parameter.Add("youtuber", selectedYoutuber);
            _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE, parameter);
            throw new NotImplementedException();
           // _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE + SelectedYoutuber.ToString());
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "YoutubeAdvisor";

            Youtubers = new List<Youtuber>();
            Youtubers.Add(new Youtuber(1, "TiboInShape", "tibo.jpg", "Musculation"));
            Youtubers.Add(new Youtuber(2, "Squeezie", "squeezie.jpg", "Jeux-vidéos"));
            Youtubers.Add(new Youtuber(3, "Zerator", "zerator.png", "Jeux-vidéos"));


            _navigationService = navigationService;
            NavigateToAddYoutuberCommand = new DelegateCommand(NavigateToAddYoutuberPage);
            NavigateToPublicProfilePageCommand = new DelegateCommand(NavigateToPublicProfilePage);

        }

        private void NavigateToPublicProfilePage()
        {
            //_navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE);
            //Myhandle();
            var parameter = new NavigationParameters();
            parameter.Add("youtuber", SelectedYoutuber);
            _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE, parameter);
        }

        private void NavigateToAddYoutuberPage()
        {
            _navigationService.NavigateAsync("AddYoutuber");
        }
    }
}
