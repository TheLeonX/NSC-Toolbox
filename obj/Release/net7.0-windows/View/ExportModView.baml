   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  )clr-namespace:NSC_ToolboxNSC_Toolbox  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  $    NSC_Toolbox.View.ExportModView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     ,local2clr-namespace:NSC_Toolbox     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_exportMod_title � Title# �   $	��800��$	��900������   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources 4  .NSC_Toolbox.Converter.GetNameFromPathConverter  GetNameFromPathConverter*  $NSC_Toolbox.Converter.BitImageLoader  BitImageLoader=   7NSC_Toolbox.Converter.PlaceholderToUnavailableConverter % !PlaceholderToUnavailableConverter��%-   &	       &	      &	 
           .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $	��800��$	��900��.+� 	 Xceed.Wpf.Toolkit.Wizard     FinishButtonClosesWindow$
 True��   HelpButtonVisibility$ Hidden=�  
NarutoFont#��[ $	��800��$	��900��.@�" 	 Xceed.Wpf.Toolkit.WizardPage  -     Name$ 	IntroPage��   Title# �     m_exportMod_page0_desc   Description# �  
�������   BackButtonVisibility$ Hidden=� % !Toolbox_button_background_color_1#���     NextPage ��  �� ElementName$ Page1��   ExteriorPanelBackground �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve$��3��$��0��$��WrapWithOverflow=�$
��Left=�$	��Top=�#��[ 
�������  m_exportMod_page0_warning#���  $��14(�  -   $ Page1��
�������#���  # �    	 m_exportMod_page1_desc# � 	  �� $ Page2��   PreviousPage �� $ 	IntroPage��   CanSelectNextPage �� *IsDataWin32Exist+ �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  � RowDefinitions �� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��35 � � ColumnDefinitions �� $
��1.2* ��� $��5 ��� $��1* �.+�� $��1��$��3�� �� $��* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* �.+��� $��4��$��2��$��1��  
 m_exportMod_page1_cpk_delete#��� 
 $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���   ! Toolbox_button_border_color_1#���  #��[   Toolbox_button_text_color_1#���  $��12(����� *DeleteCPKCommand+�� $��4��$��0��$��1��   m_exportMod_page1_cpk_select#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #���  #��[ #���  $��12(����� *SelectCPKCommand+� $��4��$��3�� �� $��* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* �.+��� $��0��$��0��$��3��$��3��$
