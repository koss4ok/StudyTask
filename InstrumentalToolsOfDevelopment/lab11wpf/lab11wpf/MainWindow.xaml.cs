using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;

namespace lab11wpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Order> orders;
        int total;
        public MainWindow()
        {
            int i = 0;
            InitializeComponent();
            lblDate.Content = DateTime.Now.ToShortDateString();
            lblOrderNum.Content = "Заказ № " + new Random().Next(1, 1000);
            orders = new ObservableCollection<Order>()
            {
                new Order(++i, "Арбуз", 3,16),
                new Order(++i, "Тыква", 10,40),
                new Order(++i, "Яблоки", 8,80),
                new Order(++i, "Дыня", 10,25),
                new Order(++i, "Абрикосы", 5,40)
            };
            dgOrders.ItemsSource = orders;
            total = orders.Sum(x => x.Sum);
            lblSumOfAll.Content = "Итого: " + total;
        }

        private void BtnToWord_Click(object sender, RoutedEventArgs e)
        {
            object oEndOfDoc = "\\endofdoc";
            Word.Application wrdApp = new Word.Application();
            wrdApp.Visible = true;
            wrdApp.Documents.Add();
            Word.Document wrdDoc = wrdApp.ActiveDocument;
            object start = 0, end = 0;
            Word.Paragraph para1 = wrdDoc.Content.Paragraphs.Add(Type.Missing);
            para1.Range.Text = "Расходная накладная №" + lblOrderNum.Content+" от "+ lblDate.Content;
            para1.Range.InsertParagraphAfter();

            para1.Range.Text = "Поставщик: " + tbxVendor.Text;
            para1.Range.InsertParagraphAfter();

            //Word.Paragraph para2 = wrdDoc.Content.Paragraphs.Add(Type.Missing);
            para1.Range.Text = "Покупатель: " + tbxBuyer.Text;
            para1.Range.InsertParagraphAfter();

            //Word.Paragraph para3 = wrdDoc.Content.Paragraphs.Add(Type.Missing);
            Word.Range range = wrdDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            para1.Range.InsertParagraphAfter();
            wrdDoc.Tables.Add(range, 5, 5);
            wrdDoc.Tables[1].Borders.Enable = 1;
            wrdDoc.Tables[1].Cell(1, 1).Range.Bold = 1;
            wrdDoc.Tables[1].Cell(1, 2).Range.Bold = 1;
            wrdDoc.Tables[1].Cell(1, 3).Range.Bold = 1;
            wrdDoc.Tables[1].Cell(1, 1).Range.Font.Size = 12;
            wrdDoc.Tables[1].Cell(1, 2).Range.Font.Size = 12;
            wrdDoc.Tables[1].Cell(1, 3).Range.Font.Size = 12;
            //Название столбцов
            wrdDoc.Tables[1].Cell(1, 1).Range.Text = "№";
            wrdDoc.Tables[1].Cell(1, 2).Range.Text = "Товар";
            wrdDoc.Tables[1].Cell(1, 3).Range.Text = "Количество";
            wrdDoc.Tables[1].Cell(1, 4).Range.Text = "Цена";
            wrdDoc.Tables[1].Cell(1, 5).Range.Text = "Сумма";
            int row = 2;
            for (int i = 0; i < orders.Count; i++, row++)
            {
                wrdDoc.Tables[1].Cell(row, 1).Range.Text = orders[i].ID.ToString();
                wrdDoc.Tables[1].Cell(row, 2).Range.Text = orders[i].Product.ToString();
                wrdDoc.Tables[1].Cell(row, 3).Range.Text = orders[i].Quantity.ToString();
                wrdDoc.Tables[1].Cell(row, 4).Range.Text = orders[i].Price.ToString();
                wrdDoc.Tables[1].Cell(row, 5).Range.Text = orders[i].Sum.ToString();
            }
            //Word.Paragraph para4 = wrdDoc.Content.Paragraphs.Add(Type.Missing);
            para1.Range.Text = "Итого: " + total;
            para1.Range.InsertParagraphAfter();
            wrdDoc.SaveAs(@"C:\Users\Koss4ok\Desktop\MyDoc");
            wrdApp.Quit();
        }

        private void BtnToExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();
            excel.Visible = true;
            excel.Workbooks.Add();
            Excel.Worksheet worksheet = (Excel.Worksheet)excel.ActiveSheet;
            worksheet.Cells[1, 1] = "№";
            worksheet.Cells[1, 2] = "Товар";
            worksheet.Cells[1, 3] = "Количиство";
            worksheet.Cells[1, 4] = "Цена";
            worksheet.Cells[1, 5] = "Сумма";
            int row = 2;
            for (int i = 0; i < orders.Count; i++, row++)
            {
                worksheet.Cells[row, 1] = orders[i].ID;
                worksheet.Cells[row, 2] = orders[i].Product;
                worksheet.Cells[row, 3] = orders[i].Quantity;
                worksheet.Cells[row, 4] = orders[i].Price;
                worksheet.Cells[row, 5] = orders[i].Sum;
            }
            row++;
            Excel.Range range = worksheet.get_Range(string.Format("D" + row), string.Format("E" + row)).Cells;
            range.Merge(Type.Missing);
            worksheet.Cells[row, 4] = "Итого: " + total;
            worksheet.Columns.AutoFit();
            worksheet.SaveAs(@"C:\Users\Koss4ok\Desktop\MyExcel");
            excel.Quit();
        }

        private void BtnFromExcel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                orders.Clear();
                var excelapp = new Excel.Application();
                excelapp.Visible = true;
                var excelappworkbooks = excelapp.Workbooks;
                //Открываем книгу и получаем на нее ссылку
                var excelappworkbook = excelapp.Workbooks.Open(@"C:\Users\Koss4ok\Desktop\MyExcel.xlsx");
                var excelsheets = excelappworkbook.Worksheets;
                //Получаем ссылку на лист 1
                var worksheet = (Excel.Worksheet)excelsheets.get_Item(1);
                //Выбираем ячейку для вывода A1
                int row = 2;
                var excelcells = worksheet.get_Range("A2", Type.Missing);
                while (!String.IsNullOrWhiteSpace(Convert.ToString((worksheet.Cells[row, 1] as Excel.Range).Value)))
                {
                    int id = (int)(worksheet.Cells[row, 1] as Excel.Range).Value;
                    string product = Convert.ToString((worksheet.Cells[row, 2] as Excel.Range).Value);
                    int quan = (int)(worksheet.Cells[row, 3] as Excel.Range).Value;
                    int price = (int)(worksheet.Cells[row, 4] as Excel.Range).Value;
                    orders.Add(new Order(id, product, quan, price));
                    row++;
                }
                excelapp.Quit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
           
        }
    }
}
