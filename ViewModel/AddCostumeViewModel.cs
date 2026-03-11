using DynamicData;
using Microsoft.WindowsAPICodePack.Dialogs;
using NSC_Toolbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static NSC_Toolbox.ViewModel.ExportModViewModel;

namespace NSC_Toolbox.ViewModel
{
    public class AddCostumeViewModel : INotifyPropertyChanged
    {
        public enum Game
        {
            StormConnections = 0,
            Storm4 = 1
        }

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

        private int _selectedGameIndex;
        public int SelectedGameIndex
        {
            get { return _selectedGameIndex; }
            set
            {
                _selectedGameIndex = value;
                // default alt colors per game
                if (_selectedGameIndex == (int)Game.Storm4)
                    AltColorCount_field = 2;
                else
                    AltColorCount_field = Math.Max(1, AltColorCount_field);
                OnPropertyChanged("SelectedGameIndex");
            }
        }

        private ObservableCollection<CharacodeEditorModel> _importCharacterList;
        public ObservableCollection<CharacodeEditorModel> ImportCharacterList
        {
            get { return _importCharacterList; }
            set
            {
                _importCharacterList = value;
                OnPropertyChanged("ImportCharacterList");
            }
        }

        private CharacodeEditorModel _importCharacterItem;
        public CharacodeEditorModel ImportCharacterItem
        {
            get { return _importCharacterItem; }
            set
            {
                bool isStorm4 = SelectedGameIndex == (int)Game.Storm4;
                _importCharacterItem = value;
                if (value is not null && !string.IsNullOrEmpty(DataWin32Path_field) && !isStorm4)
                {
                    // строим пути для текущей игры
                    var dicts = PathBuilder.BuildPathDictionaries(AppDomain.CurrentDomain.BaseDirectory, "mod", DataWin32Path_field, isStorm4);
                    var dataPaths = dicts.dataPaths;

                    // Открываем файлы по словарю
                    DuelPlayerParamEditorViewModel duelPlayerParamEditor = new DuelPlayerParamEditorViewModel();
                    PlayerIconViewModel playerIconEditor = new PlayerIconViewModel();
                    PlayerSettingParamViewModel playerSettingParamEditor = new PlayerSettingParamViewModel();
                    CostumeBreakParamViewModel costumeBreakParamEditor = new CostumeBreakParamViewModel();

                    // Use available keys safely
                    if (dataPaths.TryGetValue("DuelPlayerParam", out string duelPath))
                        duelPlayerParamEditor.OpenFile(duelPath);
                    if (dataPaths.TryGetValue("PlayerSettingParam", out string playerSettingPath))
                        playerSettingParamEditor.OpenFile(playerSettingPath);
                    if (dataPaths.TryGetValue("PlayerIcon", out string playerIconPath))
                        playerIconEditor.OpenFile(playerIconPath);
                    if (dataPaths.TryGetValue("CostumeBreakParam", out string costumeBreakPath))
                        costumeBreakParamEditor.OpenFile(costumeBreakPath);

                    string characode_name = value.CharacodeName;
                    int characode_id = value.CharacodeIndex;

                    DuelPlayerParamModel dpp_entry = duelPlayerParamEditor.FindItemWithCharacode(characode_name);

                    BaseCostumeCode_field = dpp_entry.BaseCostumes[0].CostumeName;
                    AwakeCostumeCode_field = dpp_entry.AwakeCostumes[0].CostumeName;


                    PlayerIconModel playerIconEntry = playerIconEditor.FindItemWithCharacodeID(characode_id);

                    BaseCostumeIcon_field = playerIconEntry.BaseIcon;
                    AwakeCostumeIcon_field = playerIconEntry.AwakeIcon;


                    CostumeBreakParamModel costumeBreakParamEntry = costumeBreakParamEditor.FindItemWithCharacodeID(characode_id);

                    EnableArmorBreak_field = costumeBreakParamEditor.ItemExist(characode_id);

                }else if (value is not null && !string.IsNullOrEmpty(DataWin32Path_field) && SelectedGameIndex == (int)Game.Storm4)
                {
                    // строим пути для текущей игры
                    var dicts = PathBuilder.BuildPathDictionaries(AppDomain.CurrentDomain.BaseDirectory, "mod", DataWin32Path_field, isStorm4);
                    var dataPaths = dicts.dataPaths;

                    // Открываем файлы по словарю
                    DuelPlayerParamEditorViewModel duelPlayerParamEditor = new DuelPlayerParamEditorViewModel();
                    PlayerIconViewModel playerIconEditor = new PlayerIconViewModel();
                    PlayerSettingParamS4ViewModel playerSettingParamEditor = new PlayerSettingParamS4ViewModel();
                    CostumeBreakParamViewModel costumeBreakParamEditor = new CostumeBreakParamViewModel();

                    // Use available keys safely
                    if (dataPaths.TryGetValue("DuelPlayerParam", out string duelPath))
                        duelPlayerParamEditor.OpenFile(duelPath);
                    if (dataPaths.TryGetValue("PlayerSettingParam", out string playerSettingPath))
                        playerSettingParamEditor.OpenFile(playerSettingPath);
                    if (dataPaths.TryGetValue("PlayerIcon", out string playerIconPath))
                        playerIconEditor.OpenFile(playerIconPath);
                    if (dataPaths.TryGetValue("CostumeBreakParam", out string costumeBreakPath))
                        costumeBreakParamEditor.OpenFile(costumeBreakPath);

                    string characode_name = value.CharacodeName;
                    int characode_id = value.CharacodeIndex;

                    DuelPlayerParamModel dpp_entry = duelPlayerParamEditor.FindItemWithCharacode(characode_name);

                    BaseCostumeCode_field = dpp_entry.BaseCostumes[0].CostumeName;
                    AwakeCostumeCode_field = dpp_entry.AwakeCostumes[0].CostumeName;


                    PlayerIconModel playerIconEntry = playerIconEditor.FindItemWithCharacodeID(characode_id);

                    BaseCostumeIcon_field = playerIconEntry.BaseIcon;
                    AwakeCostumeIcon_field = playerIconEntry.AwakeIcon;


                    CostumeBreakParamModel costumeBreakParamEntry = costumeBreakParamEditor.FindItemWithCharacodeID(characode_id);

                    EnableArmorBreak_field = costumeBreakParamEditor.ItemExist(characode_id);

                }
                OnPropertyChanged("ImportCharacterItem");
            }
        }

