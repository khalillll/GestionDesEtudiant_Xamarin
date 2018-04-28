using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace App3
{
    public class Admin
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

    }
}
