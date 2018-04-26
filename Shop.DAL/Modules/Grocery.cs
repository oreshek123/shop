using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Modules
{
    public class Grocery
    {
        public string Adress { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public List<Product> Products { get; set; }

        public Grocery()
        {
            Products = new List<Product>();
        }
        public Product this[int Barcode]
        {
            get { return Products.FirstOrDefault(product => product.Barcode == Barcode); }
        }

        public void ShowAllInfoAboutGrocery()
        {
            Console.WriteLine($"{this.Name} \n{this.Adress} ({this.Phone})");
            foreach (Product item in Products)
            {
                item.PrintInfo();
            }
        }
    }
}
