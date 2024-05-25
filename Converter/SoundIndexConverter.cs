using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using NSC_Toolbox.Properties;
using System.Collections.ObjectModel;

namespace NSC_Toolbox.Converter
{
    [ValueConversion(typeof(int), typeof(string))]
    class SoundIndexConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            ObservableCollection<string> Sound_List = new ObservableCollection<string> {
                "No Sound"
            };
            for (int x = 0; x < Program.NSC_SFX_LIST.Length; x++) Sound_List.Add(Program.NSC_SFX_LIST[x]);
            return Sound_List[(int)value+1].ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return DependencyProperty.UnsetValue;
        }
    }
}
