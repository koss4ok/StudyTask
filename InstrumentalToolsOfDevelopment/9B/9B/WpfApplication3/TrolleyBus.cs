using System;

namespace WpfApplication3
{
    public class TrolleyBus
    {
        static private DateTime startWorkingTime { get; set; }
        static public string StartWorkingTime { get { return startWorkingTime.ToString("dd/MM/yyyy HH:mm:ss"); } }
        static public int Count { get; set; }
        public int Number { get; set; }
        public bool IsActive { get; set; }

        static TrolleyBus()
        {
            startWorkingTime = DateTime.Now;
            Count = 5;
        }
        public TrolleyBus()
        {
            Number = 2;
        }
        public TrolleyBus(int Number)
        {
            this.Number = Number;
        }

        public string Drive()
        {
            IsActive = true;
            return "Выехал троллейбус №" + Number + " в " + DateTime.Now.ToString("HH:mm:ss") + ". Через " + DateTime.Now.Subtract(startWorkingTime).ToString(@"hh\:mm\:ss") + " от начала работы парка.\n";
        }
    }
}
