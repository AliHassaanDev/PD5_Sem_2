using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Problem_2.BL;
using Problem_2.DL;

namespace Problem_2.UI
{
    internal class CustomerUI
    {
        public int currentID = 101;
        public static string customerMenu()
        {
            ConsoleUtility.header();
            Console.WriteLine("1. Show All Products");
            Console.WriteLine("2. Buy the products");
            Console.WriteLine("3. Generate invoice ");
            Console.WriteLine("4. View Profile");
            Console.WriteLine("5.. Exit");
            Console.Write("Enter your choice: ");
            return Console.ReadLine();
        }
        public void buyProduct()
        {
            List<Product> temp = new List<Product>();
            bool isBought = false;
            do
            {
                string prodname;
                Console.WriteLine("*****  BUY PRODUCTS *****");
                Console.WriteLine("\n\n");
                Console.Write("Which Product You Want to Buy :");
                prodname = Console.ReadLine();
                Product product = ProductDL.products.Find(p => p.name == prodname);
                if (product == null)
                {
                    Console.WriteLine("No Product Found !!!");
                }
                else
                {
                    Console.WriteLine("Enter Quantity :");
                    int qty = int.Parse(Console.ReadLine());
                    if (product.stockQuantity < qty)
                    {
                        Console.WriteLine("Stock is not available !!!");
                    }
                    else
                    {
                        product.stockQuantity -= qty;
                        Console.WriteLine("Product Purchased Successfully !!!");
                        temp.Add(product);
                        isBought = true;
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine("Do you want to buy more products (Y/N) :");
                string choice = Console.ReadLine();
                if (choice.ToUpper() == "N")
                {
                    break;
                }
                Console.Clear();

            } while (true);
            if (isBought)
            {
                viewCustomerCart(temp);
                addCustomerInfo(temp);
                Console.WriteLine("Thanks for Shopping ***");
            }
            else
            {
                Console.WriteLine("No Products Bought !!!");
            }
        }

        public void viewCustomerCart(List<Product> temp)
        {
            double total = 0;
            Console.WriteLine("*****  Your Cart  *****");
            Console.WriteLine("\n\n");
            foreach (var product in temp)
            {
                
                Console.WriteLine($"Name: {product.name}");
                Console.WriteLine($"Category: {product.category}");
                Console.WriteLine($"Unit Price: {product.price}");
                Console.WriteLine($"Stock Quantity: {product.stockQuantity}");
                Console.WriteLine($"Threshold Quantity: {product.threshold}");
                Console.WriteLine($"Sales Tax: {product.calculateTax(product)}");
                Console.WriteLine("----------------------------");
                total += product.price;
            }
            Console.WriteLine("\n\n");
            Console.WriteLine($"Total Amount : {total}");
            Console.ReadKey();
            Console.Clear();
        }
        public void addCustomerInfo(List<Product> temp)
        {
            Console.WriteLine("*****  Costomer's Info  *****");
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter Your Name :");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Your Address :");
            string address = Console.ReadLine();
            Console.WriteLine("Enter your Contact Number : ");
            string contact = Console.ReadLine();
            Console.WriteLine("Enter Your Email :");
            string email = Console.ReadLine();
            Customer customer = new Customer(name, email, address, contact);
            customer.productsBought.AddRange(temp);
            currentID++;
        }

        public void generateInvoice()
        {
            Console.WriteLine("*****  INVOICE  *****");
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter Customer Name :");
            string name = Console.ReadLine();
            Customer customer = CustomerDL.customers.Find(c => c.username == name);
            if (customer == null)
            {
                Console.WriteLine("No Customer Found !!!");
            }
            else
            { 
                Console.WriteLine($"Customer Name : {customer.username}");
                Console.WriteLine($"Contact Number : {customer.contactNo}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Products Bought :");
                foreach (var product in customer.productsBought)
                {
                    
                    Console.WriteLine($"Name: {product.name}");
                    Console.WriteLine($"Category: {product.category}");
                    Console.WriteLine($"Unit Price: {product.price}");
                    Console.WriteLine($"Sales Tax: {product.calculateTax(product)}");
                    Console.WriteLine("----------------------------");
                }
            }
            Console.ReadKey();
        }
    }
}
