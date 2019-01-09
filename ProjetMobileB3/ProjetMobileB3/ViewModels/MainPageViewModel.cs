using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetMobileB3.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private const String NAVIGATE_TO_PUBLIC_PROFILE_PAGE = "PublicProfile";  
        private INavigationService _navigationService;
        public DelegateCommand NavigateToPublicProfilePageCommand { get; private set; }
        public DelegateCommand NavigateToAddYoutuberCommand { get; private set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "YoutubeAdvisor";

            _navigationService = navigationService;
            NavigateToAddYoutuberCommand = new DelegateCommand(NavigateToAddYoutuberPage);
            NavigateToPublicProfilePageCommand = new DelegateCommand(NavigateToPublicProfilePage);
            
        }

        private void NavigateToPublicProfilePage()
        {
            _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE);
        }

        private void NavigateToAddYoutuberPage()
        {
            _navigationService.NavigateAsync("AddYoutuber");
        }
    }
}
