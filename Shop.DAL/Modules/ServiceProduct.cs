using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Modules
{
    public class ServiceProduct
    {
        private Random random = new Random();
        public void GenerateProduct(Grocery grocery)
        {
            for (int i = 0; i < random.Next(5,20); i++)
            {
                Product product = new Product();
                product.Barcode = random.Next(10000, 30000);

                product.Currency.CurCode = 398;
                product.Currency.CurName = "KZT";
                product.ProdDate = DateTime.Now.AddDays(-random.Next(0,1000));
                product.ExpDay = random.Next(1, 10);
                product.ExpDate = DateTime.Now.AddDays(random.Next(0,20));
                product.Name = $"Product #{random.Next(1000, 9999)}";
                product.Price = random.Next(20,100000);

                grocery.Products.Add(product);
            }
        }

        public List<Grocery> GenerateShop()
        {
            List<Grocery> shops = new List<Grocery>();
            for (int i = 0; i < random.Next(1,10); i++)
            {
                Grocery grocery = new Grocery()
                {
                    Name = $"shop {random.Next(1000, 9999)}",
                };
                GenerateProduct(grocery);
                shops.Add(grocery);
            }
            return shops;
        }
        
    }
}
