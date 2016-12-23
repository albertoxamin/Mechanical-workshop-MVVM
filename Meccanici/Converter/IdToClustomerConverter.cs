using Meccanici.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Meccanici.Converter
{
    [ValueConversion(typeof(int),typeof(string))]
    public class IdToCustomerConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Person mech = App.customerDataService.GetCustomerDetail((int)value);
            return mech.Name + " " + mech.Surname;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
