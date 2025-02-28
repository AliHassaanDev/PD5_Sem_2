using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Problem_2.BL;
using Problem_2.DL;
using Problem_2.UI;

namespace Problem_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
                AdminDL.readFromFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Admin.txt");
                CustomerDL.readFromFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Customer.txt");
                ProductDL.readFromFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Product.txt");

                int option;
                do
                {
                    Console.Clear();
                    
                    option = ConsoleUtility.menu();

                    switch (option)
                    {
                        case 1: 
                            Admin newAdmin = AdminUI.getUserInfo();
                            AdminDL.addAdmin(newAdmin);
                            AdminDL.addToFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Admin.txt", newAdmin);
                            Console.WriteLine("Admin registered successfully!");
                            ConsoleUtility.clearScreen();
                            break;

                        case 2: 
                        Admin user = AdminUI.getUserInfo();
                        Admin existingAdmin = AdminDL.store.Find(a => a.UserName == user.UserName && a.Password == user.Password && a.Role == user.Role  );

                        if (existingAdmin != null && existingAdmin.Role =="admin")
                        {
                            AdminMenuLoop();
                        }
                        else if (existingAdmin.Role == "customer")
                            {
                                CustomerMenuLoop();
                            }
                            else
                            {
                                Console.WriteLine("Invalid credentials!");
                                ConsoleUtility.clearScreen();
                            }
                        
                        break;

                    case 3: 
                            return;
                    }
                } while (true);
            }

            static void AdminMenuLoop()
            {
                int adminOption;
                do
                {
                    adminOption = AdminUI.AdminMenu();
                    Console.Clear();

                switch (adminOption)
                {
                    case 1: 
                        ProductUI productui = new ProductUI();
                        ProductUI.ADDProducts();
                        ProductDL.addToFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Product.txt");
                        break;

                    case 2: 
                        ProductUI.showAllProducts();
                        ConsoleUtility.clearScreen();
                        break;

                    case 3: 
                        ProductUI.showHighestPricedProduct();
                        ConsoleUtility.clearScreen();
                        break;

                    case 4: 
                        ProductUI.viewSalesTax();
                        ConsoleUtility.clearScreen();
                        break;

                    case 5: 
                        ProductUI.productsToBeOrdered();
                        ConsoleUtility.clearScreen();
                        break;

                    case 6: 
                        Console.WriteLine("Admin Profile:");
                        Console.WriteLine($"Username: {AdminDL.store[0].UserName}"); 
                        ConsoleUtility.clearScreen();
                        break;

                    case 7: 
                        return;
                }
                } while (true);
            }

        static void CustomerMenuLoop()
        {
            Customer customer = new Customer();
            int customerOption;
            do
            {
                customerOption = (CustomerUI.customerMenu());
                Console.Clear();

                switch (customerOption)
                {
                    case 1: 
                        ProductUI.showAllProducts();
                        ConsoleUtility.clearScreen();
                        break;

                    case 2: 
                        new CustomerUI().buyProduct();
                        ProductDL.addToFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Product.txt");
                        break;

                    case 3: 
                        new CustomerUI().generateInvoice();
                        ConsoleUtility.clearScreen();
                        break;

                    case 4: 
                        Console.WriteLine($"Username: {customer.username}\nEmail: {customer.email}\nAddress: {customer.address}");
                        ConsoleUtility.clearScreen();
                        break;

                    case 5: 
                        return;
                }
            } while (true);
        }

    }
}

