using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace wpf10_c{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window{
        ViewModel myView = new ViewModel();
        public enum _chart { pie, area, bar, line, column }
        
        public MainWindow(){
            InitializeComponent();
            this.DataContext = myView;
            RadioButtonChanged(_chart.pie);
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(@"http://www.cbr.ru/scripts/XML_val.asp?d=0");
            try{
                webReq.AllowAutoRedirect = true;
                webReq.MaximumAutomaticRedirections = 100;
                webReq.CookieContainer = new CookieContainer(); //обнулить куки
                webReq.Method = "GET";
                Encoding win1251 = Encoding.GetEncoding(1251);
                using (WebResponse response = webReq.GetResponse()){
                    using (Stream stream = response.GetResponseStream()){
                        using (StreamReader reader = new StreamReader(stream, win1251)){
                            XDocument xdoc = XDocument.Load(reader);
                            foreach (XElement ex in xdoc.Descendants("Item").ToList()){
                                myView.AddValuta(ex.Element("Name").Value, ex.Element("ParentCode").Value);
                            }
                        }
                    }
                }
            } catch {
                MessageBox.Show("Внимание! Ошибка подлючения");
            }
        }

        private void radioButton1_Click(object sender, RoutedEventArgs e){
            RadioButtonChanged(_chart.pie);
        }

        private void radioButton2_Click(object sender, RoutedEventArgs e){
            RadioButtonChanged(_chart.area);
        }

        private void radioButton3_Click(object sender, RoutedEventArgs e){
            RadioButtonChanged(_chart.bar);
        }

        private void radioButton4_Click(object sender, RoutedEventArgs e){
            RadioButtonChanged(_chart.line);
        }

        private void radioButton5_Click(object sender, RoutedEventArgs e){
            RadioButtonChanged(_chart.column);
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e){
            if (DateTime.Today < myCalendar.SelectedDates.Last()){
                MessageBox.Show("Внимание! Неверная дата");
                myCalendar.SelectedDate = DateTime.Today;
                return;
            }
        }

        private void myCalendar_PreviewMouseUp(object sender, MouseButtonEventArgs e){
            base.OnPreviewMouseUp(e);
            if (Mouse.Captured is Calendar || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem){
                Mouse.Capture(null);
            }
        }

        private void buttonResult_Click(object sender, RoutedEventArgs e){
            if (myCalendar.SelectedDates.Count <= 1){
                MessageBox.Show("Внимание! Нужно выбрать несколько дат!");
                return;
            }
            if (myView.SelectedValuta == null){
                MessageBox.Show("Внимание! Нужно выбрать валюту!");
                return;
            }

            string d1 = myCalendar.SelectedDates.First().ToString("dd/MM/yyyy");
            string d2 = myCalendar.SelectedDates.Last().ToString("dd/MM/yyyy");
            //https://www.cbr.ru/Queries/UniDbQuery/DownloadExcel/41392?Posted=True&mode=1&VAL_NM_RQ=R01010&FromDate=04%2F02%2F2019&ToDate=04%2F09%2F2019
            string uri = @"https://www.cbr.ru/currency_base/dynamics/?UniDbQuery.Posted=True&UniDbQuery.mode=1&UniDbQuery.date_req1=&UniDbQuery.date_req2=&UniDbQuery.VAL_NM_RQ="
            + myView.SelectedValuta.Code.Trim() + @"& UniDbQuery.FromDate=" + d1 + "&UniDbQuery.ToDate=" + d2;
                //+ d1 + "&date_req2=" + d2 + "&VAL_NM_RQ=" + myView.SelectedValuta.Code.Trim();
            HttpWebRequest webReq = (HttpWebRequest)HttpWebRequest.Create(uri);
            Console.WriteLine(uri);
            try{
                List<double> valutaList = new List<double>();
                myView.KeyValueCollection.Clear();
                int index = -1;
                webReq.AllowAutoRedirect = true;
                webReq.MaximumAutomaticRedirections = 10;
                webReq.Method = "GET";
                Encoding win1251 = Encoding.GetEncoding(1251);
                using (WebResponse response = webReq.GetResponse()){
                    using (Stream stream = response.GetResponseStream()){
                        using (StreamReader reader = new StreamReader(stream, win1251)){
                            XDocument xdoc = XDocument.Load(reader);
                            foreach (XElement ex in xdoc.Descendants("Record").ToList()){
                                valutaList.Add(double.Parse(ex.Element("Value").Value) / double.Parse(ex.Element("Nominal").Value));
                            }
                            foreach(XAttribute ax in xdoc.Root.Elements().Attributes().Where(c => c.Name == "Date")){
                                myView.AddKeyValue(ax.Value, valutaList[++index]);
                            }
                        }
                    }
                }
            }catch{
                MessageBox.Show("Внимание! Ошика при подключении");
            }
            bool[] radioBoolList = { (bool)radioButton1.IsChecked, (bool)radioButton2.IsChecked, (bool)radioButton3.IsChecked, (bool)radioButton4.IsChecked, (bool)radioButton5.IsChecked };
            for (int i = 0; i < radioBoolList.Length; i++)
                if (radioBoolList[i] == true)
                    RadioButtonChanged((_chart)i);
        }

        public void RadioButtonChanged(_chart temp){
            if (myChart.Series.Count > 0) myChart.Series.RemoveAt(0);
            if (myView.SelectedValuta != null) myChart.Title = myView.SelectedValuta.Title;
            switch (temp){
                case _chart.pie:
                    PieSeries mySeries1 = new PieSeries();
                    if (myView.SelectedValuta != null) mySeries1.Title = myView.SelectedValuta.Title;
                    mySeries1.IndependentValueBinding = new Binding("Key");
                    mySeries1.DependentValueBinding = new Binding("Currency");
                    mySeries1.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries1);
                    break;
                case _chart.area:
                    AreaSeries mySeries2 = new AreaSeries();
                    if (myView.SelectedValuta != null) mySeries2.Title = myView.SelectedValuta.Title;
                    mySeries2.IndependentValueBinding = new Binding("Key");
                    mySeries2.DependentValueBinding = new Binding("Currency");
                    mySeries2.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries2);
                    break;
                case _chart.bar:
                    BarSeries mySeries3 = new BarSeries();
                    if (myView.SelectedValuta != null) mySeries3.Title = myView.SelectedValuta.Title;
                    mySeries3.IndependentValueBinding = new Binding("Key");
                    mySeries3.DependentValueBinding = new Binding("Currency");
                    mySeries3.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries3);
                    break;
                case _chart.line:
                    LineSeries mySeries4 = new LineSeries();
                    if (myView.SelectedValuta != null) mySeries4.Title = myView.SelectedValuta.Title;
                    mySeries4.IndependentValueBinding = new Binding("Key");
                    mySeries4.DependentValueBinding = new Binding("Currency");
                    mySeries4.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries4);
                    break;
                case _chart.column:
                    ColumnSeries mySeries5 = new ColumnSeries();
                    if (myView.SelectedValuta != null) mySeries5.Title = myView.SelectedValuta.Title;
                    mySeries5.IndependentValueBinding = new Binding("Key");
                    mySeries5.DependentValueBinding = new Binding("Currency");
                    mySeries5.ItemsSource = myView.KeyValueCollection;
                    myChart.Series.Add(mySeries5);
                    break;
            }
        }
    }
}
