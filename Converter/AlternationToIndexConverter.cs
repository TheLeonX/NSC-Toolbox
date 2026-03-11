using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class AlternationToIndexConverter : IValueConverter
    {
        // возвращает 1-based индекс
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int idx)
                return (idx + 1).ToString();
            return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
