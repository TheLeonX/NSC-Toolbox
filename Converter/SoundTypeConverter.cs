using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class SoundTypeConverter : IValueConverter
    {
        private static string GetRes(string key)
        {
            return Application.Current?.Resources?[key] as string ?? key;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return GetRes("m_nus3bankEditor_soundType_1");

            int idx;
            if (value is int i) idx = i;
            else
            {
                var s = value.ToString();
                if (!int.TryParse(s, out idx))
                    return s; // не числовой — возвращаем как есть
            }

            return idx switch
            {
                0 => GetRes("m_nus3bankEditor_soundType_1"),
                1 => GetRes("m_nus3bankEditor_soundType_2"),
                2 => GetRes("m_nus3bankEditor_soundType_3"),
                _ => value.ToString()
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // при редактировании пытаемся сопоставить обратно к числу, иначе Leave unchanged
            var s = value?.ToString() ?? string.Empty;
            if (string.Equals(s, GetRes("m_nus3bankEditor_soundType_1"), StringComparison.OrdinalIgnoreCase)) return 0;
            if (string.Equals(s, GetRes("m_nus3bankEditor_soundType_2"), StringComparison.OrdinalIgnoreCase)) return 1;
            if (string.Equals(s, GetRes("m_nus3bankEditor_soundType_3"), StringComparison.OrdinalIgnoreCase)) return 2;

            if (int.TryParse(s, out var v)) return v;
            return Binding.DoNothing;
        }
    }
}
