using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<TrolleyBus> Trolls = new List<TrolleyBus>();
            TrolleyBus Park;
            List<Label> Views = new List<Label>();
            DispatcherTimer Timer;
            Rodnenkiy.SizeChanged += (object sender, SizeChangedEventArgs e) =>
            {
                Views.Clear();
                foreach (var troll in Trolls)
                    Views.Add(new Label
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(2 + (troll.Number - 1) % ((int)Rodnenkiy.ActualWidth / 30) * 30, 2 + (troll.Number - 1) / ((int)Rodnenkiy.ActualWidth / 30) * 30, 0, 0),
                        Padding = new Thickness(3),
                        FontSize = 15,
                        Content = troll.Number,
                        Height = 28,
                        Width = 28,
                        Style = troll.IsActive ? (Style)FindResource("Green") : (Style)FindResource("Red")
                    });
                Rodnenkiy.Children.Clear();
                foreach (var view in Views)
                    Rodnenkiy.Children.Add(view);
            };
            button.Click += (object sender, RoutedEventArgs e) =>
            {
                Park = new TrolleyBus();
                DataContext = Park;
                Result.Text = "";
                Timer = new DispatcherTimer(DispatcherPriority.Normal, Dispatcher);
                Timer.Stop();
                Trolls.Clear();
                for (int i = 1; i <= TrolleyBus.Count; i++)
                    Trolls.Add(new TrolleyBus(i));
                Views.Clear();
                foreach (var troll in Trolls)
                    Views.Add(new Label
                    {
                        HorizontalAlignment = HorizontalAlignment.Left,
                        HorizontalContentAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Top,
                        Margin = new Thickness(2 + (troll.Number - 1) % ((int)Rodnenkiy.ActualWidth / 30) * 30, 2 + (troll.Number - 1) / ((int)Rodnenkiy.ActualWidth / 30) * 30, 0, 0),
                        Padding = new Thickness(3),
                        FontSize = 15,
                        Content = troll.Number,
                        Height = 28,
                        Width = 28,
                        Style = (Style)FindResource("Red")
                    });
                Rodnenkiy.Children.Clear();
                foreach (var view in Views)
                    Rodnenkiy.Children.Add(view);
                Random a = new Random();
                Timer.Interval = new TimeSpan(0, 0, 1);
                Timer.Tick += (object send, EventArgs ea) =>
                {
                    if (Trolls.Where(x => !x.IsActive).Count() == 0)
                        Timer.Stop();
                    if (Trolls.Where(x => !x.IsActive).Count() != 0 && a.Next(0, 2) == 1)
                    {
                        var skiped = a.Next(0, Trolls.Where(x => !x.IsActive).Count());
                        Result.Text += Trolls.Where(x => !x.IsActive).Skip(skiped).First().Drive();
                        Views.Where(x => x.Style.Equals((Style)FindResource("Red"))).Skip(skiped).First().Style = (Style)FindResource("Green");
                    }
                };
                Timer.Start();
            };
        }
    }
}
