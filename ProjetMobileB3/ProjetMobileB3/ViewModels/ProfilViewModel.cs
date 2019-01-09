using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ProjetMobileB3.ViewModels
{
	public class ProfilViewModel : BindableBase, INotifyPropertyChanged
	{
	    private INavigationService _navigationService;
	    
        public List<String> Arnaques { get; set; }
	    public List<int> Ages { get; set; }

	    public List<int> Notes { get; set; }

        public ProfilViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            

            Arnaques = new List<string>();
            Arnaques.Add("Dropshipping");
            Arnaques.Add("Incitation aux jeux d'argent");

            Ages = new List<int>();
            Ages.Add(10);
            Ages.Add(16);
            Ages.Add(18);

            Notes = new List<int>();
            Notes.Add(1);
            Notes.Add(2);
            Notes.Add(3);
            Notes.Add(4);
            Notes.Add(5);


        }

    }
}
