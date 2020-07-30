using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Tetris
{
    static class Class1
    {
        public static Key KeyUp { get; set; } = Key.Up;
        public static Key KeyDown { get; set; } = Key.Down;
        public static Key KeyLeft { get; set; } = Key.Left;
        public static Key KeyRight { get; set; } = Key.Right;
        public static int GAMESPEED { get; set; } = 700;
        static MainWindow MainWin = new MainWindow();
        static Window1 win1 = new Window1();
        
        public static void OpenSet()
        {
            Settings set = new Settings();
            set.ShowDialog();
        }

    }
}
