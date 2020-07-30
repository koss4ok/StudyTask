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

namespace _10A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lb.Width = this.Width - 15;
            lb.Height = this.Height - 90 - infoBlock.ActualHeight;
            lb.MaxHeight = (double)lb.Height;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            lb.Width = this.Width - 15;
            lb.Height = this.Height - 40 - infoBlock.ActualHeight;
            lb.MaxHeight = (double)lb.Height;
            
        }
    }
}
