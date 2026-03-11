using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class DataGridItemIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2) return string.Empty;
            var source = values[0]; // ItemsSource (или сама коллекция)
            var item = values[1];
            if (source == null || item == null) return string.Empty;

            // Если передали ICollectionView, возьмём SourceCollection
            if (source is System.ComponentModel.ICollectionView view)
                source = view.SourceCollection;

            // Если это IList — прямой индекс
            if (source is IList list)
            {
                int idx = list.IndexOf(item);
                return idx >= 0 ? (idx).ToString() : string.Empty;
            }

            // Иначе — перебор по ссылке/равенству
            if (source is IEnumerable enumerable)
            {
                int i = 0;
                foreach (var v in enumerable)
                {
                    if (ReferenceEquals(v, item) || Equals(v, item))
                        return (i).ToString();
                    i++;
                }
            }

            return string.Empty;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
