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

namespace NSC_Toolbox.ViewModel
{
    public class CostumeBreakParamViewModel : INotifyPropertyChanged {
        private int _searchIndex_field;
        public int SearchIndex_field {
            get { return _searchIndex_field; }
            set {
                _searchIndex_field = value;
                OnPropertyChanged("SearchIndex_field");
            }
        }

        private Visibility _loadingStatePlay;
        public Visibility LoadingStatePlay {
            get { return _loadingStatePlay; }
            set {
                _loadingStatePlay = value;
                OnPropertyChanged("LoadingStatePlay");
            }
        }

        private int _characodeID_field;
        public int CharacodeID_field {
            get { return _characodeID_field; }
            set {
                _characodeID_field = value;
                OnPropertyChanged("CharacodeID_field");
            }
        }
        private int _costumeID_field;
        public int CostumeID_field {
            get { return _costumeID_field; }
            set {
                _costumeID_field = value;
                OnPropertyChanged("CostumeID_field");
            }
        }
        private string _modelPath;
        public string ModelPath_field {
            get { return _modelPath; }
            set {
                _modelPath = value;
                OnPropertyChanged("ModelPath_field");
            }
        }
        private bool _enableInAwakening;
        public bool EnableInAwakening_field {
            get { return _enableInAwakening; }
            set {
                _enableInAwakening = value;
                OnPropertyChanged("EnableInAwakening_field");
            }
        }
        private bool _enableForClones;
        public bool EnableForClones_field {
            get { return _enableForClones; }
            set {
                _enableForClones = value;
                OnPropertyChanged("EnableForClones_field");
            }
        }
        private int _cloneCount;
        public int CloneCount_field {
            get { return _cloneCount; }
            set {
                _cloneCount = value;
                OnPropertyChanged("CloneCount_field");
            }
        }
        public ObservableCollection<CostumeBreakParamModel> CostumeBreakParamList { get; set; }
        private CostumeBreakParamModel _selectedCostumeBreakParam;
        public CostumeBreakParamModel SelectedCostumeBreakParam {
            get { return _selectedCostumeBreakParam; }
            set {
                _selectedCostumeBreakParam = value;
                if (value is not null) {
                    CharacodeID_field = value.CharacodeID;
                    CostumeID_field = value.CostumeID;
                    ModelPath_field = value.ModelPath;
                    EnableInAwakening_field = value.EnableInAwakening;
                    EnableForClones_field = value.EnableForClones;
                    CloneCount_field = value.CloneCount;
                }

                OnPropertyChanged("SelectedCostumeBreakParam");
            }
        }
        private int _selectedCostumeBreakParamIndex;
        public int SelectedCostumeBreakParamIndex {
            get { return _selectedCostumeBreakParamIndex; }
            set {
                _selectedCostumeBreakParamIndex = value;
                OnPropertyChanged("SelectedCostumeBreakParamIndex");
            }
        }

        public byte[] fileByte;
        public string filePath;
        public CostumeBreakParamViewModel() {

            LoadingStatePlay = Visibility.Hidden;
            CostumeBreakParamList = new ObservableCollection<CostumeBreakParamModel>();
            filePath = "";
        }

        public void Clear() {
            CostumeBreakParamList.Clear();
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
                int StartOfFile = 0x44 + BinaryReader.b_ReadIntRev(fileByte, 16);
                if (BinName.Contains("costumeBreakParam")) {

                    int entryCount = BinaryReader.b_ReadInt(fileByte, StartOfFile + 4);
                    for (int c = 0; c < entryCount; c++) {
                        int ptr = StartOfFile + 0x10 + (c * 0x20);
                        CostumeBreakParamModel CostumeBreakParamEntry = new CostumeBreakParamModel();
                        CostumeBreakParamEntry.CharacodeID = BinaryReader.b_ReadInt(fileByte, ptr);
                        CostumeBreakParamEntry.CostumeID = BinaryReader.b_ReadInt(fileByte, ptr + 0x04);
                        CostumeBreakParamEntry.ModelPath = BinaryReader.b_ReadString(fileByte, ptr + 0x08 + BinaryReader.b_ReadInt(fileByte, ptr + 0x08));
                        CostumeBreakParamEntry.EnableInAwakening = BinaryReader.b_ReadInt(fileByte, ptr + 0x10) == 1;
                        CostumeBreakParamEntry.EnableForClones = BinaryReader.b_ReadInt(fileByte, ptr + 0x14) == 1;
                        CostumeBreakParamEntry.CloneCount = BinaryReader.b_ReadInt(fileByte, ptr + 0x18);

                        CostumeBreakParamList.Add(CostumeBreakParamEntry);
                    }
                } else {
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_1"]);
                    return;
                }
            }

        }

        public CostumeBreakParamModel FindItemWithCharacodeID (int characode_id) {
            CostumeBreakParamModel entry = new CostumeBreakParamModel() { ModelPath = "data/spc/" };

            for (int i =0; i< CostumeBreakParamList.Count; i++) {
                if (CostumeBreakParamList[i].CharacodeID == characode_id) {
                    entry = (CostumeBreakParamModel)CostumeBreakParamList[i].Clone();
                    break;
                }
            }



            return entry;
        }

