using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace App_10C
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DateTime[] dates = calendar.SelectedDates.ToArray();
            PointCollection points = (PointCollection)grid.FindResource("PointCollection");
            points.Clear();
            XmlDataProvider dataProvide = new XmlDataProvider();
            string date1 = dates[0].ToShortDateString().Replace(".", "/");
            string date2 = dates[dates.Length - 1].ToShortDateString().Replace(".", "/");
            string valID = (list.SelectedItem as XmlElement).Attributes["ID"].Value;
            XmlDocument doc = new XmlDocument();
            doc.Load("http://www.cbr.ru/scripts/XML_dynamic.asp?date_req1=" + date1 + "&date_req2=" + date2 + "&VAL_NM_RQ=" + valID);
            foreach (XmlNode xn in doc.SelectNodes("/ValCurs/Record"))
            {
                string date = xn.Attributes["Date"].Value.ToString();
                double value = Convert.ToDouble(xn.SelectSingleNode("Value").InnerText);
                points.Add(new Point(date, value));
            }
        }

    }
}
