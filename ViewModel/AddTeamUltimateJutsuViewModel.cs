using Microsoft.WindowsAPICodePack.Dialogs;
using NSC_Toolbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace NSC_Toolbox.ViewModel
{
    public class AddTeamUltimateJutsuViewModel : INotifyPropertyChanged
    {
        private Visibility _loadingStatePlay;
        public Visibility LoadingStatePlay
        {
            get { return _loadingStatePlay; }
            set
            {
                _loadingStatePlay = value;
                OnPropertyChanged("LoadingStatePlay");
            }
        }
        private ObservableCollection<CharacodeEditorModel> _importCharacterList = new();
        public ObservableCollection<CharacodeEditorModel> ImportCharacterList
        {
            get => _importCharacterList;
            set
            {
                _importCharacterList = value;
                OnPropertyChanged(nameof(ImportCharacterList));
            }
        }
        private CharacodeEditorModel _importCharacterItem;
        public CharacodeEditorModel ImportCharacterItem
        {
            get { return _importCharacterItem; }
            set
            {
                _importCharacterItem = value;
                OnPropertyChanged("ImportCharacterItem");
            }
        }

        private string _rootFolder_field;
        public string RootFolderPath_field
        {
            get { return _rootFolder_field; }
            set
            {
                _rootFolder_field = value;
                if (value != null)
                {
                    MissingFiles_field = "";
                    if (File.Exists(Path.Combine(value, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin")) &&
                        File.Exists(Path.Combine(value, "data_win32", "sound", "cmnparam.xfbin")) &&
                        File.Exists(Path.Combine(value, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin"))
                        )
                        IsRootFolderExist = Directory.Exists(value);

                    if (!File.Exists(Path.Combine(value, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin")))
                    {
                        ModernWpf.MessageBox.Show(Path.Combine(value, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin") + " doesn't exist. Install new version of ModdingAPI before using this tool.");
                        return;
                    }
                    string characodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", "characode.bin.xfbin");
                    if (File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "characode.bin.xfbin")))
                    {
                        characodePath = Path.Combine(RootFolderPath_field, "data_win32", "spc", "characode.bin.xfbin");
                    }
                    CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                    charEditor.OpenFile(characodePath);
                    ImportCharacterList = charEditor.CharacodeList;

                    if (!IsRootFolderExist)
                    {
                        MessageBoxResult result = (MessageBoxResult)ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_12"], "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {

                            IsRootFolderExist = Directory.Exists(RootFolderPath_field);
                            if (IsRootFolderExist)
                            {

                                if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc")))
                                    Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "spc"));
                                if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound")))
                                    Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "sound"));


                                if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin")))
                                    File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", "pairSpSkillCombinationParam.xfbin"), Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin"));

                                if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin")))
                                    File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", "cmnparam.xfbin"), Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin"));
                            } else
                            {
                                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_11"]);
                            }
                        } else
                        {
                            MissingFiles_field = "Missing files:\n\n";
                            if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin")))
                                MissingFiles_field += Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin") + "\n";
                            if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin")))
                                MissingFiles_field += Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin") + "\n";
                        }
                    }
                } else
                    IsRootFolderExist = false;
                OnPropertyChanged("RootFolderPath_field");
            }
        }
        private bool _isRootFolderExist;
        public bool IsRootFolderExist
        {
            get { return _isRootFolderExist; }
            set
            {
                _isRootFolderExist = value;

                OnPropertyChanged("IsRootFolderExist");
            }
        }

        private string _missingFiles_field;
        public string MissingFiles_field
        {
            get { return _missingFiles_field; }
            set
            {
                _missingFiles_field = value;
                OnPropertyChanged("MissingFiles_field");
            }
        }
        private string _TUJ_Name_field;
        public string TUJ_Name_field
        {
            get { return _TUJ_Name_field; }
            set
            {
                _TUJ_Name_field = value;
                OnPropertyChanged("TUJ_Name_field");
            }
        }
        private string _TUJ_label_field;
        public string TUJ_label_field
        {
            get { return _TUJ_label_field; }
            set
            {
                _TUJ_label_field = value;
                OnPropertyChanged("TUJ_label_field");
            }
        }
        private float _unk1_field;
        public float Unk1_field
        {
            get { return _unk1_field; }
            set
            {
                _unk1_field = value;
                OnPropertyChanged("Unk1_field");
            }
        }
        private float _unk2_field;
        public float Unk2_field
        {
            get { return _unk2_field; }
            set
            {
                _unk2_field = value;
                OnPropertyChanged("Unk2_field");
            }
        }
        private int _memberCount_field;
        public int MemberCount_field
        {
            get { return _memberCount_field; }
            set
            {
                _memberCount_field = value;
                OnPropertyChanged("MemberCount_field");
            }
        }
        private bool _condition1_field;
        public bool Condition1_field
        {
            get { return _condition1_field; }
            set
            {
                _condition1_field = value;
                OnPropertyChanged("Condition1_field");
            }
        }
        private bool _condition2_field;
        public bool Condition2_field
        {
            get { return _condition2_field; }
            set
            {
                _condition2_field = value;
                OnPropertyChanged("Condition2_field");
            }
        }

        private ObservableCollection<int> _characodeIDList;
        public ObservableCollection<int> CharacodeIDList
        {
            get { return _characodeIDList; }
            set
            {
                _characodeIDList = value;
                OnPropertyChanged("CharacodeIDList");
            }
        }
        private int _selectedCharacodeIDIndex;
        public int SelectedCharacodeIDIndex
        {
            get { return _selectedCharacodeIDIndex; }
            set
            {
                _selectedCharacodeIDIndex = value;
                OnPropertyChanged("SelectedCharacodeIDIndex");
            }
        }

        public AddTeamUltimateJutsuViewModel()
        {
            LoadingStatePlay = Visibility.Hidden;
            TUJ_Name_field = "c_union_000";
            TUJ_label_field = "1plr2plr";
            Condition1_field = true;
            Condition2_field = false;
            Unk1_field = 30;
            Unk2_field = 30;
            MemberCount_field = 2;
            MissingFiles_field = "";
            ImportCharacterList = new ObservableCollection<CharacodeEditorModel>();
            CharacodeIDList = new ObservableCollection<int>();
            IsRootFolderExist = false;
        }

        public void SelectRootFolder()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                RootFolderPath_field = dialog.FileName;
            else
            {
                return;
            }
        }
        public void RefreshRootFolder()
        {
            if (RootFolderPath_field != null)
            {
                MissingFiles_field = "";
                if (File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin")) &&
                    File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin")) &&
                    File.Exists(Path.Combine(RootFolderPath_field, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin"))
                    )
                    IsRootFolderExist = Directory.Exists(RootFolderPath_field);

                if (!File.Exists(Path.Combine(RootFolderPath_field, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin")))
                {
                    ModernWpf.MessageBox.Show(Path.Combine(RootFolderPath_field, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin") + " doesn't exist. Install new version of ModdingAPI before using this tool.");
                    return;
                }
                string characodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", "characode.bin.xfbin");
                if (File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "characode.bin.xfbin")))
                {
                    characodePath = Path.Combine(RootFolderPath_field, "data_win32", "spc", "characode.bin.xfbin");
                }
                CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                charEditor.OpenFile(characodePath);
                ImportCharacterList = charEditor.CharacodeList;

                if (!IsRootFolderExist)
                {
                    MessageBoxResult result = (MessageBoxResult)ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_12"], "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {

                        IsRootFolderExist = Directory.Exists(RootFolderPath_field);
                        if (IsRootFolderExist)
                        {

                            if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc")))
                                Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "spc"));
                            if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound")))
                                Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "sound"));


                            if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin")))
                                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", "pairSpSkillCombinationParam.xfbin"), Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin"));

                            if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin")))
                                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", "cmnparam.xfbin"), Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin"));
                        } else
                        {
                            ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_11"]);
                        }
                    } else
                    {
                        MissingFiles_field = "Missing files:\n\n";
                        if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin")))
                            MissingFiles_field += Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin") + "\n";
                        if (!File.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin")))
                            MissingFiles_field += Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin") + "\n";
                    }
                }
            } else
                IsRootFolderExist = false;
        }

        List<int> SkipEntriesList = new List<int> { 55, 56, 58 };

        public void AddTeamUltimateJutsu()
        {
            try
            {
                if (CharacodeIDList.Count > 0 &&
                    !string.IsNullOrEmpty(TUJ_label_field) &&
                    !string.IsNullOrEmpty(TUJ_Name_field))
                {
                    string pairCombineParamPath = Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin");
                    string cmnparamPath = Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin");
                    string pairManagerParamPath = Path.Combine(RootFolderPath_field, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin");

                    PairSpSkillCombinationParamViewModel pairSpSkillCombinationExport = new PairSpSkillCombinationParamViewModel();
                    cmnparamViewModel cmnparamExport = new cmnparamViewModel();


                    pairSpSkillCombinationExport.OpenFile(pairCombineParamPath);
                    cmnparamExport.OpenFile(cmnparamPath);
                    byte[] pairManagerParamExport = File.ReadAllBytes(pairManagerParamPath);

                    // ---------------------------------------- Pair Sp Skill Manager Param ---------------------------------------------------------------

                    // Read all bytes from the file.
                    int entryLength = 0x18; // Each entry is 24 bytes.
                    bool exists = false;

                    // Check if any entry already has TUJ_label_field as its name.
                    int entryCount = pairManagerParamExport.Length / entryLength;
                    for (int i = 0; i < entryCount; i++)
                    {
                        int offset = i * entryLength;
                        byte[] nameBytes = new byte[0x10]; // 16 bytes for the name.
                        Array.Copy(pairManagerParamExport, offset, nameBytes, 0, 0x10);

                        // Convert the 16-byte string (assumed ASCII) and trim null terminators.
                        string entryName = Encoding.ASCII.GetString(nameBytes).TrimEnd('\0');

                        if (entryName.Equals(TUJ_label_field, StringComparison.Ordinal))
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (exists)
                    {
                        ModernWpf.MessageBox.Show(TUJ_label_field + " entry already exist in file. Change label for TUJ.");
                        return; // Entry already exists.
                    }

                    byte[] newPairManagerEntry = new byte[entryLength];
                    // Calculate the number of entries already in the export.
                    int pairManagerCount = pairManagerParamExport.Length / entryLength;

                    // Add placeholder entries only if the current count is in SkipEntriesList.
                    while (SkipEntriesList.Contains(pairManagerCount))
                    {
                        newPairManagerEntry = new byte[entryLength];
                        // Replace name with "placeholder"
                        newPairManagerEntry = BinaryReader.b_ReplaceString(newPairManagerEntry, "placeholder", 0x00);
                        // Replace Unlock Value with -1
                        newPairManagerEntry = BinaryReader.b_ReplaceBytes(newPairManagerEntry, BitConverter.GetBytes(-1), 0x10);
                        // Append the placeholder entry
                        pairManagerParamExport = BinaryReader.b_AddBytes(pairManagerParamExport, newPairManagerEntry);

                        // Update the count after appending the entry.
                        pairManagerCount = pairManagerParamExport.Length / entryLength;
                    }

                    // Now add the new entry with TUJ_label_field as its name.
                    {
                        newPairManagerEntry = new byte[entryLength];
                        newPairManagerEntry = BinaryReader.b_ReplaceString(newPairManagerEntry, TUJ_label_field, 0x00);
                        newPairManagerEntry = BinaryReader.b_ReplaceBytes(newPairManagerEntry, BitConverter.GetBytes(-1), 0x10);
                        pairManagerParamExport = BinaryReader.b_AddBytes(pairManagerParamExport, newPairManagerEntry);
                    }


                    // ---------------------------------------- Pair Sp Skill Combination Param ---------------------------------------------------------------

                    int entryPairComb = pairSpSkillCombinationExport.pairSpSkillList.Count;
                    PairSpSkillCombinationParamModel pairSpSkillCombEntry = new PairSpSkillCombinationParamModel();
                    while (SkipEntriesList.Contains(entryPairComb))
                    {
                        pairSpSkillCombEntry.TUJ_ID = entryPairComb;
                        pairSpSkillCombEntry.CharacodeList = new ObservableCollection<int> { 0 };
                        pairSpSkillCombEntry.Unk1 = 30;
                        pairSpSkillCombEntry.Unk2 = 30;
                        pairSpSkillCombEntry.TUJ_Name = "c_union_000";
                        pairSpSkillCombEntry.Condition1 = true;
                        pairSpSkillCombEntry.Condition2 = false;
                        pairSpSkillCombinationExport.pairSpSkillList.Add(pairSpSkillCombEntry);
                        entryPairComb = pairSpSkillCombinationExport.pairSpSkillList.Count; 
                        pairSpSkillCombEntry = new PairSpSkillCombinationParamModel();

                    }
                    {
                        pairSpSkillCombEntry.TUJ_ID = entryPairComb;
                        pairSpSkillCombEntry.CharacodeList = new ObservableCollection<int>(CharacodeIDList);
                        pairSpSkillCombEntry.Unk1 = 30;
                        pairSpSkillCombEntry.Unk2 = 30;
                        pairSpSkillCombEntry.TUJ_Name = TUJ_Name_field;
                        pairSpSkillCombEntry.MemberCount = MemberCount_field;
                        pairSpSkillCombEntry.Condition1 = Condition1_field;
                        pairSpSkillCombEntry.Condition2 = Condition2_field;
                        pairSpSkillCombinationExport.pairSpSkillList.Add(pairSpSkillCombEntry);
                    }
                    

                    //---------------------------------- Cmn Param ---------------------------------------------------------------------------------------------

                    int entrycmnParam = cmnparamExport.PairSplList.Count;
                    pair_spl_sndModel tuj_cmnparam_entry = new pair_spl_sndModel();
                    while (SkipEntriesList.Contains(entrycmnParam))
                    {
                        tuj_cmnparam_entry.PairSplID = entrycmnParam;
                        tuj_cmnparam_entry.PairSplName1 = "placeholder";
                        cmnparamExport.PairSplList.Add(tuj_cmnparam_entry);
                        tuj_cmnparam_entry = new pair_spl_sndModel();
                        entrycmnParam = cmnparamExport.PairSplList.Count;

                    }
                    {
                        tuj_cmnparam_entry.PairSplID = entrycmnParam;
                        tuj_cmnparam_entry.PairSplName1 = "pair_spl_" + TUJ_label_field + "_spl1";
                        tuj_cmnparam_entry.PairSplName2 = "pair_spl_" + TUJ_label_field + "_spl1";
                        tuj_cmnparam_entry.PairSoundEvFileName = "pair_spl_" + TUJ_label_field + "_ev";
                        tuj_cmnparam_entry.PairCutInChunkName = TUJ_label_field + "_spl1_cut_snd";
                        tuj_cmnparam_entry.PairAtkChunkName = TUJ_label_field + "_spl1_atk_snd";
                        cmnparamExport.PairSplList.Add(tuj_cmnparam_entry);
                    }
                    

                    //----------------------------- SAVE FILES -------------------------------------------------------------------------------------------------------
                    pairSpSkillCombinationExport.SaveFileAs(pairCombineParamPath);
                    cmnparamExport.SaveFileAs(cmnparamPath);
                    File.WriteAllBytes(pairManagerParamPath, pairManagerParamExport);

                    //-----------------------------Clean entries------------------------------------------------------------------------------------------------------
                    TUJ_Name_field = "c_union_000";
                    TUJ_label_field = "1plr2plr";
                    Condition1_field = true;
                    Condition2_field = false;
                    Unk1_field = 30;
                    Unk2_field = 30;
                    MemberCount_field = 2;
                    CharacodeIDList.Clear();


                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
            }
        }

        public void RemoveCharacodeEntry()
        {
            if (SelectedCharacodeIDIndex != -1)
            {
                CharacodeIDList.RemoveAt(SelectedCharacodeIDIndex);
            } else
            {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_2"]);
            }
        }


        public void AddCharacodeEntry()
        {
            if (CharacodeIDList.Contains(ImportCharacterItem.CharacodeIndex))
            {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_15"]);
                return;
            }
            if (CharacodeIDList.Count < 20)
            {
                CharacodeIDList.Add(ImportCharacterItem.CharacodeIndex);
                SelectedCharacodeIDIndex = CharacodeIDList.Count - 1;
                CollectionViewSource.GetDefaultView(CharacodeIDList).MoveCurrentTo(CharacodeIDList[SelectedCharacodeIDIndex]);
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_2"]);
            } else
            {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_16"]);
            }
        }
        private RelayCommand _selectRootFolderCommand;
        public RelayCommand SelectRootFolderCommand
        {
            get
            {
                return _selectRootFolderCommand ??
                  (_selectRootFolderCommand = new RelayCommand(obj => {
                      SelectRootFolder();
                  }));
            }
        }
        private RelayCommand _refreshRootFolderCommand;
        public RelayCommand RefreshRootFolderCommand
        {
            get
            {
                return _refreshRootFolderCommand ??
                  (_refreshRootFolderCommand = new RelayCommand(obj => {
                      RefreshRootFolder();
                  }));
            }
        }
        private RelayCommand _addTUJCommand;
        public RelayCommand AddTUJCommand
        {
            get
            {
                return _addTUJCommand ??
                  (_addTUJCommand = new RelayCommand(obj => {
                      AddTeamUltimateJutsu();
                  }));
            }
        }

        private RelayCommand _deleteCharacodeEntryCommand;
        public RelayCommand DeleteCharacodeEntryCommand
        {
            get
            {
                return _deleteCharacodeEntryCommand ??
                  (_deleteCharacodeEntryCommand = new RelayCommand(obj => {
                      RemoveCharacodeEntry();
                  }));
            }
        }

        private RelayCommand _addCharacodeEntryCommand;
        public RelayCommand AddCharacodeEntryCommand
        {
            get
            {
                return _addCharacodeEntryCommand ??
                  (_addCharacodeEntryCommand = new RelayCommand(obj => {
                      AddCharacodeEntry();
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
