using Problem_2.BL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Problem_2.DL
{
    internal class ProductDL
    {
        public static List<Product> products = new List<Product>();
        public static void addProduct(Product product)
        {
            products.Add(product);
        }
        public static void addToFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            foreach (Product p in products)
            {
                writer.WriteLine($"{p.name},{p.category},{p.price},{p.stockQuantity},{p.threshold}");
            }
            writer.Close();
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
                    string name = splittedRecord[0];
                    string category = splittedRecord[1];
                    double price = double.Parse(splittedRecord[2]);
                    int stockQuantity = int.Parse(splittedRecord[3]);
                    int threshold = int.Parse(splittedRecord[4]);
                    Product p = new Product(name, category, price, stockQuantity,threshold);
                    addProduct(p);
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
