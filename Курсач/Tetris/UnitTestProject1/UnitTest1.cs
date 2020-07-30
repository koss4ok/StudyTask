using System.Windows.Media;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tetris;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        MainWindow win = new MainWindow();
        [TestMethod]
        //метод для проверки корректности работы 
        //метода, считающего и возвращающего набранные очки
        public void TestScore()
        {
            int scoreNormal=50;
            for(int i=1;i<=3;++i)
            Assert.AreEqual(scoreNormal, win.getScore()/i);
        }

        [TestMethod]
        //метод для проверки метода, красящего фигуры тетромино
        public void TestColor()
        {
            Color clr = new Color();
            LinearGradientBrush kek = new LinearGradientBrush();
            Assert.AreEqual(kek.GetType(), win.getGradientColor(clr).GetType()); 
        }

        [TestMethod]
        //метод для проверки метода, обнуляющего значения
        public void TestReturn()
        {
            win.downPos = 5;
            win.leftPos = 5;
            win.isRotated = true;
            win.rotation = 99999;
            win.reset();
            Assert.AreEqual(0, win.downPos);
            Assert.AreEqual(3, win.leftPos);
            Assert.AreEqual(false, win.isRotated);
            Assert.AreEqual(0, win.rotation);

        }
    }
}
