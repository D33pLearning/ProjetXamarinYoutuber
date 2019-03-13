using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetMobileB3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using ProjetMobileB3.Interfaces;
using ProjetMobileB3.Views;
using Xamarin.Forms;
using Microsoft.AppCenter.Analytics;

namespace ProjetMobileB3.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public INavigationService _navigationService;
        public DelegateCommand NavigateToPublicProfilePageCommand { get; private set; }
        public DelegateCommand NavigateToAddYoutuberCommand { get; private set; }

        private List<Youtuber> _youtubers;
        public List<Youtuber> Youtubers
        {
            get
            {
                return _youtubers;
            }
            set
            {
                _youtubers = value;
                RaisePropertyChanged(nameof(Youtubers));
            }
        }

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

        public MainPageViewModel(INavigationService navigationService, IMyDBService myDB)
            : base(navigationService, myDB)
        {
            
            SelectedYoutuber = new Youtuber();
            Title = "YoutubeAdvisor";

            Youtubers = myDB.SelectYoutubeurs();

            _navigationService = navigationService;
            NavigateToAddYoutuberCommand = new DelegateCommand(NavigateToAddYoutuberPage);
            NavigateToPublicProfilePageCommand = new DelegateCommand(NavigateToPublicProfilePage);

        }       

        /*
         * NAVIGATION
         */
        private void NavigateToPublicProfilePage()
        {
            var parameter = new NavigationParameters();
            parameter.Add("youtuber", SelectedYoutuber);
            _navigationService.NavigateAsync(nameof(PublicProfile), parameter);
        }

        private void NavigateToAddYoutuberPage()
        {
            var parameter = new NavigationParameters();
            parameter.Add("youtuber", Youtubers);
            _navigationService.NavigateAsync("AddYoutuber", parameter);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var ayoutubeur = parameters["youtuber"] as List<Youtuber>;
            var addYoutuber = parameters["new"] as Youtuber;

            if (ayoutubeur != null)
            {
               
                Youtubers = ayoutubeur;
                var refreshYoutubers = Youtubers as List<Youtuber>;
                Youtubers = new List<Youtuber>();
                foreach (var youtuber in refreshYoutubers)
                {
                    Youtubers.Add(youtuber);
                }
                MyDBService.AddYoutubeur(addYoutuber);
                Analytics.TrackEvent("Ajout d'un youtubeur!");
                ayoutubeur = null;
            }
        }
    }
}
