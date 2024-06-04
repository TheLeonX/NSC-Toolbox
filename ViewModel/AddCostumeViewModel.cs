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

namespace NSC_Toolbox.ViewModel {
    public class AddCostumeViewModel : INotifyPropertyChanged {
        private Visibility _loadingStatePlay;
        public Visibility LoadingStatePlay {
            get { return _loadingStatePlay; }
            set {
                _loadingStatePlay = value;
                OnPropertyChanged("LoadingStatePlay");
            }
        }
        private ObservableCollection<CharacodeEditorModel> _importCharacterList;
        public ObservableCollection<CharacodeEditorModel> ImportCharacterList {
            get { return _importCharacterList; }
            set {
                _importCharacterList = value;
                OnPropertyChanged("ImportCharacterList");
            }
        }
        private CharacodeEditorModel _importCharacterItem;
        public CharacodeEditorModel ImportCharacterItem {
            get { return _importCharacterItem; }
            set {
                _importCharacterItem = value;

                DuelPlayerParamEditorViewModel duelPlayerParamEditor = new DuelPlayerParamEditorViewModel();
                PlayerIconViewModel playerIconEditor = new PlayerIconViewModel();
                PlayerSettingParamViewModel playerSettingParamEditor = new PlayerSettingParamViewModel();
                CostumeBreakParamViewModel costumeBreakParamEditor = new CostumeBreakParamViewModel();

                duelPlayerParamEditor.OpenFile(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin");
                playerSettingParamEditor.OpenFile(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin");
                playerIconEditor.OpenFile(DataWin32Path_field + "\\spc\\player_icon.xfbin");
                costumeBreakParamEditor.OpenFile(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin");


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



                OnPropertyChanged("ImportCharacterItem");
            }
        }

        private string _datawin32_field;
        public string DataWin32Path_field {
            get { return _datawin32_field; }
            set {
                _datawin32_field = value;
                if (value != null) {
                    MissingFiles_field = "";
                    if (File.Exists(value + "\\spc\\playerSettingParam.bin.xfbin") &&
                        File.Exists(value + "\\spc\\player_icon.xfbin") &&
                        File.Exists(value + "\\spc\\duelPlayerParam.xfbin") &&
                        File.Exists(value + "\\spc\\costumeBreakColorParam.xfbin") &&
                        File.Exists(value + "\\spc\\costumeBreakParam.xfbin") &&
                        File.Exists(value + "\\rpg\\param\\costumeParam.bin.xfbin") &&
                        File.Exists(value + "\\ui\\max\\select\\characterSelectParam.xfbin")
                        )
                        IsDataWin32Exist = Directory.Exists(value);
                    if (IsDataWin32Exist) {
                        string characodePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin";
                        if (File.Exists(DataWin32Path_field + "\\spc\\characode.bin.xfbin")) {
                            characodePath = DataWin32Path_field + "\\spc\\characode.bin.xfbin";
                        }
                        CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                        charEditor.OpenFile(characodePath);
                        ImportCharacterList = charEditor.CharacodeList;
                    } else {
                        MessageBoxResult result = (MessageBoxResult)ModernWpf.MessageBox.Show("Some files doesn't exist! Do you want to add missing files in directory?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes) {

                            IsDataWin32Exist = Directory.Exists(DataWin32Path_field);
                            if (IsDataWin32Exist) {

                                if (!Directory.Exists(DataWin32Path_field + "\\spc\\"))
                                    Directory.CreateDirectory(DataWin32Path_field + "\\rpg\\param\\");
                                if (!Directory.Exists(DataWin32Path_field + "\\rpg\\param\\"))
                                    Directory.CreateDirectory(DataWin32Path_field + "\\rpg\\param\\");
                                if (!Directory.Exists(DataWin32Path_field + "\\ui\\max\\select\\"))
                                    Directory.CreateDirectory(DataWin32Path_field + "\\ui\\max\\select\\");

                                if (!File.Exists(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin"))
                                    File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\playerSettingParam.bin.xfbin", DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin");
                                if (!File.Exists(DataWin32Path_field + "\\spc\\player_icon.xfbin"))
                                    File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\player_icon.xfbin", DataWin32Path_field + "\\spc\\player_icon.xfbin");
                                if (!File.Exists(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin"))
                                    File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\duelPlayerParam.xfbin", DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin");
                                if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin"))
                                    File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeBreakColorParam.xfbin", DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin");
                                if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin"))
                                    File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeBreakParam.xfbin", DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin");
                                if (!File.Exists(DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin"))
                                    File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeParam.bin.xfbin", DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin");
                                if (!File.Exists(DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin"))
                                    File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characterSelectParam.xfbin", DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin");


                                string characodePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin";
                                if (File.Exists(DataWin32Path_field + "\\spc\\characode.bin.xfbin")) {
                                    characodePath = DataWin32Path_field + "\\spc\\characode.bin.xfbin";
                                }
                                CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                                charEditor.OpenFile(characodePath);
                                ImportCharacterList = charEditor.CharacodeList;
                            } else {
                                ModernWpf.MessageBox.Show("Directory doesn't exist!");
                            }
                        } else {
                            MissingFiles_field = "Missing files:\n\n";
                            if (!File.Exists(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin"))
                                MissingFiles_field += DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin\n";
                            if (!File.Exists(DataWin32Path_field + "\\spc\\player_icon.xfbin"))
                                MissingFiles_field += DataWin32Path_field + "\\spc\\player_icon.xfbin\n";
                            if (!File.Exists(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin"))
                                MissingFiles_field += DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin\n";
                            if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin"))
                                MissingFiles_field += DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin\n";
                            if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin"))
                                MissingFiles_field += DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin\n";
                            if (!File.Exists(DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin"))
                                MissingFiles_field += DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin\n";
                            if (!File.Exists(DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin"))
                                MissingFiles_field += DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin";
                        }
                    }
                } else
                    IsDataWin32Exist = false;
                OnPropertyChanged("DataWin32Path_field");
            }
        }
        private bool _isDataWin32Exist;
        public bool IsDataWin32Exist {
            get { return _isDataWin32Exist; }
            set {
                _isDataWin32Exist = value;

                OnPropertyChanged("IsDataWin32Exist");
            }
        }
        private string _baseCostumeCode_field;
        public string BaseCostumeCode_field {
            get { return _baseCostumeCode_field; }
            set {
                _baseCostumeCode_field = value;
                OnPropertyChanged("BaseCostumeCode_field");
            }
        }
        private string _missingFiles_field;
        public string MissingFiles_field {
            get { return _missingFiles_field; }
            set {
                _missingFiles_field = value;
                OnPropertyChanged("MissingFiles_field");
            }
        }
        private string _baseCostumeIcon_field;
        public string BaseCostumeIcon_field {
            get { return _baseCostumeIcon_field; }
            set {
                _baseCostumeIcon_field = value;
                OnPropertyChanged("BaseCostumeIcon_field");
            }
        }
        private string _awakeCostumeCode_field;
        public string AwakeCostumeCode_field {
            get { return _awakeCostumeCode_field; }
            set {
                _awakeCostumeCode_field = value;
                OnPropertyChanged("AwakeCostumeCode_field");
            }
        }
        private string _awakeCostumeIcon_field;
        public string AwakeCostumeIcon_field {
            get { return _awakeCostumeIcon_field; }
            set {
                _awakeCostumeIcon_field = value;
                OnPropertyChanged("AwakeCostumeIcon_field");
            }
        }
        private bool _enableArmorBreak_field;
        public bool EnableArmorBreak_field {
            get { return _enableArmorBreak_field; }
            set {
                _enableArmorBreak_field = value;
                OnPropertyChanged("EnableArmorBreak_field");
            }
        }
        private int _altColorCount_field;
        public int AltColorCount_field {
            get { return _altColorCount_field; }
            set {
                _altColorCount_field = value;
                OnPropertyChanged("AltColorCount_field");
            }
        }
        private string _costumeName_field;
        public string CostumeName_field {
            get { return _costumeName_field; }
            set {
                _costumeName_field = value;
                OnPropertyChanged("CostumeName_field");
            }
        }
        private string _costumeDescription_field;
        public string CostumeDescription_field {
            get { return _costumeDescription_field; }
            set {
                _costumeDescription_field = value;
                OnPropertyChanged("CostumeDescription_field");
            }
        }
        public AddCostumeViewModel() {
            LoadingStatePlay = Visibility.Hidden;
            AltColorCount_field = 1;
            CostumeName_field = "practice_normal";
            MissingFiles_field = "";
            ImportCharacterList = new ObservableCollection<CharacodeEditorModel>();
            IsDataWin32Exist = false;

        }

        public void SelectDataWin32() {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                DataWin32Path_field = dialog.FileName;
            else {
                return;
            }
        }
        public void RefreshDataWin32() {
            if (DataWin32Path_field != null) {
                MissingFiles_field = "";
                if (File.Exists(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin") &&
                        File.Exists(DataWin32Path_field + "\\spc\\player_icon.xfbin") &&
                        File.Exists(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin") &&
                        File.Exists(DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin") &&
                        File.Exists(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin") &&
                        File.Exists(DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin") &&
                        File.Exists(DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin")) {

                    IsDataWin32Exist = Directory.Exists(DataWin32Path_field);
                    if (IsDataWin32Exist) {
                        string characodePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin";
                        if (File.Exists(DataWin32Path_field + "\\spc\\characode.bin.xfbin")) {
                            characodePath = DataWin32Path_field + "\\spc\\characode.bin.xfbin";
                        }
                        CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                        charEditor.OpenFile(characodePath);
                        ImportCharacterList = charEditor.CharacodeList;
                    }
                } else {
                    MessageBoxResult result = (MessageBoxResult)ModernWpf.MessageBox.Show("Some files doesn't exist! Do you want to add missing files in directory?", "Confirm", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes) {
                        
                        IsDataWin32Exist = Directory.Exists(DataWin32Path_field);
                        if (IsDataWin32Exist) {

                            if (!Directory.Exists(DataWin32Path_field + "\\spc\\"))
                                Directory.CreateDirectory(DataWin32Path_field + "\\rpg\\param\\");
                            if (!Directory.Exists(DataWin32Path_field + "\\rpg\\param\\"))
                                Directory.CreateDirectory(DataWin32Path_field + "\\rpg\\param\\");
                            if (!Directory.Exists(DataWin32Path_field + "\\ui\\max\\select\\"))
                                Directory.CreateDirectory(DataWin32Path_field + "\\ui\\max\\select\\");

                            if (!File.Exists(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\playerSettingParam.bin.xfbin", DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin");
                            if (!File.Exists(DataWin32Path_field + "\\spc\\player_icon.xfbin"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\player_icon.xfbin", DataWin32Path_field + "\\spc\\player_icon.xfbin");
                            if (!File.Exists(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\duelPlayerParam.xfbin", DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin");
                            if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeBreakColorParam.xfbin", DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin");
                            if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeBreakParam.xfbin", DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin");
                            if (!File.Exists(DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeParam.bin.xfbin", DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin");
                            if (!File.Exists(DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin"))
                                File.Copy(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characterSelectParam.xfbin", DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin");


                            string characodePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin";
                            if (File.Exists(DataWin32Path_field + "\\spc\\characode.bin.xfbin")) {
                                characodePath = DataWin32Path_field + "\\spc\\characode.bin.xfbin";
                            }
                            CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                            charEditor.OpenFile(characodePath);
                            ImportCharacterList = charEditor.CharacodeList;
                        } else {
                            ModernWpf.MessageBox.Show("Directory doesn't exist!");
                        }
                    } else {
                        MissingFiles_field = "Missing files:\n\n";
                        if (!File.Exists(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin"))
                            MissingFiles_field += DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin\n";
                        if (!File.Exists(DataWin32Path_field + "\\spc\\player_icon.xfbin"))
                            MissingFiles_field += DataWin32Path_field + "\\spc\\player_icon.xfbin\n";
                        if (!File.Exists(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin"))
                            MissingFiles_field += DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin\n";
                        if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin"))
                            MissingFiles_field += DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin\n";
                        if (!File.Exists(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin"))
                            MissingFiles_field += DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin\n";
                        if (!File.Exists(DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin"))
                            MissingFiles_field += DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin\n";
                        if (!File.Exists(DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin"))
                            MissingFiles_field += DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin";
                    }
                    
                    
                }
            } else
                IsDataWin32Exist = false;
        }

        public void AddCostume() {
            try {

                if (ImportCharacterItem is not null) {
                    if ((BaseCostumeCode_field ?? "") != "" &&
                        (BaseCostumeIcon_field ?? "") != "") {

                        DuelPlayerParamEditorViewModel duelPlayerParamEditor = new DuelPlayerParamEditorViewModel();
                        PlayerSettingParamViewModel playerSettingParamEditor = new PlayerSettingParamViewModel();
                        PlayerIconViewModel playerIconEditor = new PlayerIconViewModel();
                        CostumeBreakParamViewModel costumeBreakParamEditor = new CostumeBreakParamViewModel();
                        CostumeBreakColorParamViewModel costumeBreakColorParamEditor = new CostumeBreakColorParamViewModel();
                        CostumeParamViewModel costumeParamEditor = new CostumeParamViewModel();
                        CharacterSelectParamViewModel characterSelectParamEditor = new CharacterSelectParamViewModel();

                        duelPlayerParamEditor.OpenFile(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin");
                        playerSettingParamEditor.OpenFile(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin");
                        playerIconEditor.OpenFile(DataWin32Path_field + "\\spc\\player_icon.xfbin");
                        costumeBreakParamEditor.OpenFile(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin");
                        costumeBreakColorParamEditor.OpenFile(DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin");
                        costumeParamEditor.OpenFile(DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin");
                        characterSelectParamEditor.OpenFile(DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin");


                        string characode_name = ImportCharacterItem.CharacodeName;
                        int characode_id = ImportCharacterItem.CharacodeIndex;

                        DuelPlayerParamModel dpp_entry = duelPlayerParamEditor.FindItemWithCharacode(characode_name);
                        int costume_dpp_index = duelPlayerParamEditor.FindFreeCostumeSlot(dpp_entry);
                        dpp_entry.BaseCostumes[costume_dpp_index].CostumeName = BaseCostumeCode_field ?? "";
                        dpp_entry.AwakeCostumes[costume_dpp_index].CostumeName = AwakeCostumeCode_field ?? "";

                        PlayerSettingParamModel psp_entry = playerSettingParamEditor.FindItemWithCharacodeID(characode_id);
                        string main_psp_code = psp_entry.PSP_code;

                        psp_entry.PSP_code = characode_name + "_" + costume_dpp_index.ToString("D2");
                        psp_entry.MainPSP_ID = psp_entry.PSP_ID;
                        psp_entry.PSP_ID = playerSettingParamEditor.GetFreeSlot();
                        //psp_entry.CharacterNameMessageID = CostumeNameCSP_field ?? "";
                        //psp_entry.CostumeDescriptionMessageID = CostumeNameCollection_field ?? "";
                        psp_entry.CostumeID = costume_dpp_index;
                        psp_entry.Unk1 = costume_dpp_index;
                        playerSettingParamEditor.PlayerSettingParamList.Add(psp_entry);

                        PlayerIconModel playerIconEntry = playerIconEditor.FindItemWithCharacodeID(characode_id);
                        playerIconEntry.BaseIcon = BaseCostumeIcon_field ?? "";
                        playerIconEntry.AwakeIcon = AwakeCostumeIcon_field ?? "";
                        playerIconEntry.CostumeID = costume_dpp_index;
                        playerIconEditor.playerIconList.Add(playerIconEntry);


                        if (EnableArmorBreak_field) {
                            CostumeBreakParamModel costumeBreakParamEntry = costumeBreakParamEditor.FindItemWithCharacodeID(characode_id);
                            costumeBreakParamEntry.CharacodeID = characode_id;
                            costumeBreakParamEntry.CostumeID = costume_dpp_index;
                            costumeBreakParamEditor.CostumeBreakParamList.Add(costumeBreakParamEntry);
                        }
                        CostumeBreakColorParamModel costumeBreakColorParamEntry = new CostumeBreakColorParamModel();
                        costumeBreakColorParamEntry.PlayerSettingParamID = psp_entry.PSP_ID;
                        costumeBreakColorParamEntry.AltColor1 = Color.FromArgb(0, 0, 0, 0);
                        costumeBreakColorParamEntry.AltColor2 = Color.FromArgb(0, 0, 0, 0);
                        costumeBreakColorParamEntry.AltColor3 = Color.FromArgb(0, 0, 0, 0);
                        costumeBreakColorParamEntry.AltColor4 = Color.FromArgb(0, 0, 0, 0);
                        costumeBreakColorParamEditor.CostumeBreakColorParamList.Add(costumeBreakColorParamEntry);


                        for (int i = 0; i< AltColorCount_field; i++) {

                            CostumeParamModel costumeParamEntry = new CostumeParamModel();
                            costumeParamEntry.EntryIndex = 0;
                            costumeParamEntry.PlayerSettingParamID = psp_entry.PSP_ID;
                            costumeParamEntry.EntryType = i;
                            costumeParamEntry.EntryString = costumeParamEditor.LastCostume();
                            costumeParamEntry.UnlockCondition = 1;
                            costumeParamEntry.UnlockCost = 0;
                            //costumeParamEntry.CharacterName = CostumeNameCollection_field ?? "";
                            costumeParamEditor.CostumeParamList.Add(costumeParamEntry);
                        }
                        CharacterSelectParamModel characterSelectParamEntry = characterSelectParamEditor.FindItem(main_psp_code);
                        characterSelectParamEntry.CSP_code = psp_entry.PSP_code;
                        characterSelectParamEntry.CostumeIndex = characterSelectParamEditor.GetFreeCostumeSlot(main_psp_code);
                        characterSelectParamEntry.CostumeName = CostumeName_field ?? "";
                        characterSelectParamEntry.CostumeDescription = CostumeDescription_field ?? "";
                        characterSelectParamEditor.CharacterSelectParamList.Add(characterSelectParamEntry);
                        characterSelectParamEntry.Unk = costume_dpp_index;


                        duelPlayerParamEditor.SaveFileAs(DataWin32Path_field + "\\spc\\duelPlayerParam.xfbin");
                        playerSettingParamEditor.SaveFileAs(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin");
                        playerIconEditor.SaveFileAs(DataWin32Path_field + "\\spc\\player_icon.xfbin");
                        costumeBreakParamEditor.SaveFileAs(DataWin32Path_field + "\\spc\\costumeBreakParam.xfbin");
                        costumeBreakColorParamEditor.SaveFileAs(DataWin32Path_field + "\\spc\\costumeBreakColorParam.xfbin");
                        costumeParamEditor.SaveFileAs(DataWin32Path_field + "\\rpg\\param\\costumeParam.bin.xfbin");
                        characterSelectParamEditor.SaveFileAs(DataWin32Path_field + "\\ui\\max\\select\\characterSelectParam.xfbin");
                        SystemSounds.Beep.Play();


                    } else {
                        ModernWpf.MessageBox.Show("Write code of costume and code of icon!");
                    }
                } else {
                    ModernWpf.MessageBox.Show("Select character code in dropbox!");
                }


            } catch(Exception ex) {
                MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
            }
        }


        private RelayCommand _selectDataWin32Command;
        public RelayCommand SelectDataWin32Command {
            get {
                return _selectDataWin32Command ??
                  (_selectDataWin32Command = new RelayCommand(obj => {
                      SelectDataWin32();
                  }));
            }
        }
        private RelayCommand _refreshDataWin32Command;
        public RelayCommand RefreshDataWin32Command {
            get {
                return _refreshDataWin32Command ??
                  (_refreshDataWin32Command = new RelayCommand(obj => {
                      RefreshDataWin32();
                  }));
            }
        }
        private RelayCommand _addCostumeCommand;
        public RelayCommand AddCostumeCommand {
            get {
                return _addCostumeCommand ??
                  (_addCostumeCommand = new RelayCommand(obj => {
                      AddCostume();
                  }));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
