using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace wpf10_c{
    class Valuta : INotifyPropertyChanged{
        string title;   //название валюты
        string code;    //код валюты

        public Valuta(string _title, string _code){
            title = _title;
            code = _code;
        }

        public string Title{
            get { return title; }
            set { title = value; NotifyPropertyChanged("Title"); }
        }

        public string Code{
            get { return code; }
            set { code = value; NotifyPropertyChanged("Code"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string str = ""){
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(str));
        }
    }
}
