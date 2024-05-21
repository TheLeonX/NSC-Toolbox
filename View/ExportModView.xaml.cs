using NSC_Toolbox.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NSC_Toolbox.View {
    /// <summary>
    /// Логика взаимодействия для ExportModView.xaml
    /// </summary>
    public partial class ExportModView : Window {
        public ExportModView() {
            InitializeComponent();
            DataContext = new ExportModViewModel();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e) {
            var regex = new Regex(@"[^a-zA-Z0-9\s]");
            if (regex.IsMatch(e.KeyChar.ToString())) {
                e.Handled = true;
            }
        }
    }
}
