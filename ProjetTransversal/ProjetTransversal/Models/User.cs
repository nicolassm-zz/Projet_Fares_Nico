using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetTransversal.Models
{
    class User
    {
        public string username { get; set; }
        public string password { get; set; }

        private static User _user;

        public static User user
        {
            get { return _user ?? (_user = new User()); }
        }

    }
}
