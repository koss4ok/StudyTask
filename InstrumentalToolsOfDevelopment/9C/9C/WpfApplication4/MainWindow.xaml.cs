using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApplication4 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public AppViewModel Model = new AppViewModel();
        public MainWindow(){
            InitializeComponent();
            DataContext = Model;
        }

        private void DEP_SelectionChanged(object sender, SelectionChangedEventArgs e){
            Name.ItemsSource = Model.Departments.First(x => x == (DEP.SelectedItem as Department)).Employeers;
        }

        private void Button_Click(object sender, RoutedEventArgs e){
            Model.add_dep(dep.Text.ToString());
            dep.Text = String.Empty;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e){
            if (DEP.SelectedIndex == -1) return;
            Model.add_emp(emp.Text.ToString(), (DEP.SelectedItem as Department));
            emp.Text = String.Empty;
        }
    }
}
