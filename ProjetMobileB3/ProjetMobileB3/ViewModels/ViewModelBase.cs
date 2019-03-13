using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using ProjetMobileB3.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ProjetMobileB3.Interfaces;
using Xamarin.Forms;

namespace ProjetMobileB3.ViewModels
{
    public class ViewModelBase : BindableBase, INotifyPropertyChanged, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }
        protected IMyDBService MyDBService { get; private set; }


        //public List<Opinion> Opinions { get; set; }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value);
                
            }
        }

   

        public ViewModelBase(INavigationService navigationService, IMyDBService mydbservice)
        {
            NavigationService = navigationService;
            MyDBService = mydbservice;


            //Opinions = new List<Opinion>();
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
