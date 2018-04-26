using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.DAL.Modules
{
    public class Currency
    {
        public int CurCode { get; set; }
        public string CurName { get; set; }
        public override string ToString()
        {
            return $"{CurName} ({CurCode})";
        }
    }
    public class Product
    {
        public string Name { get; set; }
        private double Price_;
        public double Price
        {
            get { return Price_; }
            set
            {
                if (value < 0) Price_ = 0;
                else Price_ = value;
            }
        }
        public Currency Currency { get; set; } = new Currency();
        public int Barcode { get; set; }
        public int Quantity { get; set; }
        public double ExpDay { get; set; }
        public DateTime ProdDate { get; set; }
        private DateTime ExpDate_;
        public DateTime ExpDate
        {
            get => ExpDate_;
            set
            {
                double totalDays = (value - ProdDate).TotalDays;

                if (totalDays < 0)
                    ExpDate_ = ProdDate.AddDays(ExpDay);
                else if (totalDays > ExpDay)
                    ExpDate_ = ProdDate.AddDays(ExpDay);
                else ExpDate_ = value;
                
            }
        }

       
        public void PrintInfo()
        {
            Console.WriteLine($"Bar code : {this.Barcode} - {this.Name} ({this.ProdDate} - {this.ExpDate}) - $ {this.Price} {this.Currency}");
        }

        public static Product operator >(Product product1, Product product2)
        {
            if (product1.Price > product2.Price)
                return product1;
            else return product2;
        }
        public static Product operator <(Product product1, Product product2)
        {
            if (product1.Price < product2.Price)
                return product2;
            else return product1;
        }
    }
}
