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
using ProjetMobileB3.BDD;
using Xamarin.Forms;

namespace ProjetMobileB3.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private const String NAVIGATE_TO_PUBLIC_PROFILE_PAGE = "PublicProfile";  
        public INavigationService _navigationService;
        public DelegateCommand NavigateToPublicProfilePageCommand { get; private set; }
        public DelegateCommand NavigateToAddYoutuberCommand { get; private set; }

        public SQLiteConnection db { get; set;}

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
                //NavigateToYoutuberDetail(_selectedYoutuber);
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
                //NavigateToYoutuberDetail(_selectedYoutuber);
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
                //NavigateToYoutuberDetail(_selectedYoutuber);
            }
        }


        public void NavigateToYoutuberDetail(Youtuber selectedYoutuber)
        {
            var parameter = new NavigationParameters();
            parameter.Add("youtuber", selectedYoutuber);
            _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE, parameter);
            throw new NotImplementedException();
            //_navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE + SelectedYoutuber.ToString());
        }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            /*************DB*****************/

            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            db = new SQLiteConnection(databasePath);

            SelectedYoutuber = new Youtuber();

            /*db.CreateTable<Youtuber>();
            db.Insert(new Youtuber("TiboInShape", "tibo.jpg", "Musculation"));
            db.Insert(new Youtuber("Squeezie", "squeezie.jpg", "Jeux-vidéos"));
            db.Insert(new Youtuber("Zerator", "zerator.png", "Jeux-vidéos"));*/

            Title = "YoutubeAdvisor";

            Youtubers = new List<Youtuber>();
            /*Youtubers.Add(new Youtuber(1, "TiboInShape", "tibo.jpg", "Musculation"));
            Youtubers.Add(new Youtuber(2, "Squeezie", "squeezie.jpg", "Jeux-vidéos"));
            Youtubers.Add(new Youtuber(3, "Zerator", "zerator.png", "Jeux-vidéos"));*/

            
            SelectYoutubeurById(db, 1);
            //db.Delete(SelectedYoutuber);
            SelectedYoutuber.Categorie = "Musculation";
            db.Update(SelectedYoutuber);

            SelectYoutubeurs(db);


            //db.Delete(SelectedYoutuber);


            _navigationService = navigationService;
            NavigateToAddYoutuberCommand = new DelegateCommand(NavigateToAddYoutuberPage);
            NavigateToPublicProfilePageCommand = new DelegateCommand(NavigateToPublicProfilePage);

        }

        public static void AddYoutubeur(SQLiteConnection db, string nickname, string logo, string categorie)
        {
            Youtuber youtuber = new Youtuber()
            {
                Nickname = nickname,
                Logo = logo,
                Categorie = categorie
            };
            db.Insert(youtuber);
        }

        public void SelectYoutubeurs(SQLiteConnection db)
        {
            var query = db.Table<Youtuber>();

            foreach (var youtubeur in query)
            {
                Youtubers.Add(youtubeur);
            }
        }

        public void SelectYoutubeurById(SQLiteConnection db, int id)
        {
            var query = db.Table<Youtuber>().Where(v => v.Id.Equals(id));

            foreach (var youtubeur in query)
            {
                SelectedYoutuber = youtubeur;
            }
        }

        private void NavigateToPublicProfilePage()
        {
            _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE);
            var parameter = new NavigationParameters();
            parameter.Add("youtuber", SelectedYoutuber);
            parameter.Add("db", db);
            _navigationService.NavigateAsync(NAVIGATE_TO_PUBLIC_PROFILE_PAGE, parameter);
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
                db.Insert(addYoutuber);
                ayoutubeur = null;
            }
        }
    }
}
