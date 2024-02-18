using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NSC_Toolbox.Model {
    public class ExportModModel : INotifyPropertyChanged {
        private int _modType;
        public int ModType {
            get { return _modType; }
            set {
                _modType = value;
                OnPropertyChanged("ModType");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
