using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace Tetris
{
    /// <summary>
    /// Логика взаимодействия для EndGame.xaml
    /// TODO
    /// SQL команда на возврата первых 10 значений
    /// Присвоение значенией к обсерв колл
    /// List.itemsource=kek
    public partial class EndGame : Window
    {
        
        const string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Koss4ok\Desktop\Tetris\Tetris\Database.mdf;Integrated Security=True;Connect Timeout=30";
        SqlConnection connection = new SqlConnection(conString);
        ObservableCollection<String> kek = new ObservableCollection<string>();
        public EndGame()
        {
            InitializeComponent();
            RecordTable();
            
        }
        private void RecordTable()
        {
            kek.Clear();
            SqlCommand query = new SqlCommand("SELECT TOP 10  Users.Name, Result FROM Results, Users WHERE Users.Id=Results.Id_player ORDER BY Result DESC ");
            connection.Open();
                query.Connection = connection;
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    int res = reader.GetInt32(1);
                    kek.Add(name + "   "+res);
                }
                LIST.ItemsSource = kek;
            connection.Close();
            
        }

        private void But_Click(object sender, RoutedEventArgs e)
        {
            But.IsEnabled = false;
            LIST.ItemsSource = null;
            LIST.Items.Clear();
             SqlCommand query = new SqlCommand($"SELECT * FROM Users Where Name ='{txt.Text}'");
                connection.Open();
                query.Connection = connection;
                var reader = query.ExecuteReader();
                if (!reader.HasRows)//Есть ли уже в БД пользователь с таким именем?
                {
                reader.Close();
                    query = new SqlCommand($"INSERT INTO Users (Name) VALUES ('{txt.Text}')");//Если нет- добавить
                query.Connection = connection;
                query.ExecuteNonQuery();
                    query = new SqlCommand($"SELECT id FROM Users Where Name = '{txt.Text}'");//Дальше узнать присвоенный ему id
                query.Connection = connection;
                var wtf=query.ExecuteReader();
                wtf.Read();
                    query = new SqlCommand($"INSERT INTO Results (Result,Id_player) VALUES ({MainWindow.gameScore},{wtf.GetInt32(0)})");
                //В таблицу RESULTS запихать набранные очки и id того, кто набрал
                query.Connection = connection;
                wtf.Close();
                query.ExecuteNonQuery();
                }
                else//Если есть
                {
                reader.Close();
                query = new SqlCommand($"SELECT id FROM Users Where Name ='{txt.Text}'");
                //Мы пропускаем добавление и сразу достаём его id
                query.Connection = connection;
                var wtf = query.ExecuteReader();
                wtf.Read();
                query = new SqlCommand($"INSERT INTO  Results (Result,Id_player) VALUES ({MainWindow.gameScore},{wtf.GetInt32(0)})");
                //В таблицу RESULTS запихать набранные очки и id того, кто набрал
                query.Connection = connection;
                wtf.Close();
                query.ExecuteNonQuery();
            }
            connection.Close();
            MainWindow.gameScore = 0;
            RecordTable();
        }

        private void txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txt.Text == "" || txt.Text == "Введите имя")
                But.IsEnabled = false;
            else
                But.IsEnabled = true;
        }
    }
}
