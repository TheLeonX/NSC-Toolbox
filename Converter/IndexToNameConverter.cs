using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class IndexToNameConverter : IMultiValueConverter
    {
        // values[0] = ToneID (int)
        // values[1] = ToneList (IList)
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2) return string.Empty;
            if (!(values[0] is int idx)) return string.Empty;
            if (!(values[1] is System.Collections.IList list)) return $"#{idx}";

            if (idx >= 0 && idx < list.Count)
            {
                var item = list[idx];
                var prop = item?.GetType().GetProperty("Name");
                if (prop != null) return prop.GetValue(item)?.ToString() ?? $"#{idx}";
                return item?.ToString() ?? $"#{idx}";
            }

            return $"#{idx}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotImplementedException();
    }
}
