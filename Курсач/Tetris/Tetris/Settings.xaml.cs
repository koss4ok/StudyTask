using System.Windows;
using System.Windows.Input;

namespace Tetris
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (btn1.Content.ToString() == "Easy")
            {
                btn1.Content = "Normal";
                Class1.GAMESPEED = 600;
            }
            else if (btn1.Content.ToString() == "Normal")
            {
                btn1.Content = "Hard";
                Class1.GAMESPEED = 400;
            }
            else if (btn1.Content.ToString() == "Hard")
            {
                btn1.Content = "Extreme";
                Class1.GAMESPEED = 150;
            }
            else if (btn1.Content.ToString() == "Extreme")
            {
                btn1.Content = "Easy";
                Class1.GAMESPEED = 800;
            }
        }
        public Settings()
        {
            InitializeComponent();
            txt1.Text = Class1.KeyUp.ToString();
            txt2.Text = Class1.KeyDown.ToString();
            txt3.Text = Class1.KeyLeft.ToString();
            txt4.Text = Class1.KeyRight.ToString();
            switch (Class1.GAMESPEED)
            {
                case 800: btn1.Content = "Easy"; break;
                case 600: btn1.Content = "Normal"; break;
                case 400: btn1.Content = "Hard"; break;
                case 150: btn1.Content = "Extreme"; break;
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {

            if (txt1.IsFocused)
            {
                txt1.Text = e.Key.ToString();
                Class1.KeyUp = e.Key;
            }
            else if (txt2.IsFocused)
            {
                txt2.Text = e.Key.ToString();
                Class1.KeyDown = e.Key;
            }
            else if (txt3.IsFocused)
            {
                txt3.Text = e.Key.ToString();
                Class1.KeyRight = e.Key;
            }
            if (txt4.IsFocused)
            {
                txt4.Text = e.Key.ToString();
                Class1.KeyLeft = e.Key;
            }
        }
    }
}
