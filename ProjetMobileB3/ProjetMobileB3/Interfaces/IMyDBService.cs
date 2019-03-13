using ProjetMobileB3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMobileB3.Interfaces
{
    public interface IMyDBService
    {
        List<Youtuber> SelectYoutubeurs();

        void UpdateYoutubeur(Youtuber SelectedYoutubeur);

        Youtuber SelectYoutubeurById(int id);

        void AddYoutubeur(Youtuber youtuber);



    }
}
