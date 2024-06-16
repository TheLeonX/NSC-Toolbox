using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Dialogs;
using NSC_Toolbox.Properties;
using NSC_Toolbox.View;
using Octokit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;
using Octokit;
using System.Media;

namespace NSC_Toolbox.ViewModel {
    public class TitleViewModel : INotifyPropertyChanged {


        private Visibility _characterManagementVisibility;
        public Visibility CharacterManagementVisibility {
            get { return _characterManagementVisibility; }
            set {
                _characterManagementVisibility = value;
                OnPropertyChanged("CharacterManagementVisibility");
            }
        }



        private Visibility _otherToolsVisibility;
        public Visibility OtherToolsVisibility {
            get { return _otherToolsVisibility; }
            set {
                _otherToolsVisibility = value;
                OnPropertyChanged("OtherToolsVisibility");
            }
        }
        private Visibility _optionsVisibility;
        public Visibility OptionsVisibility {
            get { return _optionsVisibility; }
            set {
                _optionsVisibility = value;
                OnPropertyChanged("OptionsVisibility");
            }
        }
        private Visibility _mainWindowVisibility;
        public Visibility MainWindowVisibility {
            get { return _mainWindowVisibility; }
            set {
                _mainWindowVisibility = value;
                OnPropertyChanged("MainWindowVisibility");
            }
        }
        private Visibility _credits2024Visibility;
        public Visibility Credits2024Visibility {
            get { return _credits2024Visibility; }
            set {
                _credits2024Visibility = value;
                OnPropertyChanged("Credits2024Visibility");
            }
        }
        private int _toolTabState;
        public int ToolTabState {
            get { return _toolTabState; }
            set {
                _toolTabState = value;
                if (value > -1) {
                    switch (value) {
                        case 1:
                            CharacterManagementVisibility = Visibility.Visible;
                            OtherToolsVisibility = Visibility.Hidden;
                            OptionsVisibility = Visibility.Hidden;
                            break;
                        case 2:
                            CharacterManagementVisibility = Visibility.Hidden;
                            OtherToolsVisibility = Visibility.Visible;
                            OptionsVisibility = Visibility.Hidden;
                            break;
                        case 3:
                            CharacterManagementVisibility = Visibility.Hidden;
                            OtherToolsVisibility = Visibility.Hidden;
                            OptionsVisibility = Visibility.Visible;
                            break;
                    }
                }
                OnPropertyChanged("ToolTabState");
            }
        }
        private int _mainTabState;
        public int MainTabState {
            get { return _mainTabState; }
            set {
                _mainTabState = value;
                if (value > -1) {
                    switch (value) {
                        case 1:
                            MainWindowVisibility = Visibility.Visible;
                            Credits2024Visibility = Visibility.Hidden;
                            break;
                        case 2:
                            MainWindowVisibility = Visibility.Hidden;
                            Credits2024Visibility = Visibility.Visible;
                            break;
                    }
                }
                OnPropertyChanged("MainTabState");
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

        private int _meouchCounter;
        public int MeouchCounter {
            get { return _meouchCounter; }
            set {
                _meouchCounter = value;
                OnPropertyChanged("MeouchCounter");
            }
        }
        private int _stretchMode_field;
        public int StretchMode_field {
            get { return _stretchMode_field; }
            set {
                _stretchMode_field = value;
                OnPropertyChanged("StretchMode_field");
            }
        }

        private string _kuramaDialog;
        public string KuramaDialog {
            get { return _kuramaDialog; }
            set {
                _kuramaDialog = value;
                OnPropertyChanged("KuramaDialog");
            }
        }
        private string _kuramaName;
        public string KuramaName {
            get { return _kuramaName; }
            set {
                _kuramaName = value;
                OnPropertyChanged("KuramaName");
            }
        }

        private Visibility _meouchVisibility;
        public Visibility MeouchVisibility {
            get { return _meouchVisibility; }
            set {
                _meouchVisibility = value;
                OnPropertyChanged("MeouchVisibility");
            }
        }
        private Visibility _kyurutoVisibility;
        public Visibility KyurutoVisibility {
            get { return _kyurutoVisibility; }
            set {
                _kyurutoVisibility = value;
                OnPropertyChanged("KyurutoVisibility");
            }
        }
        private bool _meouchEffectAutoPlay;
        public bool MeouchEffectAutoPlay {
            get { return _meouchEffectAutoPlay; }
            set {
                _meouchEffectAutoPlay = value;
                OnPropertyChanged("MeouchEffectAutoPlay");
            }
        }



        private RepeatBehavior _meouchEffectRepeat;
        public RepeatBehavior MeouchEffectRepeat {
            get { return _meouchEffectRepeat; }
            set {
                _meouchEffectRepeat = value;
                OnPropertyChanged("MeouchEffectRepeat");
            }
        }
        private string _backgroundColor_field;
        public string BackgroundColor_field {
            get { return _backgroundColor_field; }
            set {
                _backgroundColor_field = value;
                OnPropertyChanged("BackgroundColor_field");
            }
        }
        private string _buttonColor_field;
        public string ButtonColor_field {
            get { return _buttonColor_field; }
            set {
                _buttonColor_field = value;
                OnPropertyChanged("ButtonColor_field");
            }
        }
        private string _textColor_field;
        public string TextColor_field {
            get { return _textColor_field; }
            set {
                _textColor_field = value;
                OnPropertyChanged("TextColor_field");
            }
        }
        private string _backgroundImagePath_field;
        public string BackgroundImagePath_field {
            get { return _backgroundImagePath_field; }
            set {
                _backgroundImagePath_field = value;
                OnPropertyChanged("BackgroundImagePath_field");
            }
        }
        public TitleViewModel() {


            ToolTabState = 1;
            KuramaName = "Kyuruto";
            MeouchCounter = 0;
            MeouchVisibility = Visibility.Hidden;
            KyurutoVisibility = Visibility.Visible;
            LoadingStatePlay = Visibility.Hidden;
            MainWindowVisibility = Visibility.Visible;
            Credits2024Visibility = Visibility.Hidden;
            MeouchEffectAutoPlay = false;
            MeouchEffectRepeat = RepeatBehavior.Forever;
            KyurutoDialogTextLoader("Hello! You can call me " + KuramaName + ".", 50);

            switch (Properties.Settings.Default.StretchMode) {
                case "Fill":
                    StretchMode_field = 0;
                    break;
                case "Uniform":
                    StretchMode_field = 1;
                    break;
                case "None":
                    StretchMode_field = 2;
                    break;
            }
            BackgroundColor_field = Properties.Settings.Default.BackgroundColor1;
            ButtonColor_field = Properties.Settings.Default.ButtonColor1;
            TextColor_field = Properties.Settings.Default.TextColor1;
            if (File.Exists(Properties.Settings.Default.BackgroundImagePath))
                BackgroundImagePath_field = Properties.Settings.Default.BackgroundImagePath;
            else {
                Properties.Settings.Default.BackgroundImagePath = "UI/background/bg_toolbox_main.png";
                Properties.Settings.Default.Save();
                BackgroundImagePath_field = Properties.Settings.Default.BackgroundImagePath;
            }
            CheckGitHubNewerVersion();
        }

        private async System.Threading.Tasks.Task CheckGitHubNewerVersion() {
            //Get all releases from GitHub
            //Source: https://octokitnet.readthedocs.io/en/latest/getting-started/
            GitHubClient client = new GitHubClient(new ProductHeaderValue("NSC-Toolbox"));
            IReadOnlyList<Release> releases = await client.Repository.Release.GetAll("TheLeonX", "NSC-Toolbox");

            //Setup the versions
            //Source: https://learn.microsoft.com/en-us/archive/msdn-technet-forums/7fe34424-0a53-46cb-b4b3-ab63b0823d01
            Version latestGitHubVersion = new Version(releases[0].TagName);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            Version localVersion = assembly.GetName().Version;

            //Compare the Versions
            //Source: https://stackoverflow.com/questions/7568147/compare-version-numbers-without-using-split-function
            int versionComparison = localVersion.CompareTo(latestGitHubVersion);
            if (versionComparison < 0) {
                SystemSounds.Beep.Play();
                ModernWpf.MessageBox.Show("There is new version of Toolbox on GitHub page.");
            }

        }
        public void SaveSettings() {
            bool restart = false;
            switch (StretchMode_field) {
                case 0:
                    Properties.Settings.Default.StretchMode = "Fill";
                    break;
                case 1:
                    Properties.Settings.Default.StretchMode = "Uniform";
                    break;
                case 2:
                    Properties.Settings.Default.StretchMode = "None";
                    break;
            }
            Properties.Settings.Default.BackgroundColor1 = BackgroundColor_field;
            Properties.Settings.Default.ButtonColor1 = ButtonColor_field;
            Properties.Settings.Default.TextColor1 = TextColor_field;
            if (File.Exists(BackgroundImagePath_field)) {
                Properties.Settings.Default.BackgroundImagePath = BackgroundImagePath_field;
                restart = true;
            }
            Properties.Settings.Default.Save();
            if (restart)
                ModernWpf.MessageBox.Show("Some changes requires to restart toolbox!");
        }
        public void ResetSettings() {
            bool restart = false;
            Properties.Settings.Default.StretchMode = "Uniform";
            Properties.Settings.Default.BackgroundColor1 = "#9C000000";
            Properties.Settings.Default.ButtonColor1 = "#9C000000";
            Properties.Settings.Default.TextColor1 = "White";
            if (Properties.Settings.Default.BackgroundImagePath != "UI/background/bg_toolbox_main.png") {
                Properties.Settings.Default.BackgroundImagePath = "UI/background/bg_toolbox_main.png";
                restart = true;

            }
            BackgroundColor_field = Properties.Settings.Default.BackgroundColor1;
            ButtonColor_field = Properties.Settings.Default.ButtonColor1;
            TextColor_field = Properties.Settings.Default.TextColor1;
            BackgroundImagePath_field = "UI/background/bg_toolbox_main.png";
            Properties.Settings.Default.Save();
            if (restart)
                ModernWpf.MessageBox.Show("Some changes requires to restart toolbox!");
        }
        public void SelectImageBackground() {
            OpenFileDialog myDialog = new OpenFileDialog();
            myDialog.Filter = "PNG Image (*.png)|*.png|JPG Image (*.jpg)|*.jpg|JPEG Image (*.jpeg)|*.jpeg";
            myDialog.CheckFileExists = true;
            myDialog.Multiselect = false;
            if (myDialog.ShowDialog() == true) {
                BackgroundImagePath_field = myDialog.FileName;
            } else {
                return;
            }
        }

        public void VisitModdingGroup() {
            System.Diagnostics.Process.Start(new ProcessStartInfo {
                FileName = Settings.Default.ModdingGroupLink,
                UseShellExecute = true
            });

        }
        public void VisitBoosty() {
            System.Diagnostics.Process.Start(new ProcessStartInfo {
                FileName = "https://boosty.to/theleonx/single-payment/donation/383406?share=target_link",
                UseShellExecute = true
            });

        }
        public void VisitGitHubPage() {
            System.Diagnostics.Process.Start(new ProcessStartInfo {
                FileName = "https://github.com/TheLeonX/NSC-Toolbox/releases",
                UseShellExecute = true
            });

        }
        public void InstallModdingAPI() {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select root folder of game";
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok) {
                Program.CopyFilesRecursively(AppDomain.CurrentDomain.BaseDirectory.ToString() + "\\ModdingAPIFiles", dialog.FileName);
                ModernWpf.MessageBox.Show("ModdingAPI was installed!");
            } else {
                return;
            }
        }
        public void DeleteModdingAPI() {
            var dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            dialog.Title = "Select root folder of game";
            CommonFileDialogResult result = dialog.ShowDialog();
            if (result == CommonFileDialogResult.Ok)
                if (Directory.Exists(dialog.FileName + "\\moddingapi")) {

                    MessageBoxResult warning = (MessageBoxResult)ModernWpf.MessageBox.Show("You are sure that you want to delete ModdingAPI? All mods inside of it will be deleted too.", "Do you want to delete it?", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    if (warning == MessageBoxResult.Yes) {

                        Directory.Delete(dialog.FileName + "\\moddingapi", true);
                        if (File.Exists(dialog.FileName + "\\xinput9_1_0.dll"))
                            File.Delete(dialog.FileName + "\\xinput9_1_0.dll");
                        if (File.Exists(dialog.FileName + "\\xinput9_1_0_o.dll"))
                            File.Delete(dialog.FileName + "\\xinput9_1_0_o.dll");
                        ModernWpf.MessageBox.Show("ModdingAPI was deleted!");
                    }
                } else {
                    return;
                }
        }
        // команда добавления нового объекта
        private RelayCommand addMeouch;
        public RelayCommand AddMeouch {
            get {
                return addMeouch ??
                  (addMeouch = new RelayCommand(obj => {
                      if (MeouchCounter == 10) {
                          MeouchVisibility = Visibility.Visible;
                          KyurutoVisibility = Visibility.Hidden;
                          MeouchEffectAutoPlay = true;
                          KuramaName = "Meouch";
                          MeouchEffectRepeat = new RepeatBehavior(1.0);
                          KuramaDialog = "";
                          KyurutoDialogTextLoader("Meow! You can call me " + KuramaName + ".", 50);
                          MeouchCounter++;

                      } else {
                          MeouchCounter++;
                      }

                  }));
            }
        }
        private RelayCommand _characterManagementCommand;
        public RelayCommand CharacterManagementCommand {
            get {
                return _characterManagementCommand ??
                  (_characterManagementCommand = new RelayCommand(obj => {
                      ToolTabState = 1;

                  }));
            }
        }
        private RelayCommand _otherToolsCommand;
        public RelayCommand OtherToolsCommand {
            get {
                return _otherToolsCommand ??
                  (_otherToolsCommand = new RelayCommand(obj => {
                      ToolTabState = 2;

                  }));
            }
        }
        private RelayCommand _optionsCommand;
        public RelayCommand OptionsCommand {
            get {
                return _optionsCommand ??
                  (_optionsCommand = new RelayCommand(obj => {
                      ToolTabState = 3;

                  }));
            }
        }
        private RelayCommand _creditsCommand;
        public RelayCommand CreditsCommand {
            get {
                return _creditsCommand ??
                  (_creditsCommand = new RelayCommand(obj => {
                      MainTabState = 2;
                  }));
            }
        }
        private RelayCommand _mainMenuCommand;
        public RelayCommand MainMenuCommand {
            get {
                return _mainMenuCommand ??
                  (_mainMenuCommand = new RelayCommand(obj => {
                      MainTabState = 1;
                  }));
            }
        }

        private RelayCommand _exportModCommand;
        public RelayCommand ExportModCommand {
            get {
                return _exportModCommand ??
                  (_exportModCommand = new RelayCommand(obj => {
                      ExportModView ExportMod = new ExportModView();
                      ExportMod.Show();

                  }));
            }
        }
        private RelayCommand _addCostumeCommand;
        public RelayCommand AddCostumeCommand {
            get {
                return _addCostumeCommand ??
                  (_addCostumeCommand = new RelayCommand(obj => {
                      AddCostumeView AddCostume = new AddCostumeView();
                      AddCostume.Show();

                  }));
            }
        }
        private RelayCommand _saveSettingsCommand;
        public RelayCommand SaveSettingsCommand {
            get {
                return _saveSettingsCommand ??
                  (_saveSettingsCommand = new RelayCommand(obj => {
                      SaveSettings();

                  }));
            }
        }
        private RelayCommand _resetSettingsCommand;
        public RelayCommand ResetSettingsCommand {
            get {
                return _resetSettingsCommand ??
                  (_resetSettingsCommand = new RelayCommand(obj => {
                      ResetSettings();

                  }));
            }
        }
        private RelayCommand _selectImageBackgroundCommand;
        public RelayCommand SelectImageBackgroundCommand {
            get {
                return _selectImageBackgroundCommand ??
                  (_selectImageBackgroundCommand = new RelayCommand(obj => {
                      SelectImageBackground();

                  }));
            }
        }
        private RelayCommand characodeRunButton;
        public RelayCommand CharacodeRunButtonCommand {
            get {
                return characodeRunButton ??
                  (characodeRunButton = new RelayCommand(obj => {
                      CharacodeEditorView CharacodeEditor = new CharacodeEditorView();
                      CharacodeEditor.Show();

                  }));
            }
        }
        private RelayCommand playerSettingParamRunButton;
        public RelayCommand PlayerSettingParamRunButtonCommand {
            get {
                return playerSettingParamRunButton ??
                  (playerSettingParamRunButton = new RelayCommand(obj => {
                      PlayerSettingParamEditorView playerSettingParamEditor = new PlayerSettingParamEditorView();
                      playerSettingParamEditor.Show();

                  }));
            }
        }
        private RelayCommand characterSelectParamRunButton;
        public RelayCommand CharacterSelectParamRunButtonCommand {
            get {
                return characterSelectParamRunButton ??
                  (characterSelectParamRunButton = new RelayCommand(obj => {
                      CharacterSelectParamEditorView characterSelectParamEditor = new CharacterSelectParamEditorView();
                      characterSelectParamEditor.Show();

                  }));
            }
        }
        private RelayCommand _PRMEditorRunButtonCommand;
        public RelayCommand PRMEditorRunButtonCommand {
            get {
                return _PRMEditorRunButtonCommand ??
                  (_PRMEditorRunButtonCommand = new RelayCommand(obj => {
                      PRMEditorView PRMEditor = new PRMEditorView();
                      PRMEditor.Show();

                  }));
            }
        }
        private RelayCommand _DuelPlayerParamEditorRunButtonCommand;
        public RelayCommand DuelPlayerParamEditorRunButtonCommand {
            get {
                return _DuelPlayerParamEditorRunButtonCommand ??
                  (_DuelPlayerParamEditorRunButtonCommand = new RelayCommand(obj => {
                      DuelPlayerParamEditorView DPPEditor = new DuelPlayerParamEditorView();
                      DPPEditor.Show();

                  }));
            }
        }
        private RelayCommand _skillCustomizeParamEditorRunButtonCommand;
        public RelayCommand SkillCustomizeParamEditorRunButtonCommand {
            get {
                return _skillCustomizeParamEditorRunButtonCommand ??
                  (_skillCustomizeParamEditorRunButtonCommand = new RelayCommand(obj => {
                      SkillCustomizeParamEditorView SkillEditor = new SkillCustomizeParamEditorView();
                      SkillEditor.Show();

                  }));
            }
        }
        private RelayCommand _skillIndexSettingParamEditorRunButtonCommand;
        public RelayCommand SkillIndexSettingParamEditorRunButtonCommand {
            get {
                return _skillIndexSettingParamEditorRunButtonCommand ??
                  (_skillIndexSettingParamEditorRunButtonCommand = new RelayCommand(obj => {
                      SkillIndexSettingParamEditorView SkillIndexEditor = new SkillIndexSettingParamEditorView();
                      SkillIndexEditor.Show();

                  }));
            }
        }
        private RelayCommand _stageInfoEditorRunButtonCommand;
        public RelayCommand StageInfoEditorRunButtonCommand {
            get {
                return _stageInfoEditorRunButtonCommand ??
                  (_stageInfoEditorRunButtonCommand = new RelayCommand(obj => {
                      StageInfoEditorView StageInfoEditor = new StageInfoEditorView();
                      StageInfoEditor.Show();

                  }));
            }
        }
        private RelayCommand _messageInfoEditorRunButtonCommand;
        public RelayCommand MessageInfoEditorRunButtonCommand {
            get {
                return _messageInfoEditorRunButtonCommand ??
                  (_messageInfoEditorRunButtonCommand = new RelayCommand(obj => {
                      MessageInfoEditorView MessageInfoEditor = new MessageInfoEditorView();
                      MessageInfoEditor.Show();

                  }));
            }
        }
        private RelayCommand _PRMLoadEditorRunButtonCommand;
        public RelayCommand PRMLoadEditorRunButtonCommand {
            get {
                return _PRMLoadEditorRunButtonCommand ??
                  (_PRMLoadEditorRunButtonCommand = new RelayCommand(obj => {
                      PRMLoadEditorView PRMLoadEditor = new PRMLoadEditorView();
                      PRMLoadEditor.Show();

                  }));
            }
        }
        private RelayCommand _cmnparamEditorRunButtonCommand;
        public RelayCommand cmnparamEditorRunButtonCommand {
            get {
                return _cmnparamEditorRunButtonCommand ??
                  (_cmnparamEditorRunButtonCommand = new RelayCommand(obj => {
                      cmnparamEditorView cmnparamEditor = new cmnparamEditorView();
                      cmnparamEditor.Show();

                  }));
            }
        }
        private RelayCommand _spSkillCustomizeParamRunButtonCommand;
        public RelayCommand SpSkillCustomizeParamRunButtonCommand {
            get {
                return _spSkillCustomizeParamRunButtonCommand ??
                  (_spSkillCustomizeParamRunButtonCommand = new RelayCommand(obj => {
                      SpSkillCustomizeParamEditorView spSkillCustomizeParam = new SpSkillCustomizeParamEditorView();
                      spSkillCustomizeParam.Show();

                  }));
            }
        }
        private RelayCommand _playerIconRunButtonCommand;
        public RelayCommand PlayerIconRunButtonCommand {
            get {
                return _playerIconRunButtonCommand ??
                  (_playerIconRunButtonCommand = new RelayCommand(obj => {
                      PlayerIconEditorView playerIconEditor = new PlayerIconEditorView();
                      playerIconEditor.Show();

                  }));
            }
        }
        private RelayCommand _awakeAuraRunButtonCommand;
        public RelayCommand AwakeAuraRunButtonCommand {
            get {
                return _awakeAuraRunButtonCommand ??
                  (_awakeAuraRunButtonCommand = new RelayCommand(obj => {
                      AwakeAuraEditorView AwakeAuraEditor = new AwakeAuraEditorView();
                      AwakeAuraEditor.Show();

                  }));
            }
        }
        private RelayCommand _spTypeSupportParamRunButtonCommand;
        public RelayCommand SpTypeSupportParamRunButtonCommand {
            get {
                return _spTypeSupportParamRunButtonCommand ??
                  (_spTypeSupportParamRunButtonCommand = new RelayCommand(obj => {
                      SpTypeSupportParamEditorView SpTypeSupportParamEditor = new SpTypeSupportParamEditorView();
                      SpTypeSupportParamEditor.Show();

                  }));
            }
        }
        private RelayCommand _afterAttachObjectRunButtonCommand;
        public RelayCommand AfterAttachObjectRunButtonCommand {
            get {
                return _afterAttachObjectRunButtonCommand ??
                  (_afterAttachObjectRunButtonCommand = new RelayCommand(obj => {
                      AfterAttachObjectEditorView AfterAttachObjectEditor = new AfterAttachObjectEditorView();
                      AfterAttachObjectEditor.Show();

                  }));
            }
        }
        private RelayCommand _appearanceAnmRunButtonCommand;
        public RelayCommand AppearanceAnmRunButtonCommand {
            get {
                return _appearanceAnmRunButtonCommand ??
                  (_appearanceAnmRunButtonCommand = new RelayCommand(obj => {
                      AppearanceAnmEditorView AppearanceAnmEditor = new AppearanceAnmEditorView();
                      AppearanceAnmEditor.Show();

                  }));
            }
        }
        private RelayCommand _privateCameraRunButtonCommand;
        public RelayCommand PrivateCameraRunButtonCommand {
            get {
                return _privateCameraRunButtonCommand ??
                  (_privateCameraRunButtonCommand = new RelayCommand(obj => {
                      PrivateCameraEditorView PrivateCameraEditor = new PrivateCameraEditorView();
                      PrivateCameraEditor.Show();

                  }));
            }
        }
        private RelayCommand _costumeParamRunButtonCommand;
        public RelayCommand CostumeParamRunButtonCommand {
            get {
                return _costumeParamRunButtonCommand ??
                  (_costumeParamRunButtonCommand = new RelayCommand(obj => {
                      CostumeParamEditorView CostumeParamEditor = new CostumeParamEditorView();
                      CostumeParamEditor.Show();

                  }));
            }
        }
        private RelayCommand _playerDoubleEffectParamRunButtonCommand;
        public RelayCommand PlayerDoubleEffectParamRunButtonCommand {
            get {
                return _playerDoubleEffectParamRunButtonCommand ??
                  (_playerDoubleEffectParamRunButtonCommand = new RelayCommand(obj => {
                      PlayerDoubleEffectParamEditorView PlayerDoubleEffectParamEditor = new PlayerDoubleEffectParamEditorView();
                      PlayerDoubleEffectParamEditor.Show();

                  }));
            }
        }

        private RelayCommand _costumeBreakParamRunButtonCommand;
        public RelayCommand CostumeBreakParamRunButtonCommand {
            get {
                return _costumeBreakParamRunButtonCommand ??
                  (_costumeBreakParamRunButtonCommand = new RelayCommand(obj => {
                      CostumeBreakParamEditorView CostumeBreakParamEditor = new CostumeBreakParamEditorView();
                      CostumeBreakParamEditor.Show();

                  }));
            }
        }
        private RelayCommand _costumeBreakColorParamRunButtonCommand;
        public RelayCommand CostumeBreakColorParamRunButtonCommand {
            get {
                return _costumeBreakColorParamRunButtonCommand ??
                  (_costumeBreakColorParamRunButtonCommand = new RelayCommand(obj => {
                      CostumeBreakColorParamEditorView CostumeBreakColorParamEditor = new CostumeBreakColorParamEditorView();
                      CostumeBreakColorParamEditor.Show();

                  }));
            }
        }
        private RelayCommand _effectPrmRunButtonCommand;
        public RelayCommand EffectPrmRunButtonCommand {
            get {
                return _effectPrmRunButtonCommand ??
                  (_effectPrmRunButtonCommand = new RelayCommand(obj => {
                      EffectPrmEditorView EffectPrmEditor = new EffectPrmEditorView();
                      EffectPrmEditor.Show();

                  }));
            }
        }
        private RelayCommand _damageEffRunButtonCommand;
        public RelayCommand DamageEffRunButtonCommand {
            get {
                return _damageEffRunButtonCommand ??
                  (_damageEffRunButtonCommand = new RelayCommand(obj => {
                      DamageEffEditorView DamageEffEditor = new DamageEffEditorView();
                      DamageEffEditor.Show();

                  }));
            }
        }
        private RelayCommand _supportActionParamRunButtonCommand;
        public RelayCommand SupportActionParamRunButtonCommand {
            get {
                return _supportActionParamRunButtonCommand ??
                  (_supportActionParamRunButtonCommand = new RelayCommand(obj => {
                      SupportActionParamEditorView SupportActionParamEditor = new SupportActionParamEditorView();
                      SupportActionParamEditor.Show();

                  }));
            }
        }
        private RelayCommand _supportSkillRecoverySpeedParamRunButtonCommand;
        public RelayCommand SupportSkillRecoverySpeedParamRunButtonCommand {
            get {
                return _supportSkillRecoverySpeedParamRunButtonCommand ??
                  (_supportSkillRecoverySpeedParamRunButtonCommand = new RelayCommand(obj => {
                      SupportSkillRecoverySpeedParamEditorView supportSkillRecoverySpeedParamEditor = new SupportSkillRecoverySpeedParamEditorView();
                      supportSkillRecoverySpeedParamEditor.Show();

                  }));
            }
        }
        private RelayCommand _skillEditorRunButtonCommand;
        public RelayCommand SkillEditorRunButtonCommand {
            get {
                return _skillEditorRunButtonCommand ??
                  (_skillEditorRunButtonCommand = new RelayCommand(obj => {
                      SkillEditorView SkillEditor = new SkillEditorView();
                      SkillEditor.Show();

                  }));
            }
        }
        private RelayCommand _installModdingAPICommand;
        public RelayCommand InstallModdingAPICommand {
            get {
                return _installModdingAPICommand ??
                  (_installModdingAPICommand = new RelayCommand(obj => {
                      InstallModdingAPI();

                  }));
            }
        }
        private RelayCommand _deleteModdingAPICommand;
        public RelayCommand DeleteModdingAPICommand {
            get {
                return _deleteModdingAPICommand ??
                  (_deleteModdingAPICommand = new RelayCommand(obj => {
                      DeleteModdingAPI();

                  }));
            }
        }
        private RelayCommand _visitModdingGroupCommand;
        public RelayCommand VisitModdingGroupCommand {
            get {
                return _visitModdingGroupCommand ??
                  (_visitModdingGroupCommand = new RelayCommand(obj => {
                      VisitModdingGroup();

                  }));
            }
        }
        private RelayCommand _boostyCommand;
        public RelayCommand BoostyCommand {
            get {
                return _boostyCommand ??
                  (_boostyCommand = new RelayCommand(obj => {
                      VisitBoosty();

                  }));
            }
        }
        private RelayCommand _visitGitHubPage;
        public RelayCommand VisitGitHubPageCommand {
            get {
                return _visitGitHubPage ??
                  (_visitGitHubPage = new RelayCommand(obj => {
                      VisitGitHubPage();

                  }));
            }
        }

        public async void KyurutoDialogTextLoader(string kuramaDialogUpdate, int timer) {
            try {
                await Task.Run(() => KyurutoDialogTextWork(kuramaDialogUpdate, timer));
            } catch (Exception) {
                //...
            }
        }

        void KyurutoDialogTextWork(string dialog, int timer) {
            KuramaDialog = "";
            for (int i = 0; i < dialog.Length; System.Threading.Thread.Sleep(timer)) {
                if (KuramaDialog.Length != i) {
                    break;
                }
                KuramaDialog += dialog[i];
                i++;
                
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "") {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }


}
