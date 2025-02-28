using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.BL
{
    internal class Customer
    {
        public string username;
        public string email;
        public string address;
        public string contactNo;
        public List<Product> productsBought;
        public Customer() { }
        public Customer(string username,  string email, string address, string contactNo)
        {
            this.username = username;
            this.email = email;
            this.address = address;
            this.contactNo = contactNo;
            productsBought = new List<Product>();
        }
    }
}
