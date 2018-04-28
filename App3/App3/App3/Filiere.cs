using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3
{
    public class Filiere
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Filierename { get; set; }
        [OneToMany("O2MClassEtudiantKey")]
        public List<Etudiant> Etud { get; set; }

    }
}
