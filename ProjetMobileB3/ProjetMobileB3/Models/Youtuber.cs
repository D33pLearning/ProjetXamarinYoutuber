using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMobileB3.Models
{
    public class Youtuber
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string Nickname { get; set; }

        public string Categorie { get; set; }
        public string Scam { get; set; }
        public int AverateRate { get; set; }
        public string EmojiRate { get; set; }
        public string EmojiAdvisedAge { get; set; }
        public int AdvisedAge { get; set; }


        public Youtuber(int Id, string Nickname, string Logo)
        {
            this.Id = Id;
            this.Logo = Logo;
            this.Nickname = Nickname;
        }

    }
}
