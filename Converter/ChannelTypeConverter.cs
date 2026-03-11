using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace NSC_Toolbox.Converter
{
    [ValueConversion(typeof(int), typeof(string))]
    class ChannelTypeConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string state = "???";
            switch ((int)value) {
                case 1:
                    state = "Mono";
                    break;
                case 2:
                    state = "Stereo";
                    break; 
            }

            return state;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}
