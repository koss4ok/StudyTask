using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab8B
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<ImgInf> ImageList;

        public MainWindow()
        {
            InitializeComponent();
            ImageList = new ObservableCollection<ImgInf>();
            lvImages.ItemsSource = ImageList;
            lbPreview.Items.Clear();
            lbPreview.ItemsSource = ImageList;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            
            ofd.Filter = "Image files (*.jpg,*.jpeg,*.jpe,*.jfif,*.png)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png";
            if (ofd.ShowDialog() == true)
            {
                ImgInf temp = new ImgInf(ofd.FileName, ofd.SafeFileName);
                ImageList.Add(temp);
            }
        }

        private void LbPreview_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (((ListBox)sender).SelectedItem != null)
            {
                imgMain.Source = ((ImgInf)((ListBox)sender).SelectedItem).Image;
                var lbItem = (ListBoxItem)lbPreview.ItemContainerGenerator.ContainerFromItem(((ListBox)sender).SelectedItem);
                lbPreview.SelectedItem = ((ListBox)sender).SelectedItem;
                lvImages.SelectedItem = ((ListBox)sender).SelectedItem;
                ((ListBoxItem)lbPreview.ItemContainerGenerator.ContainerFromItem(lbPreview.SelectedItem)).Focus();
            }
        }

        private void Landscape_Selected(object sender, RoutedEventArgs e)
        {
            RotateTransform rt = new RotateTransform(0);
            imgMain.LayoutTransform = rt;
        }

        private void Portrait_Selected(object sender, RoutedEventArgs e)
        {
            RotateTransform rt = new RotateTransform(90);
            imgMain.LayoutTransform = rt;
        }
    }
}
