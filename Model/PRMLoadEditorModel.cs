using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NSC_Toolbox.Model {
    public class PRMLoad_Model : ICloneable, INotifyPropertyChanged {

        private string _filepath;
        public string FilePath {
            get { return _filepath; }
            set {
                _filepath = value;
                OnPropertyChanged("FilePath");
            }
        }
        private string _fileName;
        public string FileName {
            get { return _fileName; }
            set {
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }
        private int _type;
        public int Type {
            get { return _type; }
            set {
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        private int _costumeIndex;
        public int CostumeIndex {
            get { return _costumeIndex; }
            set {
                _costumeIndex = value;
                OnPropertyChanged("CostumeIndex");
            }
        }
        private int _condition;
        public int Condition {
            get { return _condition; }
            set {
                _condition = value;
                OnPropertyChanged("Condition");
            }
        }

        public bool IsFlagSet(PrmLoadConditionFlags flag)
        {
            return (_condition & (int)flag) == (int)flag;
        }

        public void SetFlag(PrmLoadConditionFlags flag, bool isSet)
        {
            if (isSet)
                _condition |= (int)flag; // Set the flag
            else
                _condition &= ~(int)flag; // Unset the flag

            OnPropertyChanged("Condition");
        }

        public object Clone() {
            return new PRMLoad_Model {
                FilePath = this.FilePath,
                FileName = this.FileName,
                Type = this.Type,
                CostumeIndex = this.CostumeIndex,
                Condition = this.Condition
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


    [Flags]
    public enum PrmLoadConditionFlags : uint
    {
        None = 0,
        //Articles
        LOAD_COMMON = 0x01,  // 0x01
        LOAD_SUPPORT = 0x02,  // 0x02
        LOAD_AWAKENING = 0x04,  // 0x04
        LOAD_JUTSU1 = 0x08,  // 0x08
        LOAD_JUTSU2 = 0x10,  // 0x10
        LOAD_JUTSU3 = 0x20,  // 0x20
        LOAD_JUTSU4 = 0x40,  // 0x40
        LOAD_JUTSU5 = 0x80,  // 0x80
        LOAD_ULTIMATE1 = 0x100,  // 0x100
        LOAD_ULTIMATE2 = 0x200,  // 0x200
        LOAD_ULTIMATE3 = 0x400,  // 0x400
        LOAD_ULTIMATE4 = 0x800,  // 0x800
        //LOAD_UNK1 = 1 << 12,  // 0x1000
        LOAD_JUTSU6 = 0x2000,  // 0x2000


        ALL = ~None,
    }
}
