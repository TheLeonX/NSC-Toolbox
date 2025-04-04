﻿using NSC_Toolbox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;
using Microsoft.Win32;
using System.IO;
using NSC_Toolbox.Properties;

namespace NSC_Toolbox.ViewModel
{
    public class DamageEffViewModel : INotifyPropertyChanged {
        private int _searchIndex_field;
        public int SearchIndex_field {
            get { return _searchIndex_field; }
            set {
                _searchIndex_field = value;
                OnPropertyChanged("SearchIndex_field");
            }
        }

        public ObservableCollection<string> Sound1_List { get; set; }
        public ObservableCollection<string> Sound2_List { get; set; }
        private Visibility _loadingStatePlay;
        public Visibility LoadingStatePlay {
            get { return _loadingStatePlay; }
            set {
                _loadingStatePlay = value;
                OnPropertyChanged("LoadingStatePlay");
            }
        }

        private int _damageEffID;
        public int DamageEffID_field {
            get { return _damageEffID; }
            set {
                _damageEffID = value;
                OnPropertyChanged("DamageEffID_field");
            }
        }
        private int _extradamageEffID;
        public int ExtraDamageEffID_field {
            get { return _extradamageEffID; }
            set {
                _extradamageEffID = value;
                OnPropertyChanged("ExtraDamageEffID_field");
            }
        }
        private int _extraSoundID_field;
        public int ExtraSoundID_field {
            get { return _extraSoundID_field; }
            set {
                _extraSoundID_field = value;
                OnPropertyChanged("ExtraSoundID_field");
            }
        }
        private int _effectPrmID;
        public int EffectPrmID_field {
            get { return _effectPrmID; }
            set {
                _effectPrmID = value;
                OnPropertyChanged("EffectPrmID_field");
            }
        }
        private int _soundID_field;
        public int SoundID_field {
            get { return _soundID_field; }
            set {
                _soundID_field = value;
                OnPropertyChanged("SoundID_field");
            }
        }
        private int _unk1;
        public int Unk1_field {
            get { return _unk1; }
            set {
                _unk1 = value;
                OnPropertyChanged("Unk1_field");
            }
        }
        private int _unk2;
        public int Unk2_field {
            get { return _unk2; }
            set {
                _unk2 = value;
                OnPropertyChanged("Unk2_field");
            }
        }
        private int _extraEffectPrmID;
        public int ExtraEffectPrmID_field {
            get { return _extraEffectPrmID; }
            set {
                _extraEffectPrmID = value;
                OnPropertyChanged("ExtraEffectPrmID_field");
            }
        }
        public ObservableCollection<DamageEffModel> DamageEffList { get; set; }
        private DamageEffModel _selectedDamageEff;
        public DamageEffModel SelectedDamageEff {
            get { return _selectedDamageEff; }
            set {
                _selectedDamageEff = value;
                if (value is not null) {
                    DamageEffID_field = value.DamageEffID;
                    ExtraDamageEffID_field = value.ExtraDamageEffID;
                    ExtraSoundID_field = value.ExtraSoundID+1;
                    EffectPrmID_field = value.EffectPrmID;
                    SoundID_field = value.SoundID + 1;
                    Unk1_field = value.Unk1;
                    Unk2_field = value.Unk2;
                    ExtraEffectPrmID_field = value.ExtraEffectPrmID;
                }

                OnPropertyChanged("SelectedDamageEff");
            }
        }
        private int _selectedDamageEffIndex;
        public int SelectedDamageEffIndex {
            get { return _selectedDamageEffIndex; }
            set {
                _selectedDamageEffIndex = value;
                OnPropertyChanged("SelectedDamageEffIndex");
            }
        }

        public byte[] fileByte;
        public string filePath;
        public DamageEffViewModel() {

            LoadingStatePlay = Visibility.Hidden;
            DamageEffList = new ObservableCollection<DamageEffModel>();
            filePath = "";
            Sound1_List = new ObservableCollection<string> {
                "No Sound"
            }; 
            Sound2_List = new ObservableCollection<string> {
                "No Sound"
            };
            for (int x = 0; x < Program.NSC_SFX_LIST.Length; x++) {
                Sound1_List.Add(x.ToString() + " = " + Program.NSC_SFX_LIST[x]);
                Sound2_List.Add(x.ToString() + " = " + Program.NSC_SFX_LIST[x]);
            }
        }

        public void Clear() {
            DamageEffList.Clear();
        }

