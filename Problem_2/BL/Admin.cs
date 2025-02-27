using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.BL
{
    internal class Admin
    {
        public string UserName;
        public string Password;
        public string Role;
        public Admin(string UserName, string Password, string Role)
        {
            this.UserName = UserName;
            this.Password = Password;
            this.Role = Role;
        }
        
    }
}
