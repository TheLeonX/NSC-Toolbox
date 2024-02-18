using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using NSC_Toolbox.Properties;

namespace NSC_Toolbox.Converter
{
    [ValueConversion(typeof(Int16), typeof(string))]
    class FunctionIndexConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return Program.ME_NSC_LIST[(Int16)value].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}