        private string _datawin32_field;
        public string DataWin32Path_field
        {
            get { return _datawin32_field; }
            set
            {
                _datawin32_field = value;
                if (value != null)
                {
                    MissingFiles_field = "";
                    bool isStorm4 = SelectedGameIndex == (int)Game.Storm4;
                    var dicts = PathBuilder.BuildPathDictionaries(AppDomain.CurrentDomain.BaseDirectory, "mod", value, isStorm4);
                    var dataPaths = dicts.dataPaths;

                    // проверяем наличие ключевых файлов
                    string[] requiredKeys = isStorm4
    ? new[] { "PlayerSettingParam", "PlayerIcon", "DuelPlayerParam", "CostumeBreakColorParam", "CostumeBreakParam", "CharacterSelectParam" }
    : new[] { "PlayerSettingParam", "PlayerIcon", "DuelPlayerParam", "CostumeBreakColorParam", "CostumeBreakParam", "CostumeParam", "CharacterSelectParam" };

                    bool allExist = requiredKeys.All(k => dataPaths.ContainsKey(k) && File.Exists(dataPaths[k]));

                    IsDataWin32Exist = Directory.Exists(value) && allExist;

                    if (IsDataWin32Exist)
                    {
                        string characodePath = dataPaths.ContainsKey("Characode") ? dataPaths["Characode"] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", isStorm4 ? "NS4" : "NSC", "characode.bin.xfbin");
                        CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                        charEditor.OpenFile(characodePath);
                        ImportCharacterList = charEditor.CharacodeList;
                    } else
                    {
                        MessageBoxResult result = (MessageBoxResult)ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_12"], "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            IsDataWin32Exist = Directory.Exists(value);
                            if (IsDataWin32Exist)
                            {
                                // Создаём структуру и копируем дефолтные файлы из ParamFiles\NSC или ParamFiles\NS4
                                EnsureDefaultFiles(dataPaths, isStorm4);
                                // повторно загрузим characode
                                string characodePath = dataPaths.ContainsKey("Characode") ? dataPaths["Characode"] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", isStorm4 ? "NS4" : "NSC", "characode.bin.xfbin");
                                CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                                charEditor.OpenFile(characodePath);
                                ImportCharacterList = charEditor.CharacodeList;
                            } else
                            {
                                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_11"]);
                            }
                        } else
                        {
                            // собираем список отсутствующих файлов для отображения
                            MissingFiles_field = "Missing files:\n\n";
                            foreach (var k in requiredKeys)
                            {
                                if (!dataPaths.ContainsKey(k) || !File.Exists(dataPaths[k]))
                                {
                                    string missing = dataPaths.ContainsKey(k) ? dataPaths[k] : k;
                                    MissingFiles_field += missing + "\n";
                                }
                            }
                        }
                    }
                } else
                    IsDataWin32Exist = false;
                OnPropertyChanged("DataWin32Path_field");
            }
        }

