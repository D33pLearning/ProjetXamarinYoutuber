using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMobileB3.Models
{
    public class Youtuber
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Nickname { get; set; }

        public string Categorie { get; set; }
        public string Scam { get; set; }
        public int AverageRate { get; set; }
        public string EmojiRate { get; set; }
        public string EmojiAdvisedAge { get; set; }

        public string EmojiStars { get; set; }
        public int AdvisedAge { get; set; }


        public Youtuber(string nickname, string logo, string categorie)
        {
 
            Logo = logo;
            Nickname = nickname;
            Categorie = categorie;
            Scam = "Aucun";
            AdvisedAge = 0;
            AverageRate = 0;
            EmojiRate = "interrogation.png";
            EmojiAdvisedAge = "";
            EmojiStars = "";
        }

        public Youtuber()
        {
            this.Scam = "Aucun";
            this.AdvisedAge = 0;
            this.AverageRate = 0;
            this.EmojiRate = "interrogation.png";
            this.EmojiAdvisedAge = "";
            this.EmojiStars = "";
        }

    }
}
