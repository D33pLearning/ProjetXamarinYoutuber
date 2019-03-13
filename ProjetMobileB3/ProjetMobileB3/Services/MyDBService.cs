using ProjetMobileB3.Interfaces;
using ProjetMobileB3.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ProjetMobileB3.Services
{
    public class MyDBService : IMyDBService
    {
        public SQLiteConnection db { get; set; }

        public MyDBService() 
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");
            db = new SQLiteConnection(databasePath);
            db.CreateTable< Youtuber>();
        }

        public List<Youtuber> SelectYoutubeurs()
        {
            var query = db.Table<Youtuber>();

            return query.ToList();
        }

        public Youtuber SelectYoutubeurById(int id)
        {
            var query = db.Table<Youtuber>().Where(v => v.Id.Equals(id));

            return (query.First());

        }

        public void UpdateYoutubeur(Youtuber youtuber)
        {
            db.Update(youtuber);
        }

        public void AddYoutubeur(Youtuber youtuber)
        {
            db.Insert(youtuber);
        }
    }
}
