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

        private TitleViewModel VM;
        public MainWindow() {
            InitializeComponent();

            VM = new TitleViewModel();
            DataContext = VM;

        }

        private void LoadLocalizedText(string resourceKey)
        {
            if (Application.Current.Resources.Contains(resourceKey))
            {
                string text = (string)System.Windows.Application.Current.Resources[resourceKey];
                VM.KyurutoDialogTextLoader(text, 20);
            }
        }

        private void CharacodeEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_CharacodeEditor_Kyuruto");
        private void DuelPlayerParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_DuelPlayerParamEditor_Kyuruto");
        private void PlayerSettingParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_PlayerSettingParamEditor_Kyuruto");
        private void CharacterSelectParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_CharacterSelectParamEditor_Kyuruto");
        private void SkillCustomizeParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SkillCustomizeParamEditor_Kyuruto");
        private void SpSkillCustomizeParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SpSkillCustomizeParamEditor_Kyuruto");
        private void AfterAttachObjectEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_AfterAttachObjectEditor_Kyuruto");
        private void AppearanceAnmEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_AppearanceAnmEditor_Kyuruto");
        private void PRMEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_PRMEditor_Kyuruto");
        private void CostumeParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_CostumeParamEditor_Kyuruto");
        private void PlayerDoubleEffectParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_PlayerDoubleEffectParamEditor_Kyuruto");
        private void CmnParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_CmnParamEditor_Kyuruto");
        private void SupportActionParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SupportActionParamEditor_Kyuruto");
        private void PlayerIconEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_PlayerIconEditor_Kyuruto");
        private void AwakeAuraEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_AwakeAuraEditor_Kyuruto");
        private void SkillIndexSettingParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SkillIndexSettingParamEditor_Kyuruto");
        private void PRMLoadEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_PRMLoadEditor_Kyuruto");
        private void SpTypeSupportParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SpTypeSupportParamEditor_Kyuruto");
        private void PrivateCameraEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_PrivateCameraEditor_Kyuruto");
        private void CostumeBreakParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_CostumeBreakParamEditor_Kyuruto");
        private void CostumeBreakColorParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_CostumeBreakColorParamEditor_Kyuruto");
        private void SupportSkillRecoverySpeedParamEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SupportSkillRecoverySpeedParamEditor_Kyuruto");
        private void StageInfoEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_StageInfoEditor_Kyuruto");
        private void MessageInfoEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_MessageInfoEditor_Kyuruto");
        private void DamageEffEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_DamageEffEditor_Kyuruto");
        private void EffectPrmEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_EffectPrmEditor_Kyuruto");
        private void SkillFileEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SkillFileEditor_Kyuruto");
        private void PairSpSkillEditor_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_PairSpSkillEditor_Kyuruto");
        private void SpecialInteraction_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_SpecialInteraction_Kyuruto");
        private void ConditionPrm_MouseEnter(object sender, MouseEventArgs e) => LoadLocalizedText("m_ConditionPrm_Kyuruto");
    }
}
