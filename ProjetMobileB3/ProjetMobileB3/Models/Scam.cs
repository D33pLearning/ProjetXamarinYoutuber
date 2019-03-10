using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMobileB3.Models
{
    public class Scam
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Libelle { get; set; }
    }
}
