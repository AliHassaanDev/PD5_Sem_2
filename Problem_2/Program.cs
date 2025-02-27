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
                // Load data from files
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
                        case 1: // Sign Up
                            Admin newAdmin = AdminUI.getUserInfo();
                            AdminDL.addAdmin(newAdmin);
                            AdminDL.addToFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Admin.txt", newAdmin);
                            Console.WriteLine("Admin registered successfully!");
                            ConsoleUtility.clearScreen();
                            break;

                        case 2: // Sign In
                        Admin user = AdminUI.getUserInfo();
                        Admin existingAdmin = AdminDL.store.Find(a => a.UserName == user.UserName && a.Password == user.Password &&( a.Role =="Admin"||a.Role =="Admin"));

                        if (existingAdmin != null)
                        {
                            AdminMenuLoop();
                        }
                        else
                        {
                            Customer existingCustomer = CustomerDL.customers.Find(c => c.username == user.UserName);
                            if (existingCustomer != null)
                            {
                                CustomerMenuLoop(existingCustomer);
                            }
                            else
                            {
                                Console.WriteLine("Invalid credentials!");
                                ConsoleUtility.clearScreen();
                            }
                        }
                        break;

                    case 3: // Exit
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
                    case 1: // Add Product
                        ProductUI productui = new ProductUI();
                        ProductUI.ADDProducts();
                        ProductDL.addToFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Product.txt");
                        break;

                    case 2: // View All Products
                        ProductUI.showAllProducts();
                        ConsoleUtility.clearScreen();
                        break;

                    case 3: // Find Highest Price
                        ProductUI.showHighestPricedProduct();
                        ConsoleUtility.clearScreen();
                        break;

                    case 4: // View Sales Tax
                        ProductUI.viewSalesTax();
                        ConsoleUtility.clearScreen();
                        break;

                    case 5: // Low Stock Products
                        ProductUI.productsToBeOrdered();
                        ConsoleUtility.clearScreen();
                        break;

                    case 6: // View Profile
                        Console.WriteLine("Admin Profile:");
                        Console.WriteLine($"Username: {AdminDL.store[0].UserName}"); // Simplified for demo
                        ConsoleUtility.clearScreen();
                        break;

                    case 7: // Exit
                        return;
                }
                } while (true);
            }
        // Customer Menu Logic
        static void CustomerMenuLoop(Customer customer)
        {
            int customerOption;
            do
            {
                customerOption = int.Parse(CustomerUI.customerMenu());
                Console.Clear();

                switch (customerOption)
                {
                    case 1: // View Products
                        ProductUI.showAllProducts();
                        ConsoleUtility.clearScreen();
                        break;

                    case 2: // Buy Products
                        new CustomerUI().buyProduct();
                        ProductDL.addToFile("H:\\Semester 2\\OOPS\\PD5\\Problem_2\\Product.txt");
                        break;

                    case 3: // Generate Invoice
                        new CustomerUI().generateInvoice();
                        ConsoleUtility.clearScreen();
                        break;

                    case 4: // View Profile
                        Console.WriteLine($"Username: {customer.username}\nEmail: {customer.email}\nAddress: {customer.address}");
                        ConsoleUtility.clearScreen();
                        break;

                    case 5: // Exit
                        return;
                }
            } while (true);
        }

    }
}

