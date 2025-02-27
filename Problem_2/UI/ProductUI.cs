using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Problem_2.BL;
using Problem_2.DL;

namespace Problem_2.UI
{
    internal class ProductUI
    {
        public static void ADDProducts()
        {
            string id, name, category;
            double unitPrice, salesTax;
            int stockQty, thresholdQty;

            Console.WriteLine("*****  ADD PRODUCT *****");
            Console.WriteLine("\n\n");
            Console.WriteLine("Enter the Product ID : ");
            id = Console.ReadLine();
            Console.WriteLine("Enter the Product Name :");
            name = Console.ReadLine();
            Console.WriteLine("Enter Category :");
            category = Console.ReadLine();
            Console.WriteLine("Enter unit Price :");
            unitPrice = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter stoke Quantity :");
            stockQty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Threshold Quantity :");
            thresholdQty = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Sales Tax :");
            salesTax = double.Parse(Console.ReadLine());

            Product product = new Product( name, category, unitPrice, stockQty, thresholdQty);

            ProductDL.addProduct(product);

            Console.ReadKey();
        }

        public static void showAllProducts()
        {
            Console.WriteLine("*****  ALL PRODUCTS *****");
            Console.WriteLine("\n\n");

            foreach (var product in ProductDL.products)
            {
               
                Console.WriteLine($"Name: {product.name}");
                Console.WriteLine($"Category: {product.category}");
                Console.WriteLine($"Unit Price: {product.price}");
                Console.WriteLine($"Stock Quantity: {product.stockQuantity}");
                Console.WriteLine($"Threshold Quantity: {product.threshold}");
                Console.WriteLine($"Sales Tax: {product.calculateTax(product)}");
                Console.WriteLine("----------------------------");
            }

            Console.ReadKey();
        }

        public static void showHighestPricedProduct()
        {
            var highestPricedProduct = ProductDL.products.OrderByDescending(p => p.price).FirstOrDefault();

            if (highestPricedProduct != null)
            {
                Console.WriteLine("*****  HIGHEST PRICED PRODUCT *****");
                Console.WriteLine("\n\n");
                
                Console.WriteLine($"Name: {highestPricedProduct.name}");
                Console.WriteLine($"Category: {highestPricedProduct.category}");
                Console.WriteLine($"Unit Price: {highestPricedProduct.price}");
                Console.WriteLine($"Stock Quantity: {highestPricedProduct.stockQuantity}");
                Console.WriteLine($"Threshold Quantity: {highestPricedProduct.threshold}");
                Console.WriteLine($"Sales Tax: {highestPricedProduct.calculateTax(highestPricedProduct)}");
                Console.WriteLine("----------------------------");
            }
            else
            {
                Console.WriteLine("No products available.");
            }

            Console.ReadKey();
        }

        public static void viewSalesTax()
        {
            Console.WriteLine("*****  SALES  TAX  *****");
            Console.WriteLine("\n\n");

            foreach (var product in ProductDL.products)
            {
                
                Console.WriteLine($"Name: {product.name}");
                Console.WriteLine($"Sales Tax: {product.calculateTax(product)}");
                Console.WriteLine("----------------------------");
            }

            Console.ReadKey();
        }

        public static void productsToBeOrdered()
        {
            Console.WriteLine("***** PRODUCTS TO BE ORDERED *****");
            Console.WriteLine("\n\n");

            foreach (var product in ProductDL.products)
            {
                if (product.stockQuantity < product.threshold)
                {
                    
                    Console.WriteLine($"Name: {product.name}");
                    Console.WriteLine($"Category: {product.category}");
                    Console.WriteLine($"Minimum Quantity Required: {product.threshold - product.stockQuantity}");
                    Console.WriteLine("----------------------------");
                }
            }

            Console.ReadKey();
        }
    }
}