��Left=�$��Bottom=�#��[    m_exportMod_page1_shaderInfo#���  #���  $��12(�$��WrapWithOverflow=��� $��4��$��2��$��1�� # m_exportMod_page1_shader_delete#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *DeleteShaderCommand+�� $��4��$��0��$��1�� # m_exportMod_page1_shader_select#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectShaderCommand+� $��7��$��3�� �� $��* ��� $��5 ��� $��* �.+��� $��4��$��0��$��1�� & "m_exportMod_page1_datawin32_select#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectDataWin32Command+�� $��4��$��2��$��1�� $  m_exportMod_page1_datawin32_save#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveDataWin32Command+�� $��0��$��0��$
��Left=�$��Center=�#��[   m_exportMod_page1_cpkList#���  #���  $��12(��� $��1��$��0��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *	CPKList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedCPK+���� .R���  �� Orientation$ 
Horizontal=�.+��� ����  �� 	Converter# [ �� $��3��$��0��$
��Left=�$��Center=�#��[    m_exportMod_page1_shaderList#���  #���  $��12(��� $��4��$��0��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *ShadersList+$ OneWay=�$ PropertyChanged=� �� *SelectedShader+���� .R��� $ 
Horizontal=�.+��� ���� # [ �� $��6��$��0��$
��Left=�$��Center=�#��[ #���    m_exportMod_page1_datawin32#���  $��12(��� $��7��$��0��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *DataWin32Path_field+  -   $ Page2��
�������#���  # �     m_exportMod_page2_desc# �   True �� $ Page3�� �� $ Page1�� �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto � �� $��1* �.+��� $��0��$��0��$
��Left=�$��Center=�#��[ #���    m_exportMod_page2_modType#���  $��12(��� $��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ModType_List+ �� SelectedIndex �� *ModType_field+�� $��3��$��0��$��WrapWithOverflow=�$
��Left=�$��Center=�#��[ 
���  �� - )m_exportMod_page3_exportCharacter_warning#���  $��14(�y��� *" PageModType_character_visibility+�� $��3��$��0��$��WrapWithOverflow=�$
��Left=�$��Center=�#��[ 
���  ��#���  $��14(�y��� *PageModType_model_visibility+  -   $ Page3��
�������#���  # �     m_exportMod_page3_desc# �  $ Visible=� �� $ Page4�� �� $ Page2�� �� *IsExportModsExist+ �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.��� .+�� y��� *" PageModType_character_visibility+ �� $
��Auto ��� $��* ��� $��5 ��� $��30 � �� $��* ��� $��5 ��� $��* �.+��� $��0��$��0��$
��Left=�$��Center=�#��[ #���   % !m_exportMod_page3_selectCharacter#���  $��12(��� $��0��$��2��$
��Left=�$��Center=�#��[ #���   % !m_exportMod_page3_exportCharacter#���  $��12(��� $��1��$��0��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *ImportCharacterList+$ OneWay=�$ PropertyChanged=� �� *SelectedImportCharacter+���� .R��� $ 
Horizontal=�.+��� ���� *CharacodeName+�� $��1��$��2��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *ExportCharacterList+$ OneWay=�$ PropertyChanged=� �� *SelectedExportCharacter+���� .R��� $ 
Horizontal=�.+��� ���� *CharacodeName+�� $��3��$��0��$��1�� % !m_exportMod_page3_selectCharacode#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectCharacterCommand+�� $��3��$��2��$��1�� % !m_exportMod_page3_deleteCharacode#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *DeleteCharacterCommand+� y��� *PageModType_stage_visibility+ �� $
��Auto ��� $��* ��� $��5 ��� $��30 ��� $
��Auto ��� $��* ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto � �� $��* ��� $��5 ��� $��* �.+��� $��0��$��0��$
��Left=�$��Center=�#��[ #���   !  m_exportMod_page3_selectStage#���   $��12(��� $��0��$��2��$
��Left=�$��Center=�#��[ #���   !! m_exportMod_page3_stageExport#��� ! $��12(��� $��1��$��0��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *ImportStageList+$ OneWay=�$ PropertyChanged=� �� *SelectedImportStage+���� .R��� $ 
Horizontal=�.+��� ���� *	StageName+�� $��1��$��2��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *ExportStageList+$ OneWay=�$ PropertyChanged=� �� *SelectedExportStage+ �� *SelectedExportStageIndex+���� .R��� $ 
Horizontal=�.+��� ���� *	StageName+�� $��3��$��0��$��1�� #" m_exportMod_page3_selectStageID#��� " $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectStageCommand+�� $��3��$��2��$��1�� ## m_exportMod_page3_deleteStageID#��� # $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *DeleteStageCommand+�� $��4��$��2��$��3��$
��Left=�$��Center=�#��[ #���   1$ -m_exportMod_page3_stagePreviewImageResolution#��� $ $��12(��� $��5��$��2��$��3�� �� BitmapScalingMode$ HighQuality=�$	��116��$	��284��$
��Fill=�$
��Left=����� *StageImagePreview+�� $��6��$��2��$��1�� (% $m_exportMod_page3_SelectStagePreview#��� % $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� * SelectStageImagePreviewCommand+�� $��4��$��0��$��3��$
��Left=�$��Center=�#��[ #���   )& %m_exportMod_page3_stageIconResolution#��� & $��12(��� $��5��$��30��$��0��#���  $��Bottom=�$��Stretch=�#��[ #���  #���  $��1q����� *StageIconPath+�� $��6��$��0��$��1�� %' !m_exportMod_page3_SelectStageIcon#��� ' $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectStageIconCommand+�� $��8��$��0��$��3��$
��Left=�$��Center=�#��[ #���   ( m_exportMod_page3_stageBGM#��� ( $��12(�%	 	 Xceed.Wpf.Toolkit.IntegerUpDown	  $��9��$��30��#��[ #���  #���  $��1q��
 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]  
  	Increment  1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]!   Maximum	! 65535"   Minimum" -1#���  #   Value# �� *StageBGM_ID+�� $��9��$��2��$��1�� ) m_exportMod_page3_saveBGM#��� ) $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveBGMIDCommand+�� $��11��$��0��$��3��$
