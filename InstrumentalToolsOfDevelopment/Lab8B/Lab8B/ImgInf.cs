using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Lab8B
{
    class ImgInf
    {
        private string fullPath = null;
        private string name = null;
        private BitmapImage image = null;

        public ImgInf(string fullPath, string name)
        {
            this.fullPath = fullPath;
            this.name = name;
            this.image = new BitmapImage(new Uri(fullPath));
        }


        public BitmapImage Image
        {
            get { return this.image; }
            private set { }
        }
        public string FileName
        {
            get { return this.name; }
            private set { }
        }
        public string FullPath
        {
            get { return this.fullPath; }
            private set { }
        }


    }
}
