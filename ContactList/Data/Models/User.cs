using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.Data.Models
{
    internal class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string login { get; set; }
        public string password { get; set; }

        public override string ToString()
        {
            return $"{login} - {password}";
        }
    }
}
