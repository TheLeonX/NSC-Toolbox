using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class SlotToImageConverter : IMultiValueConverter
    {
        // values[0] = SlotIndex_field (из VM), values[1] = текущий индекс (1..24)
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                int slot = values[0] == null ? 0 : System.Convert.ToInt32(values[0]);
                int idx = values[1] == null ? 0 : System.Convert.ToInt32(values[1]);

                string key = (slot == idx) ? "charsel_brt_icon" : "charsel_empty_icon";
                var res = Application.Current.TryFindResource(key);
                return res ?? DependencyProperty.UnsetValue;
            } catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