        private bool _isDataWin32Exist;
        public bool IsDataWin32Exist
        {
            get { return _isDataWin32Exist; }
            set
            {
                _isDataWin32Exist = value;
                OnPropertyChanged("IsDataWin32Exist");
            }
        }

        private string _baseCostumeCode_field;
        public string BaseCostumeCode_field
        {
            get { return _baseCostumeCode_field; }
            set
            {
                _baseCostumeCode_field = value;
                OnPropertyChanged("BaseCostumeCode_field");
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
        private string _baseCostumeIcon_field;
        public string BaseCostumeIcon_field
        {
            get { return _baseCostumeIcon_field; }
            set
            {
                _baseCostumeIcon_field = value;
                OnPropertyChanged("BaseCostumeIcon_field");
            }
        }
        private string _awakeCostumeCode_field;
        public string AwakeCostumeCode_field
        {
            get { return _awakeCostumeCode_field; }
            set
            {
                _awakeCostumeCode_field = value;
                OnPropertyChanged("AwakeCostumeCode_field");
            }
        }
        private string _awakeCostumeIcon_field;
        public string AwakeCostumeIcon_field
        {
            get { return _awakeCostumeIcon_field; }
            set
            {
                _awakeCostumeIcon_field = value;
                OnPropertyChanged("AwakeCostumeIcon_field");
            }
        }
        private bool _enableArmorBreak_field;
        public bool EnableArmorBreak_field
        {
            get { return _enableArmorBreak_field; }
            set
            {
                _enableArmorBreak_field = value;
                OnPropertyChanged("EnableArmorBreak_field");
            }
        }
        private int _altColorCount_field;
        public int AltColorCount_field
        {
            get { return _altColorCount_field; }
            set
            {
                _altColorCount_field = value;
                OnPropertyChanged("AltColorCount_field");
            }
        }
        private string _costumeName_field;
        public string CostumeName_field
        {
            get { return _costumeName_field; }
            set
            {
                _costumeName_field = value;
                OnPropertyChanged("CostumeName_field");
            }
        }
        private string _costumeDescription_field;
        public string CostumeDescription_field
        {
            get { return _costumeDescription_field; }
            set
            {
                _costumeDescription_field = value;
                OnPropertyChanged("CostumeDescription_field");
            }
        }

        public AddCostumeViewModel()
        {
            SelectedGameIndex = (int)Game.StormConnections;
            LoadingStatePlay = Visibility.Hidden;
            AltColorCount_field = 1;
            CostumeName_field = "practice_normal";
            MissingFiles_field = "";
            ImportCharacterList = new ObservableCollection<CharacodeEditorModel>();
            IsDataWin32Exist = false;
        }

        public void SelectDataWin32()
        {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                DataWin32Path_field = dialog.FileName;
            else
            {
                return;
            }
        }

        public void RefreshDataWin32()
        {
            if (DataWin32Path_field != null)
            {
                MissingFiles_field = "";
                bool isStorm4 = SelectedGameIndex == (int)Game.Storm4;
                var dicts = PathBuilder.BuildPathDictionaries(AppDomain.CurrentDomain.BaseDirectory, "mod", DataWin32Path_field, isStorm4);
                var dataPaths = dicts.dataPaths;

                string[] requiredKeys = new[] {
                    "PlayerSettingParam", "PlayerIcon", "DuelPlayerParam",
                    "CostumeBreakColorParam", "CostumeBreakParam", "CostumeParam", "CharacterSelectParam"
                };

                bool allExist = requiredKeys.All(k => dataPaths.ContainsKey(k) && File.Exists(dataPaths[k]));

                IsDataWin32Exist = Directory.Exists(DataWin32Path_field) && allExist;

                if (IsDataWin32Exist)
                {
                    string characodePath = dataPaths.ContainsKey("Characode") ? dataPaths["Characode"] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", isStorm4 ? "NS4" : "NSC", "characode.bin.xfbin");
                    CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                    charEditor.OpenFile(characodePath);
                    ImportCharacterList = charEditor.CharacodeList;
                } else
                {
                    MessageBoxResult result = (MessageBoxResult)ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_12"], "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        IsDataWin32Exist = Directory.Exists(DataWin32Path_field);
                        if (IsDataWin32Exist)
                        {
                            EnsureDefaultFiles(dataPaths, isStorm4);
                            string characodePath = dataPaths.ContainsKey("Characode") ? dataPaths["Characode"] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", isStorm4 ? "NS4" : "NSC", "characode.bin.xfbin");
                            CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                            charEditor.OpenFile(characodePath);
                            ImportCharacterList = charEditor.CharacodeList;
                        } else
                        {
                            ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_11"]);
                        }
                    } else
                    {
                        MissingFiles_field = "Missing files:\n\n";
                        foreach (var k in requiredKeys)
                        {
                            if (!dataPaths.ContainsKey(k) || !File.Exists(dataPaths[k]))
                            {
                                string missing = dataPaths.ContainsKey(k) ? dataPaths[k] : k;
                                MissingFiles_field += missing + "\n";
                            }
                        }
                    }
                }
            } else
                IsDataWin32Exist = false;
        }

        private void EnsureDefaultFiles(Dictionary<string, string> dataPaths, bool isStorm4)
        {
            // required keys and their fallback file names in ParamFiles/{NSC|NS4}
            var requiredKeys = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
{
    { "PlayerSettingParam", "playerSettingParam.bin.xfbin" },
    { "PlayerIcon", "player_icon.xfbin" },
    { "DuelPlayerParam", "duelPlayerParam.xfbin" },
    { "CostumeBreakColorParam", "costumeBreakColorParam.xfbin" },
    { "CostumeBreakParam", "costumeBreakParam.xfbin" },
    { "CharacterSelectParam", "characterSelectParam.xfbin" },
    { "Characode", "characode.bin.xfbin" }
};

            // если не S4 — добавим CostumeParam
            if (!isStorm4)
                requiredKeys["CostumeParam"] = "costumeParam.bin.xfbin";

            string gameFolder = isStorm4 ? "NS4" : "NSC";
            string baseParamFiles = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gameFolder);

            foreach (var kv in requiredKeys)
            {
                string targetPath;
                if (dataPaths.TryGetValue(kv.Key, out targetPath))
                {
                    string dir = Path.GetDirectoryName(targetPath) ?? string.Empty;
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);

                    if (!File.Exists(targetPath))
                    {
                        string source = Path.Combine(baseParamFiles, kv.Value);
                        if (File.Exists(source))
                        {
                            try
                            {
                                File.Copy(source, targetPath);
                            } catch
                            {
                                // ignore copy errors here, caller will show missing file list if necessary
                            }
                        }
                    }
                } else
                {
                    // If no dataPaths entry - try to create folder in DataWin32Path_field with expected path
                    string fallback = Path.Combine(DataWin32Path_field ?? string.Empty, kv.Value);
                    string dir = Path.GetDirectoryName(fallback) ?? string.Empty;
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    if (!File.Exists(fallback))
                    {
                        string source = Path.Combine(baseParamFiles, kv.Value);
                        if (File.Exists(source))
                        {
                            try
                            {
                                File.Copy(source, fallback);
                            } catch
                            {
                            }
                        }
                    }
                }
            }
        }

        public void AddCostume()
        {
            try
            {
                if (ImportCharacterItem is null)
                {
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_14"]);
                    return;
                }

                if (string.IsNullOrEmpty(BaseCostumeCode_field) || string.IsNullOrEmpty(BaseCostumeIcon_field))
                {
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_13"]);
                    return;
                }

                bool isStorm4 = SelectedGameIndex == (int)Game.Storm4;
                var dicts = PathBuilder.BuildPathDictionaries(AppDomain.CurrentDomain.BaseDirectory, "mod", DataWin32Path_field, isStorm4);
                var dataPaths = dicts.dataPaths;

                DuelPlayerParamEditorViewModel duelPlayerParamEditor = new DuelPlayerParamEditorViewModel();
                PlayerIconViewModel playerIconEditor = new PlayerIconViewModel();
                CostumeBreakParamViewModel costumeBreakParamEditor = new CostumeBreakParamViewModel();

                PlayerSettingParamViewModel playerSettingParamEditor = new PlayerSettingParamViewModel();
                CharacterSelectParamViewModel characterSelectParamEditor = new CharacterSelectParamViewModel();
                CostumeBreakColorParamViewModel costumeBreakColorParamEditor = new CostumeBreakColorParamViewModel();
                CostumeParamViewModel costumeParamEditor = null;

                PlayerSettingParamS4ViewModel playerSettingParamEditorS4 = null;
                CharacterSelectParamS4ViewModel characterSelectParamEditorS4 = null;
                CostumeBreakColorParamS4ViewModel costumeBreakColorParamEditorS4 = null;

                if (isStorm4)
                {
                    try { playerSettingParamEditorS4 = new PlayerSettingParamS4ViewModel(); } catch { playerSettingParamEditorS4 = null; }
                    try { characterSelectParamEditorS4 = new CharacterSelectParamS4ViewModel(); } catch { characterSelectParamEditorS4 = null; }
                    try { costumeBreakColorParamEditorS4 = new CostumeBreakColorParamS4ViewModel(); } catch { costumeBreakColorParamEditorS4 = null; }
                }

                if (dataPaths.TryGetValue("DuelPlayerParam", out string duelPath)) duelPlayerParamEditor.OpenFile(duelPath);

                if (dataPaths.TryGetValue("PlayerSettingParam", out string pspPath))
                {
                    if (isStorm4 && playerSettingParamEditorS4 is not null) playerSettingParamEditorS4.OpenFile(pspPath);
                    else playerSettingParamEditor.OpenFile(pspPath);
                }

                if (dataPaths.TryGetValue("PlayerIcon", out string iconPath)) playerIconEditor.OpenFile(iconPath);
                if (dataPaths.TryGetValue("CostumeBreakParam", out string cbpPath)) costumeBreakParamEditor.OpenFile(cbpPath);

                if (dataPaths.TryGetValue("CostumeBreakColorParam", out string cbcpPath))
                {
                    if (isStorm4 && costumeBreakColorParamEditorS4 is not null) costumeBreakColorParamEditorS4.OpenFile(cbcpPath);
                    else costumeBreakColorParamEditor.OpenFile(cbcpPath);
                }

                if (!isStorm4 && dataPaths.TryGetValue("CostumeParam", out string costumeParamPath))
                {
                    costumeParamEditor = new CostumeParamViewModel();
                    costumeParamEditor.OpenFile(costumeParamPath);
                }

                if (dataPaths.TryGetValue("CharacterSelectParam", out string cspPath))
                {
                    if (isStorm4 && characterSelectParamEditorS4 is not null) characterSelectParamEditorS4.OpenFile(cspPath);
                    else characterSelectParamEditor.OpenFile(cspPath);
                }

                string characode_name = ImportCharacterItem.CharacodeName;
                int characode_id = ImportCharacterItem.CharacodeIndex;

                DuelPlayerParamModel dpp_entry = duelPlayerParamEditor.FindItemWithCharacode(characode_name);
                int costume_dpp_index = duelPlayerParamEditor.FindFreeCostumeSlot(dpp_entry);
                dpp_entry.BaseCostumes[costume_dpp_index].CostumeName = BaseCostumeCode_field ?? "";
                dpp_entry.AwakeCostumes[costume_dpp_index].CostumeName = AwakeCostumeCode_field ?? "";

                PlayerSettingParamModel psp_entry;
                if (isStorm4 && playerSettingParamEditorS4 is not null)
                    psp_entry = playerSettingParamEditorS4.FindItemWithCharacodeID(characode_id);
                else
                    psp_entry = playerSettingParamEditor.FindItemWithCharacodeID(characode_id);

                string main_psp_code = psp_entry.PSP_code;

                psp_entry.PSP_code = characode_name + "_" + costume_dpp_index.ToString("D2");
                psp_entry.MainPSP_ID = psp_entry.PSP_ID;

                // <- FIX: set CostumeID before assigning new PSP_ID and adding to list
                psp_entry.CostumeID = costume_dpp_index;

                if (isStorm4 && playerSettingParamEditorS4 is not null)
                {
                    psp_entry.PSP_ID = playerSettingParamEditorS4.GetFreeSlot();
                    playerSettingParamEditorS4.PlayerSettingParamList.Add(psp_entry);
                } else
                {
                    psp_entry.PSP_ID = playerSettingParamEditor.GetFreeSlot();
                    playerSettingParamEditor.PlayerSettingParamList.Add(psp_entry);
                }

                PlayerIconModel playerIconEntry = playerIconEditor.FindItemWithCharacodeID(characode_id);
                playerIconEntry.BaseIcon = BaseCostumeIcon_field ?? "";
                playerIconEntry.AwakeIcon = AwakeCostumeIcon_field ?? "";
                playerIconEntry.CostumeID = costume_dpp_index;
                playerIconEditor.playerIconList.Add(playerIconEntry);

                if (EnableArmorBreak_field)
                {
                    CostumeBreakParamModel costumeBreakParamEntry = costumeBreakParamEditor.FindItemWithCharacodeID(characode_id);
                    costumeBreakParamEntry.CharacodeID = characode_id;
                    costumeBreakParamEntry.CostumeID = costume_dpp_index;
                    costumeBreakParamEditor.CostumeBreakParamList.Add(costumeBreakParamEntry);
                }

                CostumeBreakColorParamModel costumeBreakColorParamEntry = new CostumeBreakColorParamModel
                {
                    PlayerSettingParamID = psp_entry.PSP_ID,
                    AltColor1 = Color.FromArgb(0, 0, 0, 0),
                    AltColor2 = Color.FromArgb(0, 0, 0, 0),
                    AltColor3 = Color.FromArgb(0, 0, 0, 0),
                    AltColor4 = Color.FromArgb(0, 0, 0, 0)
                };

                if (isStorm4 && costumeBreakColorParamEditorS4 is not null) costumeBreakColorParamEditorS4.CostumeBreakColorParamList.Add(costumeBreakColorParamEntry);
                else costumeBreakColorParamEditor.CostumeBreakColorParamList.Add(costumeBreakColorParamEntry);

                if (!isStorm4 && costumeParamEditor is not null)
                {
                    for (int i = 0; i < AltColorCount_field; i++)
                    {
                        CostumeParamModel costumeParamEntry = new CostumeParamModel
                        {
                            EntryIndex = 0,
                            PlayerSettingParamID = psp_entry.PSP_ID,
                            EntryType = i,
                            EntryString = costumeParamEditor.LastCostume(),
                            UnlockCondition = 1,
                            UnlockCost = 0
                        };
                        costumeParamEditor.CostumeParamList.Add(costumeParamEntry);
                    }
                }

                if (isStorm4 && characterSelectParamEditorS4 is not null)
                {
                    CharacterSelectParamModel characterSelectParamEntry = characterSelectParamEditorS4.FindItem(main_psp_code);
                    characterSelectParamEntry.CSP_code = psp_entry.PSP_code;
                    characterSelectParamEntry.CostumeIndex = characterSelectParamEditorS4.GetFreeCostumeSlot(main_psp_code);
                    characterSelectParamEntry.CostumeName = CostumeName_field ?? "";
                    characterSelectParamEntry.CostumeDescription = CostumeDescription_field ?? "";
                    characterSelectParamEditorS4.CharacterSelectParamList.Add(characterSelectParamEntry);
                    characterSelectParamEntry.Unk = costume_dpp_index;
                } else
                {
                    CharacterSelectParamModel characterSelectParamEntry = characterSelectParamEditor.FindItem(main_psp_code);
                    characterSelectParamEntry.CSP_code = psp_entry.PSP_code;
                    characterSelectParamEntry.CostumeIndex = characterSelectParamEditor.GetFreeCostumeSlot(main_psp_code);
                    characterSelectParamEntry.CostumeName = CostumeName_field ?? "";
                    characterSelectParamEntry.CostumeDescription = CostumeDescription_field ?? "";
                    characterSelectParamEditor.CharacterSelectParamList.Add(characterSelectParamEntry);
                    characterSelectParamEntry.Unk = costume_dpp_index;
                }

                if (dataPaths.TryGetValue("DuelPlayerParam", out string saveDuel)) duelPlayerParamEditor.SaveFileAs(saveDuel);

                if (dataPaths.TryGetValue("PlayerSettingParam", out string savePsp))
                {
                    if (isStorm4 && playerSettingParamEditorS4 is not null) playerSettingParamEditorS4.SaveFileAs(savePsp);
                    else playerSettingParamEditor.SaveFileAs(savePsp);
                }

                if (dataPaths.TryGetValue("PlayerIcon", out string saveIcon)) playerIconEditor.SaveFileAs(saveIcon);
                if (dataPaths.TryGetValue("CostumeBreakParam", out string saveCbp)) costumeBreakParamEditor.SaveFileAs(saveCbp);

                if (dataPaths.TryGetValue("CostumeBreakColorParam", out string saveCbcp))
                {
                    if (isStorm4 && costumeBreakColorParamEditorS4 is not null) costumeBreakColorParamEditorS4.SaveFileAs(saveCbcp);
                    else costumeBreakColorParamEditor.SaveFileAs(saveCbcp);
                }

                if (!isStorm4 && costumeParamEditor is not null && dataPaths.TryGetValue("CostumeParam", out string saveCostumeParam))
                    costumeParamEditor.SaveFileAs(saveCostumeParam);

                if (dataPaths.TryGetValue("CharacterSelectParam", out string saveCsp))
                {
                    if (isStorm4 && characterSelectParamEditorS4 is not null) characterSelectParamEditorS4.SaveFileAs(saveCsp);
                    else characterSelectParamEditor.SaveFileAs(saveCsp);
                }

                SystemSounds.Beep.Play();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
            }
        }


        private RelayCommand _selectDataWin32Command;
        public RelayCommand SelectDataWin32Command
        {
            get
            {
                return _selectDataWin32Command ??
                  (_selectDataWin32Command = new RelayCommand(obj => {
                      SelectDataWin32();
                  }));
            }
        }
        private RelayCommand _refreshDataWin32Command;
        public RelayCommand RefreshDataWin32Command
        {
            get
            {
                return _refreshDataWin32Command ??
                  (_refreshDataWin32Command = new RelayCommand(obj => {
                      RefreshDataWin32();
                  }));
            }
        }
        private RelayCommand _addCostumeCommand;
        public RelayCommand AddCostumeCommand
        {
            get
            {
                return _addCostumeCommand ??
                  (_addCostumeCommand = new RelayCommand(obj => {
                      AddCostume();
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
