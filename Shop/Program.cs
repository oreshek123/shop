using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.DAL.Modules;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProduct serviceProduct = new ServiceProduct();
            List<Grocery> groceries = serviceProduct.GenerateShop();
            foreach (Grocery item in groceries.OrderBy(grocery =>grocery.Products.Count()))
            {
                item.ShowAllInfoAboutGrocery();
            }
            
            Console.WriteLine("Введите магазин");
            string shop = Console.ReadLine();

            Console.Clear();

            Grocery shops = groceries.FirstOrDefault(grocery1 => grocery1.Name == shop);
            if (shops != null)
            {
                Console.WriteLine("Введите код продукта");
                int code = Int32.Parse(Console.ReadLine());
                Product findProduct = shops[code];
                findProduct.PrintInfo();
            }
            
                Console.ReadLine();
        }
    }
}
