using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace wpf10_c{
    class KeyValue : INotifyPropertyChanged {
        string key;     //ключ - дата dd.mm.yyyy
        double currency;//значение - стоимость валюты в рублях

        public KeyValue(string _key, double _currency){
            key = _key;
            currency = _currency;
        }

        public string Key{
            get { return key; }
            set { key = value; NotifyPropertyChanged("Key"); }
        }

        public double Currency{
            get { return currency; }
            set { currency = value; NotifyPropertyChanged("Currency"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string str = ""){
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(str));
        }
    }
}
