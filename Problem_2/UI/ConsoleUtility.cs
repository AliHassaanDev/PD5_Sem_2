using Problem_2.BL;
using Problem_2.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.UI
{
    internal class ConsoleUtility
    {
        public static void header()
        {
            Console.WriteLine("**************************************************");
            Console.WriteLine("     Departmental  Store   Management  System     ");
            Console.WriteLine("**************************************************");
        }
        public static int menu()
        {
            header();
            Console.WriteLine("***** SIGN UP / SIGN IN *****");
            Console.WriteLine("1. Sign up");
            Console.WriteLine("2. Sign in");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            int option = int.Parse(Console.ReadLine());
            clearScreen();
            return option;
        }
       
        public static void clearScreen()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
