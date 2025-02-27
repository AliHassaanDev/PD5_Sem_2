using Problem_2.BL;
using Problem_2.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.DL
{
    internal class CustomerDL
    {
        public static List<Customer> customers = new List<Customer>();

        public static void addCustomer(Customer customer)
        {
            customers.Add(customer);
        }
       
        public static void addToFile(string path, Customer c)
        {
            StreamWriter f = new StreamWriter(path, true);
            f.WriteLine(c.username + "," + c.email + "," + c.address + "," + c.contactNo);
            f.Flush();
            f.Close();
        }
        public static bool readFromFile(string path)
        {
            StreamReader f = new StreamReader(path);
            string record;
            if (File.Exists(path))
            {
                while ((record = f.ReadLine()) != null)
                {
                    string[] splittedRecord = record.Split(',');
                    string username = splittedRecord[0];
                    string password = splittedRecord[1];
                    string email = splittedRecord[2];
                    string address = splittedRecord[3];
                    string contactNo = splittedRecord[4];
                    Customer c = new Customer(username, email, address, contactNo);
                    addCustomer(c);
                }
                f.Close();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
