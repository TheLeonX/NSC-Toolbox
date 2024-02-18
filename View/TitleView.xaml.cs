using NSC_Toolbox.ViewModel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NSC_Toolbox {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            DataContext = new TitleViewModel();
            
        }

        private void CharacodeEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This is tool for editing character list and it's required for adding characters. If you work only with exist characters, you can skip this tool.",
                20);
        }

        private void DuelPlayerParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool will help you to edit character settings and add more costumes for them.",
                20);
        }

        private void PlayerSettingParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool will help you to make entries for costumes, which can be loaded with characterSelectParam file.",
                20);
        }

        private void CharacterSelectParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool will help you to edit character roster. If you made new entries in playerSettingParam file, you can load your costumes in game with that tool.",
                20);
        }

        private void SkillCustomizeParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for adding (or changing) Ninjutsus to characters and change their settings.",
                20);
        }
        private void SpSkillCustomizeParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for adding (or changing) Ultimate Jutsus to characters and change their settings.",
                20);
        }
        private void AfterAttachObjectEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool will help you to attach different objects or animations to specific bones on models.",
                20);
        }

        private void AppearanceAnmEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool will help you to change model properties for specific events: hide or make visible meshes, change blend value of materials and etc.",
                20);
        }

        private void PRMEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("If you aren't familiar with hex editing, this tool will be great for you to edit moveset settings of characters.",
                20);
        }
        private void CostumeParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for unlocking costumes (in case if you add them for characters with playerSettingParam file).",
                20);
        }
        private void PlayerDoubleEffectParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool will help you to add start/end effects for models when they appear on scene, for example: adding poof effect for shadow clones.",
                20);
        }
        private void CmnParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is requried for character sounds. cmnparam.xfbin loads all sounds for all characters and Team Ultimate Jutsus (all sounds have to be stored in CPK archive and loaded with ModdingAPI).",
                20);
        }
        private void SupportActionParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for changing support action, such as: protecting leader while you recovering chakra, throw syurikens when you throw them and etc.",
                20);
        }
        private void PlayerIconEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for loading character icons for costumes.",
                20);
        }
        private void AwakeAuraEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for loading auras to characters.",
                20);
        }
        private void SkillIndexSettingParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for changing default jutsus of characters (you can load all 6 jutsus, but pick only 2 for per character).",
                20);
        }
        private void PRMLoadEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for loading files to character. If file doesn't exist in game or data_win32 directory, game will get infinite loading when you will select characters.",
                20);
        }
        private void SpTypeSupportParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for adding extra jutsus (on D-pad) and setting them up.",
                20);
        }

        private void PrivateCameraEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for setting up camera for giant awakenings (can be enabled in duelPlayerParam file). If you adding characters, this file will be required.",
                20);
        }

        private void CostumeBreakParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for changing base model on dmg model after rounds in game (Armor Break).",
                20);
        }
        private void CostumeBreakColorParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for changing particle color when you get armor break.",
                20);
        }
        private void SupportSkillRecoverySpeedParamEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for changing recovery speed for supports.",
                20);
        }
        private void StageInfoEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool will help you to change stages in game.",
                20);
        }
        private void MessageInfoEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool is required for editing localization in game (all languages required for working tool).",
                20);
        }
        private void DamageEffEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for loading hit effects for character movesets. Effects can be found in effectprm.bin.xfbin file",
                20);
        }

        private void EffectPrmEditor_MouseEnter(object sender, MouseEventArgs e) {
            TitleViewModel VM = ((TitleViewModel)this.DataContext);
            VM.KyurutoDialogTextLoader("This tool was used for loading effects, which can be used in damageeff.bin.xfbin file.",
                20);
        }
    }
}
