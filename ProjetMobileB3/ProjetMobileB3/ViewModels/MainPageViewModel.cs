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
        private const String NAVIGATE_TO_PROFILE_PAGE = "Profil";  
        private INavigationService _navigationService;
        public DelegateCommand NavigateToProfilePageCommand { get; private set; }
        public DelegateCommand NavigateToAddYoutuberCommand { get; private set; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "YoutubeAdvisor";

            _navigationService = navigationService;
            NavigateToAddYoutuberCommand = new DelegateCommand(NavigateToAddYoutuberPage);
            NavigateToProfilePageCommand = new DelegateCommand(NavigateToProfilePage);
            
        }

        private void NavigateToProfilePage()
        {
            _navigationService.NavigateAsync(NAVIGATE_TO_PROFILE_PAGE);
        }

        private void NavigateToAddYoutuberPage()
        {
            _navigationService.NavigateAsync("AddYoutuber");
        }
    }
}