        public bool ItemExist(int characode_id) {
            bool exist = false;

            for (int i = 0; i < CostumeBreakParamList.Count; i++) {
                if (CostumeBreakParamList[i].CharacodeID == characode_id) {
                    exist = true;
                    break;
                }
            }



            return exist;
        }
        public void RemoveEntry() {
            if (SelectedCostumeBreakParam is not null) {
                CostumeBreakParamList.Remove(SelectedCostumeBreakParam);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_2"]);
            }
        }
        public void SaveEntry() {
            if (SelectedCostumeBreakParam is not null) {
                SelectedCostumeBreakParam.CharacodeID = CharacodeID_field;
                SelectedCostumeBreakParam.CostumeID = CostumeID_field;
                SelectedCostumeBreakParam.ModelPath = ModelPath_field;
                SelectedCostumeBreakParam.EnableInAwakening = EnableInAwakening_field;
                SelectedCostumeBreakParam.EnableForClones = EnableForClones_field;
                SelectedCostumeBreakParam.CloneCount = CloneCount_field;
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_tool_1"]);
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_2"]);
            }
        }
        public int SearchByteIndex(ObservableCollection<CostumeBreakParamModel> FunctionList, int member_index, int Selected) {
            for (int x = 0; x < FunctionList.Count; x++) {
                if (FunctionList[x].CharacodeID == member_index) {
                    if (Selected < x) {
                        return x;
                    }
                }

            }
            return -1;
        }

        public void SearchEntry() {
            if (SearchIndex_field > 0) {
                if (SearchByteIndex(CostumeBreakParamList, SearchIndex_field, SelectedCostumeBreakParamIndex) != -1) {
                    SelectedCostumeBreakParamIndex = SearchByteIndex(CostumeBreakParamList, SearchIndex_field, SelectedCostumeBreakParamIndex);
                    CollectionViewSource.GetDefaultView(CostumeBreakParamList).MoveCurrentTo(SelectedCostumeBreakParam);
                } else {
                    if (SearchByteIndex(CostumeBreakParamList, SearchIndex_field, 0) != -1) {
                        SelectedCostumeBreakParamIndex = SearchByteIndex(CostumeBreakParamList, SearchIndex_field, 0);
                        CollectionViewSource.GetDefaultView(CostumeBreakParamList).MoveCurrentTo(SelectedCostumeBreakParam);
                    } else {
                        ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_3"], "No result", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            } else {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_4"]);
            }
        }


        public void AddDupEntry() {
            CostumeBreakParamModel CostumeBreakParamEntry = new CostumeBreakParamModel();
            if (SelectedCostumeBreakParam is not null) {
                CostumeBreakParamEntry = (CostumeBreakParamModel)SelectedCostumeBreakParam.Clone();
            } else {
                CostumeBreakParamEntry.CharacodeID = 0;
                CostumeBreakParamEntry.CostumeID = 0;
                CostumeBreakParamEntry.ModelPath = "data/spc/";
                CostumeBreakParamEntry.EnableInAwakening = false;
                CostumeBreakParamEntry.EnableForClones = false;
                CostumeBreakParamEntry.CloneCount = 0;
            }
            CostumeBreakParamList.Add(CostumeBreakParamEntry);
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
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "bin_le/x64/costumeBreakParam.bin");
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);

            int PtrPath = fileBytes36.Length;
            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
            fileBytes36 = BinaryReader.b_AddString(fileBytes36, "costumeBreakParam");
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

            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[40]
                {
                    0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x48,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x79,0x48,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x01,0x00,0x79,0x5C,0x00,0x00,0x00,0x00,0x00
                });

            int size1_index = fileBytes36.Length - 0x10;
            int size2_index = fileBytes36.Length - 0x4;
            int count_index = fileBytes36.Length + 0x4;



            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[0x10] { 0xE9, 0x03, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x08, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });

            int startPtr = fileBytes36.Length;




            fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[CostumeBreakParamList.Count * 0x20]);

            int addSize = 0;

            List<int> modelPath_pointer = new List<int>();
            for (int x = 0; x < CostumeBreakParamList.Count; x++) {
                int ptr = startPtr + (x * 0x20);
                modelPath_pointer.Add(fileBytes36.Length);
                if (CostumeBreakParamList[x].ModelPath != ""  && CostumeBreakParamList[x].ModelPath is not null) {
                    fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, Encoding.ASCII.GetBytes(CostumeBreakParamList[x].ModelPath));
                    fileBytes36 = BinaryReader.b_AddBytes(fileBytes36, new byte[1]);
                    int newPointer3 = modelPath_pointer[x] - startPtr - x * 0x20 - 0x08;
                    fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(newPointer3), ptr + 0x08);
                    addSize += CostumeBreakParamList[x].ModelPath.Length + 1;
                }
                
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CostumeBreakParamList[x].CharacodeID), ptr);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CostumeBreakParamList[x].CostumeID), ptr + 0x04);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CostumeBreakParamList[x].EnableInAwakening), ptr + 0x10);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CostumeBreakParamList[x].EnableForClones), ptr + 0x14);
                fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CostumeBreakParamList[x].CloneCount), ptr + 0x18);
            }
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes((CostumeBreakParamList.Count * 0x20) + 0x14 + addSize), size1_index, 1);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes((CostumeBreakParamList.Count * 0x20) + 0x10 + addSize), size2_index, 1);
            fileBytes36 = BinaryReader.b_ReplaceBytes(fileBytes36, BitConverter.GetBytes(CostumeBreakParamList.Count), count_index);
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
