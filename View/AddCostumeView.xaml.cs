using NSC_Toolbox.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NSC_Toolbox.View {
    /// <summary>
    /// Логика взаимодействия для AddCostumeView.xaml
    /// </summary>
    /// 


    public partial class AddCostumeView : Window {
        private Dictionary<Label, TranslateTransform> labelTransforms = new Dictionary<Label, TranslateTransform>();

        public AddCostumeView() {
            InitializeComponent();
            DataContext = new AddCostumeViewModel();
        }
    }
}
