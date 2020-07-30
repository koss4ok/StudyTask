using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace lab9a
{
    class DateMultiValueConverter : ValidationRule, IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int[] date = new int[3];
            for (int i = 0; i < 3;i++ )
            {
                if ((string)values[i] == "")
                {
                    return false;
                }
                if (!Int32.TryParse(values[i].ToString(), out date[i]))                    
                    return "Необходимо ввести только цифры";
            }

            DateTime dt;
            try
            {
              dt = new DateTime(date[2], date[1], date[0]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                return "такой даты нет";
            }
            return dt.ToShortDateString();
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            DateTime dt;
            if(DateTime.TryParse(value.ToString(),out dt))
            {
                string[] dd = new string[] { dt.Day.ToString(), dt.Month.ToString(), dt.Year.ToString() };
                return dd;
            }
            else
            {             
                string[] qwe = new string[] { "Невозможно", "провести", "преобразование" };
                return qwe;
            }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            try
            {
                DateTime dateTime = (DateTime)value;
                
            }
            catch (InvalidCastException e)
            {
                return new ValidationResult(false, e.Message);
            }          
            return new ValidationResult(false, "This is outside try in Validate method");
        }
    }
}
