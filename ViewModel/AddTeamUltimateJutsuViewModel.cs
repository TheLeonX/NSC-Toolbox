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

        // Game selector: 0 = StormConnections (NSC), 1 = Storm4 (NS4)
        private int _selectedGameIndex = 0;
        public int SelectedGameIndex
        {
            get => _selectedGameIndex;
            set
            {
                _selectedGameIndex = value;
                OnPropertyChanged(nameof(SelectedGameIndex));
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

                    bool isStorm4 = SelectedGameIndex == 1;

                    // compute paths depending on game
                    string pairCombinePath = isStorm4
                        ? Path.Combine(value, "data_win32", "spc", "WIN64", "pairSpSkillCombinationParam.xfbin")
                        : Path.Combine(value, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin");

                    string cmnparamPath = Path.Combine(value, "data_win32", "sound", "cmnparam.xfbin");

                    // prefer param path under moddingapi\param\NS4 or NSC; fallback to old location moddingapi\mods\base_game
                    string pairManagerParamPath = isStorm4
                        ? Path.Combine(value, "moddingapi", "param", "NS4", "pairSpSkillManagerParam.xfbin")
                        : Path.Combine(value, "moddingapi", "param", "NSC", "pairSpSkillManagerParam.xfbin");

                    string pairManagerFallback = Path.Combine(value, "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin");

                    // check existence
                    bool pairCombineExists = File.Exists(pairCombinePath);
                    bool cmnExists = File.Exists(cmnparamPath);
                    bool pairManagerExists = File.Exists(pairManagerParamPath) || File.Exists(pairManagerFallback);

                    if (pairCombineExists && cmnExists && pairManagerExists)
                        IsRootFolderExist = Directory.Exists(value);
                    else
                        IsRootFolderExist = false;

                    // ensure pairManager exists message: prefer param path, if neither exists show message
                    if (!File.Exists(pairManagerParamPath) && !File.Exists(pairManagerFallback))
                    {
                        ModernWpf.MessageBox.Show(pairManagerParamPath + " or " + pairManagerFallback + " doesn't exist. Install new version of ModdingAPI before using this tool.");
                        return;
                    }

                    // characode path: prefer data_win32\spc\WIN64\... for S4
                    string characodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", SelectedGameIndex == 1 ? "NS4" : "NSC", "characode.bin.xfbin");
                    string dataCharacode = Path.Combine(RootFolderPath_field ?? string.Empty, "data_win32", "spc", "characode.bin.xfbin");

                    if (File.Exists(dataCharacode))
                        characodePath = dataCharacode;

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
                                // create folders and copy defaults from ParamFiles/{NSC|NS4}
                                if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "WIN64")))
                                    Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "spc", "WIN64"));
                                if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound")))
                                    Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "sound"));

                                // choose source folder
                                string paramFilesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", SelectedGameIndex == 1 ? "NS4" : "NSC");

                                // copy pair combine
                                string srcPairCombine = Path.Combine(paramFilesFolder, "pairSpSkillCombinationParam.xfbin");
                                string dstPairCombine = pairCombinePath;
                                if (!File.Exists(dstPairCombine) && File.Exists(srcPairCombine))
                                    File.Copy(srcPairCombine, dstPairCombine);

                                // copy cmnparam
                                string srcCmn = Path.Combine(paramFilesFolder, "cmnparam.xfbin");
                                string dstCmn = cmnparamPath;
                                if (!File.Exists(dstCmn) && File.Exists(srcCmn))
                                    File.Copy(srcCmn, dstCmn);

                                // copy pair manager (try param location then fallback)
                                string srcPairManager = Path.Combine(paramFilesFolder, "pairSpSkillManagerParam.xfbin");
                                if (!File.Exists(pairManagerParamPath) && File.Exists(srcPairManager))
                                {
                                    Directory.CreateDirectory(Path.GetDirectoryName(pairManagerParamPath) ?? Path.Combine(value, "moddingapi", "param", SelectedGameIndex == 1 ? "NS4" : "NSC"));
                                    File.Copy(srcPairManager, pairManagerParamPath);
                                }
                            } else
                            {
                                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_11"]);
                            }
                        } else
                        {
                            MissingFiles_field = "Missing files:\n\n";
                            if (!File.Exists(pairCombinePath))
                                MissingFiles_field += pairCombinePath + "\n";
                            if (!File.Exists(cmnparamPath))
                                MissingFiles_field += cmnparamPath + "\n";
                            if (!File.Exists(pairManagerParamPath) && !File.Exists(pairManagerFallback))
                                MissingFiles_field += pairManagerParamPath + "\n";
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

                bool isStorm4 = SelectedGameIndex == 1;

                string pairCombinePath = isStorm4
                    ? Path.Combine(RootFolderPath_field, "data_win32", "spc", "WIN64", "pairSpSkillCombinationParam.xfbin")
                    : Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin");

                string cmnparamPath = Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin");

                string pairManagerParamPath = isStorm4
                    ? Path.Combine(RootFolderPath_field, "moddingapi", "param", "NS4", "pairSpSkillManagerParam.xfbin")
                    : Path.Combine(RootFolderPath_field, "moddingapi", "param", "NSC", "pairSpSkillManagerParam.xfbin");


                bool pairCombineExists = File.Exists(pairCombinePath);
                bool cmnExists = File.Exists(cmnparamPath);
                bool pairManagerExists = File.Exists(pairManagerParamPath);

                if (pairCombineExists && cmnExists && pairManagerExists)
                    IsRootFolderExist = Directory.Exists(RootFolderPath_field);
                else
                    IsRootFolderExist = false;

                string characodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", SelectedGameIndex == 1 ? "NS4" : "NSC", "characode.bin.xfbin");
                string dataCharacode = Path.Combine(RootFolderPath_field ?? string.Empty, "data_win32", "spc", "characode.bin.xfbin");

                if (File.Exists(dataCharacode))
                    characodePath = dataCharacode;

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
                            if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "spc", "WIN64")))
                                Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "spc", "WIN64"));
                            if (!Directory.Exists(Path.Combine(RootFolderPath_field, "data_win32", "sound")))
                                Directory.CreateDirectory(Path.Combine(RootFolderPath_field, "data_win32", "sound"));

                            string paramFilesFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString(), "ParamFiles", SelectedGameIndex == 1 ? "NS4" : "NSC");

                            string srcPairCombine = Path.Combine(paramFilesFolder, "pairSpSkillCombinationParam.xfbin");
                            string dstPairCombine = pairCombinePath;
                            if (!File.Exists(dstPairCombine) && File.Exists(srcPairCombine))
                                File.Copy(srcPairCombine, dstPairCombine);

                            string srcCmn = Path.Combine(paramFilesFolder, "cmnparam.xfbin");
                            string dstCmn = cmnparamPath;
                            if (!File.Exists(dstCmn) && File.Exists(srcCmn))
                                File.Copy(srcCmn, dstCmn);

                            string srcPairManager = Path.Combine(paramFilesFolder, "pairSpSkillManagerParam.xfbin");
                            if (!File.Exists(pairManagerParamPath) && File.Exists(srcPairManager))
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(pairManagerParamPath) ?? Path.Combine(RootFolderPath_field, "moddingapi", "param", SelectedGameIndex == 1 ? "NS4" : "NSC"));
                                File.Copy(srcPairManager, pairManagerParamPath);
                            }
                        } else
                        {
                            ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_11"]);
                        }
                    } else
                    {
                        MissingFiles_field = "Missing files:\n\n";
                        if (!File.Exists(pairCombinePath))
                            MissingFiles_field += pairCombinePath + "\n";
                        if (!File.Exists(cmnparamPath))
                            MissingFiles_field += cmnparamPath + "\n";
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
                    bool isStorm4 = SelectedGameIndex == 1;

                    string pairCombineParamPath = isStorm4
                        ? Path.Combine(RootFolderPath_field, "data_win32", "spc", "WIN64", "pairSpSkillCombinationParam.xfbin")
                        : Path.Combine(RootFolderPath_field, "data_win32", "spc", "pairSpSkillCombinationParam.xfbin");

                    string cmnparamPath = Path.Combine(RootFolderPath_field, "data_win32", "sound", "cmnparam.xfbin");

                    string pairManagerParamPath = isStorm4
                        ? Path.Combine(RootFolderPath_field, "moddingapi", "param", "NS4", "pairSpSkillManagerParam.xfbin")
                        : Path.Combine(RootFolderPath_field, "moddingapi", "param", "NSC", "pairSpSkillManagerParam.xfbin");

                    PairSpSkillCombinationParamViewModel pairSpSkillCombinationExport = new PairSpSkillCombinationParamViewModel();
                    cmnparamViewModel cmnparamExport = new cmnparamViewModel();

                    pairSpSkillCombinationExport.OpenFile(pairCombineParamPath);
                    cmnparamExport.OpenFile(cmnparamPath);
                    byte[] pairManagerParamExport = File.ReadAllBytes(pairManagerParamPath);

                    // ---------------------------------------- Pair Sp Skill Manager Param ---------------------------------------------------------------

                    int entryLength = 0x18; // Each entry is 24 bytes.
                    bool exists = false;

                    int entryCount = pairManagerParamExport.Length / entryLength;
                    for (int i = 0; i < entryCount; i++)
                    {
                        int offset = i * entryLength;
                        byte[] nameBytes = new byte[0x10]; // 16 bytes for the name.
                        Array.Copy(pairManagerParamExport, offset, nameBytes, 0, 0x10);

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
                        return;
                    }

                    byte[] newPairManagerEntry = new byte[entryLength];
                    int pairManagerCount = pairManagerParamExport.Length / entryLength;

                    while (SkipEntriesList.Contains(pairManagerCount))
                    {
                        newPairManagerEntry = new byte[entryLength];
                        newPairManagerEntry = BinaryReader.b_ReplaceString(newPairManagerEntry, "placeholder", 0x00);
                        newPairManagerEntry = BinaryReader.b_ReplaceBytes(newPairManagerEntry, BitConverter.GetBytes(-1), 0x10);
                        pairManagerParamExport = BinaryReader.b_AddBytes(pairManagerParamExport, newPairManagerEntry);
                        pairManagerCount = pairManagerParamExport.Length / entryLength;
                    }

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
