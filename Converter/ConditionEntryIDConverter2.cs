using DynamicData;
using NSC_Toolbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NSC_Toolbox.Converter
{
    public class ConditionEntryIDConverter2 : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || values[0] is not ConditionManagerModel condition || values[1] is not ObservableCollection<ConditionManagerModel> conditionList)
                return "???";

            Application.Current.Dispatcher.Invoke(() =>
            {
                int index = conditionList.IndexOf(condition);
                condition.OnPropertyChanged(nameof(condition.ConditionName)); // Force UI refresh
            });

            int index = conditionList.IndexOf(condition);
            return index >= 0 ? $"{index} - " : "???";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
