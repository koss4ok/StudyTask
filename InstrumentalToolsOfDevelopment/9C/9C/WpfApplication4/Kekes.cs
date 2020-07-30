using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;


namespace WpfApplication4{
    public class AppViewModel : INotifyPropertyChanged{
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Department> Departments { get; set; }

        public AppViewModel(){
            Departments = new ObservableCollection<Department>();

            var dep1 = new Department { Name = "Административный отдел" };
            var dep2 = new Department { Name = "Технический отдел" };
            var emp1 = new Employeer { Name = "Борис Державин" };
            var emp2 = new Employeer { Name = "Иван Попов" };
            var emp3 = new Employeer { Name = "Илья Сидоров" };

            dep1.Employeers.Add(emp1);
            dep1.Employeers.Add(emp2);
            dep2.Employeers.Add(emp3);

            Departments.Add(dep1);
            Departments.Add(dep2);
        }
        public void add_dep(string name){
            Departments.Add(new Department { Name = name });
        }
        public void add_emp(string name, Department dep){
            dep.Employeers.Add(new Employeer { Name = name });
        }
        protected void OnPropertyChanged(string name){
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
    }


    public class Employeer : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;

        public string Name{
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        protected void OnPropertyChanged(string name){
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null){
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }


    public class Department : INotifyPropertyChanged {
        public ObservableCollection<Employeer> Employeers { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private string name;

        public string Name{
            get { return name; }
            set {
                name = value;
                OnPropertyChanged("Name");
            }
        }
        public Department(){
            Employeers = new ObservableCollection<Employeer>();
        }
        protected void OnPropertyChanged(string name){
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null){
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}