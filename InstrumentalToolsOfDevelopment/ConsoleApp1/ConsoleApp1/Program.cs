using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите градусы ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите минуты ");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.Write("Введите направление ");
                char c = Convert.ToChar(Console.ReadLine());
                Angles A1 = new Angles();
                Angles A2 = new Angles(a, b, c);
                A1.Output();
                A2.Output();

            }
            catch
            {
                Console.Write("Не правильный тип переменных");
            }
            Console.ReadKey();
        }
    }
    class Angles
    {
        private int grad;
        private double min;
        private char napr;
        public Angles()
        {
            grad = 0;
            min = 0;
            napr = 'S';
        }
        public Angles(int x, double y, char z)
        {
            this.grad = x;
            this.min = y;
            this.napr = z;
        }
        public void Output() => Console.WriteLine("CoOrds at {0} {1} {2}", grad, min, napr);
    }
}
