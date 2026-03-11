using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class NameEmptyConverter : IValueConverter
    {
        private static string GetRes(string key)
        {
            return Application.Current?.Resources?[key] as string ?? key;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value as string;
            if (string.IsNullOrWhiteSpace(s) || string.Equals(s, "nothing", StringComparison.OrdinalIgnoreCase))
                return GetRes("m_nus3bankEditor_soundType_1"); // "Пустой слот"
            return s;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var s = value?.ToString();
            if (string.IsNullOrWhiteSpace(s)) return Binding.DoNothing;
            if (string.Equals(s, GetRes("m_nus3bankEditor_soundType_1"), StringComparison.OrdinalIgnoreCase))
                return "nothing";
            return s;
        }
    }
}
