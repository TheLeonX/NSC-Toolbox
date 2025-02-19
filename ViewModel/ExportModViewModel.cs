using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using NSC_Toolbox.Model;
using NSC_Toolbox.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace NSC_Toolbox.ViewModel
{
    public static class BitmapConversion
    {
        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                          source.GetHbitmap(),
                          IntPtr.Zero,
                          Int32Rect.Empty,
                          BitmapSizeOptions.FromEmptyOptions());
        }
    }
    public class ExportModViewModel : INotifyPropertyChanged
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
        private Visibility _pageModType_character_visibility;
        public Visibility PageModType_character_visibility
        {
            get { return _pageModType_character_visibility; }
            set
            {
                _pageModType_character_visibility = value;
                OnPropertyChanged("PageModType_character_visibility");
            }
        }
        private Visibility _pageModType_tuj_visibility;
        public Visibility PageModType_tuj_visibility
        {
            get { return _pageModType_tuj_visibility; }
            set
            {
                _pageModType_tuj_visibility = value;
                OnPropertyChanged("PageModType_tuj_visibility");
            }
        }
        private Visibility _pageModType_stage_visibility;
        public Visibility PageModType_stage_visibility
        {
            get { return _pageModType_stage_visibility; }
            set
            {
                _pageModType_stage_visibility = value;
                OnPropertyChanged("PageModType_stage_visibility");
            }
        }
        private Visibility _pageModType_model_visibility;
        public Visibility PageModType_model_visibility
        {
            get { return _pageModType_model_visibility; }
            set
            {
                _pageModType_model_visibility = value;
                OnPropertyChanged("PageModType_model_visibility");
            }
        }
        private Visibility _pageModType_resources_visibility;
        public Visibility PageModType_resources_visibility
        {
            get { return _pageModType_resources_visibility; }
            set
            {
                _pageModType_resources_visibility = value;
                OnPropertyChanged("PageModType_resources_visibility");
            }
        }
        private Visibility _pageModType_accessory_visibility;
        public Visibility PageModType_accessory_visibility
        {
            get { return _pageModType_accessory_visibility; }
            set
            {
                _pageModType_accessory_visibility = value;
                OnPropertyChanged("PageModType_accessory_visibility");
            }
        }
        private BitmapSource _imagePreview;
        public BitmapSource ImagePreview
        {
            get { return _imagePreview; }
            set
            {
                _imagePreview = value;
                OnPropertyChanged("ImagePreview");
            }
        }

        private Bitmap _imageLoader;
        public Bitmap ImageLoader
        {
            get { return _imageLoader; }
            set
            {
                _imageLoader = value;
                ImagePreview = BitmapConversion.BitmapToBitmapSource(value);
                OnPropertyChanged("ImageLoader");
            }
        }

        private int _modType_field;
        public int ModType_field
        {
            get { return _modType_field; }
            set
            {
                _modType_field = value;
                ImportCharacterList.Clear();
                ExportCharacterList.Clear();
                ImportModelList.Clear();
                ExportModelList.Clear();
                ImportStageList.Clear();
                ExportStageList.Clear();
                StageImagePreviewPathList.Clear();
                StageIconPathList.Clear();
                StageBGMIDList.Clear();
                string characodePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin";

                if (File.Exists(DataWin32Path_field + "\\spc\\characode.bin.xfbin"))
                {
                    characodePath = DataWin32Path_field + "\\spc\\characode.bin.xfbin";
                }
                CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                charEditor.OpenFile(characodePath);
                ImportCharacterList = charEditor.CharacodeList;
                switch (value)
                {
                    //Character export
                    case 0:
                        PageModType_character_visibility = Visibility.Visible;
                        PageModType_stage_visibility = Visibility.Hidden;
                        PageModType_model_visibility = Visibility.Hidden;
                        PageModType_accessory_visibility = Visibility.Hidden;
                        PageModType_resources_visibility = Visibility.Hidden;
                        
                        break;
                    //Stage export
                    case 1:
                        PageModType_character_visibility = Visibility.Hidden;
                        PageModType_stage_visibility = Visibility.Visible;
                        PageModType_model_visibility = Visibility.Hidden;
                        PageModType_accessory_visibility = Visibility.Hidden;
                        PageModType_resources_visibility = Visibility.Hidden;
                        PageModType_tuj_visibility = Visibility.Hidden;

                        string stageInfoPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\StageInfo.bin.xfbin";

                        if (File.Exists(DataWin32Path_field + "\\stage\\StageInfo.bin.xfbin"))
                        {
                            stageInfoPath = DataWin32Path_field + "\\stage\\StageInfo.bin.xfbin";
                        }
                        StageInfoViewModel stageEditor = new StageInfoViewModel();
                        stageEditor.OpenFile(stageInfoPath);
                        ImportStageList = stageEditor.StageInfoList;
                        break;
                    //Model export
                    case 2:
                        PageModType_character_visibility = Visibility.Hidden;
                        PageModType_stage_visibility = Visibility.Hidden;
                        PageModType_model_visibility = Visibility.Visible;
                        PageModType_accessory_visibility = Visibility.Hidden;
                        PageModType_resources_visibility = Visibility.Hidden;
                        PageModType_tuj_visibility = Visibility.Hidden;

                        string playerSettingParamPath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\playerSettingParam.bin.xfbin";

                        if (File.Exists(DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin"))
                        {
                            playerSettingParamPath = DataWin32Path_field + "\\spc\\playerSettingParam.bin.xfbin";
                        }
                        PlayerSettingParamViewModel PSPEditor = new PlayerSettingParamViewModel();
                        PSPEditor.OpenFile(playerSettingParamPath);
                        ImportModelList = PSPEditor.PlayerSettingParamList;

                        break;
                    //Resources export
                    case 3:
                        PageModType_character_visibility = Visibility.Hidden;
                        PageModType_stage_visibility = Visibility.Hidden;
                        PageModType_model_visibility = Visibility.Hidden;
                        PageModType_resources_visibility = Visibility.Visible;
                        PageModType_accessory_visibility = Visibility.Hidden;
                        PageModType_tuj_visibility = Visibility.Hidden;
                        break;
                    //Team Ultimate Jutsu Export
                    case 4:
                        PageModType_character_visibility = Visibility.Hidden;
                        PageModType_stage_visibility = Visibility.Hidden;
                        PageModType_model_visibility = Visibility.Hidden;
                        PageModType_resources_visibility = Visibility.Hidden;
                        PageModType_tuj_visibility = Visibility.Visible;
                        PageModType_accessory_visibility = Visibility.Hidden;

                        TeamUltimateJutsuList.Clear();
                        string pairManagerParamPath = Path.Combine(Path.GetDirectoryName(DataWin32Path_field), "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin");

                        byte[] pairManagerParamExport = File.ReadAllBytes(pairManagerParamPath);

                        // Read all bytes from the file.
                        int entryLength = 0x18; // Each entry is 24 bytes.

                        // Check if any entry already has TUJ_label_field as its name.
                        int entryCount = pairManagerParamExport.Length / entryLength;
                        for (int i = 0; i < entryCount; i++)
                        {
                            int offset = i * entryLength;
                            byte[] nameBytes = new byte[0x10]; // 16 bytes for the name.
                            Array.Copy(pairManagerParamExport, offset, nameBytes, 0, 0x10);

                            // Convert the 16-byte string (assumed ASCII) and trim null terminators.
                            string entryName = Encoding.ASCII.GetString(nameBytes).TrimEnd('\0');
                            TeamUltimateJutsuList.Add(entryName);
                        }


                        break;
                    //Accessory export
                    case 5:
                        PageModType_character_visibility = Visibility.Hidden;
                        PageModType_stage_visibility = Visibility.Hidden;
                        PageModType_model_visibility = Visibility.Hidden;
                        PageModType_resources_visibility = Visibility.Hidden;
                        PageModType_tuj_visibility = Visibility.Hidden;
                        PageModType_accessory_visibility = Visibility.Visible;
                        break;
                }
                OnPropertyChanged("ModType_field");
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
                    IsDataWin32Exist = Directory.Exists(value);
                    string characodePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin";
                    if (File.Exists(DataWin32Path_field + "\\spc\\characode.bin.xfbin"))
                    {
                        characodePath = DataWin32Path_field + "\\spc\\characode.bin.xfbin";
                    }
                    CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                    charEditor.OpenFile(characodePath);
                    ImportCharacterList = charEditor.CharacodeList;
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
        private bool _isExportCharactersExist;
        public bool IsExportModsExist
        {
            get { return _isExportCharactersExist; }
            set
            {
                _isExportCharactersExist = value;
                OnPropertyChanged("IsExportModsExist");
            }
        }
        private bool _isModReady;
        public bool IsModReady
        {
            get { return _isModReady; }
            set
            {
                _isModReady = value;
                OnPropertyChanged("IsModReady");
            }
        }
        private bool _isModCompiled;
        public bool IsModCompiled
        {
            get { return _isModCompiled; }
            set
            {
                _isModCompiled = value;
                OnPropertyChanged("IsModCompiled");
            }
        }
        private string _modName_field;
        public string ModName_field
        {
            get { return _modName_field; }
            set
            {
                _modName_field = value;
                if (value != null && value != "")
                {
                    IsModReady = true;
                } else
                    IsModReady = false;
                OnPropertyChanged("ModName_field");
            }
        }
        private string _modDesc_field;
        public string ModDesc_field
        {
            get { return _modDesc_field; }
            set
            {
                _modDesc_field = value;
                OnPropertyChanged("ModDesc_field");
            }
        }
        private string _modVersion_field;
        public string ModVersion_field
        {
            get { return _modVersion_field; }
            set
            {
                _modVersion_field = value;
                OnPropertyChanged("ModVersion_field");
            }
        }
        private string _modAuthor_field;
        public string ModAuthor_field
        {
            get { return _modAuthor_field; }
            set
            {
                _modAuthor_field = value;
                OnPropertyChanged("ModAuthor_field");
            }
        }
        private string _modIconPath_field;
        public string ModIconPath_field
        {
            get
            {
                return _modIconPath_field;
            }
            set
            {
                _modIconPath_field = value;
                if (File.Exists(value))
                    ImageLoader = (Bitmap)Bitmap.FromFile(value, true);
                else
                    ImageLoader = (Bitmap)Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Resources\\TemplateImages\\template_icon.png", true);
                OnPropertyChanged("ModIconPath_field");
            }
        }
        private ObservableCollection<string> _shadersList;
        public ObservableCollection<string> ShadersList
        {
            get { return _shadersList; }
            set
            {
                _shadersList = value;
                OnPropertyChanged("ShadersList");
            }
        }
        private string _selectedShader;
        public string SelectedShader
        {
            get { return _selectedShader; }
            set
            {
                _selectedShader = value;
                OnPropertyChanged("SelectedShader");
            }
        }
        private ObservableCollection<string> _cpkList;
        public ObservableCollection<string> CPKList
        {
            get { return _cpkList; }
            set
            {
                _cpkList = value;
                OnPropertyChanged("CPKList");
            }
        }
        private string _selectedCPK;
        public string SelectedCPK
        {
            get { return _selectedCPK; }
            set
            {
                _selectedCPK = value;
                OnPropertyChanged("SelectedCPK");
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
        private CharacodeEditorModel _selectedImportCharacter;
        public CharacodeEditorModel SelectedImportCharacter
        {
            get { return _selectedImportCharacter; }
            set
            {
                _selectedImportCharacter = value;
                OnPropertyChanged("SelectedImportCharacter");
            }
        }
        private ObservableCollection<CharacodeEditorModel> _exportCharacterList;
        public ObservableCollection<CharacodeEditorModel> ExportCharacterList
        {
            get { return _exportCharacterList; }
            set
            {
                _exportCharacterList = value;
                OnPropertyChanged("ExportCharacterList");
            }
        }
        private CharacodeEditorModel _selectedExportCharacter;
        public CharacodeEditorModel SelectedExportCharacter
        {
            get { return _selectedExportCharacter; }
            set
            {
                _selectedExportCharacter = value;
                OnPropertyChanged("SelectedExportCharacter");
            }
        }

        private ObservableCollection<StageInfoModel> _importStageList;
        public ObservableCollection<StageInfoModel> ImportStageList
        {
            get { return _importStageList; }
            set
            {
                _importStageList = value;
                OnPropertyChanged("ImportStageList");
            }
        }
        private StageInfoModel _selectedImportStage;
        public StageInfoModel SelectedImportStage
        {
            get { return _selectedImportStage; }
            set
            {
                _selectedImportStage = value;
                OnPropertyChanged("SelectedImportStage");
            }
        }
        private ObservableCollection<StageInfoModel> _exportStageList;
        public ObservableCollection<StageInfoModel> ExportStageList
        {
            get { return _exportStageList; }
            set
            {
                _exportStageList = value;
                OnPropertyChanged("ExportStageList");
            }
        }
        private StageInfoModel _selectedExportStage;
        public StageInfoModel SelectedExportStage
        {
            get { return _selectedExportStage; }
            set
            {
                _selectedExportStage = value;
                if (SelectedExportStageIndex > -1)
                {
                    StagePreviewPath = StageImagePreviewPathList[SelectedExportStageIndex];
                    StageIconPath = StageIconPathList[SelectedExportStageIndex];
                    StageBGM_ID = StageBGMIDList[SelectedExportStageIndex];
                    StageMessageID = StageMessageIDList[SelectedExportStageIndex];
                }
                OnPropertyChanged("SelectedExportStage");
            }
        }
        private int _selectedExportStageIndex;
        public int SelectedExportStageIndex
        {
            get { return _selectedExportStageIndex; }
            set
            {
                _selectedExportStageIndex = value;
                OnPropertyChanged("SelectedExportStageIndex");
            }
        }
        private ObservableCollection<string> _stageImagePreviewPathList;
        public ObservableCollection<string> StageImagePreviewPathList
        {
            get { return _stageImagePreviewPathList; }
            set
            {
                _stageImagePreviewPathList = value;
                OnPropertyChanged("StageImagePreviewPathList");
            }
        }
        private ObservableCollection<string> _stageIconPathList;
        public ObservableCollection<string> StageIconPathList
        {
            get { return _stageIconPathList; }
            set
            {
                _stageIconPathList = value;
                OnPropertyChanged("StageIconPathList");
            }
        }
        private ObservableCollection<int> _stageBGMIDList;
        public ObservableCollection<int> StageBGMIDList
        {
            get { return _stageBGMIDList; }
            set
            {
                _stageBGMIDList = value;
                OnPropertyChanged("StageBGMIDList");
            }
        }
        private ObservableCollection<string> _stageMessageIDList;
        public ObservableCollection<string> StageMessageIDList
        {
            get { return _stageMessageIDList; }
            set
            {
                _stageMessageIDList = value;
                OnPropertyChanged("StageMessageIDList");
            }
        }
        private int _stageBGM_ID;
        public int StageBGM_ID
        {
            get { return _stageBGM_ID; }
            set
            {
                _stageBGM_ID = value;
                OnPropertyChanged("StageBGM_ID");
            }
        }
        private string _stageMessageID;
        public string StageMessageID
        {
            get { return _stageMessageID; }
            set
            {
                _stageMessageID = value;
                OnPropertyChanged("StageMessageID");
            }
        }
        private string _stageIconPath;
        public string StageIconPath
        {
            get
            {
                return _stageIconPath;
            }
            set
            {
                _stageIconPath = value;
                OnPropertyChanged("StageIconPath");
            }
        }

        private string _stagePreviewPath;
        public string StagePreviewPath
        {
            get
            {
                return _stagePreviewPath;
            }
            set
            {
                _stagePreviewPath = value;
                if (File.Exists(value))
                    StagePreviewLoader = (Bitmap)Bitmap.FromFile(value, true);
                else
                    StagePreviewLoader = (Bitmap)Bitmap.FromFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Resources\\TemplateImages\\stage_tex.png", true);
                OnPropertyChanged("StagePreviewPath");
            }
        }
        private BitmapSource _stageImagePreview;
        public BitmapSource StageImagePreview
        {
            get { return _stageImagePreview; }
            set
            {
                _stageImagePreview = value;
                OnPropertyChanged("StageImagePreview");
            }
        }

        private Bitmap _stagePreviewLoader;
        public Bitmap StagePreviewLoader
        {
            get { return _stagePreviewLoader; }
            set
            {
                _stagePreviewLoader = value;
                StageImagePreview = BitmapConversion.BitmapToBitmapSource(value);
                OnPropertyChanged("StagePreviewLoader");
            }
        }

        private ObservableCollection<PlayerSettingParamModel> _importModelList;
        public ObservableCollection<PlayerSettingParamModel> ImportModelList
        {
            get { return _importModelList; }
            set
            {
                _importModelList = value;
                OnPropertyChanged("ImportModelList");
            }
        }
        private PlayerSettingParamModel _selectedImportModel;
        public PlayerSettingParamModel SelectedImportModel
        {
            get { return _selectedImportModel; }
            set
            {
                _selectedImportModel = value;
                OnPropertyChanged("SelectedImportModel");
            }
        }

        private ObservableCollection<PlayerSettingParamModel> _exportModelList;
        public ObservableCollection<PlayerSettingParamModel> ExportModelList
        {
            get { return _exportModelList; }
            set
            {
                _exportModelList = value;
                OnPropertyChanged("ExportModelList");
            }
        }
        private PlayerSettingParamModel _selectedExportModel;
        public PlayerSettingParamModel SelectedExportModel
        {
            get { return _selectedExportModel; }
            set
            {
                _selectedExportModel = value;
                OnPropertyChanged("SelectedExportModel");
            }
        }

        private ObservableCollection<string> _teamUltimateJutsuList;
        public ObservableCollection<string> TeamUltimateJutsuList
        {
            get { return _teamUltimateJutsuList; }
            set
            {
                _teamUltimateJutsuList = value;
                OnPropertyChanged("TeamUltimateJutsuList");
            }
        }
        private string _selectedTeamUltimateJutsu;
        public string SelectedTeamUltimateJutsu
        {
            get { return _selectedTeamUltimateJutsu; }
            set
            {
                _selectedTeamUltimateJutsu = value;
                OnPropertyChanged("SelectedTeamUltimateJutsu");
                IsExportModsExist = SelectedTeamUltimateJutsu != "placeholder";
            }
        }
        private int _selectedTeamUltimateJutsuIndex;
        public int SelectedTeamUltimateJutsuIndex
        {
            get { return _selectedTeamUltimateJutsuIndex; }
            set
            {
                _selectedTeamUltimateJutsuIndex = value;
                OnPropertyChanged("SelectedTeamUltimateJutsuIndex");
            }
        }

        public ObservableCollection<string> ModType_List { get; set; }
        public string filePath;
        public ExportModViewModel()
        {

            ImportCharacterList = new ObservableCollection<CharacodeEditorModel>();
            ExportCharacterList = new ObservableCollection<CharacodeEditorModel>();
            ImportModelList = new ObservableCollection<PlayerSettingParamModel>();
            ExportModelList = new ObservableCollection<PlayerSettingParamModel>();
            ImportStageList = new ObservableCollection<StageInfoModel>();
            ExportStageList = new ObservableCollection<StageInfoModel>();
            StageImagePreviewPathList = new ObservableCollection<string>();
            StageIconPathList = new ObservableCollection<string>();
            StageMessageIDList = new ObservableCollection<string>();
            StageBGMIDList = new ObservableCollection<int>();
            ModType_List = new ObservableCollection<string>();
            ShadersList = new ObservableCollection<string>();
            CPKList = new ObservableCollection<string>();
            TeamUltimateJutsuList = new ObservableCollection<string>();
            LoadingStatePlay = Visibility.Hidden;
            filePath = "";
            ModIconPath_field = AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Resources\\TemplateImages\\template_icon.png";
            PageModType_character_visibility = Visibility.Visible;
            PageModType_stage_visibility = Visibility.Hidden;
            PageModType_model_visibility = Visibility.Hidden;
            PageModType_accessory_visibility = Visibility.Hidden;
            ModType_field = 0;
            IsModReady = false;
            IsDataWin32Exist = false;
            IsExportModsExist = false;
            IsModCompiled = false;
            for (int x = 0; x < Program.ModType.Length; x++) ModType_List.Add(Program.ModType[x]);
        }

        public void ClearModInfo()
        {
            ShadersList.Clear();
            CPKList.Clear();
            DataWin32Path_field = "";
        }
        public void SelectCPK()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "CPK Archive (*.CPK)|*.CPK";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                foreach (string file in myDialog.FileNames)
                {
                    CPKList.Add(file);
                }
            } else
            {
                return;
            }
        }
        public void DeleteCPK()
        {
            if (SelectedCPK is not null)
            {
                CPKList.Remove(SelectedCPK);
            } else
                ModernWpf.MessageBox.Show("Select CPK which you want to delete");
        }
        public void SelectCharacter()
        {
            if (SelectedImportCharacter is not null)
            {
                if (!ExportCharacterList.Contains(SelectedImportCharacter))
                    ExportCharacterList.Add(SelectedImportCharacter);
                else
                    ModernWpf.MessageBox.Show("Character was already selected!");
                IsExportModsExist = ExportCharacterList.Count > 0;
            } else
                ModernWpf.MessageBox.Show("Select Character which you want to export");
        }
        public void DeleteCharacter()
        {
            if (SelectedExportCharacter is not null)
            {
                ExportCharacterList.Remove(SelectedExportCharacter);
                IsExportModsExist = ExportCharacterList.Count > 0;
            } else
                ModernWpf.MessageBox.Show("Select Character which you want to delete");
        }
        public void SelectModel()
        {
            if (SelectedImportModel is not null)
            {
                if (!ExportModelList.Contains(SelectedImportModel))
                    ExportModelList.Add(SelectedImportModel);
                else
                    ModernWpf.MessageBox.Show("Model was already selected!");
                IsExportModsExist = ExportModelList.Count > 0;
            } else
                ModernWpf.MessageBox.Show("Select Character which you want to export");
        }
        public void DeleteModel()
        {
            if (SelectedExportModel is not null)
            {
                ExportModelList.Remove(SelectedExportModel);
                IsExportModsExist = ExportModelList.Count > 0;
            } else
                ModernWpf.MessageBox.Show("Select Model which you want to delete");
        }
        public void SelectStage()
        {
            if (SelectedImportStage is not null)
            {
                if (!ExportStageList.Contains(SelectedImportStage))
                {
                    StageImagePreviewPathList.Add(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Resources\\TemplateImages\\stage_tex.png");
                    StageIconPathList.Add(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\Resources\\TemplateImages\\stage_icon.dds");
                    StageMessageIDList.Add("Location005");
                    StageBGMIDList.Add(-1);

                    ExportStageList.Add(SelectedImportStage);
                } else
                    ModernWpf.MessageBox.Show("Stage was already selected!");
                IsExportModsExist = ExportStageList.Count > 0;
            } else
                ModernWpf.MessageBox.Show("Select Stage which you want to export");
        }
        public void DeleteStage()
        {
            if (SelectedExportStage is not null && SelectedExportStageIndex > -1)
            {
                StageImagePreviewPathList.RemoveAt(SelectedExportStageIndex);
                StageIconPathList.RemoveAt(SelectedExportStageIndex);
                StageBGMIDList.RemoveAt(SelectedExportStageIndex);
                StageMessageIDList.RemoveAt(SelectedExportStageIndex);
                ExportStageList.Remove(SelectedExportStage);
                IsExportModsExist = ExportStageList.Count > 0;
            } else
                ModernWpf.MessageBox.Show("Select Stage which you want to delete");
        }
        public void SelectShader()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "HLSL Shaders - Vertex and Pixel (*.HLSL)|*.HLSL";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                foreach (string file in myDialog.FileNames)
                {
                    ShadersList.Add(file);
                }
            } else
            {
                return;
            }
        }
        public void SelectModIcon()
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "PNG Image (*.png)|*.png";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = false;
            if (myDialog.ShowDialog() == true)
            {
                ModIconPath_field = myDialog.FileName;
            } else
            {
                return;
            }
        }

        public void SelectStageImagePreview()
        {
            if (SelectedExportStageIndex > -1)
            {
                OpenFileDialog myDialog = new OpenFileDialog();
                myDialog.Filter = "PNG Image (*.png)|*.png";
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                if (myDialog.ShowDialog() == true)
                {
                    StageImagePreviewPathList[SelectedExportStageIndex] = myDialog.FileName;
                    StagePreviewPath = myDialog.FileName;
                } else
                {
                    return;
                }
            } else
            {
                ModernWpf.MessageBox.Show("Select stage!");
            }
        }
        public void SelectStageIcon()
        {
            if (SelectedExportStageIndex > -1)
            {
                OpenFileDialog myDialog = new OpenFileDialog();
                myDialog.Filter = "DDS Image (*.dds)|*.dds";
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                if (myDialog.ShowDialog() == true)
                {
                    StageIconPathList[SelectedExportStageIndex] = myDialog.FileName;
                } else
                {
                    return;
                }
            } else
            {
                ModernWpf.MessageBox.Show("Select stage!");
            }
        }
        public void SaveBGMID()
        {
            if (SelectedExportStageIndex > -1)
            {
                StageBGMIDList[SelectedExportStageIndex] = StageBGM_ID;
            } else
            {
                ModernWpf.MessageBox.Show("Select stage!");
            }
        }
        public void SaveStageMessageID()
        {
            if (SelectedExportStageIndex > -1)
            {
                StageMessageIDList[SelectedExportStageIndex] = StageMessageID;
            } else
            {
                ModernWpf.MessageBox.Show("Select stage!");
            }
        }
        public void DeleteShader()
        {
            if (SelectedShader is not null)
            {
                ShadersList.Remove(SelectedShader);
            } else
                ModernWpf.MessageBox.Show("Select shader which you want to delete");
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
        public void SaveDataWin32()
        {
            if (DataWin32Path_field != null)
            {
                IsDataWin32Exist = Directory.Exists(DataWin32Path_field);
            } else
                IsDataWin32Exist = false;
        }

        async void CompileModAsyncProcess(string output_folder)
        {
            try
            {
                await Task.Run(() => CompileModProcess(output_folder));
                LoadingStatePlay = Visibility.Hidden;
                SystemSounds.Beep.Play();
            } catch (Exception ex)
            {
                ModernWpf.MessageBox.Show(ex.StackTrace + "\n\n" + ex.Message);
            }
        }

        public void CompileModProcess(string output_folder)
        {
            //Create Mode Folder
            string mod_path = output_folder + "\\" + ModName_field;
            Directory.CreateDirectory(mod_path);

            //Check param files in data_win32
            string characodePath = Path.Combine(DataWin32Path_field, "spc", "characode.bin.xfbin");
            bool characodeExist = File.Exists(characodePath);

            string duelPlayerParamPath = Path.Combine(DataWin32Path_field, "spc", "duelPlayerParam.xfbin");
            bool duelPlayerParamExist = File.Exists(duelPlayerParamPath);

            string playerSettingParamPath = Path.Combine(DataWin32Path_field, "spc", "playerSettingParam.bin.xfbin");
            bool playerSettingParamExist = File.Exists(playerSettingParamPath);

            string skillCustomizeParamPath = Path.Combine(DataWin32Path_field, "spc", "skillCustomizeParam.xfbin");
            bool skillCustomizeParamExist = File.Exists(skillCustomizeParamPath);

            string spSkillCustomizeParamPath = Path.Combine(DataWin32Path_field, "spc", "spSkillCustomizeParam.xfbin");
            bool SpSkillCustomizeParamExist = File.Exists(spSkillCustomizeParamPath);

            string skillIndexSettingParamPath = Path.Combine(DataWin32Path_field, "spc", "skillIndexSettingParam.xfbin");
            bool skillIndexSettingParamExist = File.Exists(skillIndexSettingParamPath);

            string supportSkillRecoverySpeedParamPath = Path.Combine(DataWin32Path_field, "spc", "supportSkillRecoverySpeedParam.xfbin");
            bool supportSkillRecoverySpeedParamExist = File.Exists(supportSkillRecoverySpeedParamPath);

            string privateCameraPath = Path.Combine(DataWin32Path_field, "spc", "privateCamera.bin.xfbin");
            bool privateCameraExist = File.Exists(privateCameraPath);

            string characterSelectParamPath = Path.Combine(DataWin32Path_field, "ui", "max", "select", "characterSelectParam.xfbin");
            bool characterSelectParamExist = File.Exists(characterSelectParamPath);

            string costumeBreakColorParamPath = Path.Combine(DataWin32Path_field, "spc", "costumeBreakColorParam.xfbin");
            bool costumeBreakColorParamExist = File.Exists(costumeBreakColorParamPath);

            string costumeParamPath = Path.Combine(DataWin32Path_field, "rpg", "param", "costumeParam.bin.xfbin");
            bool costumeParamExist = File.Exists(costumeParamPath);

            string playerIconPath = Path.Combine(DataWin32Path_field, "spc", "player_icon.xfbin");
            bool playerIconExist = File.Exists(playerIconPath);

            string cmnparamPath = Path.Combine(DataWin32Path_field, "sound", "cmnparam.xfbin");
            bool cmnparamExist = File.Exists(cmnparamPath);

            string supportActionParamPath = Path.Combine(DataWin32Path_field, "spc", "supportActionParam.xfbin");
            bool supportActionParamExist = File.Exists(supportActionParamPath);

            string awakeAuraPath = Path.Combine(DataWin32Path_field, "spc", "awakeAura.xfbin");
            bool awakeAuraExist = File.Exists(awakeAuraPath);

            string appearanceAnmPath = Path.Combine(DataWin32Path_field, "spc", "appearanceAnm.xfbin");
            bool appearanceAnmExist = File.Exists(appearanceAnmPath);

            string afterAttachObjectPath = Path.Combine(DataWin32Path_field, "spc", "afterAttachObject.xfbin");
            bool afterAttachObjectExist = File.Exists(afterAttachObjectPath);

            string playerDoubleEffectParamPath = Path.Combine(DataWin32Path_field, "spc", "playerDoubleEffectParam.xfbin");
            bool playerDoubleEffectParamExist = File.Exists(playerDoubleEffectParamPath);

            string spTypeSupportParamPath = Path.Combine(DataWin32Path_field, "spc", "spTypeSupportParam.xfbin");
            bool spTypeSupportParamExist = File.Exists(spTypeSupportParamPath);

            string costumeBreakParamPath = Path.Combine(DataWin32Path_field, "spc", "costumeBreakParam.xfbin");
            bool costumeBreakParamExist = File.Exists(costumeBreakParamPath);

            string messageInfoPath = Path.Combine(DataWin32Path_field, "message");
            bool messageInfoExist = Directory.Exists(messageInfoPath);

            string damageeffPath = Path.Combine(DataWin32Path_field, "spc", "damageeff.bin.xfbin");
            bool damageeffExist = File.Exists(damageeffPath);

            string effectprmPath = Path.Combine(DataWin32Path_field, "spc", "effectprm.bin.xfbin");
            bool effectprmExist = File.Exists(effectprmPath);

            string damageprmPath = Path.Combine(DataWin32Path_field, "spc", "damageprm.bin.xfbin");
            bool damageprmExist = File.Exists(damageprmPath);

            string pairSpSkillCombinePath = Path.Combine(DataWin32Path_field, "spc", "pairSpSkillCombinationParam.xfbin");
            bool pairSpSkillCombineExist = File.Exists(pairSpSkillCombinePath);

            string pairSpSkillManagerPath = Path.Combine(Path.GetDirectoryName(DataWin32Path_field), "moddingapi", "mods", "base_game", "pairSpSkillManagerParam.xfbin");
            bool pairSpSkillManagerExist = File.Exists(pairSpSkillManagerPath);

            //Create config file
            var MyIni = new IniFile(@mod_path + "\\mod_config.ini");
            MyIni.Write("ModName", ModName_field, "ModManager");
            MyIni.Write("Description", ModDesc_field, "ModManager");
            MyIni.Write("Author", ModAuthor_field, "ModManager");
            MyIni.Write("LastUpdate", DateTime.Today.ToString("dd/MM/yyyy"), "ModManager");
            MyIni.Write("Version", ModVersion_field, "ModManager");
            MyIni.Write("EnableMod", "true", "ModManager");

            //Copy Icon 
            File.Copy(ModIconPath_field, mod_path + "\\mod_icon.png", true);


            //Copy all resources from mod folder
            Program.CopyFilesRecursivelyModManager(DataWin32Path_field, mod_path + "\\Resources\\Files\\data");

            //Copy all CPKs
            Directory.CreateDirectory(mod_path + "\\Resources\\CPKs");
            foreach (string file in CPKList)
            {
                string cpk_name = Path.GetFileName(file);
                File.Copy(file, mod_path + "\\Resources\\CPKs\\" + cpk_name, true);
            }
            //Copy all shaders
            Directory.CreateDirectory(mod_path + "\\Resources\\Shaders");
            foreach (string file in ShadersList)
            {
                string shader_name = Path.GetFileName(file);
                File.Copy(file, mod_path + "\\Resources\\Shaders\\" + shader_name, true);
            }
            //characode.bin.xfbin 
            CharacodeEditorViewModel Characode = new CharacodeEditorViewModel();
            Characode.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin");

            ObservableCollection<string> ExportMessageNameList = new ObservableCollection<string>();
            if (DataWin32Path_field != null && DataWin32Path_field != "" &&
                ModName_field != null && ModName_field != "" && ModType_field > -1
                && Directory.Exists(output_folder))
            {
                switch (ModType_field)
                {
                    //Compile Character Mod
                    case 0:
                        List<string> awakeningModels = new List<string>();
                        List<string> baseModels = new List<string>();

                        DuelPlayerParamEditorViewModel ImportDuelPlayerParam = new DuelPlayerParamEditorViewModel();
                        PlayerSettingParamViewModel ImportPlayerSettingParam = new PlayerSettingParamViewModel();
                        SkillCustomizeParamViewModel ImportSkillCustomizeParam = new SkillCustomizeParamViewModel();
                        SpSkillCustomizeParamViewModel ImportSpSkillCustomizeParam = new SpSkillCustomizeParamViewModel();
                        SkillIndexSettingParamViewModel ImportSkillIndexParam = new SkillIndexSettingParamViewModel();
                        SupportSkillRecoverySpeedParamViewModel ImportSupportSkillRecoverySpeed = new SupportSkillRecoverySpeedParamViewModel();
                        PrivateCameraViewModel ImportPrivateCamera = new PrivateCameraViewModel();
                        CharacterSelectParamViewModel ImportCharacterSelectParam = new CharacterSelectParamViewModel();
                        CostumeBreakColorParamViewModel ImportCostumeBreakColorParam = new CostumeBreakColorParamViewModel();
                        CostumeParamViewModel ImportCostumeParam = new CostumeParamViewModel();
                        PlayerIconViewModel ImportPlayerIcon = new PlayerIconViewModel();
                        cmnparamViewModel ImportCmnParam = new cmnparamViewModel();
                        SupportActionParamViewModel ImportSupportActionParam = new SupportActionParamViewModel();
                        AwakeAuraViewModel ImportAwakeAura = new AwakeAuraViewModel();
                        AppearanceAnmViewModel ImportAppearanceAnm = new AppearanceAnmViewModel();
                        AfterAttachObjectViewModel ImportAfterAttachObject = new AfterAttachObjectViewModel();
                        PlayerDoubleEffectParamViewModel ImportPlayerDoubleEffectParam = new PlayerDoubleEffectParamViewModel();
                        SpTypeSupportParamViewModel ImportSpTypeSupportParam = new SpTypeSupportParamViewModel();
                        CostumeBreakParamViewModel ImportCostumeBreakParam = new CostumeBreakParamViewModel();
                        MessageInfoViewModel ImportMessageInfo = new MessageInfoViewModel();
                        DamageEffViewModel OriginalDamageEff = new DamageEffViewModel();
                        DamageEffViewModel ImportDamageEff = new DamageEffViewModel();
                        EffectPrmViewModel OriginalEffectPrm = new EffectPrmViewModel();
                        EffectPrmViewModel ImportEffectPrm = new EffectPrmViewModel();
                        DamagePrmViewModel ImportDamagePrm = new DamagePrmViewModel();
                        DamagePrmViewModel OriginalDamagePrm = new DamagePrmViewModel();

                        if (duelPlayerParamExist)
                            ImportDuelPlayerParam.OpenFile(duelPlayerParamPath);

                        if (playerSettingParamExist)
                            ImportPlayerSettingParam.OpenFile(playerSettingParamPath);
                        else
                            ImportPlayerSettingParam.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\playerSettingParam.bin.xfbin");


                        if (skillCustomizeParamExist)
                            ImportSkillCustomizeParam.OpenFile(skillCustomizeParamPath);

                        if (SpSkillCustomizeParamExist)
                            ImportSpSkillCustomizeParam.OpenFile(spSkillCustomizeParamPath);

                        if (skillIndexSettingParamExist)
                            ImportSkillIndexParam.OpenFile(skillIndexSettingParamPath);

                        if (supportSkillRecoverySpeedParamExist)
                            ImportSupportSkillRecoverySpeed.OpenFile(supportSkillRecoverySpeedParamPath);

                        if (privateCameraExist)
                            ImportPrivateCamera.OpenFile(privateCameraPath);

                        if (characterSelectParamExist)
                            ImportCharacterSelectParam.OpenFile(characterSelectParamPath);

                        if (costumeBreakColorParamExist)
                            ImportCostumeBreakColorParam.OpenFile(costumeBreakColorParamPath);

                        if (costumeParamExist)
                            ImportCostumeParam.OpenFile(costumeParamPath);
                        else
                            ImportCostumeParam.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeParam.bin.xfbin");

                        if (playerIconExist)
                            ImportPlayerIcon.OpenFile(playerIconPath);

                        if (cmnparamExist)
                            ImportCmnParam.OpenFile(cmnparamPath);

                        if (supportActionParamExist)
                            ImportSupportActionParam.OpenFile(supportActionParamPath);

                        if (awakeAuraExist)
                            ImportAwakeAura.OpenFile(awakeAuraPath);

                        if (appearanceAnmExist)
                            ImportAppearanceAnm.OpenFile(appearanceAnmPath);

                        if (afterAttachObjectExist)
                            ImportAfterAttachObject.OpenFile(afterAttachObjectPath);

                        if (playerDoubleEffectParamExist)
                            ImportPlayerDoubleEffectParam.OpenFile(playerDoubleEffectParamPath);

                        if (spTypeSupportParamExist)
                            ImportSpTypeSupportParam.OpenFile(spTypeSupportParamPath);

                        if (costumeBreakParamExist)
                            ImportCostumeBreakParam.OpenFile(costumeBreakParamPath);


                        if (messageInfoExist)
                            ImportMessageInfo.OpenFiles(messageInfoPath);

                        if (damageeffExist)
                            ImportDamageEff.OpenFile(damageeffPath);


                        if (effectprmExist)
                            ImportEffectPrm.OpenFile(effectprmPath);

                        OriginalDamageEff.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\damageeff.bin.xfbin");
                        OriginalEffectPrm.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\effectprm.bin.xfbin");
                        OriginalDamagePrm.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\damageprm.bin.xfbin");

                        if (damageprmExist)
                            ImportDamagePrm.OpenFile(damageprmPath);

                        foreach (CharacodeEditorModel character in ExportCharacterList)
                        {
                            bool ReplaceCharacter = false;
                            for (int i = 0; i < Characode.CharacodeList.Count; i++)
                            {
                                if (Characode.CharacodeList[i].CharacodeName == character.CharacodeName)
                                {
                                    ReplaceCharacter = true;
                                    break;
                                }
                            }
                            bool partner = false;


                            string character_path = mod_path + "\\Characters\\" + character.CharacodeName + "\\data";
                            Directory.CreateDirectory(character_path + "\\spc");
                            Directory.CreateDirectory(character_path + "\\rpg\\param");
                            Directory.CreateDirectory(character_path + "\\ui\\max\\select");
                            Directory.CreateDirectory(character_path + "\\sound");

                            var MyCharacterIni = new IniFile(mod_path + "\\Characters\\" + character.CharacodeName + "\\character_config.ini");
                            //Save Character Config
                            MyCharacterIni.Write("Partner", "false", "ModManager");
                            MyCharacterIni.Write("Page", "-1", "ModManager");
                            MyCharacterIni.Write("Slot", "-1", "ModManager");
                            DuelPlayerParamEditorViewModel ExportDuelPlayerParam = new DuelPlayerParamEditorViewModel();
                            PlayerSettingParamViewModel ExportPlayerSettingParam = new PlayerSettingParamViewModel();
                            SkillCustomizeParamViewModel ExportSkillCustomizeParam = new SkillCustomizeParamViewModel();
                            SpSkillCustomizeParamViewModel ExportSpSkillCustomizeParam = new SpSkillCustomizeParamViewModel();
                            SkillIndexSettingParamViewModel ExportSkillIndexParam = new SkillIndexSettingParamViewModel();
                            SupportSkillRecoverySpeedParamViewModel ExportSupportSkillRecoverySpeed = new SupportSkillRecoverySpeedParamViewModel();
                            PrivateCameraViewModel ExportPrivateCamera = new PrivateCameraViewModel();
                            CharacterSelectParamViewModel ExportCharacterSelectParam = new CharacterSelectParamViewModel();
                            CostumeBreakColorParamViewModel ExportCostumeBreakColorParam = new CostumeBreakColorParamViewModel();
                            CostumeParamViewModel ExportCostumeParam = new CostumeParamViewModel();
                            PlayerIconViewModel ExportPlayerIcon = new PlayerIconViewModel();
                            cmnparamViewModel ExportCmnParam = new cmnparamViewModel();
                            SupportActionParamViewModel ExportSupportActionParam = new SupportActionParamViewModel();
                            AwakeAuraViewModel ExportAwakeAura = new AwakeAuraViewModel();
                            AppearanceAnmViewModel ExportAppearanceAnm = new AppearanceAnmViewModel();
                            AfterAttachObjectViewModel ExportAfterAttachObject = new AfterAttachObjectViewModel();
                            PlayerDoubleEffectParamViewModel ExportPlayerDoubleEffectParam = new PlayerDoubleEffectParamViewModel();
                            SpTypeSupportParamViewModel ExportSpTypeSupportParam = new SpTypeSupportParamViewModel();
                            CostumeBreakParamViewModel ExportCostumeBreakParam = new CostumeBreakParamViewModel();
                            MessageInfoViewModel ExportMessageInfo = new MessageInfoViewModel();
                            DamageEffViewModel ExportDamageEff = new DamageEffViewModel();
                            EffectPrmViewModel ExportEffectPrm = new EffectPrmViewModel();
                            DamagePrmViewModel ExportDamagePrm = new DamagePrmViewModel();
                            /*----------------------------------------REQUIRED FILES--------------------------------------*/

                            string moddingAPIPath = Path.GetDirectoryName(DataWin32Path_field) + "\\moddingapi\\mods\\base_game";
                            string character_moddingAPI_path = mod_path + "\\Characters\\" + character.CharacodeName + "\\moddingapi\\mods\\base_game";
                            Directory.CreateDirectory(character_moddingAPI_path);
                            if (Directory.Exists(moddingAPIPath))
                            {
                                //Special Conditions
                                string specialCondParamPath = moddingAPIPath + "\\specialCondParam.xfbin";
                                if (File.Exists(specialCondParamPath))
                                {
                                    byte[] FileBytes = File.ReadAllBytes(specialCondParamPath);
                                    int EntryCount = FileBytes.Length / 0x20;

                                    for (int z = 0; z < EntryCount; z++)
                                    {
                                        int ptr = 0x20 * z;
                                        string ConditionName = BinaryReader.b_ReadString(FileBytes, ptr);
                                        int CondCharacodeID = BinaryReader.b_ReadIntFromTwoBytes(FileBytes, ptr + 0x17);
                                        if (CondCharacodeID == character.CharacodeIndex)
                                        {
                                            byte[] Section = new byte[0x20];
                                            Section = BinaryReader.b_ReplaceString(Section, ConditionName, 0);
                                            Section = BinaryReader.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x17);
                                            File.WriteAllBytes(character_moddingAPI_path + "\\specialCondParam.xfbin", Section);
                                            break;
                                        }
                                    }
                                }
                                //Partners
                                string partnerSlotParamPath = moddingAPIPath + "\\partnerSlotParam.xfbin";
                                if (File.Exists(partnerSlotParamPath))
                                {
                                    byte[] FileBytes = File.ReadAllBytes(partnerSlotParamPath);
                                    int EntryCount = FileBytes.Length / 0x20;

                                    for (int z = 0; z < EntryCount; z++)
                                    {
                                        int ptr = 0x20 * z;
                                        string ConditionName = BinaryReader.b_ReadString(FileBytes, ptr);
                                        int CondCharacodeID = BinaryReader.b_ReadIntFromTwoBytes(FileBytes, ptr + 0x17);
                                        if (CondCharacodeID == character.CharacodeIndex)
                                        {
                                            byte[] Section = new byte[0x20];
                                            Section = BinaryReader.b_ReplaceString(Section, ConditionName, 0);
                                            Section = BinaryReader.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x17);
                                            File.WriteAllBytes(character_moddingAPI_path + "\\partnerSlotParam.xfbin", Section);

                                            //Save Character Config
                                            MyCharacterIni.Write("Partner", "true", "ModManager");
                                            MyCharacterIni.Write("Page", "0", "ModManager");
                                            MyCharacterIni.Write("Slot", "0", "ModManager");
                                            partner = true;
                                            break;
                                        }
                                    }
                                }
                                //Susanoo Fix
                                string susanooCondParamPath = moddingAPIPath + "\\susanooCondParam.xfbin";
                                if (File.Exists(susanooCondParamPath))
                                {
                                    byte[] FileBytes = File.ReadAllBytes(susanooCondParamPath);
                                    int EntryCount = FileBytes.Length / 0x20;

                                    for (int z = 0; z < EntryCount; z++)
                                    {
                                        int ptr = 0x20 * z;
                                        string ConditionName = BinaryReader.b_ReadString(FileBytes, ptr);
                                        int CondCharacodeID = BinaryReader.b_ReadIntFromTwoBytes(FileBytes, ptr + 0x17);
                                        if (CondCharacodeID == character.CharacodeIndex)
                                        {
                                            byte[] Section = new byte[0x20];
                                            Section = BinaryReader.b_ReplaceString(Section, ConditionName, 0);
                                            Section = BinaryReader.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x17);
                                            File.WriteAllBytes(character_moddingAPI_path + "\\susanooCondParam.xfbin", Section);
                                            break;
                                        }
                                    }
                                }
                            }

                            //duelPlayerParam
                            if (duelPlayerParamExist)
                            {

                                foreach (DuelPlayerParamModel duelEntry in ImportDuelPlayerParam.DuelPlayerParamList)
                                {
                                    if (duelEntry.BinName.Contains(character.CharacodeName))
                                    {
                                        ExportDuelPlayerParam.DuelPlayerParamList.Add((DuelPlayerParamModel)duelEntry.Clone());

                                        for (int i = 0; i < 20; i++)
                                        {
                                            if (!awakeningModels.Contains(duelEntry.AwakeCostumes[i].CostumeName))
                                                awakeningModels.Add(duelEntry.AwakeCostumes[i].CostumeName);
                                            if (!baseModels.Contains(duelEntry.BaseCostumes[i].CostumeName))
                                                baseModels.Add(duelEntry.BaseCostumes[i].CostumeName);
                                        }
                                        break;

                                    }
                                }
                                if (ExportDuelPlayerParam.DuelPlayerParamList.Count < 1 && !ReplaceCharacter)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing duelPlayerParam entry.");
                                    continue;
                                }
                            } else if (!duelPlayerParamExist && !ReplaceCharacter)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing duelPlayerParam file.");
                                continue;
                            }
                            //playerSettingParam
                            foreach (PlayerSettingParamModel PSPEntry in ImportPlayerSettingParam.PlayerSettingParamList)
                            {
                                if (PSPEntry.CharacodeID == character.CharacodeIndex)
                                {
                                    ExportPlayerSettingParam.PlayerSettingParamList.Add((PlayerSettingParamModel)PSPEntry.Clone());
                                    if (!ExportMessageNameList.Contains(PSPEntry.CharacterNameMessageID))
                                        ExportMessageNameList.Add(PSPEntry.CharacterNameMessageID);
                                    if (!ExportMessageNameList.Contains(PSPEntry.CostumeDescriptionMessageID))
                                        ExportMessageNameList.Add(PSPEntry.CostumeDescriptionMessageID);
                                }
                            }
                            //skillCustomizeParam
                            if (skillCustomizeParamExist)
                            {

                                foreach (SkillCustomizeParamModel SkillEntry in ImportSkillCustomizeParam.SkillCustomizeParamList)
                                {
                                    if (SkillEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportSkillCustomizeParam.SkillCustomizeParamList.Add((SkillCustomizeParamModel)SkillEntry.Clone());
                                        if (messageInfoExist)
                                        {
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu1_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu1_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu2_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu2_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu3_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu3_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu4_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu4_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu5_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu5_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu6_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu6_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu1_awa_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu1_awa_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu2_awa_air_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu2_awa_air_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu1_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu1_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu2_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu2_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu3_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu3_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu4_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu4_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu5_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu5_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu6_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu6_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu1_awa_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu1_awa_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu2_awa_normal_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu2_awa_normal_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu1_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu1_ex_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu2_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu2_ex_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu3_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu3_ex_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu4_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu4_ex_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu5_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu5_ex_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu6_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu6_ex_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu1_awa_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu1_awa_ex_name);
                                            if (!ExportMessageNameList.Contains(SkillEntry.Jutsu2_awa_ex_name))
                                                ExportMessageNameList.Add(SkillEntry.Jutsu2_awa_ex_name);
                                        }
                                        break;
                                    }
                                }
                                if (ExportSkillCustomizeParam.SkillCustomizeParamList.Count < 1 && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing skillCustomizeParam entry.");
                                    continue;
                                }
                            } else if (!playerSettingParamExist && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing skillCustomizeParam file.");
                                continue;
                            }
                            //spSkillCustomizeParam
                            if (SpSkillCustomizeParamExist)
                            {

                                foreach (SpSkillCustomizeParamModel SpSkillEntry in ImportSpSkillCustomizeParam.SpSkillCustomizeParamList)
                                {
                                    if (SpSkillEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportSpSkillCustomizeParam.SpSkillCustomizeParamList.Add((SpSkillCustomizeParamModel)SpSkillEntry.Clone());
                                        if (messageInfoExist)
                                        {
                                            if (!ExportMessageNameList.Contains(SpSkillEntry.Ultimate1name))
                                                ExportMessageNameList.Add(SpSkillEntry.Ultimate1name);
                                            if (!ExportMessageNameList.Contains(SpSkillEntry.Ultimate2name))
                                                ExportMessageNameList.Add(SpSkillEntry.Ultimate2name);
                                            if (!ExportMessageNameList.Contains(SpSkillEntry.Ultimate3name))
                                                ExportMessageNameList.Add(SpSkillEntry.Ultimate3name);
                                            if (!ExportMessageNameList.Contains(SpSkillEntry.Ultimate4name))
                                                ExportMessageNameList.Add(SpSkillEntry.Ultimate4name);
                                        }
                                        break;
                                    }
                                }
                                if (ExportSpSkillCustomizeParam.SpSkillCustomizeParamList.Count < 1 && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing spSkillCustomizeParam entry.");
                                    continue;
                                }
                            } else if (!SpSkillCustomizeParamExist && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing spSkillCustomizeParam file.");
                                continue;
                            }
                            //skillIndexSettingParam
                            if (skillIndexSettingParamExist)
                            {

                                foreach (SkillIndexSettingParamModel SkillIndexEntry in ImportSkillIndexParam.SkillIndexSettingParamList)
                                {
                                    if (SkillIndexEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportSkillIndexParam.SkillIndexSettingParamList.Add((SkillIndexSettingParamModel)SkillIndexEntry.Clone());
                                        break;
                                    }
                                }
                                if (ExportSkillIndexParam.SkillIndexSettingParamList.Count < 1 && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing skillIndexSettingParam entry.");
                                    continue;
                                }
                            } else if (!SpSkillCustomizeParamExist && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing skillIndexSettingParam file.");
                                continue;
                            }

                            //supportSkillRecoverySpeedParam
                            if (supportSkillRecoverySpeedParamExist)
                            {

                                foreach (SupportSkillRecoverySpeedParamModel supportSkillRecoveryEntry in ImportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList)
                                {
                                    if (supportSkillRecoveryEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Add((SupportSkillRecoverySpeedParamModel)supportSkillRecoveryEntry.Clone());
                                        break;
                                    }
                                }
                                if (ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Count < 1 && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing supportSkillRecoverySpeedParam entry.");
                                    continue;
                                }
                            } else if (!supportSkillRecoverySpeedParamExist && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing supportSkillRecoverySpeedParam file.");
                                continue;
                            }
                            //privateCamera
                            if (privateCameraExist)
                            {

                                foreach (PrivateCameraModel PrivateCameraEntry in ImportPrivateCamera.PrivateCameraList)
                                {
                                    if (PrivateCameraEntry.CharacodeIndex == character.CharacodeIndex)
                                    {
                                        ExportPrivateCamera.PrivateCameraList.Add((PrivateCameraModel)PrivateCameraEntry.Clone());
                                        break;
                                    }
                                }
                                if (ExportPrivateCamera.PrivateCameraList.Count < 1 && !ReplaceCharacter)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing privateCamera entry.");
                                    continue;
                                }
                            } else if (!privateCameraExist && !ReplaceCharacter)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing privateCamera file.");
                                continue;
                            }


                            //characterSelectParam
                            if (characterSelectParamExist)
                            {

                                foreach (CharacterSelectParamModel CharacterSelectParamEntry in ImportCharacterSelectParam.CharacterSelectParamList)
                                {
                                    for (int i = 0; i < ExportPlayerSettingParam.PlayerSettingParamList.Count; i++)
                                    {
                                        if (CharacterSelectParamEntry.CSP_code == ExportPlayerSettingParam.PlayerSettingParamList[i].PSP_code)
                                        {
                                            ExportCharacterSelectParam.CharacterSelectParamList.Add((CharacterSelectParamModel)CharacterSelectParamEntry.Clone());
                                            if (messageInfoExist)
                                            {
                                                if (!ExportMessageNameList.Contains(CharacterSelectParamEntry.CostumeName))
                                                    ExportMessageNameList.Add(CharacterSelectParamEntry.CostumeName);
                                                if (!ExportMessageNameList.Contains(CharacterSelectParamEntry.CostumeDescription))
                                                    ExportMessageNameList.Add(CharacterSelectParamEntry.CostumeDescription);
                                            }
                                            break;
                                        }
                                    }

                                }
                                if (ExportCharacterSelectParam.CharacterSelectParamList.Count < 1 && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing characterSelectParam entry.");
                                    continue;
                                }
                            } else if (!characterSelectParamExist && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing characterSelectParam file.");
                                continue;
                            }
                            //costumeBreakColorParam
                            if (costumeBreakColorParamExist)
                            {

                                foreach (CostumeBreakColorParamModel CostumeBreakColorEntry in ImportCostumeBreakColorParam.CostumeBreakColorParamList)
                                {
                                    for (int i = 0; i < ExportPlayerSettingParam.PlayerSettingParamList.Count; i++)
                                    {
                                        if (CostumeBreakColorEntry.PlayerSettingParamID == ExportPlayerSettingParam.PlayerSettingParamList[i].PSP_ID)
                                        {
                                            ExportCostumeBreakColorParam.CostumeBreakColorParamList.Add((CostumeBreakColorParamModel)CostumeBreakColorEntry.Clone());
                                            break;
                                        }
                                    }

                                }
                                //if (ExportCostumeBreakColorParam.CostumeBreakColorParamList.Count < 1 && !ReplaceCharacter && !partner) {
                                //    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing costumeBreakColorParam entry.");
                                //    continue;
                                //}
                            }
                            //else if (!characterSelectParamExist && !ReplaceCharacter && !partner) {
                            //    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing costumeBreakColorParam file.");
                            //    continue;
                            //}
                            //costumeParam
                            // if (costumeParamExist) {

                            foreach (CostumeParamModel CostumeEntry in ImportCostumeParam.CostumeParamList)
                            {
                                for (int i = 0; i < ExportPlayerSettingParam.PlayerSettingParamList.Count; i++)
                                {
                                    if (CostumeEntry.PlayerSettingParamID == ExportPlayerSettingParam.PlayerSettingParamList[i].PSP_ID)
                                    {
                                        ExportCostumeParam.CostumeParamList.Add((CostumeParamModel)CostumeEntry.Clone());
                                        if (messageInfoExist)
                                        {
                                            if (!ExportMessageNameList.Contains(CostumeEntry.CharacterName))
                                                ExportMessageNameList.Add(CostumeEntry.CharacterName);
                                        }
                                    }
                                }

                            }
                            if (ExportCostumeParam.CostumeParamList.Count < 1 && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing costumeParam entry.");
                                continue;
                            }
                            //} else if (!costumeParamExist && !ReplaceCharacter && !partner) {
                            //    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing costumeParam file.");
                            //    continue;
                            //}
                            //player_icon
                            if (playerIconExist)
                            {

                                foreach (PlayerIconModel PlayerIconEntry in ImportPlayerIcon.playerIconList)
                                {
                                    if (PlayerIconEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportPlayerIcon.playerIconList.Add((PlayerIconModel)PlayerIconEntry.Clone());
                                    }
                                }
                                if (ExportPlayerIcon.playerIconList.Count < 1 && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing player_icon entry.");
                                    continue;
                                }
                            } else if (!playerIconExist && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing player_icon file.");
                                continue;
                            }
                            //cmnparam
                            if (cmnparamExist)
                            {

                                foreach (player_sndModel playerSndEntry in ImportCmnParam.PlayerSndList)
                                {
                                    if (playerSndEntry.PlayerCharacode == character.CharacodeName)
                                    {
                                        ExportCmnParam.PlayerSndList.Add((player_sndModel)playerSndEntry.Clone());
                                        break;
                                    }
                                }
                                if (ExportCmnParam.PlayerSndList.Count < 1 && !ReplaceCharacter)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing cmnparam player_snd entry.");
                                    continue;
                                }
                            } else if (!cmnparamExist && !ReplaceCharacter)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing cmnparam player_snd file.");
                                continue;
                            }
                            //supportActionParam
                            if (supportActionParamExist)
                            {

                                foreach (SupportActionParamModel supportActionEntry in ImportSupportActionParam.SupportActionParamList)
                                {
                                    if (supportActionEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportSupportActionParam.SupportActionParamList.Add((SupportActionParamModel)supportActionEntry.Clone());
                                        break;
                                    }
                                }
                                if (ExportSupportActionParam.SupportActionParamList.Count < 1 && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing supportActionParam entry.");
                                    continue;
                                }
                            } else if (!playerSettingParamExist && !ReplaceCharacter && !partner)
                            {
                                MessageBox.Show("Character with characode " + character.CharacodeName + " wasn't exported, cuz it has missing supportActionParam file.");
                                continue;
                            }
                            /*----------------------------------------NOT REQUIRED FILES--------------------------------------*/
                            //awakeAura
                            if (awakeAuraExist)
                            {

                                foreach (AwakeAuraModel awakeAuraEntry in ImportAwakeAura.AwakeAuraList)
                                {
                                    if (awakeAuraEntry.Characode == character.CharacodeName)
                                    {
                                        ExportAwakeAura.AwakeAuraList.Add((AwakeAuraModel)awakeAuraEntry.Clone());
                                    }
                                }
                            }
                            //appearanceAnm
                            if (appearanceAnmExist)
                            {

                                foreach (AppearanceAnmModel appearanceEntry in ImportAppearanceAnm.AppearanceAnmList)
                                {
                                    if (appearanceEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportAppearanceAnm.AppearanceAnmList.Add((AppearanceAnmModel)appearanceEntry.Clone());
                                    }
                                }
                            }
                            //afterAttachObject
                            if (afterAttachObjectExist)
                            {

                                foreach (AfterAttachObjectModel afterAttachEntry in ImportAfterAttachObject.AfterAttachObjectList)
                                {
                                    if (afterAttachEntry.Costume == character.CharacodeName || awakeningModels.Contains(afterAttachEntry.Characode) || baseModels.Contains(afterAttachEntry.Characode))
                                    {
                                        ExportAfterAttachObject.AfterAttachObjectList.Add((AfterAttachObjectModel)afterAttachEntry.Clone());
                                    }
                                }
                            }
                            //playerDoubleEffectParam
                            if (playerDoubleEffectParamExist)
                            {

                                foreach (PlayerDoubleEffectParamModel playerDoubleEffectEntry in ImportPlayerDoubleEffectParam.PlayerDoubleEffectParamList)
                                {
                                    if (playerDoubleEffectEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportPlayerDoubleEffectParam.PlayerDoubleEffectParamList.Add((PlayerDoubleEffectParamModel)playerDoubleEffectEntry.Clone());
                                    }
                                }
                            }
                            //spTypeSupportParam
                            if (spTypeSupportParamExist)
                            {

                                foreach (SpTypeSupportParamModel spTypeSupportEntry in ImportSpTypeSupportParam.SpTypeSupportParamList)
                                {
                                    if (spTypeSupportEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportSpTypeSupportParam.SpTypeSupportParamList.Add((SpTypeSupportParamModel)spTypeSupportEntry.Clone());
                                        if (!ExportMessageNameList.Contains(spTypeSupportEntry.DownJutsuName))
                                            ExportMessageNameList.Add(spTypeSupportEntry.DownJutsuName);
                                        if (!ExportMessageNameList.Contains(spTypeSupportEntry.UpJutsuName))
                                            ExportMessageNameList.Add(spTypeSupportEntry.UpJutsuName);
                                        if (!ExportMessageNameList.Contains(spTypeSupportEntry.LeftJutsuName))
                                            ExportMessageNameList.Add(spTypeSupportEntry.LeftJutsuName);
                                        if (!ExportMessageNameList.Contains(spTypeSupportEntry.RightJutsuName))
                                            ExportMessageNameList.Add(spTypeSupportEntry.RightJutsuName);
                                        break;
                                    }
                                }
                            }

                            //costumeBreakParam
                            if (costumeBreakParamExist)
                            {

                                foreach (CostumeBreakParamModel costumeBreakEntry in ImportCostumeBreakParam.CostumeBreakParamList)
                                {
                                    if (costumeBreakEntry.CharacodeID == character.CharacodeIndex)
                                    {
                                        ExportCostumeBreakParam.CostumeBreakParamList.Add((CostumeBreakParamModel)costumeBreakEntry.Clone());
                                    }
                                }
                            }
                            //damageprm
                            if (damageprmExist)
                            {
                                for (int i = OriginalDamagePrm.DamagePrmList.Count; i < ImportDamagePrm.DamagePrmList.Count; i++)
                                {
                                    if (ImportDamagePrm.DamagePrmList[i].Data[0] != 0)
                                    {
                                        ExportDamagePrm.DamagePrmList.Add((DamagePrmModel)ImportDamagePrm.DamagePrmList[i].Clone());
                                    }
                                }

                            }

                            //prm_load
                            string prm_load_path = DataWin32Path_field + "\\spcload\\" + character.CharacodeName + "prm_load.bin.xfbin";
                            string prm_path = "";
                            if (File.Exists(prm_load_path))
                            {
                                PRMLoadEditorViewModel ImportPRMLoad = new PRMLoadEditorViewModel();
                                ImportPRMLoad.OpenFile(prm_load_path);

                                //look for prm file in data_win32
                                foreach (PRMLoad_Model PRM_Load_Entry in ImportPRMLoad.PRMLoadList)
                                {
                                    if (PRM_Load_Entry.FileName.Contains("prm") && PRM_Load_Entry.FileName.Contains("<code>"))
                                    {
                                        prm_path = DataWin32Path_field + "\\" + PRM_Load_Entry.FilePath + "\\" + PRM_Load_Entry.FileName.Replace("<code>", character.CharacodeName) + ".xfbin";
                                        break;
                                    }
                                }
                                //prm
                                prm_path = prm_path.Replace("/", "\\");
                                if (File.Exists(prm_path))
                                {
                                    PRMEditorViewModel ImportPRM = new PRMEditorViewModel();
                                    ImportPRM.OpenFile(prm_path);

                                    for (int ver = 0; ver < ImportPRM.VerList.Count; ver++)
                                    {
                                        for (int pl_anm = 0; pl_anm < ImportPRM.VerList[ver].PL_ANM_Sections.Count; pl_anm++)
                                        {
                                            for (int function = 0; function < ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList.Count; function++)
                                            {
                                                //damageeff
                                                if (damageeffExist)
                                                {
                                                    bool DamageEffExistInVanila = false;
                                                    foreach (DamageEffModel damageEffEntry in OriginalDamageEff.DamageEffList)
                                                    {
                                                        if (damageEffEntry.DamageEffID == ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].DamageHitEffectID)
                                                        {
                                                            DamageEffExistInVanila = true;
                                                            break;
                                                        }
                                                    }
                                                    if (!DamageEffExistInVanila)
                                                    {
                                                        foreach (DamageEffModel damageEffEntry in ExportDamageEff.DamageEffList)
                                                        {
                                                            if (damageEffEntry.DamageEffID == ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].DamageHitEffectID)
                                                            {
                                                                DamageEffExistInVanila = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    if (!DamageEffExistInVanila)
                                                    {
                                                        foreach (DamageEffModel damageEffEntry in ImportDamageEff.DamageEffList)
                                                        {
                                                            if (damageEffEntry.DamageEffID == ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].DamageHitEffectID)
                                                            {
                                                                DamageEffModel new_entry = (DamageEffModel)damageEffEntry.Clone();

                                                                bool ExtraDamageEffExistInVanila = false;
                                                                foreach (DamageEffModel ExtraDamageEffEntry in OriginalDamageEff.DamageEffList)
                                                                {
                                                                    if (ExtraDamageEffEntry.DamageEffID == new_entry.ExtraDamageEffID)
                                                                    {
                                                                        ExtraDamageEffExistInVanila = true;
                                                                        break;
                                                                    }
                                                                }
                                                                if (!ExtraDamageEffExistInVanila)
                                                                    new_entry.ExtraDamageEffID = 0;
                                                                new_entry.ExtraEffectPrmID = 0;
                                                                ExportDamageEff.DamageEffList.Add(new_entry);
                                                                //effectprm
                                                                if (effectprmExist)
                                                                {
                                                                    bool EffectPrmExistInVanila = false;
                                                                    foreach (EffectPrmModel EffectPrmEntry in OriginalEffectPrm.EffectPrmList)
                                                                    {
                                                                        if (EffectPrmEntry.EffectPrmID == new_entry.EffectPrmID)
                                                                        {
                                                                            EffectPrmExistInVanila = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                    if (!EffectPrmExistInVanila)
                                                                    {
                                                                        foreach (EffectPrmModel EffectPrmEntry in ImportEffectPrm.EffectPrmList)
                                                                        {
                                                                            if (EffectPrmEntry.EffectPrmID == new_entry.EffectPrmID)
                                                                            {
                                                                                ExportEffectPrm.EffectPrmList.Add(EffectPrmEntry);
                                                                                break;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }


                                                //check all message entries in prm
                                                if (ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].FunctionID == 0x96 && messageInfoExist)
                                                {
                                                    if (!ExportMessageNameList.Contains(ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].StringParam))
                                                        ExportMessageNameList.Add(ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].StringParam);
                                                }
                                            }
                                        }
                                    }
                                }

                            }

                            //messageInfo
                            if (messageInfoExist)
                            {
                                for (int i = 1; i < 20; i++)
                                {
                                    ExportMessageNameList.Add(character.CharacodeName + "_bd_" + i.ToString("D2"));
                                }
                                if (ExportMessageNameList.IndexOf("") != -1)
                                    ExportMessageNameList.RemoveAt(ExportMessageNameList.IndexOf(""));
                                for (int i = 0; i < ExportMessageNameList.Count; i++)
                                {
                                    ImportMessageInfo.MessageInfo_preview_List = ImportMessageInfo.MessageInfo_List[0];
                                    for (int message = 0; message < ImportMessageInfo.MessageInfo_preview_List.Count; message++)
                                    {
                                        if (BitConverter.ToString(ImportMessageInfo.MessageInfo_preview_List[message].CRC32Code) == BitConverter.ToString(BinaryReader.crc32(ExportMessageNameList[i])))
                                        {

                                            for (int l = 0; l < Program.langList.Length; l++)
                                            {
                                                MessageInfoModel copy_entry = (MessageInfoModel)ImportMessageInfo.MessageInfo_List[l][message].Clone();
                                                ExportMessageInfo.MessageInfo_List[l].Add(copy_entry);
                                            }
                                            break;
                                        }
                                    }
                                }


                            }



                            //Save All Params

                            if (ExportDuelPlayerParam.DuelPlayerParamList.Count > 0)
                                ExportDuelPlayerParam.SaveFileAs(character_path + "\\spc\\duelPlayerParam.xfbin");
                            if (ExportPlayerSettingParam.PlayerSettingParamList.Count > 0)
                                ExportPlayerSettingParam.SaveFileAs(character_path + "\\spc\\playerSettingParam.bin.xfbin");
                            if (ExportSkillCustomizeParam.SkillCustomizeParamList.Count > 0)
                                ExportSkillCustomizeParam.SaveFileAs(character_path + "\\spc\\skillCustomizeParam.xfbin");
                            if (ExportSpSkillCustomizeParam.SpSkillCustomizeParamList.Count > 0)
                                ExportSpSkillCustomizeParam.SaveFileAs(character_path + "\\spc\\spSkillCustomizeParam.xfbin");
                            if (ExportSkillIndexParam.SkillIndexSettingParamList.Count > 0)
                                ExportSkillIndexParam.SaveFileAs(character_path + "\\spc\\skillIndexSettingParam.xfbin");
                            if (ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Count > 0)
                                ExportSupportSkillRecoverySpeed.SaveFileAs(character_path + "\\spc\\supportSkillRecoverySpeedParam.xfbin");
                            if (ExportPlayerIcon.playerIconList.Count > 0)
                                ExportPlayerIcon.SaveFileAs(character_path + "\\spc\\player_icon.xfbin");
                            if (ExportAwakeAura.AwakeAuraList.Count > 0)
                                ExportAwakeAura.SaveFileAs(character_path + "\\spc\\awakeAura.xfbin");
                            if (ExportAppearanceAnm.AppearanceAnmList.Count > 0)
                                ExportAppearanceAnm.SaveFileAs(character_path + "\\spc\\appearanceAnm.xfbin");
                            if (ExportCharacterSelectParam.CharacterSelectParamList.Count > 0)
                                ExportCharacterSelectParam.SaveFileAs(character_path + "\\ui\\max\\select\\characterSelectParam.xfbin");
                            if (ExportAfterAttachObject.AfterAttachObjectList.Count > 0)
                                ExportAfterAttachObject.SaveFileAs(character_path + "\\spc\\afterAttachObject.xfbin");
                            if (ExportSpTypeSupportParam.SpTypeSupportParamList.Count > 0)
                                ExportSpTypeSupportParam.SaveFileAs(character_path + "\\spc\\spTypeSupportParam.xfbin");
                            if (ExportCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                ExportCostumeBreakParam.SaveFileAs(character_path + "\\spc\\costumeBreakParam.xfbin");
                            if (ExportCostumeBreakColorParam.CostumeBreakColorParamList.Count > 0)
                                ExportCostumeBreakColorParam.SaveFileAs(character_path + "\\spc\\costumeBreakColorParam.xfbin");
                            if (ExportCostumeParam.CostumeParamList.Count > 0)
                                ExportCostumeParam.SaveFileAs(character_path + "\\rpg\\param\\costumeParam.bin.xfbin");
                            if (ExportPrivateCamera.PrivateCameraList.Count > 0)
                                ExportPrivateCamera.SaveFileAs(character_path + "\\spc\\privateCamera.bin.xfbin");
                            if (ExportPlayerDoubleEffectParam.PlayerDoubleEffectParamList.Count > 0)
                                ExportPlayerDoubleEffectParam.SaveFileAs(character_path + "\\spc\\playerDoubleEffectParam.xfbin");
                            if (ExportSupportActionParam.SupportActionParamList.Count > 0)
                                ExportSupportActionParam.SaveFileAs(character_path + "\\spc\\supportActionParam.xfbin");
                            if (ExportCmnParam.PlayerSndList.Count > 0)
                                ExportCmnParam.SaveFileAs(character_path + "\\sound\\cmnparam.xfbin");
                            if (ExportDamageEff.DamageEffList.Count > 0)
                                ExportDamageEff.SaveFileAs(character_path + "\\spc\\damageeff.bin.xfbin");
                            if (ExportEffectPrm.EffectPrmList.Count > 0)
                                ExportEffectPrm.SaveFileAs(character_path + "\\spc\\effectprm.bin.xfbin");
                            if (ExportMessageInfo.MessageInfo_List[0].Count > 0)
                                ExportMessageInfo.SaveFileAs(character_path);
                            if (ExportDamagePrm.DamagePrmList.Count > 0)
                                ExportDamagePrm.SaveFileAs(character_path + "\\spc\\damageprm.bin.xfbin");


                            

                        }


                        break;
                    //Compile Stage Mod
                    case 1:

                        MessageInfoViewModel ImportStageMessageInfo = new MessageInfoViewModel();
                        if (messageInfoExist)
                            ImportStageMessageInfo.OpenFiles(messageInfoPath);

                        int StageIndex = 0;
                        foreach (StageInfoModel stage in ExportStageList)
                        {

                            StageInfoViewModel ExportStage = new StageInfoViewModel();
                            MessageInfoViewModel ExportStageMessageInfo = new MessageInfoViewModel();

                            ExportStage.StageInfoList.Add((StageInfoModel)stage.Clone());
                            //MessageInfo
                            if (messageInfoExist)
                            {
                                ImportStageMessageInfo.MessageInfo_preview_List = ImportStageMessageInfo.MessageInfo_List[0];
                                for (int message = 0; message < ImportStageMessageInfo.MessageInfo_preview_List.Count; message++)
                                {
                                    if (BitConverter.ToString(ImportStageMessageInfo.MessageInfo_preview_List[message].CRC32Code) == BitConverter.ToString(BinaryReader.crc32(StageMessageIDList[StageIndex])))
                                    {

                                        for (int l = 0; l < Program.langList.Length; l++)
                                        {
                                            MessageInfoModel copy_entry = (MessageInfoModel)ImportStageMessageInfo.MessageInfo_List[l][message].Clone();
                                            ExportStageMessageInfo.MessageInfo_List[l].Add(copy_entry);
                                        }
                                        break;
                                    }
                                }
                            }
                            //Save All Params
                            string stage_path = mod_path + "\\Stages\\" + stage.StageName + "\\data";
                            Directory.CreateDirectory(stage_path + "\\stage");
                            ExportStage.SaveFileAs(stage_path + "\\stage\\StageInfo.bin.xfbin", true);
                            if (ExportStageMessageInfo.MessageInfo_List[0].Count > 0)
                                ExportStageMessageInfo.SaveFileAs(stage_path);


                            bool hellExist = false;
                            for (int i = 0; i < stage.FilePaths.Count; i++)
                            {
                                if (stage.FilePaths[i].FilePath.Contains("wall"))
                                {
                                    hellExist = true;
                                    break;
                                }
                            }

                            //Save Stage Config
                            var MyStageIni = new IniFile(mod_path + "\\Stages\\" + stage.StageName + "\\stage_config.ini");
                            MyStageIni.Write("BGM_ID", StageBGMIDList[StageIndex].ToString(), "ModManager");
                            MyStageIni.Write("MessageID", StageMessageIDList[StageIndex], "ModManager");
                            MyStageIni.Write("Hell", hellExist.ToString().ToLower(), "ModManager");

                            //Save Stage Icon
                            File.Copy(StageIconPathList[StageIndex], mod_path + "\\Stages\\" + stage.StageName + "\\stage_icon.dds", true);
                            //Save Stage Preview
                            File.Copy(StageImagePreviewPathList[StageIndex], mod_path + "\\Stages\\" + stage.StageName + "\\stage_preview.png", true);
                            StageIndex++;
                        }

                        break;
                    //Compile Character Model Mod
                    case 2:
                        CharacodeEditorViewModel ImportModelCharacode = new CharacodeEditorViewModel();
                        DuelPlayerParamEditorViewModel ImportModelDuelPlayerParam = new DuelPlayerParamEditorViewModel();
                        CharacterSelectParamViewModel ImportModelCharacterSelectParam = new CharacterSelectParamViewModel();
                        CostumeParamViewModel ImportModelCostumeParam = new CostumeParamViewModel();
                        PlayerIconViewModel ImportModelPlayerIcon = new PlayerIconViewModel();
                        CostumeBreakColorParamViewModel ImportModelCostumeBreakColorParam = new CostumeBreakColorParamViewModel();
                        CostumeBreakParamViewModel ImportModelCostumeBreakParam = new CostumeBreakParamViewModel();
                        MessageInfoViewModel ImportModelMessageInfo = new MessageInfoViewModel();

                        if (duelPlayerParamExist)
                            ImportModelDuelPlayerParam.OpenFile(duelPlayerParamPath);
                        else
                            ImportModelDuelPlayerParam.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\duelPlayerParam.xfbin");
                        if (characterSelectParamExist)
                            ImportModelCharacterSelectParam.OpenFile(characterSelectParamPath);
                        else
                            ImportModelCharacterSelectParam.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characterSelectParam.xfbin");
                        if (costumeParamExist)
                            ImportModelCostumeParam.OpenFile(costumeParamPath);
                        else
                            ImportModelCostumeParam.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeParam.bin.xfbin");
                        if (playerIconExist)
                            ImportModelPlayerIcon.OpenFile(playerIconPath);
                        else
                            ImportModelPlayerIcon.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\player_icon.xfbin");
                        if (costumeBreakColorParamExist)
                            ImportModelCostumeBreakColorParam.OpenFile(costumeBreakColorParamPath);
                        else
                            ImportModelCostumeBreakColorParam.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\costumeBreakColorParam.xfbin");
                        if (characodeExist)
                            ImportModelCharacode.OpenFile(characodePath);
                        else
                            ImportModelCharacode.OpenFile(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ParamFiles\\characode.bin.xfbin");
                        if (costumeBreakParamExist)
                            ImportModelCostumeBreakParam.OpenFile(costumeBreakParamPath);
                        if (messageInfoExist)
                            ImportModelMessageInfo.OpenFiles(messageInfoPath);

                        foreach (PlayerSettingParamModel model in ExportModelList)
                        {

                            PlayerSettingParamViewModel ExportModelPlayerSettingParam = new PlayerSettingParamViewModel();
                            CharacterSelectParamViewModel ExportModelCharacterSelectParam = new CharacterSelectParamViewModel();
                            CostumeParamViewModel ExportModelCostumeParam = new CostumeParamViewModel();
                            PlayerIconViewModel ExportModelPlayerIcon = new PlayerIconViewModel();
                            CostumeBreakColorParamViewModel ExportModelCostumeBreakColorParam = new CostumeBreakColorParamViewModel();
                            CostumeBreakParamViewModel ExportModelCostumeBreakParam = new CostumeBreakParamViewModel();
                            ObservableCollection<string> ExportModelMessageNameList = new ObservableCollection<string>();
                            MessageInfoViewModel ExportModelMessageInfo = new MessageInfoViewModel();

                            string characode = ImportModelCharacode.CharacodeList[model.CharacodeID - 1].CharacodeName;
                            int model_index = model.CostumeID;
                            string basemodel_code = "";
                            string awakemodel_code = "";

                            /*----------------------------------------REQUIRED FILES--------------------------------------*/

                            //playerSettingParam
                            ExportModelPlayerSettingParam.PlayerSettingParamList.Add((PlayerSettingParamModel)model.Clone());
                            if (!ExportModelMessageNameList.Contains(model.CharacterNameMessageID))
                                ExportModelMessageNameList.Add(model.CharacterNameMessageID);
                            if (!ExportModelMessageNameList.Contains(model.CostumeDescriptionMessageID))
                                ExportModelMessageNameList.Add(model.CostumeDescriptionMessageID);

                            //duelPlayerParam
                            foreach (DuelPlayerParamModel duelEntry in ImportModelDuelPlayerParam.DuelPlayerParamList)
                            {
                                if (duelEntry.BinName.Contains(characode))
                                {
                                    basemodel_code = duelEntry.BaseCostumes[model_index].CostumeName;
                                    awakemodel_code = duelEntry.AwakeCostumes[model_index].CostumeName;
                                    break;
                                }
                            }
                            if (basemodel_code == "")
                            {
                                MessageBox.Show("Model with PlayerSettingParam code " + model.PSP_code + " wasn't exported, cuz it has missing duelPlayerParam entry.");
                                continue;
                            }
                            //player_icon
                            foreach (PlayerIconModel PlayerIconEntry in ImportModelPlayerIcon.playerIconList)
                            {
                                if (PlayerIconEntry.CharacodeID == model.CharacodeID && PlayerIconEntry.CostumeID == model_index)
                                {
                                    ExportModelPlayerIcon.playerIconList.Add((PlayerIconModel)PlayerIconEntry.Clone());
                                    break;
                                }
                            }
                            if (ExportModelPlayerIcon.playerIconList.Count < 1)
                            {
                                MessageBox.Show("Model with PlayerSettingParam code " + model.PSP_code + " wasn't exported, cuz it has missing player_icon entry.");
                                continue;
                            }
                            //characterSelectParam
                            foreach (CharacterSelectParamModel CharacterSelectParamEntry in ImportModelCharacterSelectParam.CharacterSelectParamList)
                            {
                                if (CharacterSelectParamEntry.CSP_code == model.PSP_code)
                                {
                                    ExportModelCharacterSelectParam.CharacterSelectParamList.Add((CharacterSelectParamModel)CharacterSelectParamEntry.Clone());
                                    if (!ExportModelMessageNameList.Contains(CharacterSelectParamEntry.CostumeDescription))
                                        ExportModelMessageNameList.Add(CharacterSelectParamEntry.CostumeDescription);
                                    if (!ExportModelMessageNameList.Contains(CharacterSelectParamEntry.CostumeName))
                                        ExportModelMessageNameList.Add(CharacterSelectParamEntry.CostumeName);
                                    break;
                                }
                            }
                            if (ExportModelCharacterSelectParam.CharacterSelectParamList.Count < 1)
                            {
                                MessageBox.Show("Model with PlayerSettingParam code " + model.PSP_code + " wasn't exported, cuz it has missing characterSelectParam entry.");
                                continue;
                            }
                            //costumeParam
                            foreach (CostumeParamModel CostumeParamEntry in ImportModelCostumeParam.CostumeParamList)
                            {
                                if (CostumeParamEntry.PlayerSettingParamID == model.PSP_ID)
                                {
                                    ExportModelCostumeParam.CostumeParamList.Add((CostumeParamModel)CostumeParamEntry.Clone());
                                    if (!ExportModelMessageNameList.Contains(CostumeParamEntry.CharacterName))
                                    {
                                        ExportModelMessageNameList.Add(CostumeParamEntry.CharacterName);

                                    }
                                }
                            }
                            if (ExportModelCostumeParam.CostumeParamList.Count < 1)
                            {
                                MessageBox.Show("Model with PlayerSettingParam code " + model.PSP_code + " wasn't exported, cuz it has missing costumeParam entry.");
                                continue;
                            }
                            //costumeBreakColorParam
                            foreach (CostumeBreakColorParamModel CostumeBreakColorParamEntry in ImportModelCostumeBreakColorParam.CostumeBreakColorParamList)
                            {
                                if (CostumeBreakColorParamEntry.PlayerSettingParamID == model.PSP_ID)
                                {
                                    ExportModelCostumeBreakColorParam.CostumeBreakColorParamList.Add((CostumeBreakColorParamModel)CostumeBreakColorParamEntry.Clone());
                                    break;
                                }
                            }
                            if (ExportModelCostumeBreakColorParam.CostumeBreakColorParamList.Count < 1)
                            {
                                CostumeBreakColorParamModel cbcp_entry = new CostumeBreakColorParamModel();
                                cbcp_entry.PlayerSettingParamID = model.PSP_ID;
                                cbcp_entry.AltColor1 = Color.FromArgb(255, 255, 255, 1);
                                cbcp_entry.AltColor2 = Color.FromArgb(255, 255, 255, 1);
                                cbcp_entry.AltColor3 = Color.FromArgb(255, 255, 255, 1);
                                cbcp_entry.AltColor4 = Color.FromArgb(255, 255, 255, 1);
                                ExportModelCostumeBreakColorParam.CostumeBreakColorParamList.Add(cbcp_entry);

                            }
                            //costumeBreakParam
                            if (costumeBreakParamExist)
                            {

                                foreach (CostumeBreakParamModel costumeBreakEntry in ImportModelCostumeBreakParam.CostumeBreakParamList)
                                {
                                    if (costumeBreakEntry.CharacodeID == model.CharacodeID && costumeBreakEntry.CostumeID == model_index)
                                    {
                                        ExportModelCostumeBreakParam.CostumeBreakParamList.Add((CostumeBreakParamModel)costumeBreakEntry.Clone());
                                    }
                                }
                            }
                            //messageInfo
                            if (messageInfoExist)
                            {
                                if (ExportModelMessageNameList.Contains("practice_normal"))
                                    ExportModelMessageNameList.RemoveAt(ExportModelMessageNameList.IndexOf("practice_normal"));
                                for (int i = 0; i < ExportModelMessageNameList.Count; i++)
                                {
                                    ImportModelMessageInfo.MessageInfo_preview_List = ImportModelMessageInfo.MessageInfo_List[0];
                                    for (int message = 0; message < ImportModelMessageInfo.MessageInfo_preview_List.Count; message++)
                                    {
                                        if (BitConverter.ToString(ImportModelMessageInfo.MessageInfo_preview_List[message].CRC32Code) == BitConverter.ToString(BinaryReader.crc32(ExportModelMessageNameList[i])))
                                        {

                                            for (int l = 0; l < Program.langList.Length; l++)
                                            {
                                                MessageInfoModel copy_entry = (MessageInfoModel)ImportModelMessageInfo.MessageInfo_List[l][message].Clone();
                                                ExportModelMessageInfo.MessageInfo_List[l].Add(copy_entry);
                                            }
                                            break;
                                        }
                                    }
                                }


                            }
                            //Save All Params
                            string model_path = mod_path + "\\Models\\" + model.PSP_code + "\\data";
                            Directory.CreateDirectory(model_path + "\\spc");
                            Directory.CreateDirectory(model_path + "\\rpg\\param");
                            Directory.CreateDirectory(model_path + "\\ui\\max\\select");
                            ExportModelPlayerSettingParam.SaveFileAs(model_path + "\\spc\\playerSettingParam.bin.xfbin");
                            ExportModelPlayerIcon.SaveFileAs(model_path + "\\spc\\player_icon.xfbin");
                            ExportModelCharacterSelectParam.SaveFileAs(model_path + "\\ui\\max\\select\\characterSelectParam.xfbin");
                            if (ExportModelCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                ExportModelCostumeBreakParam.SaveFileAs(model_path + "\\spc\\costumeBreakParam.xfbin");
                            if (ExportModelCostumeBreakColorParam.CostumeBreakColorParamList.Count > 0)
                                ExportModelCostumeBreakColorParam.SaveFileAs(model_path + "\\spc\\costumeBreakColorParam.xfbin");
                            ExportModelCostumeParam.SaveFileAs(model_path + "\\rpg\\param\\costumeParam.bin.xfbin");
                            if (ExportModelMessageInfo.MessageInfo_List[0].Count > 0)
                                ExportModelMessageInfo.SaveFileAs(model_path);

                            //Save Model Config
                            var MyModelIni = new IniFile(mod_path + "\\Models\\" + model.PSP_code + "\\model_config.ini");
                            MyModelIni.Write("Characode", characode, "ModManager");
                            MyModelIni.Write("BaseModel", basemodel_code, "ModManager");
                            MyModelIni.Write("AwakeModel", awakemodel_code, "ModManager");
                        }

                        break;
                    //Compile Resource Mod
                    case 3:
                        break;
                    //Team Ultimate Jutsu Mod
                    case 4:
                        List<string> missingFiles = new List<string>();
                        if (!pairSpSkillCombineExist)
                            missingFiles.Add(Path.GetFileName(pairSpSkillCombinePath));

                        if (!pairSpSkillManagerExist)
                            missingFiles.Add(Path.GetFileName(pairSpSkillManagerPath));

                        if (!cmnparamExist)
                            missingFiles.Add(Path.GetFileName(cmnparamPath));

                        //if (!messageInfoExist)
                        //missingFiles.Add(Path.GetFileName(messageInfoPath));

                        if (missingFiles.Any())
                        {
                            string message = "Some files are missing required for export:\n" +
                                             string.Join("\n", missingFiles);
                            ModernWpf.MessageBox.Show(message);
                            return;
                        } else
                        {
                            MessageInfoViewModel ImportTUJMessageInfo = new MessageInfoViewModel();
                            PairSpSkillCombinationParamViewModel ImportTeamUltimateJutsu = new PairSpSkillCombinationParamViewModel();
                            cmnparamViewModel ImportTUJCmnparam = new cmnparamViewModel();

                            ImportTUJMessageInfo.OpenFiles(messageInfoPath);
                            ImportTeamUltimateJutsu.OpenFile(pairSpSkillCombinePath);
                            ImportTUJCmnparam.OpenFile(cmnparamPath);

                            MessageInfoViewModel ExportTUJMessageInfo = new MessageInfoViewModel();
                            cmnparamViewModel ExportTUJCmnparam = new cmnparamViewModel();

                            PairSpSkillCombinationParamModel pairSpSkillEntry = ImportTeamUltimateJutsu.pairSpSkillList.FirstOrDefault(item => item.TUJ_ID == SelectedTeamUltimateJutsuIndex);
                            pair_spl_sndModel cmnTUJParamEntry = ImportTUJCmnparam.PairSplList.FirstOrDefault(item => item.PairSplID == SelectedTeamUltimateJutsuIndex);

                            if (pairSpSkillEntry is null)
                            {
                                MessageBox.Show("Couldn't find entry in pairSpSkillCombinationParam for that Team Ultimate Jutsu.");
                                return;
                            }
                            if (cmnTUJParamEntry is null)
                            {
                                MessageBox.Show("Couldn't find entry in cmnparam for that Team Ultimate Jutsu.");
                                return;
                            }


                            // Get all prm files in the DataWin32Path_field directory (searching recursively)
                            string[] prmFiles = Directory.GetFiles(DataWin32Path_field, "*prm*.xfbin", SearchOption.AllDirectories);

                            foreach (string prmFilePath in prmFiles)
                            {
                                string fixedPath = prmFilePath.Replace("/", "\\");
                                if (File.Exists(fixedPath))
                                {
                                    PRMEditorViewModel ImportPRM = new PRMEditorViewModel();
                                    ImportPRM.OpenFile(fixedPath);

                                    for (int ver = 0; ver < ImportPRM.VerList.Count; ver++)
                                    {
                                        for (int pl_anm = 0; pl_anm < ImportPRM.VerList[ver].PL_ANM_Sections.Count; pl_anm++)
                                        {
                                            for (int function = 0; function < ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList.Count; function++)
                                            {
                                                if (ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].FunctionID == 0x96
                                                    && messageInfoExist)
                                                {
                                                    string message = ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].StringParam;
                                                    if (!ExportMessageNameList.Contains(message))
                                                    {
                                                        ExportMessageNameList.Add(message);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            ExportMessageNameList.Add(pairSpSkillEntry.TUJ_Name);
                            //MessageInfo
                            if (messageInfoExist)
                            {
                                ImportTUJMessageInfo.MessageInfo_preview_List = ImportTUJMessageInfo.MessageInfo_List[0];
                                for (int message = 0; message < ImportTUJMessageInfo.MessageInfo_preview_List.Count; message++)
                                {
                                    bool matchFound = false;
                                    foreach (string exportMessageName in ExportMessageNameList)
                                    {
                                        if (BitConverter.ToString(ImportTUJMessageInfo.MessageInfo_preview_List[message].CRC32Code) ==
                                            BitConverter.ToString(BinaryReader.crc32(exportMessageName)))
                                        {
                                            matchFound = true;
                                            break;
                                        }
                                    }
                                    if (matchFound)
                                    {
                                        for (int l = 0; l < Program.langList.Length; l++)
                                        {
                                            MessageInfoModel copy_entry = (MessageInfoModel)ImportTUJMessageInfo.MessageInfo_List[l][message].Clone();
                                            ExportTUJMessageInfo.MessageInfo_List[l].Add(copy_entry);
                                        }
                                    }
                                }
                            }

                            //cmnparam
                            ExportTUJCmnparam.PairSplList.Add((pair_spl_sndModel)cmnTUJParamEntry.Clone());


                            string characodeNamesString = string.Join(",",
                                pairSpSkillEntry.CharacodeList
                                .Select(id =>
                                {
                                    // Find the character entry in ImportCharacterList
                                    var character = ImportCharacterList.FirstOrDefault(c => c.CharacodeIndex == id);
                                    if (character == null)
                                    {
                                        // If we can't find the character, log a message and return
                                        MessageBox.Show($"Character with characode index {id} not found in characode.bin.xfbin file.");
                                        return null; // This will be handled by the Where clause below
                                    }
                                    return character.CharacodeName;
                                })
                                .Where(name => name != null) // Only include non-null CharacodeNames
                                .ToArray());
                            if (characodeNamesString.Split(',').Length != pairSpSkillEntry.CharacodeList.Count)
                            {
                                return;
                            }

                            //Create TUJ Directory
                            string tuj_path = Path.Combine(mod_path, "TUJ", SelectedTeamUltimateJutsu, "data");
                            Directory.CreateDirectory(Path.Combine(tuj_path, "sound"));


                            //Save TUJ Config
                            var MyTUJIni = new IniFile(Path.Combine(mod_path, "TUJ", SelectedTeamUltimateJutsu, "TUJ_config.ini"));
                            MyTUJIni.Write("Label", SelectedTeamUltimateJutsu, "ModManager");
                            MyTUJIni.Write("Name", pairSpSkillEntry.TUJ_Name, "ModManager");
                            MyTUJIni.Write("Flag1", pairSpSkillEntry.Condition1.ToString(), "ModManager");
                            MyTUJIni.Write("Flag2", pairSpSkillEntry.Condition2.ToString(), "ModManager");
                            MyTUJIni.Write("MemberCount", pairSpSkillEntry.MemberCount.ToString(), "ModManager");
                            MyTUJIni.Write("Characodes", characodeNamesString, "ModManager");

                            //SaveParamFiles
                            if (ExportTUJMessageInfo.MessageInfo_List[0].Count > 0)
                                ExportTUJMessageInfo.SaveFileAs(tuj_path);
                            if (ExportTUJCmnparam.PairSplList.Count > 0)
                                ExportTUJCmnparam.SaveFileAs(Path.Combine(tuj_path, "sound", "cmnparam.xfbin"));
                        }
                        break;
                    //Compile Accessory Mod
                    case 5:
                        break;
                }
                IsModCompiled = true;
                if (File.Exists(mod_path + ".nsc"))
                    File.Delete(mod_path + ".nsc");
                ZipFile.CreateFromDirectory(mod_path, mod_path + ".nsc");
                Directory.Delete(mod_path, true);
            }
        }


        public void CompileMod()
        {
            string OutputFolder = "";

            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                OutputFolder = dialog.FileName;
            else
            {
                return;
            }
            //Load All Files In Mod Folder
            if (Directory.Exists(OutputFolder))
            {
                LoadingStatePlay = Visibility.Visible;
                CompileModAsyncProcess(OutputFolder);

            } else
                ModernWpf.MessageBox.Show("Some settings were setup incorrectly!");
        }

        private RelayCommand _selectCPKCommand;
        public RelayCommand SelectCPKCommand
        {
            get
            {
                return _selectCPKCommand ??
                  (_selectCPKCommand = new RelayCommand(obj =>
                  {
                      SelectCPK();
                  }));
            }
        }
        private RelayCommand _deleteCPKCommand;
        public RelayCommand DeleteCPKCommand
        {
            get
            {
                return _deleteCPKCommand ??
                  (_deleteCPKCommand = new RelayCommand(obj =>
                  {
                      DeleteCPK();
                  }));
            }
        }
        private RelayCommand _selectShaderCommand;
        public RelayCommand SelectShaderCommand
        {
            get
            {
                return _selectShaderCommand ??
                  (_selectShaderCommand = new RelayCommand(obj =>
                  {
                      SelectShader();
                  }));
            }
        }
        private RelayCommand _deleteShaderCommand;
        public RelayCommand DeleteShaderCommand
        {
            get
            {
                return _deleteShaderCommand ??
                  (_deleteShaderCommand = new RelayCommand(obj =>
                  {
                      DeleteShader();
                  }));
            }
        }
        private RelayCommand _selectDataWin32Command;
        public RelayCommand SelectDataWin32Command
        {
            get
            {
                return _selectDataWin32Command ??
                  (_selectDataWin32Command = new RelayCommand(obj =>
                  {
                      SelectDataWin32();
                  }));
            }
        }
        private RelayCommand _saveDataWin32Command;
        public RelayCommand SaveDataWin32Command
        {
            get
            {
                return _saveDataWin32Command ??
                  (_saveDataWin32Command = new RelayCommand(obj =>
                  {
                      SaveDataWin32();
                  }));
            }
        }
        private RelayCommand _selectCharacterCommand;
        public RelayCommand SelectCharacterCommand
        {
            get
            {
                return _selectCharacterCommand ??
                  (_selectCharacterCommand = new RelayCommand(obj =>
                  {
                      SelectCharacter();
                  }));
            }
        }
        private RelayCommand _deleteCharacterCommand;
        public RelayCommand DeleteCharacterCommand
        {
            get
            {
                return _deleteCharacterCommand ??
                  (_deleteCharacterCommand = new RelayCommand(obj =>
                  {
                      DeleteCharacter();
                  }));
            }
        }
        private RelayCommand _selectModelCommand;
        public RelayCommand SelectModelCommand
        {
            get
            {
                return _selectModelCommand ??
                  (_selectModelCommand = new RelayCommand(obj =>
                  {
                      SelectModel();
                  }));
            }
        }
        private RelayCommand _deleteModelCommand;
        public RelayCommand DeleteModelCommand
        {
            get
            {
                return _deleteModelCommand ??
                  (_deleteModelCommand = new RelayCommand(obj =>
                  {
                      DeleteModel();
                  }));
            }
        }
        private RelayCommand _selectStageCommand;
        public RelayCommand SelectStageCommand
        {
            get
            {
                return _selectStageCommand ??
                  (_selectStageCommand = new RelayCommand(obj =>
                  {
                      SelectStage();
                  }));
            }
        }
        private RelayCommand _deleteStageCommand;
        public RelayCommand DeleteStageCommand
        {
            get
            {
                return _deleteStageCommand ??
                  (_deleteStageCommand = new RelayCommand(obj =>
                  {
                      DeleteStage();
                  }));
            }
        }
        private RelayCommand _selectModIconCommand;
        public RelayCommand SelectModIconCommand
        {
            get
            {
                return _selectModIconCommand ??
                  (_selectModIconCommand = new RelayCommand(obj =>
                  {
                      SelectModIcon();
                  }));
            }
        }
        private RelayCommand _selectStageImagePreviewCommand;
        public RelayCommand SelectStageImagePreviewCommand
        {
            get
            {
                return _selectStageImagePreviewCommand ??
                  (_selectStageImagePreviewCommand = new RelayCommand(obj =>
                  {
                      SelectStageImagePreview();
                  }));
            }
        }
        private RelayCommand _selectStageIconCommand;
        public RelayCommand SelectStageIconCommand
        {
            get
            {
                return _selectStageIconCommand ??
                  (_selectStageIconCommand = new RelayCommand(obj =>
                  {
                      SelectStageIcon();
                  }));
            }
        }
        private RelayCommand _saveBGMIDCommand;
        public RelayCommand SaveBGMIDCommand
        {
            get
            {
                return _saveBGMIDCommand ??
                  (_saveBGMIDCommand = new RelayCommand(obj =>
                  {
                      SaveBGMID();
                  }));
            }
        }
        private RelayCommand _saveStageMessageIDCommand;
        public RelayCommand SaveStageMessageIDCommand
        {
            get
            {
                return _saveStageMessageIDCommand ??
                  (_saveStageMessageIDCommand = new RelayCommand(obj =>
                  {
                      SaveStageMessageID();
                  }));
            }
        }
        private RelayCommand _compileModCommand;
        public RelayCommand CompileModCommand
        {
            get
            {
                return _compileModCommand ??
                  (_compileModCommand = new RelayCommand(obj =>
                  {
                      CompileMod();
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
