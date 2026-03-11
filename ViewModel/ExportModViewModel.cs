using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using NSC_Toolbox.Model;
using NSC_Toolbox.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace NSC_Toolbox.ViewModel
{

    public static class BitmapConversion
    {
        [DllImport("gdi32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject(IntPtr hObject);

        public static BitmapSource BitmapToBitmapSource(Bitmap source)
        {
            IntPtr hBitmap = source.GetHbitmap();
            try
            {
                return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            } finally
            {
                DeleteObject(hBitmap);
            }
        }
    }

    public class ExportModViewModel : INotifyPropertyChanged
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
        private string[] _screenshots_field;
        public string[] Screenshots_field
        {
            get { return _screenshots_field; }
            set
            {
                _screenshots_field = value;
                OnPropertyChanged("Screenshots_field");
            }
        }
        private bool _encryptFiles_field;
        public bool EncryptFiles_field
        {
            get { return _encryptFiles_field; }
            set
            {
                _encryptFiles_field = value;
                OnPropertyChanged("EncryptFiles_field");
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
                StageIconPathListSC.Clear();
                StageIconPathListS4.Clear();
                StageBGMIDList.Clear();
                StageBGMID_NS4_List.Clear();

                bool isStorm4 = (SelectedGameIndex == (int)Game.Storm4);
                string gamePath = isStorm4 ? "NS4" : "NSC";
                string characodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "characode.bin.xfbin");

                if (File.Exists(Path.Combine(DataWin32Path_field, "spc", "characode.bin.xfbin")))
                {
                    characodePath = Path.Combine(DataWin32Path_field, "spc", "characode.bin.xfbin");
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
                        PageModType_tuj_visibility = Visibility.Hidden;

                        break;
                    //Stage export
                    case 1:
                        PageModType_character_visibility = Visibility.Hidden;
                        PageModType_stage_visibility = Visibility.Visible;
                        PageModType_model_visibility = Visibility.Hidden;
                        PageModType_accessory_visibility = Visibility.Hidden;
                        PageModType_resources_visibility = Visibility.Hidden;
                        PageModType_tuj_visibility = Visibility.Hidden;

                        string stageInfoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "StageInfo.bin.xfbin");

                        if (File.Exists(Path.Combine(DataWin32Path_field, "stage", "StageInfo.bin.xfbin")))
                        {
                            stageInfoPath = Path.Combine(DataWin32Path_field, "stage", "StageInfo.bin.xfbin");
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

                        string playerSettingParamPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "playerSettingParam.bin.xfbin");

                        if (File.Exists(Path.Combine(DataWin32Path_field, "spc", "playerSettingParam.bin.xfbin")))
                        {
                            playerSettingParamPath = Path.Combine(DataWin32Path_field, "spc", "playerSettingParam.bin.xfbin");
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
                        string pairManagerParamPath = Path.Combine(Path.GetDirectoryName(DataWin32Path_field), "moddingapi", "param", gamePath, "pairSpSkillManagerParam.xfbin");

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

                    bool isStorm4 = (SelectedGameIndex == (int)Game.Storm4);
                    string gamePath = isStorm4 ? "NS4" : "NSC";
                    string characodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "characode.bin.xfbin");
                    if (File.Exists(Path.Combine(DataWin32Path_field, "spc", "characode.bin.xfbin")))
                    {
                        characodePath = Path.Combine(DataWin32Path_field, "spc", "characode.bin.xfbin");
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
        private int _selectedGameIndex;
        public int SelectedGameIndex
        {
            get { return _selectedGameIndex; }
            set
            {
                _selectedGameIndex = value;
                if (value != null)
                {
                    bool isStorm4 = (value == (int)Game.Storm4);
                    string gamePath = isStorm4 ? "NS4" : "NSC";

                    if (isStorm4)
                    {

                        ModIconPath_field = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "TemplateImages", "template_icon_S4.png");
                    } else
                    {

                        ModIconPath_field = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "TemplateImages", "template_icon_SC.png");
                    }
                        string characodePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "characode.bin.xfbin");
                    if (File.Exists(Path.Combine(DataWin32Path_field, "spc", "characode.bin.xfbin")))
                    {
                        characodePath = Path.Combine(DataWin32Path_field, "spc", "characode.bin.xfbin");
                    }

                    CharacodeEditorViewModel charEditor = new CharacodeEditorViewModel();
                    charEditor.OpenFile(characodePath);
                    ImportCharacterList = charEditor.CharacodeList;
                }

                OnPropertyChanged("SelectedGameIndex");
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
                    StageIconPathSC = StageIconPathListSC[SelectedExportStageIndex];
                    StageIconPathS4 = StageIconPathListS4[SelectedExportStageIndex];
                    StageBGM_ID = StageBGMIDList[SelectedExportStageIndex];
                    StageBGM_ID_NS4 = StageBGMID_NS4_List[SelectedExportStageIndex];
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
        private ObservableCollection<string> _stageIconPathListSC;
        public ObservableCollection<string> StageIconPathListSC
        {
            get { return _stageIconPathListSC; }
            set
            {
                _stageIconPathListSC = value;
                OnPropertyChanged("StageIconPathListSC");
            }
        }
        private ObservableCollection<string> _stageIconPathListS4;
        public ObservableCollection<string> StageIconPathListS4
        {
            get { return _stageIconPathListS4; }
            set
            {
                _stageIconPathListS4 = value;
                OnPropertyChanged("StageIconPathListS4");
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
        private ObservableCollection<int> _stageBGMID_NS4_List;
        public ObservableCollection<int> StageBGMID_NS4_List
        {
            get { return _stageBGMID_NS4_List; }
            set
            {
                _stageBGMID_NS4_List = value;
                OnPropertyChanged("StageBGMID_NS4_List");
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
                if (SelectedExportStageIndex != -1)
                {
                    StageBGMIDList[SelectedExportStageIndex] = _stageBGM_ID;
                }
                OnPropertyChanged("StageBGM_ID");
            }
        }
        private int _stageBGM_ID_NS4;
        public int StageBGM_ID_NS4
        {
            get { return _stageBGM_ID_NS4; }
            set
            {
                _stageBGM_ID_NS4 = value;
                if (SelectedExportStageIndex != -1)
                {
                    StageBGMID_NS4_List[SelectedExportStageIndex] = _stageBGM_ID_NS4;
                }
                OnPropertyChanged("StageBGM_ID_NS4");
            }
        }
        private string _stageMessageID;
        public string StageMessageID
        {
            get { return _stageMessageID; }
            set
            {
                _stageMessageID = value;
                if (SelectedExportStageIndex > -1)
                {
                    StageMessageIDList[SelectedExportStageIndex] = StageMessageID;
                }
                OnPropertyChanged("StageMessageID");
            }
        }
        private string _stageIconPathSC;
        public string StageIconPathSC
        {
            get
            {
                return _stageIconPathSC;
            }
            set
            {
                _stageIconPathSC = value;
                OnPropertyChanged("StageIconPathSC");
            }
        }
        private string _stageIconPathS4;
        public string StageIconPathS4
        {
            get
            {
                return _stageIconPathS4;
            }
            set
            {
                _stageIconPathS4 = value;
                OnPropertyChanged("StageIconPathS4");
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

            DataWin32Path_field = "";
            ImportCharacterList = new ObservableCollection<CharacodeEditorModel>();
            ExportCharacterList = new ObservableCollection<CharacodeEditorModel>();
            ImportModelList = new ObservableCollection<PlayerSettingParamModel>();
            ExportModelList = new ObservableCollection<PlayerSettingParamModel>();
            ImportStageList = new ObservableCollection<StageInfoModel>();
            ExportStageList = new ObservableCollection<StageInfoModel>();
            StageImagePreviewPathList = new ObservableCollection<string>();
            StageIconPathListSC = new ObservableCollection<string>();
            StageIconPathListS4 = new ObservableCollection<string>();
            StageMessageIDList = new ObservableCollection<string>();
            StageBGMIDList = new ObservableCollection<int>();
            StageBGMID_NS4_List = new ObservableCollection<int>();
            ModType_List = new ObservableCollection<string>();
            ShadersList = new ObservableCollection<string>();
            CPKList = new ObservableCollection<string>();
            TeamUltimateJutsuList = new ObservableCollection<string>();
            LoadingStatePlay = Visibility.Hidden;
            filePath = "";
            ModIconPath_field = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "TemplateImages", "template_icon_SC.png");

            PageModType_character_visibility = Visibility.Visible;
            PageModType_stage_visibility = Visibility.Hidden;
            PageModType_model_visibility = Visibility.Hidden;
            PageModType_accessory_visibility = Visibility.Hidden;
            ModType_field = 0;
            IsModReady = false;
            IsDataWin32Exist = false;
            IsExportModsExist = false;
            IsModCompiled = false;
            EncryptFiles_field = false;
            SelectedGameIndex = 0;
            Screenshots_field = new string[0];
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
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_20"]);
        }
        public void SelectCharacter()
        {
            if (SelectedImportCharacter is not null)
            {
                if (!ExportCharacterList.Contains(SelectedImportCharacter))
                    ExportCharacterList.Add(SelectedImportCharacter);
                else
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_21"]);
                IsExportModsExist = ExportCharacterList.Count > 0;
            } else
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_22"]);
        }
        public void DeleteCharacter()
        {
            if (SelectedExportCharacter is not null)
            {
                ExportCharacterList.Remove(SelectedExportCharacter);
                IsExportModsExist = ExportCharacterList.Count > 0;
            } else
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_23"]);
        }
        public void SelectModel()
        {
            if (SelectedImportModel is not null)
            {
                if (!ExportModelList.Contains(SelectedImportModel))
                    ExportModelList.Add(SelectedImportModel);
                else
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_24"]);
                IsExportModsExist = ExportModelList.Count > 0;
            } else
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_22"]);
        }
        public void DeleteModel()
        {
            if (SelectedExportModel is not null)
            {
                ExportModelList.Remove(SelectedExportModel);
                IsExportModsExist = ExportModelList.Count > 0;
            } else
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_25"]);
        }
        public void SelectStage()
        {
            if (SelectedImportStage is not null)
            {
                if (!ExportStageList.Contains(SelectedImportStage))
                {
                    StageImagePreviewPathList.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "TemplateImages", "stage_tex.png"));
                    StageIconPathListSC.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "TemplateImages", "stage_icon_SC.dds"));
                    StageIconPathListS4.Add(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "TemplateImages", "stage_icon_S4.dds"));
                    StageMessageIDList.Add("Location005");
                    StageBGMIDList.Add(-1);
                    StageBGMID_NS4_List.Add(-1);

                    ExportStageList.Add(SelectedImportStage);
                } else
                    ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_26"]);
                IsExportModsExist = ExportStageList.Count > 0;
            } else
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_27"]);
        }
        public void DeleteStage()
        {
            if (SelectedExportStage is not null && SelectedExportStageIndex > -1)
            {
                StageImagePreviewPathList.RemoveAt(SelectedExportStageIndex);
                StageIconPathListSC.RemoveAt(SelectedExportStageIndex);
                StageIconPathListS4.RemoveAt(SelectedExportStageIndex);
                StageBGMIDList.RemoveAt(SelectedExportStageIndex);
                StageBGMID_NS4_List.RemoveAt(SelectedExportStageIndex);
                StageMessageIDList.RemoveAt(SelectedExportStageIndex);
                ExportStageList.Remove(SelectedExportStage);
                IsExportModsExist = ExportStageList.Count > 0;
            } else
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_28"]);
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
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_29"]);
            }
        }
        public void SelectScreenshots()
        {
            Screenshots_field = new string[0];
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "PNG Image (*.png)|*.png|JPG Image (*.jpg)|*.jpg|JPEG Image (*.jpeg)|*.jpeg|BMP Image (*.bmp)|*.bmp";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = true;
            if (myDialog.ShowDialog() == true)
            {
                Screenshots_field = myDialog.FileNames;
            } else
            {
                Screenshots_field = new string[0];
                return;
            }
        }
        public void SelectStageIconSC()
        {
            if (SelectedExportStageIndex > -1)
            {
                OpenFileDialog myDialog = new OpenFileDialog();
                myDialog.Filter = "DDS Image (*.dds)|*.dds";
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                if (myDialog.ShowDialog() == true)
                {
                    StageIconPathListSC[SelectedExportStageIndex] = myDialog.FileName;
                } else
                {
                    return;
                }
            } else
            {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_29"]);
            }
        }
        public void SelectStageIconS4()
        {
            if (SelectedExportStageIndex > -1)
            {
                OpenFileDialog myDialog = new OpenFileDialog();
                myDialog.Filter = "DDS Image (*.dds)|*.dds";
                myDialog.CheckFileExists = true;
                myDialog.Multiselect = false;
                if (myDialog.ShowDialog() == true)
                {
                    StageIconPathListS4[SelectedExportStageIndex] = myDialog.FileName;
                } else
                {
                    return;
                }
            } else
            {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_29"]);
            }
        }
        public void SaveBGMID()
        {
            if (SelectedExportStageIndex > -1)
            {
                StageBGMIDList[SelectedExportStageIndex] = StageBGM_ID;
                StageBGMID_NS4_List[SelectedExportStageIndex] = StageBGM_ID_NS4;
            } else
            {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_29"]);
            }
        }
        public void SaveStageMessageID()
        {
            if (SelectedExportStageIndex > -1)
            {
                StageMessageIDList[SelectedExportStageIndex] = StageMessageID;
            } else
            {
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_29"]);
            }
        }
        public void DeleteShader()
        {
            if (SelectedShader is not null)
            {
                ShadersList.Remove(SelectedShader);
            } else
                ModernWpf.MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_30"]);
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
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string logDir = Path.Combine(appDir, "logs");
                Directory.CreateDirectory(logDir);

                string logPath = Path.Combine(
                    logDir,
                    $"error_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt"
                );

                File.WriteAllText(
                    logPath,
                    $"Time: {DateTime.Now:O}{Environment.NewLine}" +
                    $"Message: {ex.Message}{Environment.NewLine}{Environment.NewLine}" +
                    $"StackTrace:{Environment.NewLine}{ex.StackTrace}"
                );

                MessageBox.Show(
                    $"Error: {ex.Message}\n\nLog saved to:\n{logPath}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
        public static class PathBuilder
        {
            public class PathTemplate
            {
                public string[] NSC { get; }
                public string[] NS4 { get; }

                public PathTemplate(string[] both) : this(both, both) { }
                public PathTemplate(string[] nsc, string[] ns4)
                {
                    NSC = nsc ?? Array.Empty<string>();
                    NS4 = ns4 ?? Array.Empty<string>();
                }
            }

            /// <summary>
            /// Возвращает (dataPaths, moddingApiPaths) в зависимости от isStorm4.
            /// </summary>
            /// 

            public static (Dictionary<string, string> dataPaths, Dictionary<string, string> moddingApiPaths) BuildPathDictionaries(
                string outputFolder,
                string modName,
                string dataWin32Path,
                bool isStorm4)
            {
                if (outputFolder == null) throw new ArgumentNullException(nameof(outputFolder));
                if (modName == null) throw new ArgumentNullException(nameof(modName));
                if (dataWin32Path == null) throw new ArgumentNullException(nameof(dataWin32Path));

                string modPath = Path.Combine(outputFolder, modName);
                Directory.CreateDirectory(modPath);

                string gamePath = isStorm4 ? "NS4" : "NSC";

                // Шаблоны путей — сегменты относительно dataWin32Path.
                var templates = new Dictionary<string, PathTemplate>(StringComparer.OrdinalIgnoreCase)
        {
            // примеры: если путь одинаков для обеих игр — передаём один массив
            { "Characode", new PathTemplate(new[]{ "spc", "characode.bin.xfbin" }) },
            // для NS4 добавляем WIN64 между "spc" и файлом
            { "PlayerSettingParam", new PathTemplate(
                new[]{ "spc", "playerSettingParam.bin.xfbin" },
                new[]{ "spc", "WIN64", "playerSettingParam.bin.xfbin" }) },
            { "DuelPlayerParam", new PathTemplate(
                new[]{ "spc", "duelPlayerParam.xfbin" },
                new[]{ "spc", "duelPlayerParam.xfbin" }) },
            { "SkillCustomizeParam", new PathTemplate(
                new[]{ "spc", "skillCustomizeParam.xfbin" },
                new[]{ "spc", "WIN64", "skillCustomizeParam.xfbin" }) },
            { "SpSkillCustomizeParam", new PathTemplate(
                new[]{ "spc", "spSkillCustomizeParam.xfbin" },
                new[]{ "spc", "WIN64", "spSkillCustomizeParam.xfbin" }) },
            { "SkillIndexSettingParam", new PathTemplate(
                new[]{ "spc", "skillIndexSettingParam.xfbin" },
                new[]{ "spc", "skillIndexSettingParam.xfbin" })
                    },
            { "SupportSkillRecoverySpeedParam", new PathTemplate(
                new[]{ "spc", "supportSkillRecoverySpeedParam.xfbin" },
                new[] { "spc", "supportSkillRecoverySpeedParam.xfbin" }) },
            { "PrivateCamera", new PathTemplate(
                new[]{ "spc", "privateCamera.bin.xfbin" },
                new[] { "spc", "privateCamera.bin.xfbin" }) },
            { "CharacterSelectParam", new PathTemplate(
                new[]{ "ui", "max", "select", "characterSelectParam.xfbin" },
                new[]{ "ui", "max", "select", "WIN64", "characterSelectParam.xfbin" }) },
            { "CostumeBreakColorParam", new PathTemplate(
                new[]{ "spc", "costumeBreakColorParam.xfbin" },
                new[] { "spc", "WIN64", "costumeBreakColorParam.xfbin" }) },
            { "CostumeParam", new PathTemplate(
                new[]{ "rpg", "param", "costumeParam.bin.xfbin" },
                new[]{ "rpg", "param", "WIN64", "costumeParam.bin.xfbin" }
                ) },
            { "PlayerIcon", new PathTemplate(
                new[]{ "spc", "player_icon.xfbin" },
                new[] { "spc", "WIN64", "player_icon.xfbin" }) },
            { "CmnParam", new PathTemplate(
                new[]{ "sound", "cmnparam.xfbin" },
                new[]{ "sound", "cmnparam.xfbin" }
                ) },
            { "SupportActionParam", new PathTemplate(
                new[]{ "spc", "supportActionParam.xfbin" },
                new[] { "spc", "WIN64", "supportActionParam.xfbin" }) },
            { "AwakeAura", new PathTemplate(
                new[]{ "spc", "awakeAura.xfbin" },
                new[] { "spc", "WIN64", "awakeAura.xfbin" }) },
            { "AppearanceAnm", new PathTemplate(
                new[]{ "spc", "appearanceAnm.xfbin" },
                new[] { "spc", "WIN64", "appearanceAnm.xfbin" }) },
            { "AfterAttachObject", new PathTemplate(
                new[]{ "spc", "afterAttachObject.xfbin" },
                new[] { "spc", "WIN64", "afterAttachObject.xfbin" }) },
            { "PlayerDoubleEffectParam", new PathTemplate(
                new[]{ "spc", "playerDoubleEffectParam.xfbin" },
                new[] { "spc", "WIN64", "playerDoubleEffectParam.xfbin" }) },
            { "SpTypeSupportParam", new PathTemplate(
                new[]{ "spc", "spTypeSupportParam.xfbin" },
                new[] { "spc", "WIN64", "spTypeSupportParam.xfbin" }) },
            { "CostumeBreakParam", new PathTemplate(
                new[]{ "spc", "costumeBreakParam.xfbin" },
                new[] { "spc", "WIN64", "costumeBreakParam.xfbin" }) },
            { "MessageInfoFolder", new PathTemplate(
                new[]{ "message" }, new[]{ "message" }) },
            { "DamageEff", new PathTemplate(
                new[]{ "spc", "damageeff.bin.xfbin" }, new[] { "spc", "damageeff.bin.xfbin" }) },
            { "EffectPrm", new PathTemplate(
                new[]{ "spc", "effectprm.bin.xfbin" }, new[] { "spc", "effectprm.bin.xfbin" }) },
            { "DamagePrm", new PathTemplate(
                new[]{ "spc", "damageprm.bin.xfbin" }, new[] { "spc", "damageprm.bin.xfbin" }) },
            { "PairSpSkillCombinationParam", new PathTemplate(
                new[]{ "spc", "pairSpSkillCombinationParam.xfbin" },
                new[] { "spc", "WIN64", "pairSpSkillCombinationParam.xfbin" }) },
            { "ConditionPrm", new PathTemplate(
                new[]{ "spc", "conditionprm.bin.xfbin" }, new[] { "spc", "conditionprm.bin.xfbin" }) }
            // Добавляй сюда новые ключи — в любом месте легко указать разные сегменты для NSC и NS4
        };

                // Построение словаря dataPaths
                var dataPaths = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "ModPath", modPath }
        };

                foreach (var kv in templates)
                {
                    string[] segments = isStorm4 ? kv.Value.NS4 : kv.Value.NSC;
                    string path = CombinePaths(dataWin32Path, segments);
                    dataPaths[kv.Key] = path;
                }

                // moddingapi/param/{GamePath} и его файлы (шаблоны одинаковы для обеих игр по структуре base->имена)
                string moddingApiBase = Path.Combine(Path.GetDirectoryName(dataWin32Path) ?? string.Empty, "moddingapi", "param", gamePath);
                var moddingApiPaths = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)




                {
            { "Base", moddingApiBase },
            { "PairSpSkillManager", Path.Combine(moddingApiBase, "pairSpSkillManagerParam.xfbin") },
            { "BgmManagerParam", Path.Combine(moddingApiBase, "bgmManagerParam.xfbin") },
            { "GuardEffectParam", Path.Combine(moddingApiBase, "guardEffectParam.xfbin") },
            { "GudoBallParam", Path.Combine(moddingApiBase, "gudoBallParam.xfbin") },
            { "OugiAwakeningParam", Path.Combine(moddingApiBase, "ougiAwakeningParam.xfbin") },
            { "SpecialInteractionManager", Path.Combine(moddingApiBase, "specialInteractionManager.xfbin") },
            { "ConditionPrmManager", Path.Combine(moddingApiBase, "conditionprmManager.xfbin") },
            { "SpecialCondParam", Path.Combine(moddingApiBase, "specialCondParam.xfbin") },
            { "SusanooCondParam", Path.Combine(moddingApiBase, "susanooCondParam.xfbin") },
            { "PartnerSlotParam", Path.Combine(moddingApiBase, "partnerSlotParam.xfbin") }
        };

                return (dataPaths, moddingApiPaths);
            }

            private static string CombinePaths(string basePath, string[] segments)
            {
                if (string.IsNullOrEmpty(basePath)) basePath = string.Empty;
                if (segments == null || segments.Length == 0) return basePath;
                var all = new string[segments.Length + 1];
                all[0] = basePath;
                Array.Copy(segments, 0, all, 1, segments.Length);
                return Path.Combine(all);
            }
        }
        public void CompileModProcess(string output_folder)
        {
            try
            {
                bool isStorm4 = (SelectedGameIndex == (int)Game.Storm4);
                var (dataPaths, moddingApiPaths) = PathBuilder.BuildPathDictionaries(output_folder, ModName_field, DataWin32Path_field, isStorm4);


                string gamePath = isStorm4 ? "NS4" : "NSC";
                // Create config file
                var MyIni = new IniFile(Path.Combine(dataPaths["ModPath"], "mod_config.ini"));
                MyIni.Write("ModName", ModName_field, "ModManager");
                MyIni.Write("Description", ModDesc_field, "ModManager");
                MyIni.Write("Author", ModAuthor_field, "ModManager");
                MyIni.Write("LastUpdate", DateTime.Today.ToString("dd/MM/yyyy"), "ModManager");
                MyIni.Write("Version", ModVersion_field, "ModManager");
                MyIni.Write("Game", gamePath, "ModManager");
                MyIni.Write("EnableMod", "true", "ModManager");

                // Copy Icon
                File.Copy(ModIconPath_field, Path.Combine(dataPaths["ModPath"], "mod_icon.png"), true);
                if (Screenshots_field is not null && Screenshots_field.Length > 0)
                {
                    Directory.CreateDirectory(Path.Combine(dataPaths["ModPath"], "Screenshots"));
                    for (int i = 0; i < Screenshots_field.Length; i++)
                    {
                        File.Copy(Screenshots_field[i], Path.Combine(dataPaths["ModPath"], "Screenshots", Path.GetFileName(Screenshots_field[i])), true);
                    }
                }

                if (!EncryptFiles_field)
                {
                    // Copy all resources from mod folder
                    Program.CopyFilesRecursivelyModManager(DataWin32Path_field, Path.Combine(dataPaths["ModPath"], "Resources", "Files", "data"));
                } else
                {
                    FileEncryptor.CopyFilesWithEncryption(DataWin32Path_field, Path.Combine(dataPaths["ModPath"], "Resources", "Files", "data"));
                }

                // Copy all CPKs
                Directory.CreateDirectory(Path.Combine(dataPaths["ModPath"], "Resources", "CPKs"));
                foreach (string file in CPKList)
                {
                    string cpk_name = Path.GetFileName(file);
                    File.Copy(file, Path.Combine(dataPaths["ModPath"], "Resources", "CPKs", cpk_name), true);
                }

                // Copy all shaders
                Directory.CreateDirectory(Path.Combine(dataPaths["ModPath"], "Resources", "Shaders"));
                foreach (string file in ShadersList)
                {
                    string shader_name = Path.GetFileName(file);
                    File.Copy(file, Path.Combine(dataPaths["ModPath"], "Resources", "Shaders", shader_name), true);
                }

                // characode.bin.xfbin
                CharacodeEditorViewModel Characode = new CharacodeEditorViewModel();
                Characode.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "characode.bin.xfbin"));


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

                            //Storm Connections
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
                            SpecialInteractionManagerViewModel ImportSpecialInteraction = new SpecialInteractionManagerViewModel();
                            ConditionPrmViewModel ImportConditionPrm = new ConditionPrmViewModel();
                            ConditionManagerViewModel ImportConditionPrmManager = new ConditionManagerViewModel();
                            GuardEffectParamViewModel ImportGuardEffectParam = new GuardEffectParamViewModel();


                            //Storm 4
                            PlayerSettingParamS4ViewModel ImportPlayerSettingParamS4 = new PlayerSettingParamS4ViewModel();
                            SkillCustomizeParamS4ViewModel ImportSkillCustomizeParamS4 = new SkillCustomizeParamS4ViewModel();
                            CharacterSelectParamS4ViewModel ImportCharacterSelectParamS4 = new CharacterSelectParamS4ViewModel();
                            MessageInfoS4ViewModel ImportMessageInfoS4 = new MessageInfoS4ViewModel();
                            CostumeBreakColorParamS4ViewModel ImportCostumeBreakColorParamS4 = new CostumeBreakColorParamS4ViewModel();

                            if (File.Exists(dataPaths["DuelPlayerParam"]))
                                ImportDuelPlayerParam.OpenFile(dataPaths["DuelPlayerParam"]);

                            if (!isStorm4)
                            {

                                if (File.Exists(dataPaths["PlayerSettingParam"]))
                                    ImportPlayerSettingParam.OpenFile(dataPaths["PlayerSettingParam"]);
                                else
                                    ImportPlayerSettingParam.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "playerSettingParam.bin.xfbin"));
                            } else
                            {

                                if (File.Exists(dataPaths["PlayerSettingParam"]))
                                    ImportPlayerSettingParamS4.OpenFile(dataPaths["PlayerSettingParam"]);
                                else
                                    ImportPlayerSettingParamS4.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "playerSettingParam.bin.xfbin"));
                            }
                            if (File.Exists(dataPaths["SkillCustomizeParam"]) && !isStorm4)
                                ImportSkillCustomizeParam.OpenFile(dataPaths["SkillCustomizeParam"]);
                            else if (File.Exists(dataPaths["SkillCustomizeParam"]) && isStorm4)
                                ImportSkillCustomizeParamS4.OpenFile(dataPaths["SkillCustomizeParam"]);

                            if (File.Exists(dataPaths["SpSkillCustomizeParam"]))
                                ImportSpSkillCustomizeParam.OpenFile(dataPaths["SpSkillCustomizeParam"]);

                            if (File.Exists(dataPaths["SkillIndexSettingParam"]))
                                ImportSkillIndexParam.OpenFile(dataPaths["SkillIndexSettingParam"]);

                            if (File.Exists(dataPaths["SupportSkillRecoverySpeedParam"]))
                                ImportSupportSkillRecoverySpeed.OpenFile(dataPaths["SupportSkillRecoverySpeedParam"]);

                            if (File.Exists(dataPaths["PrivateCamera"]))
                                ImportPrivateCamera.OpenFile(dataPaths["PrivateCamera"]);

                            if (File.Exists(dataPaths["CharacterSelectParam"]) && !isStorm4)
                                ImportCharacterSelectParam.OpenFile(dataPaths["CharacterSelectParam"]);
                            else if (File.Exists(dataPaths["CharacterSelectParam"]) && isStorm4)
                                ImportCharacterSelectParamS4.OpenFile(dataPaths["CharacterSelectParam"]);

                            if (File.Exists(dataPaths["CostumeBreakColorParam"]) && !isStorm4)
                                ImportCostumeBreakColorParam.OpenFile(dataPaths["CostumeBreakColorParam"]);
                            else if (File.Exists(dataPaths["CostumeBreakColorParam"]) && isStorm4)
                                ImportCostumeBreakColorParamS4.OpenFile(dataPaths["CostumeBreakColorParam"]);
                            if (!isStorm4)
                            {

                                if (File.Exists(dataPaths["CostumeParam"]))
                                    ImportCostumeParam.OpenFile(dataPaths["CostumeParam"]);
                                else
                                    ImportCostumeParam.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "costumeParam.bin.xfbin"));
                            }
                            if (File.Exists(dataPaths["PlayerIcon"]))
                                ImportPlayerIcon.OpenFile(dataPaths["PlayerIcon"]);

                            if (File.Exists(dataPaths["CmnParam"]))
                                ImportCmnParam.OpenFile(dataPaths["CmnParam"]);

                            if (File.Exists(dataPaths["SupportActionParam"]))
                                ImportSupportActionParam.OpenFile(dataPaths["SupportActionParam"]);

                            if (File.Exists(dataPaths["AwakeAura"]))
                                ImportAwakeAura.OpenFile(dataPaths["AwakeAura"]);

                            if (File.Exists(dataPaths["AppearanceAnm"]))
                                ImportAppearanceAnm.OpenFile(dataPaths["AppearanceAnm"]);

                            if (File.Exists(dataPaths["AfterAttachObject"]))
                                ImportAfterAttachObject.OpenFile(dataPaths["AfterAttachObject"]);

                            if (File.Exists(dataPaths["PlayerDoubleEffectParam"]))
                                ImportPlayerDoubleEffectParam.OpenFile(dataPaths["PlayerDoubleEffectParam"]);

                            if (File.Exists(dataPaths["SpTypeSupportParam"]))
                                ImportSpTypeSupportParam.OpenFile(dataPaths["SpTypeSupportParam"]);

                            if (File.Exists(dataPaths["CostumeBreakParam"]))
                                ImportCostumeBreakParam.OpenFile(dataPaths["CostumeBreakParam"]);

                            if (Directory.Exists(dataPaths["MessageInfoFolder"]) && !isStorm4)
                                ImportMessageInfo.OpenFiles(dataPaths["MessageInfoFolder"]);
                            else if (Directory.Exists(dataPaths["MessageInfoFolder"]) && isStorm4)
                                ImportMessageInfoS4.OpenFiles(dataPaths["MessageInfoFolder"]);

                            if (File.Exists(dataPaths["DamageEff"]))
                                ImportDamageEff.OpenFile(dataPaths["DamageEff"]);

                            if (File.Exists(dataPaths["EffectPrm"]))
                                ImportEffectPrm.OpenFile(dataPaths["EffectPrm"]);

                            if (File.Exists(moddingApiPaths["SpecialInteractionManager"]))
                                ImportSpecialInteraction.OpenFile(moddingApiPaths["SpecialInteractionManager"]);

                            if (File.Exists(dataPaths["ConditionPrm"]))
                                ImportConditionPrm.OpenFile(dataPaths["ConditionPrm"]);

                            if (File.Exists(moddingApiPaths["ConditionPrmManager"]))
                                ImportConditionPrmManager.OpenFile(moddingApiPaths["ConditionPrmManager"]);
                            if (File.Exists(moddingApiPaths["GuardEffectParam"]))
                                ImportGuardEffectParam.OpenFile(moddingApiPaths["GuardEffectParam"]);

                            OriginalDamageEff.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "damageeff.bin.xfbin"));
                            OriginalEffectPrm.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "effectprm.bin.xfbin"));
                            OriginalDamagePrm.OpenFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ParamFiles", gamePath, "damageprm.bin.xfbin"));


                            if (File.Exists(dataPaths["DamagePrm"]))
                                ImportDamagePrm.OpenFile(dataPaths["DamagePrm"]);

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


                                string character_path = Path.Combine(dataPaths["ModPath"], "Characters", character.CharacodeName, "data");

                                Directory.CreateDirectory(Path.Combine(character_path, "spc", "WIN64"));
                                Directory.CreateDirectory(Path.Combine(character_path, "rpg", "param", "WIN64"));
                                Directory.CreateDirectory(Path.Combine(character_path, "ui", "max", "select", "WIN64"));
                                Directory.CreateDirectory(Path.Combine(character_path, "sound"));

                                var MyCharacterIni = new IniFile(Path.Combine(dataPaths["ModPath"], "Characters", character.CharacodeName, "character_config.ini"));

                                //Save Character Config

                                MyCharacterIni.Write("Partner", "false", "ModManager");
                                MyCharacterIni.Write("Page", "-1", "ModManager");
                                MyCharacterIni.Write("Slot", "-1", "ModManager");
                                MyCharacterIni.Write("Page_NS4", "-1", "ModManager");
                                MyCharacterIni.Write("Slot_NS4", "-1", "ModManager");
                                MyCharacterIni.Write("Game", gamePath, "ModManager");
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
                                ConditionPrmViewModel ExportConditionPrm = new ConditionPrmViewModel();
                                ConditionManagerViewModel ExportConditionPrmManager = new ConditionManagerViewModel();
                                GuardEffectParamViewModel ExportGuardEffectParam = new GuardEffectParamViewModel();


                                PlayerSettingParamS4ViewModel ExportPlayerSettingParamS4 = new PlayerSettingParamS4ViewModel();
                                SkillCustomizeParamS4ViewModel ExportSkillCustomizeParamS4 = new SkillCustomizeParamS4ViewModel();
                                CharacterSelectParamS4ViewModel ExportCharacterSelectParamS4 = new CharacterSelectParamS4ViewModel();
                                CostumeBreakColorParamS4ViewModel ExportCostumeBreakColorParamS4 = new CostumeBreakColorParamS4ViewModel();
                                MessageInfoS4ViewModel ExportMessageInfoS4 = new MessageInfoS4ViewModel();


                                /*----------------------------------------REQUIRED FILES--------------------------------------*/
                                //string moddingAPIPath = Path.Combine(Path.GetDirectoryName(DataWin32Path_field), "moddingapi", "mods", "base_game");
                                string character_moddingAPI_path = Path.Combine(dataPaths["ModPath"], "Characters", character.CharacodeName, "moddingapi", "param");
                                Directory.CreateDirectory(character_moddingAPI_path);
                                if (Directory.Exists(moddingApiPaths["Base"]))
                                {
                                    //Special Conditions
                                    if (File.Exists(moddingApiPaths["SpecialCondParam"]))
                                    {
                                        byte[] FileBytes = File.ReadAllBytes(moddingApiPaths["SpecialCondParam"]);
                                        int EntryCount = FileBytes.Length / 0x20;

                                        for (int z = 0; z < EntryCount; z++)
                                        {
                                            int ptr = 0x20 * z;
                                            string ConditionName = BinaryReader.b_ReadString(FileBytes, ptr);
                                            int CondCharacodeID = BinaryReader.b_ReadIntFromTwoBytes(FileBytes, ptr + 0x18);
                                            if (CondCharacodeID == character.CharacodeIndex)
                                            {
                                                byte[] Section = new byte[0x20];
                                                Section = BinaryReader.b_ReplaceString(Section, ConditionName, 0);
                                                Section = BinaryReader.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x18);
                                                File.WriteAllBytes(character_moddingAPI_path + "\\specialCondParam.xfbin", Section);
                                                break;
                                            }
                                        }
                                    }
                                    //Partners
                                    if (File.Exists(moddingApiPaths["PartnerSlotParam"]))
                                    {
                                        byte[] FileBytes = File.ReadAllBytes(moddingApiPaths["PartnerSlotParam"]);
                                        int EntryCount = FileBytes.Length / 0x20;

                                        for (int z = 0; z < EntryCount; z++)
                                        {
                                            int ptr = 0x20 * z;
                                            string ConditionName = BinaryReader.b_ReadString(FileBytes, ptr);
                                            int CondCharacodeID = BinaryReader.b_ReadIntFromTwoBytes(FileBytes, ptr + 0x18);
                                            if (CondCharacodeID == character.CharacodeIndex)
                                            {
                                                byte[] Section = new byte[0x20];
                                                Section = BinaryReader.b_ReplaceString(Section, ConditionName, 0);
                                                Section = BinaryReader.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x18);
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
                                    if (File.Exists(moddingApiPaths["SusanooCondParam"]))
                                    {
                                        byte[] FileBytes = File.ReadAllBytes(moddingApiPaths["SusanooCondParam"]);
                                        int EntryCount = FileBytes.Length / 0x20;

                                        for (int z = 0; z < EntryCount; z++)
                                        {
                                            int ptr = 0x20 * z;
                                            string ConditionName = BinaryReader.b_ReadString(FileBytes, ptr);
                                            int CondCharacodeID = BinaryReader.b_ReadIntFromTwoBytes(FileBytes, ptr + 0x18);
                                            if (CondCharacodeID == character.CharacodeIndex)
                                            {
                                                byte[] Section = new byte[0x20];
                                                Section = BinaryReader.b_ReplaceString(Section, ConditionName, 0);
                                                Section = BinaryReader.b_ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0x18);
                                                File.WriteAllBytes(character_moddingAPI_path + "\\susanooCondParam.xfbin", Section);
                                                break;
                                            }
                                        }
                                    }

                                    //OugiAwakeningParam
                                    if (File.Exists(moddingApiPaths["OugiAwakeningParam"]))
                                    {
                                        byte[] FileBytes = File.ReadAllBytes(moddingApiPaths["OugiAwakeningParam"]);
                                        int EntryCount = FileBytes.Length / 0x4;

                                        for (int z = 0; z < EntryCount; z++)
                                        {
                                            int ptr = 0x4 * z;
                                            int CondCharacodeID = BinaryReaderV2.ReadInt32LittleEndian(FileBytes, ptr);
                                            if (CondCharacodeID == character.CharacodeIndex)
                                            {
                                                byte[] Section = new byte[0x4];
                                                Section = BinaryWriterV2.ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0);
                                                File.WriteAllBytes(character_moddingAPI_path + "\\ougiAwakeningParam.xfbin", Section);
                                                break;
                                            }
                                        }
                                    }

                                    //GudoBallParam
                                    if (File.Exists(moddingApiPaths["GudoBallParam"]))
                                    {
                                        byte[] FileBytes = File.ReadAllBytes(moddingApiPaths["GudoBallParam"]);
                                        int EntryCount = FileBytes.Length / 0x4;

                                        for (int z = 0; z < EntryCount; z++)
                                        {
                                            int ptr = 0x4 * z;
                                            int CondCharacodeID = BinaryReaderV2.ReadInt32LittleEndian(FileBytes, ptr);
                                            if (CondCharacodeID == character.CharacodeIndex)
                                            {
                                                byte[] Section = new byte[0x4];
                                                Section = BinaryWriterV2.ReplaceBytes(Section, BitConverter.GetBytes(CondCharacodeID), 0);
                                                File.WriteAllBytes(character_moddingAPI_path + "\\gudoBallParam.xfbin", Section);
                                                break;
                                            }
                                        }
                                    }

                                }

                                //duelPlayerParam
                                if (File.Exists(dataPaths["DuelPlayerParam"]))
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
                                            //conditionprm and conditionprm manager
                                            if (File.Exists(dataPaths["ConditionPrm"]) && File.Exists(moddingApiPaths["ConditionPrmManager"]))
                                            {
                                                ConditionPrmModel selectedConditionPRM = ImportConditionPrm.ConditionList.FirstOrDefault(c => c.ConditionName == duelEntry.AwakeningCondition);
                                                ConditionManagerModel selectedConditionManager = ImportConditionPrmManager.ConditionList.FirstOrDefault(c => c.ConditionName == duelEntry.AwakeningCondition);

                                                if (selectedConditionPRM != null && selectedConditionManager != null)
                                                {
                                                    // Add the main condition
                                                    ExportConditionPrm.ConditionList.Add((ConditionPrmModel)selectedConditionPRM.Clone());
                                                    ExportConditionPrmManager.ConditionList.Add((ConditionManagerModel)selectedConditionManager.Clone());

                                                    string currentConditionName = selectedConditionManager.AfterConditionName;

                                                    // Loop to add debuff conditions recursively until AfterConditionName is null or empty
                                                    while (!string.IsNullOrEmpty(currentConditionName))
                                                    {
                                                        // Find the next condition (debuff)
                                                        ConditionPrmModel nextConditionPRM = ImportConditionPrm.ConditionList.FirstOrDefault(c => c.ConditionName == currentConditionName);
                                                        ConditionManagerModel nextConditionManager = ImportConditionPrmManager.ConditionList.FirstOrDefault(c => c.ConditionName == currentConditionName);

                                                        if (nextConditionPRM != null && nextConditionManager != null)
                                                        {
                                                            // Add the debuff condition
                                                            ExportConditionPrm.ConditionList.Add((ConditionPrmModel)nextConditionPRM.Clone());
                                                            ExportConditionPrmManager.ConditionList.Add((ConditionManagerModel)nextConditionManager.Clone());

                                                            // Set the next condition to be the AfterConditionName of the current debuff
                                                            currentConditionName = nextConditionManager.AfterConditionName;
                                                        } else
                                                        {
                                                            // Exit the loop if no matching condition is found
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                            break;




                                        }
                                    }
                                    if (ExportDuelPlayerParam.DuelPlayerParamList.Count < 1 && !ReplaceCharacter)
                                    {
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_32"]);
                                        continue;
                                    }
                                } else if (!File.Exists(dataPaths["DuelPlayerParam"]) && !ReplaceCharacter)
                                {
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_33"]);
                                    continue;
                                }

                                if (!isStorm4)
                                {
                                    //playerSettingParam NSC
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
                                } else
                                {
                                    //playerSettingParam S4
                                    foreach (PlayerSettingParamModel PSPEntry in ImportPlayerSettingParamS4.PlayerSettingParamList)
                                    {
                                        if (PSPEntry.CharacodeID == character.CharacodeIndex)
                                        {
                                            PSPEntry.DLC_ID = 0;
                                            ExportPlayerSettingParamS4.PlayerSettingParamList.Add((PlayerSettingParamModel)PSPEntry.Clone());
                                            if (!ExportMessageNameList.Contains(PSPEntry.CharacterNameMessageID))
                                                ExportMessageNameList.Add(PSPEntry.CharacterNameMessageID);
                                            if (!ExportMessageNameList.Contains(PSPEntry.CostumeDescriptionMessageID))
                                                ExportMessageNameList.Add(PSPEntry.CostumeDescriptionMessageID);

                                            CostumeParamModel CostumeEntry1 = new CostumeParamModel();
                                            CostumeEntry1.PlayerSettingParamID = PSPEntry.PSP_ID;
                                            CostumeEntry1.EntryIndex = 0;
                                            CostumeEntry1.CharacterName = PSPEntry.CharacterNameMessageID;
                                            if (CostumeEntry1.CharacterName == "")
                                                CostumeEntry1.CharacterName = "c_cha_404";
                                            CostumeEntry1.EntryType = 0;
                                            CostumeEntry1.UnlockCondition = 1;
                                            CostumeParamModel CostumeEntry2 = new CostumeParamModel();
                                            CostumeEntry2.PlayerSettingParamID = PSPEntry.PSP_ID;
                                            CostumeEntry2.EntryIndex = 0;
                                            CostumeEntry2.CharacterName = PSPEntry.CharacterNameMessageID;
                                            CostumeEntry2.EntryType = 1;
                                            CostumeEntry2.UnlockCondition = 1;
                                            if (CostumeEntry2.CharacterName == "")
                                                CostumeEntry2.CharacterName = "c_cha_404";
                                            ExportCostumeParam.CostumeParamList.Add(CostumeEntry1);
                                            ExportCostumeParam.CostumeParamList.Add(CostumeEntry2);
                                        }
                                    }
                                }
                                if (!isStorm4)
                                {
                                    //skillCustomizeParam NSC
                                    if (File.Exists(dataPaths["SkillCustomizeParam"]))
                                    {

                                        foreach (SkillCustomizeParamModel SkillEntry in ImportSkillCustomizeParam.SkillCustomizeParamList)
                                        {
                                            if (SkillEntry.CharacodeID == character.CharacodeIndex)
                                            {
                                                ExportSkillCustomizeParam.SkillCustomizeParamList.Add((SkillCustomizeParamModel)SkillEntry.Clone());
                                                if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                            MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " skillCustomizeParam entry.");
                                            continue;
                                        }
                                    } else if (!File.Exists(dataPaths["SkillCustomizeParam"]) && !ReplaceCharacter && !partner)
                                    {
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " skillCustomizeParam file.");
                                        continue;
                                    }
                                } else
                                {
                                    //skillCustomizeParam S4
                                    if (File.Exists(dataPaths["SkillCustomizeParam"]))
                                    {

                                        foreach (SkillCustomizeParamModel SkillEntry in ImportSkillCustomizeParamS4.SkillCustomizeParamList)
                                        {
                                            if (SkillEntry.CharacodeID == character.CharacodeIndex)
                                            {
                                                ExportSkillCustomizeParamS4.SkillCustomizeParamList.Add((SkillCustomizeParamModel)SkillEntry.Clone());
                                                if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                        if (ExportSkillCustomizeParamS4.SkillCustomizeParamList.Count < 1 && !ReplaceCharacter && !partner)
                                        {
                                            MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " skillCustomizeParam entry.");
                                            continue;
                                        }
                                    } else if (!File.Exists(dataPaths["SkillCustomizeParam"]) && !ReplaceCharacter && !partner)
                                    {
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " skillCustomizeParam file.");
                                        continue;
                                    }
                                }
                                //spSkillCustomizeParam
                                if (File.Exists(dataPaths["SpSkillCustomizeParam"]))
                                {

                                    foreach (SpSkillCustomizeParamModel SpSkillEntry in ImportSpSkillCustomizeParam.SpSkillCustomizeParamList)
                                    {
                                        if (SpSkillEntry.CharacodeID == character.CharacodeIndex)
                                        {
                                            ExportSpSkillCustomizeParam.SpSkillCustomizeParamList.Add((SpSkillCustomizeParamModel)SpSkillEntry.Clone());
                                            if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + "spSkillCustomizeParam entry.");
                                        continue;
                                    }
                                } else if (!File.Exists(dataPaths["SpSkillCustomizeParam"]) && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " spSkillCustomizeParam file.");
                                    continue;
                                }
                                //skillIndexSettingParam
                                if (File.Exists(dataPaths["SkillIndexSettingParam"]))
                                {

                                    foreach (SkillIndexSettingParamModel SkillIndexEntry in ImportSkillIndexParam.SkillIndexSettingParamList)
                                    {
                                        if (SkillIndexEntry.CharacodeID == character.CharacodeIndex)
                                        {
                                            ExportSkillIndexParam.SkillIndexSettingParamList.Add((SkillIndexSettingParamModel)SkillIndexEntry.Clone());
                                            break;
                                        }
                                    }
                                    //if (ExportSkillIndexParam.SkillIndexSettingParamList.Count < 1 && !ReplaceCharacter && !partner)
                                    //{
                                    //    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " skillIndexSettingParam entry.");
                                    //    continue;
                                    //}
                                } else
                                {
                                    SkillIndexSettingParamModel SkillIndexEntry = new SkillIndexSettingParamModel();
                                    SkillIndexEntry.CharacodeID = character.CharacodeIndex;
                                    SkillIndexEntry.JutsuIndex1 = 0;
                                    SkillIndexEntry.JutsuIndex2 = 0;
                                    ExportSkillIndexParam.SkillIndexSettingParamList.Add((SkillIndexSettingParamModel)SkillIndexEntry.Clone());

                                }
                                //supportSkillRecoverySpeedParam
                                if (File.Exists(dataPaths["SupportSkillRecoverySpeedParam"]))
                                {

                                    foreach (SupportSkillRecoverySpeedParamModel supportSkillRecoveryEntry in ImportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList)
                                    {
                                        if (supportSkillRecoveryEntry.CharacodeID == character.CharacodeIndex)
                                        {
                                            ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Add((SupportSkillRecoverySpeedParamModel)supportSkillRecoveryEntry.Clone());
                                            break;
                                        }
                                    }
                                    //if (ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Count < 1 && !ReplaceCharacter && !partner)
                                    //{
                                    //    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " supportSkillRecoverySpeedParam entry.");
                                    //    continue;
                                    //}
                                } else
                                {
                                    SupportSkillRecoverySpeedParamModel supportSkillRecoveryEntry = new SupportSkillRecoverySpeedParamModel();
                                    supportSkillRecoveryEntry.CharacodeID = character.CharacodeIndex;
                                    supportSkillRecoveryEntry.Jutsu1 = 1;
                                    supportSkillRecoveryEntry.Jutsu2 = 1;
                                    supportSkillRecoveryEntry.Jutsu3 = 1;
                                    supportSkillRecoveryEntry.Jutsu4 = 1;
                                    supportSkillRecoveryEntry.Jutsu5 = 1;
                                    supportSkillRecoveryEntry.Jutsu6 = 1;
                                    supportSkillRecoveryEntry.Jutsu1_awa = 1;
                                    supportSkillRecoveryEntry.Jutsu2_awa = 1;
                                    ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Add((SupportSkillRecoverySpeedParamModel)supportSkillRecoveryEntry.Clone());


                                }

                                //privateCamera
                                if (File.Exists(dataPaths["PrivateCamera"]))
                                {

                                    foreach (PrivateCameraModel PrivateCameraEntry in ImportPrivateCamera.PrivateCameraList)
                                    {
                                        if (PrivateCameraEntry.CharacodeIndex == character.CharacodeIndex)
                                        {
                                            ExportPrivateCamera.PrivateCameraList.Add((PrivateCameraModel)PrivateCameraEntry.Clone());
                                            break;
                                        }
                                    }
                                    if (ExportPrivateCamera.PrivateCameraList.Count < 1)
                                    {
                                        PrivateCameraModel PrivateCameraEntry = new PrivateCameraModel();
                                        PrivateCameraEntry.CharacodeIndex = character.CharacodeIndex;
                                        PrivateCameraEntry.Unk1 = -1;
                                        PrivateCameraEntry.Unk2 = -1;
                                        PrivateCameraEntry.FOV = -1;
                                        PrivateCameraEntry.FOV2 = -1;
                                        PrivateCameraEntry.CameraAngle = -1;
                                        PrivateCameraEntry.CameraDistance = -1;
                                        PrivateCameraEntry.CameraDistance2 = -1;
                                        PrivateCameraEntry.CameraHeight = -1;
                                        PrivateCameraEntry.CameraHeight2 = -1;
                                        PrivateCameraEntry.CameraMovement = -1;
                                        PrivateCameraEntry.CameraSpeed = -1;
                                        ExportPrivateCamera.PrivateCameraList.Add((PrivateCameraModel)PrivateCameraEntry.Clone());
                                    }
                                } else
                                {
                                    PrivateCameraModel PrivateCameraEntry = new PrivateCameraModel();
                                    PrivateCameraEntry.CharacodeIndex = character.CharacodeIndex;
                                    PrivateCameraEntry.Unk1 = -1;
                                    PrivateCameraEntry.Unk2 = -1;
                                    PrivateCameraEntry.FOV = -1;
                                    PrivateCameraEntry.FOV2 = -1;
                                    PrivateCameraEntry.CameraAngle = -1;
                                    PrivateCameraEntry.CameraDistance = -1;
                                    PrivateCameraEntry.CameraDistance2 = -1;
                                    PrivateCameraEntry.CameraHeight = -1;
                                    PrivateCameraEntry.CameraHeight2 = -1;
                                    PrivateCameraEntry.CameraMovement = -1;
                                    PrivateCameraEntry.CameraSpeed = -1;
                                    ExportPrivateCamera.PrivateCameraList.Add((PrivateCameraModel)PrivateCameraEntry.Clone());
                                }

                                if (!isStorm4)
                                {
                                    //characterSelectParam NSC
                                    if (File.Exists(dataPaths["CharacterSelectParam"]))
                                    {

                                        foreach (CharacterSelectParamModel CharacterSelectParamEntry in ImportCharacterSelectParam.CharacterSelectParamList)
                                        {
                                            for (int i = 0; i < ExportPlayerSettingParam.PlayerSettingParamList.Count; i++)
                                            {
                                                if (CharacterSelectParamEntry.CSP_code == ExportPlayerSettingParam.PlayerSettingParamList[i].PSP_code)
                                                {
                                                    ExportCharacterSelectParam.CharacterSelectParamList.Add((CharacterSelectParamModel)CharacterSelectParamEntry.Clone());
                                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                            MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " characterSelectParam entry.");
                                            continue;
                                        }
                                    } else if (!File.Exists(dataPaths["CharacterSelectParam"]) && !ReplaceCharacter && !partner)
                                    {
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " characterSelectParam file.");
                                        continue;
                                    }
                                } else
                                {
                                    //characterSelectParam S4
                                    if (File.Exists(dataPaths["CharacterSelectParam"]))
                                    {

                                        foreach (CharacterSelectParamModel CharacterSelectParamEntry in ImportCharacterSelectParamS4.CharacterSelectParamList)
                                        {
                                            for (int i = 0; i < ExportPlayerSettingParamS4.PlayerSettingParamList.Count; i++)
                                            {
                                                if (CharacterSelectParamEntry.CSP_code == ExportPlayerSettingParamS4.PlayerSettingParamList[i].PSP_code)
                                                {
                                                    CharacterSelectParamEntry.CostumeIndex -= 1;
                                                    ExportCharacterSelectParamS4.CharacterSelectParamList.Add((CharacterSelectParamModel)CharacterSelectParamEntry.Clone());
                                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                        if (ExportCharacterSelectParamS4.CharacterSelectParamList.Count < 1 && !ReplaceCharacter && !partner)
                                        {
                                            MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " characterSelectParam entry.");
                                            continue;
                                        }
                                    } else if (!File.Exists(dataPaths["CharacterSelectParam"]) && !ReplaceCharacter && !partner)
                                    {
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " characterSelectParam file.");
                                        continue;
                                    }
                                }
                                if (!isStorm4)
                                {
                                    //costumeBreakColorParam NSC
                                    if (File.Exists(dataPaths["CostumeBreakColorParam"]))
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
                                    }
                                } else
                                {
                                    //costumeBreakColorParam S4
                                    if (File.Exists(dataPaths["CostumeBreakColorParam"]))
                                    {

                                        foreach (CostumeBreakColorParamModel CostumeBreakColorEntry in ImportCostumeBreakColorParamS4.CostumeBreakColorParamList)
                                        {
                                            for (int i = 0; i < ExportPlayerSettingParamS4.PlayerSettingParamList.Count; i++)
                                            {
                                                if (CostumeBreakColorEntry.PlayerSettingParamID == ExportPlayerSettingParamS4.PlayerSettingParamList[i].PSP_ID)
                                                {
                                                    ExportCostumeBreakColorParamS4.CostumeBreakColorParamList.Add((CostumeBreakColorParamModel)CostumeBreakColorEntry.Clone());
                                                    break;
                                                }
                                            }

                                        }
                                    }
                                }

                                if (!isStorm4)
                                {
                                    //costumeParam
                                    // if (costumeParamExist) {
                                    foreach (CostumeParamModel CostumeEntry in ImportCostumeParam.CostumeParamList)
                                    {
                                        for (int i = 0; i < ExportPlayerSettingParam.PlayerSettingParamList.Count; i++)
                                        {
                                            if (CostumeEntry.PlayerSettingParamID == ExportPlayerSettingParam.PlayerSettingParamList[i].PSP_ID)
                                            {
                                                ExportCostumeParam.CostumeParamList.Add((CostumeParamModel)CostumeEntry.Clone());
                                                if (Directory.Exists(dataPaths["MessageInfoFolder"]))
                                                {
                                                    if (!ExportMessageNameList.Contains(CostumeEntry.CharacterName))
                                                        ExportMessageNameList.Add(CostumeEntry.CharacterName);
                                                }
                                            }
                                        }

                                    }
                                    if (ExportCostumeParam.CostumeParamList.Count < 1 && !ReplaceCharacter && !partner)
                                    {
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " costumeParam entry.");
                                        continue;
                                    }
                                    //} else if (!costumeParamExist && !ReplaceCharacter && !partner) {
                                    //    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] +" " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + "costumeParam file.");
                                    //    continue;
                                    //}
                                } 
                                //player_icon
                                if (File.Exists(dataPaths["PlayerIcon"]))
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
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " player_icon entry.");
                                        continue;
                                    }
                                } else if (!File.Exists(dataPaths["PlayerIcon"]) && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " player_icon file.");
                                    continue;
                                }
                                //cmnparam
                                if (File.Exists(dataPaths["CmnParam"]))
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
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " cmnparam player_snd entry.");
                                        continue;
                                    }
                                } else if (!File.Exists(dataPaths["CmnParam"]) && !ReplaceCharacter)
                                {
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " cmnparam player_snd file.");
                                    continue;
                                }
                                //supportActionParam
                                if (File.Exists(dataPaths["SupportActionParam"]))
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
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " supportActionParam entry.");
                                        continue;
                                    }
                                } else if (!File.Exists(dataPaths["PlayerSettingParam"]) && !ReplaceCharacter && !partner)
                                {
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_31"] + " " + character.CharacodeName + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + " supportActionParam file.");
                                    continue;
                                }
                                /*----------------------------------------NOT REQUIRED FILES--------------------------------------*/
                                //awakeAura
                                if (File.Exists(dataPaths["AwakeAura"]))
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
                                if (File.Exists(dataPaths["AppearanceAnm"]))
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
                                if (File.Exists(dataPaths["AfterAttachObject"]))
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
                                if (File.Exists(dataPaths["PlayerDoubleEffectParam"]))
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
                                if (File.Exists(dataPaths["SpTypeSupportParam"]))
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
                                if (File.Exists(dataPaths["CostumeBreakParam"]))
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
                                if (File.Exists(dataPaths["DamagePrm"]))
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
                                string prm_load_path = Path.Combine(DataWin32Path_field, "spcload", character.CharacodeName + "prm_load.bin.xfbin");
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
                                            prm_path = Path.Combine(DataWin32Path_field, PRM_Load_Entry.FilePath, PRM_Load_Entry.FileName.Replace("<code>", character.CharacodeName) + ".xfbin");
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
                                                    if (File.Exists(dataPaths["DamageEff"]))
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
                                                                    if (File.Exists(dataPaths["EffectPrm"]))
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
                                                    if (ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].FunctionID == 0x96 && Directory.Exists(dataPaths["MessageInfoFolder"]))
                                                    {
                                                        if (!ExportMessageNameList.Contains(ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].StringParam))
                                                            ExportMessageNameList.Add(ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].StringParam);
                                                    }

                                                    if (ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].FunctionID > 0x120 & isStorm4)
                                                    {
                                                        ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].FunctionID = 0x10E;
                                                    }

                                                }
                                            }
                                        }
                                    }

                                }
                                if (!isStorm4)
                                {
                                    //messageInfo NSC
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                } else
                                {
                                    //messageInfo S4
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
                                    {
                                        for (int i = 1; i < 20; i++)
                                        {
                                            ExportMessageNameList.Add(character.CharacodeName + "_bd_" + i.ToString("D2"));
                                        }
                                        if (ExportMessageNameList.IndexOf("") != -1)
                                            ExportMessageNameList.RemoveAt(ExportMessageNameList.IndexOf(""));
                                        for (int i = 0; i < ExportMessageNameList.Count; i++)
                                        {
                                            ImportMessageInfoS4.MessageInfo_preview_List = ImportMessageInfoS4.MessageInfo_List[0];
                                            for (int message = 0; message < ImportMessageInfoS4.MessageInfo_preview_List.Count; message++)
                                            {
                                                if (BitConverter.ToString(ImportMessageInfoS4.MessageInfo_preview_List[message].CRC32Code) == BitConverter.ToString(BinaryReader.crc32(ExportMessageNameList[i])))
                                                {

                                                    for (int l = 0; l < Program.langS4List.Length; l++)
                                                    {
                                                        MessageInfoModel copy_entry = (MessageInfoModel)ImportMessageInfoS4.MessageInfo_List[l][message].Clone();
                                                        ExportMessageInfoS4.MessageInfo_List[l].Add(copy_entry);
                                                    }
                                                    break;
                                                }
                                            }
                                        }


                                    }
                                }

                                if (File.Exists(moddingApiPaths["SpecialInteractionManager"]))
                                {
                                    SpecialInteractionManagerModel specialInteractionEntry = ImportSpecialInteraction.SpecialInteractionList.FirstOrDefault(item => item.MainCharacodeID == character.CharacodeIndex);

                                    if (specialInteractionEntry != null && specialInteractionEntry.TriggerList != null && specialInteractionEntry.TriggerList.Count > 0)
                                    {
                                        //specialInteractionManager
                                        string characodeNamesString = string.Join(",",
                                           specialInteractionEntry.TriggerList
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
                                        //if (characodeNamesString.Split(',').Length != specialInteractionEntry.TriggerList.Count)
                                        //{
                                        //    return;
                                        //}
                                        if (specialInteractionEntry.TriggerList.Count > 0)
                                        {
                                            var specialInteractionIni = new IniFile(Path.Combine(dataPaths["ModPath"], "Characters", character.CharacodeName, "specialInteraction_config.ini"));


                                            //specialInteractionIni.Write("MainCharacode", character.CharacodeName, "ModManager");
                                            specialInteractionIni.Write("TriggerList", characodeNamesString, "ModManager");
                                        }
                                    }


                                }
                                if (File.Exists(moddingApiPaths["GuardEffectParam"]))
                                {

                                    foreach (GuardEffectParamModel GuardEffectParamEntry in ImportGuardEffectParam.GuardEffectParamList)
                                    {
                                        if (GuardEffectParamEntry.CharacodeID == character.CharacodeIndex)
                                        {
                                            ExportGuardEffectParam.GuardEffectParamList.Add((GuardEffectParamModel)GuardEffectParamEntry.Clone());
                                        }
                                    }
                                }


                                //Save All Params
                                if (!isStorm4)
                                {
                                    if (ExportDuelPlayerParam.DuelPlayerParamList.Count > 0)
                                        ExportDuelPlayerParam.SaveFileAs(Path.Combine(character_path, "spc", "duelPlayerParam.xfbin"));
                                    if (ExportPlayerSettingParam.PlayerSettingParamList.Count > 0)
                                        ExportPlayerSettingParam.SaveFileAs(Path.Combine(character_path, "spc", "playerSettingParam.bin.xfbin"));
                                    if (ExportSkillCustomizeParam.SkillCustomizeParamList.Count > 0)
                                        ExportSkillCustomizeParam.SaveFileAs(Path.Combine(character_path, "spc", "skillCustomizeParam.xfbin"));
                                    if (ExportSpSkillCustomizeParam.SpSkillCustomizeParamList.Count > 0)
                                        ExportSpSkillCustomizeParam.SaveFileAs(Path.Combine(character_path, "spc", "spSkillCustomizeParam.xfbin"));
                                    if (ExportSkillIndexParam.SkillIndexSettingParamList.Count > 0)
                                        ExportSkillIndexParam.SaveFileAs(Path.Combine(character_path, "spc", "skillIndexSettingParam.xfbin"));
                                    if (ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Count > 0)
                                        ExportSupportSkillRecoverySpeed.SaveFileAs(Path.Combine(character_path, "spc", "supportSkillRecoverySpeedParam.xfbin"));
                                    if (ExportPlayerIcon.playerIconList.Count > 0)
                                        ExportPlayerIcon.SaveFileAs(Path.Combine(character_path, "spc", "player_icon.xfbin"));
                                    if (ExportAwakeAura.AwakeAuraList.Count > 0)
                                        ExportAwakeAura.SaveFileAs(Path.Combine(character_path, "spc", "awakeAura.xfbin"));
                                    if (ExportAppearanceAnm.AppearanceAnmList.Count > 0)
                                        ExportAppearanceAnm.SaveFileAs(Path.Combine(character_path, "spc", "appearanceAnm.xfbin"));
                                    if (ExportCharacterSelectParam.CharacterSelectParamList.Count > 0)
                                        ExportCharacterSelectParam.SaveFileAs(Path.Combine(character_path, "ui", "max", "select", "characterSelectParam.xfbin"));
                                    if (ExportAfterAttachObject.AfterAttachObjectList.Count > 0)
                                        ExportAfterAttachObject.SaveFileAs(Path.Combine(character_path, "spc", "afterAttachObject.xfbin"));
                                    if (ExportSpTypeSupportParam.SpTypeSupportParamList.Count > 0)
                                        ExportSpTypeSupportParam.SaveFileAs(Path.Combine(character_path, "spc", "spTypeSupportParam.xfbin"));
                                    if (ExportCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                        ExportCostumeBreakParam.SaveFileAs(Path.Combine(character_path, "spc", "costumeBreakParam.xfbin"));
                                    if (ExportCostumeBreakColorParam.CostumeBreakColorParamList.Count > 0)
                                        ExportCostumeBreakColorParam.SaveFileAs(Path.Combine(character_path, "spc", "costumeBreakColorParam.xfbin"));
                                    if (ExportCostumeParam.CostumeParamList.Count > 0)
                                        ExportCostumeParam.SaveFileAs(Path.Combine(character_path, "rpg", "param", "costumeParam.bin.xfbin"));
                                    if (ExportPrivateCamera.PrivateCameraList.Count > 0)
                                        ExportPrivateCamera.SaveFileAs(Path.Combine(character_path, "spc", "privateCamera.bin.xfbin"));
                                    if (ExportPlayerDoubleEffectParam.PlayerDoubleEffectParamList.Count > 0)
                                        ExportPlayerDoubleEffectParam.SaveFileAs(Path.Combine(character_path, "spc", "playerDoubleEffectParam.xfbin"));
                                    if (ExportSupportActionParam.SupportActionParamList.Count > 0)
                                        ExportSupportActionParam.SaveFileAs(Path.Combine(character_path, "spc", "supportActionParam.xfbin"));
                                    if (ExportCmnParam.PlayerSndList.Count > 0)
                                        ExportCmnParam.SaveFileAs(Path.Combine(character_path, "sound", "cmnparam.xfbin"));
                                    if (ExportDamageEff.DamageEffList.Count > 0)
                                        ExportDamageEff.SaveFileAs(Path.Combine(character_path, "spc", "damageeff.bin.xfbin"));
                                    if (ExportEffectPrm.EffectPrmList.Count > 0)
                                        ExportEffectPrm.SaveFileAs(Path.Combine(character_path, "spc", "effectprm.bin.xfbin"));
                                    if (ExportMessageInfo.MessageInfo_List[0].Count > 0)
                                        ExportMessageInfo.SaveFileAs(character_path);
                                    if (ExportDamagePrm.DamagePrmList.Count > 0)
                                        ExportDamagePrm.SaveFileAs(Path.Combine(character_path, "spc", "damageprm.bin.xfbin"));
                                    if (ExportConditionPrm.ConditionList.Count > 0)
                                        ExportConditionPrm.SaveFileAs(Path.Combine(character_path, "spc", "conditionprm.bin.xfbin"));
                                    if (ExportConditionPrmManager.ConditionList.Count > 0)
                                        ExportConditionPrmManager.SaveFileAs(Path.Combine(character_moddingAPI_path, "conditionprmManager.xfbin"));
                                    if (ExportGuardEffectParam.GuardEffectParamList.Count > 0)
                                        ExportGuardEffectParam.SaveFileAs(Path.Combine(character_moddingAPI_path, "guardEffectParam.xfbin"));
                                } else
                                {
                                    //if (ExportDuelPlayerParam.DuelPlayerParamList.Count > 0)
                                    //    ExportDuelPlayerParam.SaveFileAs(Path.Combine(character_path, "spc", "duelPlayerParam.xfbin"));
                                    //if (ExportPlayerSettingParamS4.PlayerSettingParamList.Count > 0)
                                    //    ExportPlayerSettingParamS4.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "playerSettingParam.bin.xfbin"));
                                    //if (ExportSkillCustomizeParamS4.SkillCustomizeParamList.Count > 0)
                                    //    ExportSkillCustomizeParamS4.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "skillCustomizeParam.xfbin"));
                                    //if (ExportSpSkillCustomizeParam.SpSkillCustomizeParamList.Count > 0)
                                    //    ExportSpSkillCustomizeParam.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "spSkillCustomizeParam.xfbin"));
                                    //if (ExportPlayerIcon.playerIconList.Count > 0)
                                    //    ExportPlayerIcon.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "player_icon.xfbin"));
                                    //if (ExportAwakeAura.AwakeAuraList.Count > 0)
                                    //    ExportAwakeAura.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "awakeAura.xfbin"));
                                    //if (ExportAppearanceAnm.AppearanceAnmList.Count > 0)
                                    //    ExportAppearanceAnm.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "appearanceAnm.xfbin"));
                                    //if (ExportCharacterSelectParamS4.CharacterSelectParamList.Count > 0)
                                    //    ExportCharacterSelectParamS4.SaveFileAs(Path.Combine(character_path, "ui", "max", "select", "WIN64", "characterSelectParam.xfbin"));
                                    //if (ExportAfterAttachObject.AfterAttachObjectList.Count > 0)
                                    //    ExportAfterAttachObject.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "afterAttachObject.xfbin"));
                                    //if (ExportSpTypeSupportParam.SpTypeSupportParamList.Count > 0)
                                    //    ExportSpTypeSupportParam.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "spTypeSupportParam.xfbin"));
                                    //if (ExportCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                    //    ExportCostumeBreakParam.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "costumeBreakParam.xfbin"));
                                    //if (ExportCostumeBreakColorParamS4.CostumeBreakColorParamList.Count > 0)
                                    //    ExportCostumeBreakColorParamS4.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "costumeBreakColorParam.xfbin"));
                                    //if (ExportCostumeParam.CostumeParamList.Count > 0)
                                    //    ExportCostumeParam.SaveFileAs(Path.Combine(character_path, "rpg", "param", "WIN64", "costumeParam.bin.xfbin"));
                                    //if (ExportPrivateCamera.PrivateCameraList.Count > 0)
                                    //    ExportPrivateCamera.SaveFileAs(Path.Combine(character_path, "spc", "privateCamera.bin.xfbin"));
                                    //if (ExportPlayerDoubleEffectParam.PlayerDoubleEffectParamList.Count > 0)
                                    //    ExportPlayerDoubleEffectParam.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "playerDoubleEffectParam.xfbin"));
                                    //if (ExportSupportActionParam.SupportActionParamList.Count > 0)
                                    //    ExportSupportActionParam.SaveFileAs(Path.Combine(character_path, "spc", "WIN64", "supportActionParam.xfbin"));
                                    //if (ExportCmnParam.PlayerSndList.Count > 0)
                                    //    ExportCmnParam.SaveFileAs(Path.Combine(character_path, "sound", "cmnparam.xfbin"));
                                    //if (ExportDamageEff.DamageEffList.Count > 0)
                                    //    ExportDamageEff.SaveFileAs(Path.Combine(character_path, "spc", "damageeff.bin.xfbin"));
                                    //if (ExportEffectPrm.EffectPrmList.Count > 0)
                                    //    ExportEffectPrm.SaveFileAs(Path.Combine(character_path, "spc", "effectprm.bin.xfbin"));
                                    //if (ExportMessageInfoS4.MessageInfo_List[0].Count > 0)
                                    //    ExportMessageInfoS4.SaveFileAs(character_path);
                                    //if (ExportDamagePrm.DamagePrmList.Count > 0)
                                    //    ExportDamagePrm.SaveFileAs(Path.Combine(character_path, "spc", "damageprm.bin.xfbin"));
                                    //if (ExportConditionPrm.ConditionList.Count > 0)
                                    //    ExportConditionPrm.SaveFileAs(Path.Combine(character_path, "spc", "conditionprm.bin.xfbin"));
                                    //if (ExportConditionPrmManager.ConditionList.Count > 0)
                                    //    ExportConditionPrmManager.SaveFileAs(Path.Combine(character_moddingAPI_path, "conditionprmManager.xfbin"));

                                    if (ExportDuelPlayerParam.DuelPlayerParamList.Count > 0)
                                        ExportDuelPlayerParam.SaveFileAs(Path.Combine(character_path, "spc", "duelPlayerParam.xfbin"));
                                    if (ExportPlayerSettingParamS4.PlayerSettingParamList.Count > 0)
                                        ExportPlayerSettingParamS4.SaveFileAs(Path.Combine(character_path, "spc", "playerSettingParam.bin.xfbin"));
                                    if (ExportSkillCustomizeParamS4.SkillCustomizeParamList.Count > 0)
                                        ExportSkillCustomizeParamS4.SaveFileAs(Path.Combine(character_path, "spc", "skillCustomizeParam.xfbin"));
                                    if (ExportSpSkillCustomizeParam.SpSkillCustomizeParamList.Count > 0)
                                        ExportSpSkillCustomizeParam.SaveFileAs(Path.Combine(character_path, "spc", "spSkillCustomizeParam.xfbin"));
                                    if (ExportPlayerIcon.playerIconList.Count > 0)
                                        ExportPlayerIcon.SaveFileAs(Path.Combine(character_path, "spc","player_icon.xfbin"));
                                    if (ExportAwakeAura.AwakeAuraList.Count > 0)
                                        ExportAwakeAura.SaveFileAs(Path.Combine(character_path, "spc", "awakeAura.xfbin"));
                                    if (ExportAppearanceAnm.AppearanceAnmList.Count > 0)
                                        ExportAppearanceAnm.SaveFileAs(Path.Combine(character_path, "spc", "appearanceAnm.xfbin"));
                                    if (ExportCharacterSelectParamS4.CharacterSelectParamList.Count > 0)
                                        ExportCharacterSelectParamS4.SaveFileAs(Path.Combine(character_path, "ui", "max", "select", "characterSelectParam.xfbin"));
                                    if (ExportAfterAttachObject.AfterAttachObjectList.Count > 0)
                                        ExportAfterAttachObject.SaveFileAs(Path.Combine(character_path, "spc", "afterAttachObject.xfbin"));
                                    if (ExportSpTypeSupportParam.SpTypeSupportParamList.Count > 0)
                                        ExportSpTypeSupportParam.SaveFileAs(Path.Combine(character_path, "spc", "spTypeSupportParam.xfbin"));
                                    if (ExportCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                        ExportCostumeBreakParam.SaveFileAs(Path.Combine(character_path, "spc", "costumeBreakParam.xfbin"));
                                    if (ExportCostumeBreakColorParamS4.CostumeBreakColorParamList.Count > 0)
                                        ExportCostumeBreakColorParamS4.SaveFileAs(Path.Combine(character_path, "spc","costumeBreakColorParam.xfbin"));
                                    if (ExportCostumeParam.CostumeParamList.Count > 0)
                                        ExportCostumeParam.SaveFileAs(Path.Combine(character_path, "rpg", "param", "costumeParam.bin.xfbin"));
                                    if (ExportPrivateCamera.PrivateCameraList.Count > 0)
                                        ExportPrivateCamera.SaveFileAs(Path.Combine(character_path, "spc", "privateCamera.bin.xfbin"));
                                    if (ExportPlayerDoubleEffectParam.PlayerDoubleEffectParamList.Count > 0)
                                        ExportPlayerDoubleEffectParam.SaveFileAs(Path.Combine(character_path, "spc", "playerDoubleEffectParam.xfbin"));
                                    if (ExportSupportActionParam.SupportActionParamList.Count > 0)
                                        ExportSupportActionParam.SaveFileAs(Path.Combine(character_path, "spc", "supportActionParam.xfbin"));
                                    if (ExportCmnParam.PlayerSndList.Count > 0)
                                        ExportCmnParam.SaveFileAs(Path.Combine(character_path, "sound", "cmnparam.xfbin"));
                                    if (ExportDamageEff.DamageEffList.Count > 0)
                                        ExportDamageEff.SaveFileAs(Path.Combine(character_path, "spc", "damageeff.bin.xfbin"));
                                    if (ExportEffectPrm.EffectPrmList.Count > 0)
                                        ExportEffectPrm.SaveFileAs(Path.Combine(character_path, "spc", "effectprm.bin.xfbin"));
                                    if (ExportMessageInfoS4.MessageInfo_List[0].Count > 0)
                                        ExportMessageInfoS4.SaveFileAs(character_path);
                                    if (ExportDamagePrm.DamagePrmList.Count > 0)
                                        ExportDamagePrm.SaveFileAs(Path.Combine(character_path, "spc", "damageprm.bin.xfbin"));
                                    if (ExportConditionPrm.ConditionList.Count > 0)
                                        ExportConditionPrm.SaveFileAs(Path.Combine(character_path, "spc", "conditionprm.bin.xfbin"));
                                    if (ExportConditionPrmManager.ConditionList.Count > 0)
                                        ExportConditionPrmManager.SaveFileAs(Path.Combine(character_moddingAPI_path, "conditionprmManager.xfbin"));

                                    if (ExportSkillIndexParam.SkillIndexSettingParamList.Count > 0)
                                        ExportSkillIndexParam.SaveFileAs(Path.Combine(character_path, "spc", "skillIndexSettingParam.xfbin"));
                                    if (ExportSupportSkillRecoverySpeed.SupportSkillRecoverySpeedParamList.Count > 0)
                                        ExportSupportSkillRecoverySpeed.SaveFileAs(Path.Combine(character_path, "spc", "supportSkillRecoverySpeedParam.xfbin"));
                                }




                            }


                            break;
                        //Compile Stage Mod
                        case 1:

                            MessageInfoViewModel ImportStageMessageInfo = new MessageInfoViewModel();
                            MessageInfoS4ViewModel ImportStageMessageInfoS4 = new MessageInfoS4ViewModel();

                            if (Directory.Exists(dataPaths["MessageInfoFolder"]) && !isStorm4)
                                ImportStageMessageInfo.OpenFiles(dataPaths["MessageInfoFolder"]);
                            else if (Directory.Exists(dataPaths["MessageInfoFolder"]) && isStorm4)
                                ImportStageMessageInfoS4.OpenFiles(dataPaths["MessageInfoFolder"]);
                            int StageIndex = 0;
                            foreach (StageInfoModel stage in ExportStageList)
                            {

                                string stage_moddingAPI_path = Path.Combine(dataPaths["ModPath"], "Stages", stage.StageName, "moddingapi", "param", gamePath);
                                StageInfoViewModel ExportStage = new StageInfoViewModel();
                                MessageInfoViewModel ExportStageMessageInfo = new MessageInfoViewModel();
                                MessageInfoS4ViewModel ExportStageMessageInfoS4 = new MessageInfoS4ViewModel();

                                //BgmManagerParam

                                if (File.Exists(moddingApiPaths["BgmManagerParam"]))
                                {
                                    byte[] FileBytes = File.ReadAllBytes(moddingApiPaths["BgmManagerParam"]);
                                    int EntryCount = FileBytes.Length / 0x68;

                                    for (int z = 0; z < EntryCount; z++)
                                    {
                                        int ptr = 0x68 * z;
                                        string StageName = BinaryReaderV2.ReadNullTerminatedString(FileBytes, ptr);
                                        string StageSfx = BinaryReaderV2.ReadNullTerminatedString(FileBytes, 0x30);
                                        int BgmId = BinaryReaderV2.ReadInt32LittleEndian(FileBytes, 0x60);
                                        int Unk = BinaryReaderV2.ReadInt32LittleEndian(FileBytes, 0x64);
                                        if (StageName == stage.StageName)
                                        {
                                            byte[] Section = new byte[0x68];
                                            Section = BinaryWriterV2.ReplaceBytes(Section, Encoding.ASCII.GetBytes(StageName), 0);
                                            Section = BinaryWriterV2.ReplaceBytes(Section, Encoding.ASCII.GetBytes(StageSfx), 0x30);
                                            Section = BinaryWriterV2.ReplaceBytes(Section, BitConverter.GetBytes(BgmId), 0x34);
                                            Section = BinaryWriterV2.ReplaceBytes(Section, BitConverter.GetBytes(Unk), 0x34);
                                            File.WriteAllBytes(stage_moddingAPI_path + "\\bgmManagerParam.xfbin", Section);
                                            break;
                                        }
                                    }
                                }
                                ExportStage.StageInfoList.Add((StageInfoModel)stage.Clone());
                                if (!isStorm4)
                                {
                                    //MessageInfo NSC
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                } else
                                {
                                    //MessageInfo S4
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
                                    {
                                        ImportStageMessageInfoS4.MessageInfo_preview_List = ImportStageMessageInfoS4.MessageInfo_List[0];
                                        for (int message = 0; message < ImportStageMessageInfoS4.MessageInfo_preview_List.Count; message++)
                                        {
                                            if (BitConverter.ToString(ImportStageMessageInfoS4.MessageInfo_preview_List[message].CRC32Code) == BitConverter.ToString(BinaryReader.crc32(StageMessageIDList[StageIndex])))
                                            {

                                                for (int l = 0; l < Program.langS4List.Length; l++)
                                                {
                                                    MessageInfoModel copy_entry = (MessageInfoModel)ImportStageMessageInfoS4.MessageInfo_List[l][message].Clone();
                                                    ExportStageMessageInfoS4.MessageInfo_List[l].Add(copy_entry);
                                                }
                                                break;
                                            }
                                        }
                                    }
                                }

                                //Save All Params
                                string stagePath = Path.Combine(dataPaths["ModPath"], "Stages", stage.StageName, "data");
                                Directory.CreateDirectory(Path.Combine(stagePath, "stage", "WIN64"));

                                ExportStage.SaveFileAs(Path.Combine(stagePath, "stage", "StageInfo.bin.xfbin"), true);
                                if (ExportStageMessageInfo.MessageInfo_List[0].Count > 0)
                                    ExportStageMessageInfo.SaveFileAs(stagePath);


                                bool hellExist = stage.FilePaths.Any(file => file.FilePath.Contains("wall"));

                                // Save Stage Config
                                var MyStageIni = new IniFile(Path.Combine(dataPaths["ModPath"], "Stages", stage.StageName, "stage_config.ini"));
                                MyStageIni.Write("BGM_ID", StageBGMIDList[StageIndex].ToString(), "ModManager");
                                MyStageIni.Write("BGM_ID_NS4", StageBGMID_NS4_List[StageIndex].ToString(), "ModManager");
                                MyStageIni.Write("MessageID", StageMessageIDList[StageIndex], "ModManager");
                                MyStageIni.Write("Hell", hellExist.ToString().ToLower(), "ModManager");
                                MyStageIni.Write("Game", gamePath, "ModManager");

                                // Save Stage Icon
                                File.Copy(StageIconPathListSC[StageIndex], Path.Combine(dataPaths["ModPath"], "Stages", stage.StageName, "stage_icon_SC.dds"), true);
                                File.Copy(StageIconPathListS4[StageIndex], Path.Combine(dataPaths["ModPath"], "Stages", stage.StageName, "stage_icon_S4.dds"), true);

                                // Save Stage Preview
                                File.Copy(StageImagePreviewPathList[StageIndex], Path.Combine(dataPaths["ModPath"], "Stages", stage.StageName, "stage_preview.png"), true);

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

                            CharacterSelectParamS4ViewModel ImportModelCharacterSelectParamS4 = new CharacterSelectParamS4ViewModel();
                            CostumeBreakColorParamS4ViewModel ImportModelCostumeBreakColorParamS4 = new CostumeBreakColorParamS4ViewModel();
                            MessageInfoS4ViewModel ImportModelMessageInfoS4 = new MessageInfoS4ViewModel();

                            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory.ToString();
                            string paramFilesPath = Path.Combine(baseDirectory, "ParamFiles", gamePath);

                            if (File.Exists(dataPaths["DuelPlayerParam"]))
                                ImportModelDuelPlayerParam.OpenFile(dataPaths["DuelPlayerParam"]);
                            else
                                ImportModelDuelPlayerParam.OpenFile(Path.Combine(paramFilesPath, "duelPlayerParam.xfbin"));
                            if (!isStorm4)
                            {

                                if (File.Exists(dataPaths["CharacterSelectParam"]))
                                    ImportModelCharacterSelectParam.OpenFile(dataPaths["CharacterSelectParam"]);
                                else
                                    ImportModelCharacterSelectParam.OpenFile(Path.Combine(paramFilesPath, "characterSelectParam.xfbin"));
                            } else
                            {

                                if (File.Exists(dataPaths["CharacterSelectParam"]))
                                    ImportModelCharacterSelectParamS4.OpenFile(dataPaths["CharacterSelectParam"]);
                                else
                                    ImportModelCharacterSelectParamS4.OpenFile(Path.Combine(paramFilesPath, "characterSelectParam.xfbin"));
                            }
                            if (!isStorm4)
                            {

                                if (File.Exists(dataPaths["CostumeParam"]))
                                    ImportModelCostumeParam.OpenFile(dataPaths["CostumeParam"]);
                                else
                                    ImportModelCostumeParam.OpenFile(Path.Combine(paramFilesPath, "costumeParam.bin.xfbin"));
                            }

                            if (File.Exists(dataPaths["PlayerIcon"]))
                                ImportModelPlayerIcon.OpenFile(dataPaths["PlayerIcon"]);
                            else
                                ImportModelPlayerIcon.OpenFile(Path.Combine(paramFilesPath, "player_icon.xfbin"));

                            if (!isStorm4)
                            {

                                if (File.Exists(dataPaths["CostumeBreakColorParam"]))
                                    ImportModelCostumeBreakColorParam.OpenFile(dataPaths["CostumeBreakColorParam"]);
                                else
                                    ImportModelCostumeBreakColorParam.OpenFile(Path.Combine(paramFilesPath, "costumeBreakColorParam.xfbin"));
                            } else
                            {

                                if (File.Exists(dataPaths["CostumeBreakColorParam"]))
                                    ImportModelCostumeBreakColorParamS4.OpenFile(dataPaths["CostumeBreakColorParam"]);
                                else
                                    ImportModelCostumeBreakColorParamS4.OpenFile(Path.Combine(paramFilesPath, "costumeBreakColorParam.xfbin"));
                            }

                            if (File.Exists(dataPaths["Characode"]))
                                ImportModelCharacode.OpenFile(dataPaths["Characode"]);
                            else
                                ImportModelCharacode.OpenFile(Path.Combine(paramFilesPath, "characode.bin.xfbin"));

                            if (File.Exists(dataPaths["CostumeBreakParam"]))
                                ImportModelCostumeBreakParam.OpenFile(dataPaths["CostumeBreakParam"]);

                            if (Directory.Exists(dataPaths["MessageInfoFolder"]) && !isStorm4)
                                ImportModelMessageInfo.OpenFiles(dataPaths["MessageInfoFolder"]);
                            else if (Directory.Exists(dataPaths["MessageInfoFolder"]) && isStorm4)
                                ImportModelMessageInfoS4.OpenFiles(dataPaths["MessageInfoFolder"]);


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



                                PlayerSettingParamS4ViewModel ExportModelPlayerSettingParamS4 = new PlayerSettingParamS4ViewModel();
                                CharacterSelectParamS4ViewModel ExportModelCharacterSelectParamS4 = new CharacterSelectParamS4ViewModel();
                                CostumeBreakColorParamS4ViewModel ExportModelCostumeBreakColorParamS4 = new CostumeBreakColorParamS4ViewModel();
                                MessageInfoS4ViewModel ExportModelMessageInfoS4 = new MessageInfoS4ViewModel();

                                string characode = ImportModelCharacode.CharacodeList[model.CharacodeID - 1].CharacodeName;
                                int model_index = model.CostumeID;
                                string basemodel_code = "";
                                string awakemodel_code = "";

                                /*----------------------------------------REQUIRED FILES--------------------------------------*/

                                //playerSettingParam
                                if (!isStorm4)
                                {

                                    ExportModelPlayerSettingParam.PlayerSettingParamList.Add((PlayerSettingParamModel)model.Clone());
                                } else
                                {

                                    ExportModelPlayerSettingParamS4.PlayerSettingParamList.Add((PlayerSettingParamModel)model.Clone());
                                }
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
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_35"] + " " + model.PSP_code + (string)System.Windows.Application.Current.Resources["m_error_32"]);
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
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_35"] + " " + model.PSP_code + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + "player_icon entry.");
                                    continue;
                                }
                                //characterSelectParam
                                if (!isStorm4)
                                {
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
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_35"] + " " + model.PSP_code + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + "characterSelectParam entry.");
                                        continue;
                                    }
                                } else
                                {
                                    foreach (CharacterSelectParamModel CharacterSelectParamEntry in ImportModelCharacterSelectParamS4.CharacterSelectParamList)
                                    {
                                        if (CharacterSelectParamEntry.CSP_code == model.PSP_code)
                                        {
                                            ExportModelCharacterSelectParamS4.CharacterSelectParamList.Add((CharacterSelectParamModel)CharacterSelectParamEntry.Clone());
                                            if (!ExportModelMessageNameList.Contains(CharacterSelectParamEntry.CostumeDescription))
                                                ExportModelMessageNameList.Add(CharacterSelectParamEntry.CostumeDescription);
                                            if (!ExportModelMessageNameList.Contains(CharacterSelectParamEntry.CostumeName))
                                                ExportModelMessageNameList.Add(CharacterSelectParamEntry.CostumeName);
                                            break;
                                        }
                                    }
                                    if (ExportModelCharacterSelectParamS4.CharacterSelectParamList.Count < 1)
                                    {
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_35"] + " " + model.PSP_code + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + "characterSelectParam entry.");
                                        continue;
                                    }
                                }
                                if (!isStorm4)
                                {
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
                                        MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_35"] + " " + model.PSP_code + " " + (string)System.Windows.Application.Current.Resources["m_error_34"] + "costumeParam entry.");
                                        continue;
                                    }
                                }

                                if (!isStorm4)
                                {
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
                                } else
                                {
                                    //costumeBreakColorParam
                                    foreach (CostumeBreakColorParamModel CostumeBreakColorParamEntry in ImportModelCostumeBreakColorParamS4.CostumeBreakColorParamList)
                                    {
                                        if (CostumeBreakColorParamEntry.PlayerSettingParamID == model.PSP_ID)
                                        {
                                            ExportModelCostumeBreakColorParamS4.CostumeBreakColorParamList.Add((CostumeBreakColorParamModel)CostumeBreakColorParamEntry.Clone());
                                            break;
                                        }
                                    }
                                    if (ExportModelCostumeBreakColorParamS4.CostumeBreakColorParamList.Count < 1)
                                    {
                                        CostumeBreakColorParamModel cbcp_entry = new CostumeBreakColorParamModel();
                                        cbcp_entry.PlayerSettingParamID = model.PSP_ID;
                                        cbcp_entry.AltColor1 = Color.FromArgb(255, 255, 255, 1);
                                        cbcp_entry.AltColor2 = Color.FromArgb(255, 255, 255, 1);
                                        cbcp_entry.AltColor3 = Color.FromArgb(255, 255, 255, 1);
                                        cbcp_entry.AltColor4 = Color.FromArgb(255, 255, 255, 1);
                                        ExportModelCostumeBreakColorParamS4.CostumeBreakColorParamList.Add(cbcp_entry);

                                    }
                                }
                                //costumeBreakParam
                                if (File.Exists(dataPaths["CostumeBreakParam"]))
                                {

                                    foreach (CostumeBreakParamModel costumeBreakEntry in ImportModelCostumeBreakParam.CostumeBreakParamList)
                                    {
                                        if (costumeBreakEntry.CharacodeID == model.CharacodeID && costumeBreakEntry.CostumeID == model_index)
                                        {
                                            ExportModelCostumeBreakParam.CostumeBreakParamList.Add((CostumeBreakParamModel)costumeBreakEntry.Clone());
                                        }
                                    }
                                }
                                if (!isStorm4)
                                {
                                    //messageInfo
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                } else
                                {
                                    //messageInfo
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
                                    {
                                        if (ExportModelMessageNameList.Contains("practice_normal"))
                                            ExportModelMessageNameList.RemoveAt(ExportModelMessageNameList.IndexOf("practice_normal"));
                                        for (int i = 0; i < ExportModelMessageNameList.Count; i++)
                                        {
                                            ImportModelMessageInfoS4.MessageInfo_preview_List = ImportModelMessageInfoS4.MessageInfo_List[0];
                                            for (int message = 0; message < ImportModelMessageInfo.MessageInfo_preview_List.Count; message++)
                                            {
                                                if (BitConverter.ToString(ImportModelMessageInfoS4.MessageInfo_preview_List[message].CRC32Code) == BitConverter.ToString(BinaryReader.crc32(ExportModelMessageNameList[i])))
                                                {

                                                    for (int l = 0; l < Program.langS4List.Length; l++)
                                                    {
                                                        MessageInfoModel copy_entry = (MessageInfoModel)ImportModelMessageInfoS4.MessageInfo_List[l][message].Clone();
                                                        ExportModelMessageInfoS4.MessageInfo_List[l].Add(copy_entry);
                                                    }
                                                    break;
                                                }
                                            }
                                        }


                                    }
                                }
                                string modelPath = Path.Combine(dataPaths["ModPath"], "Models", model.PSP_code, "data");
                                Directory.CreateDirectory(Path.Combine(modelPath, "spc", "WIN64"));
                                Directory.CreateDirectory(Path.Combine(modelPath, "rpg", "param", "WIN64"));
                                Directory.CreateDirectory(Path.Combine(modelPath, "ui", "max", "select", "WIN64"));
                                if (!isStorm4)
                                {
                                    ExportModelPlayerSettingParam.SaveFileAs(Path.Combine(modelPath, "spc", "playerSettingParam.bin.xfbin"));
                                    ExportModelPlayerIcon.SaveFileAs(Path.Combine(modelPath, "spc", "player_icon.xfbin"));
                                    ExportModelCharacterSelectParam.SaveFileAs(Path.Combine(modelPath, "ui", "max", "select", "characterSelectParam.xfbin"));

                                    if (ExportModelCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                        ExportModelCostumeBreakParam.SaveFileAs(Path.Combine(modelPath, "spc", "costumeBreakParam.xfbin"));

                                    if (ExportModelCostumeBreakColorParam.CostumeBreakColorParamList.Count > 0)
                                        ExportModelCostumeBreakColorParam.SaveFileAs(Path.Combine(modelPath, "spc", "costumeBreakColorParam.xfbin"));

                                    ExportModelCostumeParam.SaveFileAs(Path.Combine(modelPath, "rpg", "param", "costumeParam.bin.xfbin"));

                                    if (ExportModelMessageInfo.MessageInfo_List[0].Count > 0)
                                        ExportModelMessageInfo.SaveFileAs(modelPath);
                                } else
                                {
                                    //ExportModelPlayerSettingParamS4.SaveFileAs(Path.Combine(modelPath, "spc", "WIN64", "playerSettingParam.bin.xfbin"));
                                    //ExportModelPlayerIcon.SaveFileAs(Path.Combine(modelPath, "spc", "WIN64", "player_icon.xfbin"));
                                    //ExportModelCharacterSelectParamS4.SaveFileAs(Path.Combine(modelPath, "ui", "max", "select", "WIN64", "characterSelectParam.xfbin"));

                                    //if (ExportModelCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                    //    ExportModelCostumeBreakParam.SaveFileAs(Path.Combine(modelPath, "spc", "WIN64", "costumeBreakParam.xfbin"));

                                    //if (ExportModelCostumeBreakColorParamS4.CostumeBreakColorParamList.Count > 0)
                                    //    ExportModelCostumeBreakColorParamS4.SaveFileAs(Path.Combine(modelPath, "spc", "WIN64", "costumeBreakColorParam.xfbin"));

                                    ////ExportModelCostumeParam.SaveFileAs(Path.Combine(modelPath, "rpg", "param", "costumeParam.bin.xfbin"));

                                    //if (ExportModelMessageInfoS4.MessageInfo_List[0].Count > 0)
                                    //    ExportModelMessageInfoS4.SaveFileAs(modelPath);

                                    ExportModelPlayerSettingParamS4.SaveFileAs(Path.Combine(modelPath, "spc", "playerSettingParam.bin.xfbin"));
                                    ExportModelPlayerIcon.SaveFileAs(Path.Combine(modelPath, "spc", "player_icon.xfbin"));
                                    ExportModelCharacterSelectParamS4.SaveFileAs(Path.Combine(modelPath, "ui", "max", "select",  "characterSelectParam.xfbin"));

                                    if (ExportModelCostumeBreakParam.CostumeBreakParamList.Count > 0)
                                        ExportModelCostumeBreakParam.SaveFileAs(Path.Combine(modelPath, "spc", "costumeBreakParam.xfbin"));

                                    if (ExportModelCostumeBreakColorParamS4.CostumeBreakColorParamList.Count > 0)
                                        ExportModelCostumeBreakColorParamS4.SaveFileAs(Path.Combine(modelPath, "spc", "costumeBreakColorParam.xfbin"));

                                    //ExportModelCostumeParam.SaveFileAs(Path.Combine(modelPath, "rpg", "param", "costumeParam.bin.xfbin"));

                                    if (ExportModelMessageInfoS4.MessageInfo_List[0].Count > 0)
                                        ExportModelMessageInfoS4.SaveFileAs(modelPath);
                                }

                                // Save Model Config
                                var MyModelIni = new IniFile(Path.Combine(dataPaths["ModPath"], "Models", model.PSP_code, "model_config.ini"));

                                MyModelIni.Write("Characode", characode, "ModManager");
                                MyModelIni.Write("BaseModel", basemodel_code, "ModManager");
                                MyModelIni.Write("AwakeModel", awakemodel_code, "ModManager");
                                MyModelIni.Write("Game", gamePath, "ModManager");

                            }

                            break;
                        //Compile Resource Mod
                        case 3:
                            break;
                        //Team Ultimate Jutsu Mod
                        case 4:
                            List<string> missingFiles = new List<string>();
                            if (!File.Exists(dataPaths["PairSpSkillCombinationParam"]))
                                missingFiles.Add(Path.GetFileName(dataPaths["PairSpSkillCombinationParam"]));

                            if (!File.Exists(moddingApiPaths["PairSpSkillManager"]))
                                missingFiles.Add(Path.GetFileName(moddingApiPaths["PairSpSkillManager"]));

                            if (!File.Exists(dataPaths["CmnParam"]))
                                missingFiles.Add(Path.GetFileName(dataPaths["CmnParam"]));

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

                                MessageInfoS4ViewModel ImportTUJMessageInfoS4 = new MessageInfoS4ViewModel();

                                if (!isStorm4)
                                {

                                    ImportTUJMessageInfo.OpenFiles(dataPaths["MessageInfoFolder"]);
                                } else
                                {

                                    ImportTUJMessageInfoS4.OpenFiles(dataPaths["MessageInfoFolder"]);
                                }
                                ImportTeamUltimateJutsu.OpenFile(dataPaths["PairSpSkillCombinationParam"]);
                                ImportTUJCmnparam.OpenFile(dataPaths["CmnParam"]);

                                MessageInfoViewModel ExportTUJMessageInfo = new MessageInfoViewModel();
                                MessageInfoS4ViewModel ExportTUJMessageInfoS4 = new MessageInfoS4ViewModel();
                                cmnparamViewModel ExportTUJCmnparam = new cmnparamViewModel();

                                PairSpSkillCombinationParamModel pairSpSkillEntry = ImportTeamUltimateJutsu.pairSpSkillList.FirstOrDefault(item => item.TUJ_ID == SelectedTeamUltimateJutsuIndex);
                                pair_spl_sndModel cmnTUJParamEntry = ImportTUJCmnparam.PairSplList.FirstOrDefault(item => item.PairSplID == SelectedTeamUltimateJutsuIndex);

                                if (pairSpSkillEntry is null)
                                {
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_36"]);
                                    return;
                                }
                                if (cmnTUJParamEntry is null)
                                {
                                    MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_37"]);
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
                                                        && Directory.Exists(dataPaths["MessageInfoFolder"]))
                                                    {
                                                        string message = ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].StringParam;
                                                        if (!ExportMessageNameList.Contains(message))
                                                        {
                                                            ExportMessageNameList.Add(message);
                                                        }
                                                    }
                                                    if (ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].FunctionID > 0x120 & isStorm4)
                                                    {
                                                        ImportPRM.VerList[ver].PL_ANM_Sections[pl_anm].FunctionList[function].FunctionID = 0x10E;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                ExportMessageNameList.Add(pairSpSkillEntry.TUJ_Name);
                                //MessageInfo
                                if (!isStorm4)
                                {
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
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
                                } else
                                {
                                    if (Directory.Exists(dataPaths["MessageInfoFolder"]))
                                    {
                                        ImportTUJMessageInfoS4.MessageInfo_preview_List = ImportTUJMessageInfoS4.MessageInfo_List[0];
                                        for (int message = 0; message < ImportTUJMessageInfoS4.MessageInfo_preview_List.Count; message++)
                                        {
                                            bool matchFound = false;
                                            foreach (string exportMessageName in ExportMessageNameList)
                                            {
                                                if (BitConverter.ToString(ImportTUJMessageInfoS4.MessageInfo_preview_List[message].CRC32Code) ==
                                                    BitConverter.ToString(BinaryReader.crc32(exportMessageName)))
                                                {
                                                    matchFound = true;
                                                    break;
                                                }
                                            }
                                            if (matchFound)
                                            {
                                                for (int l = 0; l < Program.langS4List.Length; l++)
                                                {
                                                    MessageInfoModel copy_entry = (MessageInfoModel)ImportTUJMessageInfoS4.MessageInfo_List[l][message].Clone();
                                                    ExportTUJMessageInfoS4.MessageInfo_List[l].Add(copy_entry);
                                                }
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
                                string tuj_path = Path.Combine(dataPaths["ModPath"], "TUJ", SelectedTeamUltimateJutsu, "data");
                                Directory.CreateDirectory(Path.Combine(tuj_path, "sound"));


                                //Save TUJ Config
                                var MyTUJIni = new IniFile(Path.Combine(dataPaths["ModPath"], "TUJ", SelectedTeamUltimateJutsu, "TUJ_config.ini"));
                                MyTUJIni.Write("Label", SelectedTeamUltimateJutsu, "ModManager");
                                MyTUJIni.Write("Name", pairSpSkillEntry.TUJ_Name, "ModManager");
                                MyTUJIni.Write("Flag1", pairSpSkillEntry.Condition1.ToString(), "ModManager");
                                MyTUJIni.Write("Flag2", pairSpSkillEntry.Condition2.ToString(), "ModManager");
                                MyTUJIni.Write("MemberCount", pairSpSkillEntry.MemberCount.ToString(), "ModManager");
                                MyTUJIni.Write("Characodes", characodeNamesString, "ModManager");
                                MyTUJIni.Write("Game", gamePath, "ModManager");

                                //SaveParamFiles
                                if (!isStorm4)
                                {

                                    if (ExportTUJMessageInfo.MessageInfo_List[0].Count > 0)
                                        ExportTUJMessageInfo.SaveFileAs(tuj_path);
                                } else
                                {

                                    if (ExportTUJMessageInfoS4.MessageInfo_List[0].Count > 0)
                                        ExportTUJMessageInfoS4.SaveFileAs(tuj_path);
                                }
                                if (ExportTUJCmnparam.PairSplList.Count > 0)
                                    ExportTUJCmnparam.SaveFileAs(Path.Combine(tuj_path, "sound", "cmnparam.xfbin"));
                            }
                            break;
                        //Compile Accessory Mod
                        case 5:
                            break;
                    }
                    IsModCompiled = true;

                    string ModExt = ".uns";
                    if (EncryptFiles_field)
                        ModExt = ".unse";


                    if (File.Exists(dataPaths["ModPath"] + ModExt))
                        File.Delete(dataPaths["ModPath"] + ModExt);
                    ZipFile.CreateFromDirectory(dataPaths["ModPath"], dataPaths["ModPath"] + ModExt);
                    Directory.Delete(dataPaths["ModPath"], true);
                }
            } catch (Exception ex)
            {
                string appDir = AppDomain.CurrentDomain.BaseDirectory;
                string logDir = Path.Combine(appDir, "logs");
                Directory.CreateDirectory(logDir);

                string logPath = Path.Combine(
                    logDir,
                    $"error_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.txt"
                );

                File.WriteAllText(
                    logPath,
                    $"Time: {DateTime.Now:O}{Environment.NewLine}" +
                    $"Message: {ex.Message}{Environment.NewLine}{Environment.NewLine}" +
                    $"StackTrace:{Environment.NewLine}{ex.StackTrace}"
                );

                MessageBox.Show(
                    $"Error: {ex.Message}\n\nLog saved to:\n{logPath}",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );

               // ModernWpf.MessageBox.Show(
               //     $"Message: {ex.Message}{Environment.NewLine}{Environment.NewLine}" +
               //     $"StackTrace:{Environment.NewLine}{ex.StackTrace}",
               //    "Error",
               //    MessageBoxButton.OK,
               //    MessageBoxImage.Error
               //);
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
                MessageBox.Show((string)System.Windows.Application.Current.Resources["m_error_38"]);
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
        private RelayCommand _selectScreenshotsCommand;
        public RelayCommand SelectScreenshotsCommand
        {
            get
            {
                return _selectScreenshotsCommand ??
                  (_selectScreenshotsCommand = new RelayCommand(obj =>
                  {
                      SelectScreenshots();
                  }));
            }
        }
        private RelayCommand _selectStageIconSCCommand;
        public RelayCommand SelectStageIconSCCommand
        {
            get
            {
                return _selectStageIconSCCommand ??
                  (_selectStageIconSCCommand = new RelayCommand(obj =>
                  {
                      SelectStageIconSC();
                  }));
            }
        }
        private RelayCommand _selectStageIconS4Command;
        public RelayCommand SelectStageIconS4Command
        {
            get
            {
                return _selectStageIconS4Command ??
                  (_selectStageIconS4Command = new RelayCommand(obj =>
                  {
                      SelectStageIconS4();
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