        public void OpenFile(string basepath = "") {
            Clear();
            if (basepath == "") {
                OpenFileDialog myDialog = new OpenFileDialog();
                myDialog.Filter = "XFBIN Container (*.xfbin)|*.xfbin";
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                if (myDialog.ShowDialog() == true) {
                    filePath = myDialog.FileName;
                } else {
                    return;
                }
            } else {
                filePath = basepath;
            }
            if (File.Exists(filePath)) {
                fileByte = File.ReadAllBytes(filePath);
                int Index3 = 128;
                string BinName = "";
                string BinPath = BinaryReader.b_ReadString(fileByte, Index3);
                Index3 = Index3 + BinPath.Length + 2;
                for (int x = 0; x < 3; x++) {
                    string name = BinaryReader.b_ReadString(fileByte, Index3);
                    if (x == 0)
                        BinName = name;
                    Index3 = Index3 + name.Length + 1;
                }
                int StartOfFile = 0x34 + BinaryReader.b_ReadIntRev(fileByte, 16);
                if (BinName.Contains("damageeff")) {

                    int entryCount = BinaryReader.b_ReadInt(fileByte, StartOfFile + 4);
                    for (int c = 0; c < entryCount; c++) {
                        int ptr = StartOfFile + 8 + (c * 0x24);
                        DamageEffModel DamageEffEntry = new DamageEffModel();
                        DamageEffEntry.DamageEffID = BinaryReader.b_ReadInt(fileByte, ptr);
                        DamageEffEntry.ExtraDamageEffID = BinaryReader.b_ReadInt(fileByte, ptr + 0x04);
                        DamageEffEntry.ExtraSoundID = BinaryReader.b_ReadInt(fileByte, ptr + 0x08);
                        DamageEffEntry.EffectPrmID = BinaryReader.b_ReadInt(fileByte, ptr + 0x0C);
                        DamageEffEntry.SoundID = BinaryReader.b_ReadInt(fileByte, ptr + 0x10);
                        DamageEffEntry.Unk1 = BinaryReader.b_ReadInt(fileByte, ptr + 0x14);
                        DamageEffEntry.Unk2 = BinaryReader.b_ReadInt(fileByte, ptr + 0x18);
                        DamageEffEntry.ExtraEffectPrmID = BinaryReader.b_ReadInt(fileByte, ptr + 0x1C);
                        DamageEffList.Add(DamageEffEntry);
                    }
                } else {
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_1"]);
                    return;
                }
            }

        }

