using Microsoft.Win32;
using System.Data;
using System.IO;
using System.Windows;

namespace _10B
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

        private void Save(object sender, RoutedEventArgs e)
        {
            var Set = new DataSet();
            var dialog = new SaveFileDialog { Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*" };
            if ((bool)dialog.ShowDialog()){
                FileStream fs = new FileStream(dialog.FileName, FileMode.Create);
                Set.Tables.Add((Data.ItemsSource as DataView).ToTable());
                Set.WriteXml(fs);
                fs.Close();
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog { Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*" };
                if ((bool)dialog.ShowDialog())
                {
                    Label.Content = dialog.FileName;
                    var Set = new DataSet();
                    Set.ReadXml((string)Label.Content);
                    Data.ItemsSource = new DataView(Set.Tables[0]);
                }
            }
            catch { MessageBox.Show("Не считать"); }
        }
    }
}

