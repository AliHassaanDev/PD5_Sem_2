using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Problem_2.BL;
using Problem_2.DL;

namespace Problem_2.UI
{
    internal class AdminUI
    {
        public static int AdminMenu()
        {
            ConsoleUtility.header();
            Console.WriteLine("1. Add Product");
            Console.WriteLine("2. Show All Products");
            Console.WriteLine("3. Find Product With Highest Price ");
            Console.WriteLine("4. View Sales Tax of All Products.");
            Console.WriteLine("5. Products to be Ordered.");
            Console.WriteLine("6. View Profile");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");
            int option =int.Parse(Console.ReadLine());
            return option;
        }
        public static Admin getUserInfo()
        {
            ConsoleUtility.header();
            Console.Write("Enter Name:");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine();
            Console.Write("Enter Role: ");
            string role = Console.ReadLine();
            Admin user = new Admin(userName, password, role);
            ConsoleUtility.clearScreen();
            return user;

        }
        public static void showAll(List<Admin> users)
        {
            foreach (Admin user in users)
            {
                Console.WriteLine("{0} \t {1}", user.UserName, user.Password);
            }
        }
        
    }
}
