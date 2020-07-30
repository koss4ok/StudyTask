using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    public class Shape
    {
        protected double s,p;
        protected string name;
       protected Shape()
        {
            s = 0;
            p = 0;
            name = "Без названия";
        }
        void Show()
        {

        }
        void S() { }
        void P() { }
    }
    public class Circle : Shape
    {
        double r;
        Circle()
        {
            s = 0;
            p = 0;
            name = "Круг";
        }
        Circle(double a)
        {
            r = a;
            s = S();
            p = P();
            name = "Круг";
        }

        double S()
        {
            return(Math.PI*Math.Pow(r,2));
        }
        double P()
        {
            return (2 * Math.PI * r);
        }
    }
    public class Rect : Shape
    {
        static protected double a;
        static protected double b;
        protected Rect()
        {
            s = 0;
            p = 0;
            name = "Прямоугольник";
        }
        protected Rect(double q,double w)
        { 
            a = q;
            b = w;
            s = S();
            p = P();
            name = "Прямоугольник";
        }
        protected  double S()
        {
            return(s = a * b);
        }
        protected double P()
        {
            return(p = (a + b) * 2);
        }
    }
    public class Square:Rect
    {
        Square()
        {
            s = 0;
            p = 0;
            name = "Квадрат";
        }
        Square(double z):base(a,b)
        {
            s = S();
            p = P();
        }

        private new double S()
        {
            return (Math.Pow(a, 2));
        }
        private new double P()
        {
            return a*4;
        }


    }
}
