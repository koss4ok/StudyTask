using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11wpf
{
    class Order
    {
        public int ID { get; private set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int Price{ get; set; }
        public int Sum { get; private set; }
        public Order(int id, string product, int quantity, int price)
        {
            ID = id;
            Product = product;
            Quantity = quantity;
            Price = price;
            Sum = quantity * price;
        }

    }
}
