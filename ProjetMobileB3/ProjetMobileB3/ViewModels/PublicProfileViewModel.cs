using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetMobileB3.ViewModels
{
	public class PublicProfileViewModel : BindableBase
	{
	    private const String NAVIGATE_TO_PROFIL_PAGE = "Profil";
	    private INavigationService _navigationService;
	    public DelegateCommand NavigateToProfilCommand { get; private set; }
        public PublicProfileViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToProfilCommand = new DelegateCommand(NavigateToProfilPage);
        }

	    private void NavigateToProfilPage()
	    {
	        _navigationService.NavigateAsync(NAVIGATE_TO_PROFIL_PAGE);
	    }
    }
}
