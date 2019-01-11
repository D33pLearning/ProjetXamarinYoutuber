using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetMobileB3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ProjetMobileB3.ViewModels
{
    public class ViewModelBase : BindableBase, INotifyPropertyChanged, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        public List<Youtuber> Youtubers { get; set; }
        public string Test { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private Youtuber _selectedYoutuber;
        public Youtuber SelectedYoutuber
        {
            get { return _selectedYoutuber; }
            set
            {
                _selectedYoutuber = value;
                RaisePropertyChanged("SelectedYoutuber");
            }
            
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;

            Youtubers = new List<Youtuber>();
            Youtubers.Add(new Youtuber(1, "TiboInShape", "tibo.jpg"));
            Youtubers.Add(new Youtuber(2, "Squezzie", "squeezie.jpg"));
            /*if (SelectedYoutuber == null)
                Test = "Empty";
            else
            {
                Test = "Pas empty";
            }*/

        }

        public string GetIdYoutuber()
        {
            /*if (SelectedYoutuber == null)
                return "hello";
            return SelectedYoutuber.Nickname;*/
            return("hello");
        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
