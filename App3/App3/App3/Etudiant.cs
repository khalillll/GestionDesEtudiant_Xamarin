using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace App3
{
    public class Etudiant
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int Cne { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Date_naiss { get; set; }
        
        public int Absence { get; set; }

        [ForeignKey(typeof(Filiere))]
        public int IdFiliere { get; set; }
    }
}