��Left=�$��Center=�#��[ #���   $*  m_exportMod_page3_StageMessageID#��� * $��12(��� $��12��$��30��$��0��#���  $��Bottom=�$��Stretch=�#��[ #���  #���  $��1q����� *StageMessageID+�� $��13��$��2��$��1�� (+ $m_exportMod_page3_saveStageMessageID#��� + $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveStageMessageIDCommand+� y��� *PageModType_model_visibility+ �� $
��Auto ��� $
��Auto ��� $��* ��� $��5 ��� $��30 � �� $��* ��� $��5 ��� $��* �.+��� $��0��$��0��$��3��$
��Left=�$��Center=�#��[ 
���  �� ), %m_exportMod_page3_exportModelsWarning#��� , $��12(��� $��1��$��0��$
��Left=�$��Center=�#��[ #���   "- m_exportMod_page3_importModels#��� - $��12(��� $��1��$��2��$
��Left=�$��Center=�#��[ #���   ". m_exportMod_page3_exportModels#��� . $��12(��� $��2��$��0��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *ImportModelList+$ OneWay=�$ PropertyChanged=� �� *SelectedImportModel+���� .R��� $ 
Horizontal=�.+��� ���� *
PSP_code+�� $��2��$��2��#���  #���  $��1q�$��Stretch=�$��Stretch=�#��[ $��12(����� *ExportModelList+$ OneWay=�$ PropertyChanged=� �� *SelectedExportModel+���� .R��� $ 
Horizontal=�.+��� ���� *
PSP_code+�� $��4��$��0��$��1�� !/ m_exportMod_page3_selectModel#��� / $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectModelCommand+�� $��4��$��2��$��1�� !0 m_exportMod_page3_deleteModel#��� 0 $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *DeleteModelCommand+� y��� *" PageModType_resources_visibility+ �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � �� $��1* ��� $��5 ��� $��1* �.+��� $��0��$��0��$��3��$
��Left=�$��Center=�#��[ #���   1 m_exportMod_page4_modName#��� 1 $��12(��� $��1��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�:   4NSC_Toolbox.DisallowSpecialCharactersTextboxBehavior $   DisallowSpecialCharacters$
$ true������ *ModName_field+�� $��3��$��0��$��3��$
��Left=�$��Center=�#��[ #���   2 m_exportMod_page4_modDesc#��� 2 $��12(��� $��4��$��0��$��3��% �� TextWrapping$% NoWrap=�& �� AcceptsReturn$
& true��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ModDesc_field+�� $��6��$��0��$��3��$
��Left=�$��Center=�#��[ #���   3 m_exportMod_page4_modAuthor#��� 3 $��12(��� $��7��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ModAuthor_field+�� $��9��$��0��$��3��$
��Left=�$��Center=�#��[ #���    4 m_exportMod_page4_ModVersion#��� 4 $��12(��� $��10��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ModVersion_field+�� $��12��$��0��$��3��$
��Left=�$��Center=�#��[ #���   5 m_exportMod_page4_modIcon#��� 5 $��12(��� $��12��$��2��$��3��$
��Left=�$��Center=�#��[ #���   $6  m_exportMod_page4_ModIconWarning#��� 6 $��12(��� $��13��$��2��$��3��$ HighQuality=�$	��100��$	��100��$
��Fill=�$
��Left=����� *ImagePreview+� $��13��$��0�� �� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0��$��30��$��0��#���  $	��Top=�$��Stretch=�#��[ #���  #���  $��1q����� *ModIconPath_field+�� $��2��$��0��$��1�� #7 m_exportMod_page4_selectModIcon#��� 7 $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectModIconCommand+�� $��17��$��0��$��3�� "8 m_exportMod_pageFinish_compile#��� 8 $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(�{��� *
IsModReady+���� *CompileModCommand+� y��� *PageModType_tuj_visibility+ �� $
��Auto ��� $
��Auto ��� $��5 ��� $��30 � �� $��* �.+��� $��0��$��0��$
��Left=�$��Center=�#��[ #���   9 m_exportMod_page3_tuj_001#��� 9 $��12(��� $��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *TeamUltimateJutsuList+ �� *SelectedTeamUltimateJutsu+ �� * SelectedTeamUltimateJutsuIndex+���� .R��� #��[ ���� # [ ���� ' �� 
TargetType"' ��( �� Triggers( �� ) �� Binding) �� * �� Value* placeholder.a��� + �� Property+ � ��, �� Value
, �����  -   $ Page4��
�������#���  # �    : m_exportMod_page4_desc# � : -   NextButtonVisibility$- Hidden=�.   CancelButtonVisibility$. Hidden=� �� $ 
PageFinish�� �� $ Page3��/   	CanFinish/ �� *IsModCompiled+ �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��* ��� $
��Auto � �� $��1* ��� $��5 ��� $��1* �.+��� $��0��$��0��$��3��$
��Left=�$��Center=�#��[ #���  #��� 1 $��12(��� $��1��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�$
$ true������ *ModName_field+�� $��3��$��0��$��3��$
��Left=�$��Center=�#��[ #���  #��� 2 $��12(��� $��4��$��0��$��3��$% NoWrap=�$
& true��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ModDesc_field+�� $��6��$��0��$��3��$
��Left=�$��Center=�#��[ #���  #��� 3 $��12(��� $��7��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ModAuthor_field+�� $��9��$��0��$��3��$
��Left=�$��Center=�#��[ #���  #��� 4 $��12(��� $��10��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ModVersion_field+�� $��12��$��0��$��3��$
��Left=�$��Center=�#��[ #���  #��� 5 $��12(��� $��12��$��2��$��3��$
��Left=�$��Center=�#��[ #���  #��� 6 $��12(��� $��13��$��2��$��3��$ HighQuality=�$	��100��$	��100��$
��Fill=�$
��Left=����� *ImagePreview+� $��13��$��0�� �� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0��$��30��$��0��#���  $	��Top=�$��Stretch=�#��[ #���  #���  $��1q����� *ModIconPath_field+�� $��2��$��0��$��1��#��� 7 $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SelectModIconCommand+�� $��17��$��0��$��3��#��� 8 $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(�{��� *
IsModReady+���� *CompileModCommand+  -   $ 
PageFinish��
�������#���  # �   0   CanSelectPreviousPage0 True	 False$ Visible=�$- Hidden=�$. Hidden=�/ �� *IsModCompiled+ �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  �� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0��$��0��$��WrapWithOverflow=�$
��Left=�$	��Top=�#��[ 
������� ; m_exportMod_pageFinish_desc#��� ; $��14(��� $��2��$��0��$��1��#��� 8 $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *CompileModCommand+� $��10��$��10��1 K� ZIndex$1 10��
������ y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��2   LoadingState2 �� *LoadingStatePlay+