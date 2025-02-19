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
    public class CharacodeToNameConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2)
            {
                return "Unknown1";
            }

            if (values[0] is not int characodeID)
            {
                return "Unknown2";
            }

            if (values[1] is not ObservableCollection<CharacodeEditorModel> importCharacterList)
            {
                return "Unknown3";
            }

            var character = importCharacterList.FirstOrDefault(c => c.CharacodeIndex == characodeID);

            if (character == null)
            {
                return "Unknown4";
            }


            return character.CharacodeName;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
