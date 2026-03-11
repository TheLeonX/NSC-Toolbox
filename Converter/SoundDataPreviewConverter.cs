using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class SoundDataPreviewConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is byte[] data && data.Length >= 4)
            {
                return Encoding.ASCII.GetString(data, 0, 4);
            }
            return "No Sound Data"; // если null или меньше 4 байт
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