        public void RemoveEntry() {
            if (SelectedDamageEff is not null) {
                DamageEffList.Remove(SelectedDamageEff);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_2"]);
            }
        }
        public void SaveEntry() {
            if (SelectedDamageEff is not null) {
                SelectedDamageEff.DamageEffID = DamageEffID_field;
                SelectedDamageEff.ExtraDamageEffID = ExtraDamageEffID_field;
                SelectedDamageEff.ExtraSoundID = ExtraSoundID_field - 1;
                SelectedDamageEff.EffectPrmID = EffectPrmID_field;
                SelectedDamageEff.SoundID = SoundID_field - 1;
                SelectedDamageEff.Unk1 = Unk1_field;
                SelectedDamageEff.Unk2 = Unk2_field;
                SelectedDamageEff.ExtraEffectPrmID = ExtraEffectPrmID_field;
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_1"]);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_2"]);
            }
        }
        public int SearchByteIndex(ObservableCollection<DamageEffModel> FunctionList, int member_index, int Selected) {
            for (int x = 0; x < FunctionList.Count; x++) {
                if (FunctionList[x].DamageEffID == member_index) {
                    if (Selected < x) {
                        return x;
                    }
                }

            }
            return -1;
        }

        public void SearchEntry() {
            if (SearchIndex_field > 0) {
                if (SearchByteIndex(DamageEffList, SearchIndex_field, SelectedDamageEffIndex) != -1) {
                    SelectedDamageEffIndex = SearchByteIndex(DamageEffList, SearchIndex_field, SelectedDamageEffIndex);
                    CollectionViewSource.GetDefaultView(DamageEffList).MoveCurrentTo(SelectedDamageEff);
                } else {
                    if (SearchByteIndex(DamageEffList, SearchIndex_field, 0) != -1) {
                        SelectedDamageEffIndex = SearchByteIndex(DamageEffList, SearchIndex_field, 0);
                        CollectionViewSource.GetDefaultView(DamageEffList).MoveCurrentTo(SelectedDamageEff);
                    } else {
                        ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_3"], "No result", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_4"]);
            }
        }


        public void AddDupEntry() {
            DamageEffModel DamageEffEntry = new DamageEffModel();
            if (SelectedDamageEff is not null) {
                DamageEffEntry = (DamageEffModel)SelectedDamageEff.Clone();
            } else {
                DamageEffEntry.DamageEffID = 0;
                DamageEffEntry.ExtraDamageEffID = -1;
                DamageEffEntry.ExtraSoundID = -1;
                DamageEffEntry.EffectPrmID = 0;
                DamageEffEntry.SoundID = -1;
                DamageEffEntry.Unk1 = 0x08;
                DamageEffEntry.Unk2 = 0x4E;
                DamageEffEntry.ExtraEffectPrmID = 0;
            }
            DamageEffList.Add(DamageEffEntry);
            ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_2"]);
        }

        public void SaveFile() {
            if (filePath != "") {

                if (File.Exists(filePath + ".backup")) {
                    File.Delete(filePath + ".backup");
                }
                File.Copy(filePath, filePath + ".backup");
                File.WriteAllBytes(filePath, ConvertToFile());
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_3"] + filePath + ".");
            } else {
                SaveFileAs();
            }
        }

        public void SaveFileAs(string basepath = "") {
            SaveFileDialog s = new SaveFileDialog();
            {
                s.DefaultExt = ".xfbin";
                s.Filter = "*.xfbin|*.xfbin";
            }
            if (basepath != "")
                s.FileName = basepath;
            else
                s.ShowDialog();
            if (s.FileName == "") {
                return;
            }
            if (s.FileName == filePath) {
                if (File.Exists(filePath + ".backup")) {
                    File.Delete(filePath + ".backup");
                }
                File.Copy(filePath, filePath + ".backup");
            } else {
                filePath = s.FileName;
            }
            File.WriteAllBytes(filePath, ConvertToFile());
            if (basepath == "")
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_3"] + filePath + ".");
        }

        public byte[] ConvertToFile() {
            // Build the header
            int totalLength4 = 0;

            byte[] fileBytes36 = new byte[127] { 0x4E, 0x55, 0x43, 0x43, 0x00, 0x00, 0x00, 0x79, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80, 0xBC, 0x00, 0x00, 0x00, 0x03, 0x00, 0x79, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x3B, 0x00, 0x00, 0x01, 0x49, 0x00, 0x00, 0x4C, 0xE3, 0x00, 0x00, 0x01, 0x4B, 0x00, 0x00, 0x0F, 0x6F, 0x00, 0x00, 0x01, 0x4B, 0x00, 0x00, 0x0F, 0x84, 0x00, 0x00, 0x05, 0x20, 0x00, 0x00, 0x00, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x4E, 0x75, 0x6C, 0x6C, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x42, 0x69, 0x6E, 0x61, 0x72, 0x79, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x50, 0x61, 0x67, 0x65, 0x00, 0x6E, 0x75, 0x63, 0x63, 0x43, 0x68, 0x75, 0x6E, 0x6B, 0x49, 0x6E, 0x64, 0x65, 0x78, 0x00 };
            int PtrNucc = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "D:/next5/char_hi/param/player/Converter/bin/damageeff.bin");
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);

            int PtrPath = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "damageeff");
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "Page0");
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "index");
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);

            int PtrName = fileBytes36.Length;
            totalLength4 = PtrName;
            int AddedBytes = 0;

            while (fileBytes36.Length % 4 != 0) {
                AddedBytes++;
                fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            }

            // Build bin1
            totalLength4 = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[48]
            {
                0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x01,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x02,0x00,0x00,0x00,0x03,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x03
            });

            int PtrSection = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[16]
            {
                0,
                0,
                0,
                0,
                0,
                0,
                0,
                1,
                0,
                0,
                0,
                2,
                0,
                0,
                0,
                3
            });

            totalLength4 = fileBytes36.Length;

            int PathLength = PtrPath - 127;
            int NameLength = PtrName - PtrPath;
            int Section1Length = PtrSection - PtrName - AddedBytes;
            int FullLength = totalLength4 - 68 + 40;
            int ReplaceIndex8 = 16;
            byte[] buffer8 = BitConverter.GetBytes(FullLength);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 36;
            buffer8 = BitConverter.GetBytes(2);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 40;
            buffer8 = BitConverter.GetBytes(PathLength);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 44;
            buffer8 = BitConverter.GetBytes(4);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 48;
            buffer8 = BitConverter.GetBytes(NameLength);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 52;
            buffer8 = BitConverter.GetBytes(4);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 56;
            buffer8 = BitConverter.GetBytes(Section1Length);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);
            ReplaceIndex8 = 60;
            buffer8 = BitConverter.GetBytes(4);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, buffer8, ReplaceIndex8, 1);

            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[28]
                {
                    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x63,0x79,0x76,0x00,0x00,0x08,0x98,0x00,0x00,0x00,0x01,0x00,0x63,0x79,0x76,0x00,0x00,0x08,0x94
                });

            int size1_index = fileBytes36.Length - 0x10;
            int size2_index = fileBytes36.Length - 0x4;
            int count_index = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[4]);
            int startOfFile = fileBytes36.Length;

            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[DamageEffList.Count * 0x24]);
            for (int x = 0; x < DamageEffList.Count; x++) {
                int ptr = startOfFile + (x * 0x24);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].DamageEffID), ptr);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].ExtraDamageEffID), ptr + 0x04);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].ExtraSoundID), ptr + 0x08);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].EffectPrmID), ptr + 0x0C);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].SoundID), ptr + 0x10);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].Unk1), ptr + 0x14);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].Unk2), ptr + 0x18);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList[x].ExtraEffectPrmID), ptr + 0x1C);
            }
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes((DamageEffList.Count * 0x24) + 0x8), size1_index, 1);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes((DamageEffList.Count * 0x24) + 0x4), size2_index, 1);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(DamageEffList.Count), count_index);
            return BinaryReader.b_AddBytes(fileBytes36, new byte[20]
            {
                0x00,0x00,0x00,0x08,0x00,0x00,0x00,0x02,0x00,0x79,0x8D,0x77,0x00,0x00,0x00,0x04,0x00,0x00,0x00,0x00
            });
        }

        private RelayCommand _saveFileAsCommand;
        public RelayCommand SaveFileAsCommand {
            get {
                return _saveFileAsCommand ??
                  (_saveFileAsCommand = new RelayCommand(obj => {
                      SaveFileAsAsync();
                  }));
            }
        }
        private RelayCommand _saveFileCommand;
        public RelayCommand SaveFileCommand {
            get {
                return _saveFileCommand ??
                  (_saveFileCommand = new RelayCommand(obj => {
                      SaveFileAsync();
                  }));
            }
        }
        private RelayCommand _openFileCommand;
        public RelayCommand OpenFileCommand {
            get {
                return _openFileCommand ??
                  (_openFileCommand = new RelayCommand(obj => {
                      OpenFileAsync();
                  }));
            }
        }
        private RelayCommand _deleteEntryCommand;
        public RelayCommand DeleteEntryCommand {
            get {
                return _deleteEntryCommand ??
                  (_deleteEntryCommand = new RelayCommand(obj => {
                      RemoveEntryAsync();
                  }));
            }
        }

        private RelayCommand _addDupEntryCommand;
        public RelayCommand AddDupEntryCommand {
            get {
                return _addDupEntryCommand ??
                  (_addDupEntryCommand = new RelayCommand(obj => {
                      AddDupEntryAsync();
                  }));
            }
        }
        private RelayCommand _saveEntryCommand;
        public RelayCommand SaveEntryCommand {
            get {
                return _saveEntryCommand ??
                  (_saveEntryCommand = new RelayCommand(obj => {
                      SaveEntryAsync();
                  }));
            }
        }
        private RelayCommand _searchEntryCommand;
        public RelayCommand SearchEntryCommand {
            get {
                return _searchEntryCommand ??
                  (_searchEntryCommand = new RelayCommand(obj => {
                      SearchEntryAsync();
                  }));
            }
        }
        public async void SaveFileAsync() {
            LoadingStatePlay = Visibility.Visible;
            await Task.Run(() => App.Current.Dispatcher.Invoke(() => SaveFile()));
            LoadingStatePlay = Visibility.Hidden;

        }
        public async void SaveFileAsAsync(string basepath = "") {
            LoadingStatePlay = Visibility.Visible;
            await Task.Run(() => App.Current.Dispatcher.Invoke(() => SaveFileAs(basepath)));
            LoadingStatePlay = Visibility.Hidden;

        }
        public async void OpenFileAsync(string basepath = "") {
            LoadingStatePlay = Visibility.Visible;
            await Task.Run(() => App.Current.Dispatcher.Invoke(() => OpenFile(basepath)));
            LoadingStatePlay = Visibility.Hidden;

        }
        public async void SearchEntryAsync() {
            LoadingStatePlay = Visibility.Visible;
            await Task.Run(() => App.Current.Dispatcher.Invoke(() => SearchEntry()));
            LoadingStatePlay = Visibility.Hidden;

        }
        public async void AddDupEntryAsync() {
            await Task.Run(() => App.Current.Dispatcher.Invoke(() => AddDupEntry()));

        }
        public async void SaveEntryAsync() {
            await Task.Run(() => App.Current.Dispatcher.Invoke(() => SaveEntry()));

        }
        public async void RemoveEntryAsync() {
            await Task.Run(() => App.Current.Dispatcher.Invoke(() => RemoveEntry()));

        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
