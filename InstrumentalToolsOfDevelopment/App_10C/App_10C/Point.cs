using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_10C
{
    class Point
    {
        //public string Date;
        public string Date { get; set; }
        public double Value { get; set; }

        public Point(string date, double value)
        {
            Value = value;
            Date = date;
        }
    }
}
