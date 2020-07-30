using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите название ");
                string z = Console.ReadLine();
                Console.Write("Введите количество ");
                int x = Convert.ToInt16(Console.ReadLine());
                Console.Write("Введите цену за единицу ");
                double c = Convert.ToDouble(Console.ReadLine());
                orders A = new orders(z, x, c);
                Console.Write("Стоимость заказа {0} равна {1}",A.itemname,A.Cost());
            }
            catch
            {
                Console.Write("Не допустимые типы значений ");
            }
            Console.ReadKey();
        }
    }
        struct orders
        {
            public string itemname;
            public int unitCount;
            public double unitCost;
                public orders(string a, int b,double c)
                {
                this.itemname = a;
                this.unitCount=b;
                this.unitCost=c;
                }
            public double Cost()
            {
                return unitCost * unitCount;
            }
        }
}
