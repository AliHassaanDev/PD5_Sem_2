using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2.BL
{
    internal class Product
    {
       
        public string name;
        public string category;
        public double price;
        public int stockQuantity;
        public int threshold;

        public Product() { }

        public Product(string name,string category,double price,int stockQuantity, int threshold)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.stockQuantity = stockQuantity;
            this.threshold = threshold;
        }
        public double calculateTax(Product p)
        {
            double tax = 0.0;
            if (p.category == "grocery")
            {
                tax =p.price*0.10;
            }
            else if (p.category == "fruit")
            {
                tax =p.price*0.05;
            }
            else
            {
                tax =p.price*0.15;
            }
            return tax;
        }
        public void sellProduct(int quantity)
        {
            stockQuantity -= quantity;
        }
    }
}
