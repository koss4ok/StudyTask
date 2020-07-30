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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int z=0;
        Coffee Amerikano = new Coffee("Американо", 20);
        Coffee Capuchino = new Coffee("Капучино", 15);
        Coffee Expresso = new Coffee("Эспрессо", 10);
        Coffee Cacao = new Coffee("Какао", 25);
        public MainWindow()
        {
            InitializeComponent();
        }
        class Coffee
        {
            private string name;
            private int price;
            public Coffee(string name, int price)
            {
                this.price = price;
                this.name = name;
            }
           public int Pr()
            {            
                 return this.price;
            }
           public string Nm()
            {
                return this.name;
            }


        }

        private void but()
        {
            if (rb1.IsChecked==true && z>= Amerikano.Pr()) { btn2.IsEnabled = true; }
            else if(rb2.IsChecked == true && z >= Capuchino.Pr()) { btn2.IsEnabled = true; }
            else if (rb3.IsChecked == true && z >= Expresso.Pr()) { btn2.IsEnabled = true; }
            else if (rb4.IsChecked == true && z >= Cacao.Pr()) { btn2.IsEnabled = true; }
            if (rb1.IsChecked == true && z < Amerikano.Pr()) { btn2.IsEnabled = false; }
            else if (rb2.IsChecked == true && z < Capuchino.Pr()) { btn2.IsEnabled = false; }
            else if (rb3.IsChecked == true && z < Expresso.Pr()) { btn2.IsEnabled = false; }
            else if (rb4.IsChecked == true && z < Cacao.Pr()) { btn2.IsEnabled = false; }
        }
        private void otch()
        {
            z = 0;
            rb1.IsChecked = false;
            rb2.IsChecked = false;
            rb3.IsChecked = false;
            rb4.IsChecked = false;
            cb1.IsChecked = false;
            cb2.IsChecked = false;
            lbl2.Content = "Внесенная сумма: ";
            lbl1.Content = "Цена выбранного напитка: ";
            txt1.Text = "";
            Sugar.Visibility = Visibility.Hidden;
            Milk.Visibility = Visibility.Hidden;
            qwe.Visibility = Visibility.Hidden;
            btn2.IsEnabled = false;
        }
        private int schet(int a)
        {
            z -= a;
            return z;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
                qwe.Source = new BitmapImage(new Uri(@"C:\Users\Koss4ok\Desktop\1\УПК\4 курс\ИСРПО\WpfApp1\WpfApp1\Американо.jpg"));
            lbl1.Content="Цена " + Amerikano.Nm() + " составляет " + Amerikano.Pr();
            but();
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            qwe.Source = new BitmapImage(new Uri(@"C:\Users\Koss4ok\Desktop\1\УПК\4 курс\ИСРПО\WpfApp1\WpfApp1\Капучино.jpg"));
            lbl1.Content = "Цена " + Capuchino.Nm() + " составляет " + Capuchino.Pr();
            but();
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            qwe.Source = new BitmapImage(new Uri(@"C:\Users\Koss4ok\Desktop\1\УПК\4 курс\ИСРПО\WpfApp1\WpfApp1\Эспрессо.jpg"));
            lbl1.Content = "Цена " + Expresso.Nm() + " составляет " + Expresso.Pr();
            but();
        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            qwe.Source = new BitmapImage(new Uri(@"C:\Users\Koss4ok\Desktop\1\УПК\4 курс\ИСРПО\WpfApp1\WpfApp1\Какао.jpg"));
            lbl1.Content = "Цена " + Cacao.Nm() + " составляет " + Cacao.Pr();
            but();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            Sugar.Visibility = Visibility.Visible;
        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {
            Milk.Visibility = Visibility.Visible;
        }

        public void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            Sugar.Visibility = Visibility.Hidden;
        }

        private void CheckBox_Unchecked_1(object sender, RoutedEventArgs e)
        {
            Milk.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                z += Convert.ToInt32(txt1.Text);
                lbl2.Content = "Внесенная сумма " + z + " руб.";
                but();
            }
            catch
            {
                MessageBox.Show("Ошибка,вы ввели некоректную сумму");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rb1.IsChecked == true) { schet(Amerikano.Pr()); MessageBox.Show("Ваш " + Amerikano.Nm() + " готов"); }
            else if (rb2.IsChecked == true) { schet(Capuchino.Pr()); MessageBox.Show("Ваш " + Capuchino.Nm() + " готов"); }
            else if (rb3.IsChecked == true) { schet(Expresso.Pr()); MessageBox.Show("Ваш " + Expresso.Nm() + " готов"); }
            else if (rb4.IsChecked == true) { schet(Cacao.Pr());MessageBox.Show("Ваш " + Cacao.Nm() + " готов"); }

            MessageBox.Show("Сдача составляет " + z + " руб.");
            otch();
        }

        private void txt1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!((e.Key.GetHashCode() >= 34) && (e.Key.GetHashCode() <= 43)) && !((e.Key.GetHashCode() >= 74) && (e.Key.GetHashCode() <= 83)))
                e.Handled = true;
        }
    }
}
