using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace lab8A
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ManualResetEventSlim mres;

        //MediaElement me;
        public MainWindow()
        {
            InitializeComponent();
            //  me = new MediaElement();
            slVolume.Value = 0.25;
            mres = new ManualResetEventSlim(false);       
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                me.Source = new Uri(ofd.FileName);
                this.Title = ofd.SafeFileName;
                //btnPlay_Click(this, null);
                slBalance.Value = 0;
                slSpeed.Value = 1;
            }
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            if (me.Source != null)
                me.Play();
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            if (me.Source != null)
                me.Stop();
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            if (me.Source != null && me.CanPause)
                me.Pause();
        }
    }
}
