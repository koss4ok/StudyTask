using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace wpf10_c{
    class ViewModel : INotifyPropertyChanged{ 
        ObservableCollection<KeyValue> keyValueCollection;  //коллекция котировок валют
        ObservableCollection<Valuta> valutaCollection;      //коллекция названий и кодов валют
        Valuta selectedValuta;  //выбранное название валюты

        public ViewModel(){
            keyValueCollection = new ObservableCollection<KeyValue>();
            valutaCollection = new ObservableCollection<Valuta>();
        }

        public ObservableCollection<KeyValue> KeyValueCollection{
            get { return keyValueCollection; }
        }

        public ObservableCollection<Valuta> ValutaCollection{
            get { return valutaCollection; }
        }

        public Valuta SelectedValuta{
            get { return selectedValuta; }
            set { selectedValuta = value; NotifyPropertyChanged("SelectedValuta"); }
        }

        public void AddKeyValue(string key, double value){
            keyValueCollection.Add(new KeyValue(key, value));
        }

        public void AddValuta(string _title, string _code){
            valutaCollection.Add(new Valuta(_title, _code));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]string str = ""){
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(str));
        }
    }
}
