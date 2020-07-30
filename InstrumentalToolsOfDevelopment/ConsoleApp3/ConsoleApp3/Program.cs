using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    enum orientation : byte
    {
        north = 1,
        south = 2,
        east = 3,
        west = 4
    }
    class Program
    {
        static void Main(string[] args)
        {
            orientation myDirection;
            try
            {
                Console.WriteLine("Введите число ");
                byte myByte = Convert.ToByte(Console.ReadLine());
                myDirection = checked((orientation)myByte);
                if ((myDirection < orientation.north) || (myDirection > orientation.west))
                {
                    throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine("myDirection = {0}", myDirection);
            }
            catch
            {
                Console.WriteLine("Значение должно быть от 1 до 4");
            }              
            Console.ReadKey();
        }

    }
}
