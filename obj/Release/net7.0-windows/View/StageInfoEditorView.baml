   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  *    $NSC_Toolbox.View.StageInfoEditorView   /Controls"clr-namespace:NSC_Toolbox.Controls  W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 3	converter#clr-namespace:NSC_Toolbox.Converter 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��$	��900��$	��780��   m_stageInfoEditor � Title# [  ����   TitleBackground �� ImageSource# �   j� Stretch$ UniformToFill=� � 	Resources   TabItemText �� 
TargetType �� Triggers �� Binding �� RelativeSource	 �� AncestorType
 �� Value �� Property �� Value2  ,NSC_Toolbox.Converter.ColorToStringConverter  ColorToStringConverter��%�   &	       &	 �     �� " �� ��  �� *
IsSelected+ �� 	 TabItem
 True.a���  � ��
 �������  �� *
IsSelected+ �� 	 TabItem	
 False.a���  � ��
 �����  .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z  �� Path$ StretchMode�.��� $
��1300��$
��1100�� � ColumnDefinitions �� $��5 ��� $
��1.2* ��� $��5 ��� $
��1.5* ��� $��5 ��� $
��1.5* ��� $��5 � � RowDefinitions �� $��50 ��� $��5 ��� $��* ��� $��5 ��� $
��1.5* ��� $��5 ��� $
��1.5* ��� $��5 ��� $	��100 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ 
������� m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ 
������� �� *SaveFileCommand+m�  	 m_SaveAsFile#��� 	 #��[ 
������� �� *SaveFileAsCommand+� $��4��$��1��$��3�� �� $
��Auto ��� $��* �.+��� $��0��$��Center=�$��Bottom=�#��[  
 m_stageList#��� 
 #���  $��10(�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $��1��$ �� IsSynchronizedWithCurrentItem$
 TrueY� % !Toolbox_button_background_color_1#���   ! Toolbox_button_border_color_1#���  $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *StageInfoList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedStage+ �� SelectedIndex �� *SelectedStageIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� #��[ #���  $��12(����� *	StageName+$ OneWay=�$ PropertyChanged=�� $��1��$��8�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��1��  m_AddDupEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #���  #��[ #���  $��12(����� *AddDupEntryCommand+��   m_DeleteEntry#���  $��0��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #���  #��[ #���  $��12(����� *DeleteEntryCommand+��   m_SearchEntry#���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SearchEntryCommand+�� #���  #��[ $��2��$��0��$��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *StageTextBoxString+� $��3��$��8��$��3�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��  m_stageCopyProperties#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *CopyEntryCommand+��   m_stagePasteProperties#���  $��1��$��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *PasteEntryCommand+�� $��0��$��1��$��2��  m_SaveEntry#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveEntryCommand+� $��1��$��2�� �� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* �.+��� $��0��$��0��$
��Left=�$��Center=�#��[   m_stageName#���  #���  $��10(��� $��0��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *StageName_field+�� $��0��$��3��$
��Left=�$��Center=�#��[   m_stageMessageID#���  #���  $��10(��� $��0��$��4��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *StageMessageID_field+�� $��0��$��6��$
��Left=�$��Center=�#��[   m_stageFilter#���  #���  $��10(��� $��0��$��7��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *StageFilter_field+�� $��0��$��9��$��1��$
��Left=�$��Center=�#��[   m_stageWeather#���  #���  $��10(��� $��0��$��10��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q� �� *Weather_field+.@��� .����   m_stageWeather_0#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_stageWeather_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_stageWeather_2#��[ #���  $��Stretch=�$��Stretch=�#��[ � $��2��$��3��$��1�� �� $��2* ��� $��* � �� $
��Auto ��� $��* ��� $��40 ��� $��40 �.+��� $��0��$��3��$��Center=�$��Bottom=�#��[   m_stagePathList#���  #���  $��10(��� $��1��$��3��$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=����� *FilePathList+$ OneWay=�$ PropertyChanged=� �� *SelectedFilePath+ �� *SelectedFilePathIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *
FilePath+$ OneWay=�$ PropertyChanged=��� $��2��$��2��  
m_AddEntry#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddPathEntryCommand+�� $��0��$��3��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *RemovePathEntryCommand+�� $��2��$��3��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SavePathEntryCommand+�� $��0��$��2��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *FilePathTextBox_field+� $��4��$��3��$��1�� �� $��* ��� $��* � �� $
��Auto ��� $��* ��� $
��Auto ��� $��40 ��� $��40 �.+��� $��0��$��3��$��Center=�$��Bottom=�#��[   m_stageObjectList#���  #���  $��10(��� $��1��$��3��$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=����� *
ObjectList+$ OneWay=�$ PropertyChanged=� �� *SelectedObject+ �� *SelectedObjectIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *
ObjectName+$ OneWay=�$ PropertyChanged=��� $��2��$��4��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddObjectEntryCommand+�� $��0��$��4��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *RemoveObjectEntryCommand+�� $��2��$
��Left=�$��Bottom=�#��[   m_stageEntryType#���  #���  $��10(��� $��0��$��3��$��3��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *ObjectEntryType_List+ �� *EntryType_field+� $��3��$��6��$��3��#���  .+��� $��1q�#���  �� $��0,2,0,0q�
���   �$��5q�����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Transparent�� � Offset$ 0Q�� $ Transparent��$ 1Q�.@��� ���� $��9��$��Center=�$
��Left=�  d� 	IsChecked  �� *EnableFog_field+.���� #��[    
m_stageFog#��[  $��Center=�$��Stretch=�#��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 �.+��� $��0��$
��Left=�$��Center=�#��[  ! m_stageFogStartDistance#��� ! #���  $��10(�$ 	 Xceed.Wpf.Toolkit.DoubleUpDown  $��1��$��35��� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]!   	Increment! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]"   Value" �� *FogStartDistance_field+�� $��3��$
��Left=�$��Center=�#��[  " m_stageFogEndDistance#��� " #���  $��10(�  $��4��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *FogEndDistance_field+�� $��6��$
��Left=�$��Center=�#��[  # m_stageFogStrength#��� # #���  $��10(�  $��7��$��35��! 1#   Minimum# 0$   Maximum$ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *FogStrength_field+�� ���� $��9��$��Center=�$
��Left=�  �� *EnableMonoColorFilter_field+.���� #��[  $ m_stageMonoFilter#��[$ $��Center=�$��Stretch=�#��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$
��Left=�$��Center=�#��[  % m_stageMonoBlueTone#��� % #���  $��10(�  $��1��$��35��! 1# -0.5$ 0.5$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *MonoBlueTone_field+�� $��3��$
��Left=�$��Center=�#��[  & m_stageMonoRedTone#��� & #���  $��10(�  $��4��$��35��! 1# -0.5$ 0.5$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *MonoRedTone_field+�� $��6��$
��Left=�$��Center=�#��[  ' m_stageMonoAlpha#��� ' #���  $��10(�  $��7��$��35��! 1# 0$ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *MonoAlpha_field+�� ���� $��9��$��Center=�$
��Left=�  �� *EnableGlareEffect_field+.���� #��[  ( m_stageGlares#��[( $��Center=�$��Stretch=�#��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 �.+��� $��0��$
��Left=�$��Center=�#��[  ") m_stageGlareLuminanceThreshold#��� ) #���  $��10(�  $��1��$��35��! 1# 0$ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *GlareLuminanceThreshold_field+�� $��3��$
��Left=�$��Center=�#��[  * m_stageGlareSubtracted#��� * #���  $��10(�  $��4��$��35��! 1# 0$ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *GlareSubtracted_field+�� $��6��$
��Left=�$��Center=�#��[  #+ m_stageGlareCompositionStrength#��� + #���  $��10(�  $��7��$��35��! 1# 0$ 100$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� * GlareCompositionStrength_field+�� ���� $��3��$��Center=�$
��Left=�  �� *EnableSoftFocus_field+.���� #��[  , m_stageSoftFocus#��[, $��Center=�$��Stretch=�#��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 �.+��� $��0��$
��Left=�$��Center=�#��[  - m_stageSoftFocusStrength#��� - #���  $��10(�  $��1��$��35��! 1# 0$ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SoftFocusStrength_field+�� ���� $��10��$��3��$��Center=�$
��Left=�  �� *EnableSunShaft_field+.���� #��[  . m_stageSunShaft#��[. $��Center=�$��Stretch=�#��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$
��Left=�$��Center=�#��[   / m_stageSunShaftStartDistance#��� / #���  $��10(�  $��1��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SunShaftStartDistance_field+�� $��3��$
��Left=�$��Center=�#��[  0 m_stageSunShaftEndDistance#��� 0 #���  $��10(�  $��4��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SunShaftEndDistance_field+�� $��6��$
��Left=�$��Center=�#��[  1 m_stageSunShaftAlpha#��� 1 #���  $��10(�  $��7��$��35��! 1# 0$ 100$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SunShaftAlpha_field+�� $��9��$
��Left=�$��Center=�#��[  2 m_stageSunShaftBlurWidth#��� 2 #���  $��10(�  $��10��$��35��! 1# 0$ 255$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SunShaftBlurWidth_field+�� $��9��$��3��$
��Left=�$��Center=�#��[  )3 %m_stageSunShaftAttenuationCoefficient#��� 3 #���  $��10(�  $��3��$��10��$��35��! 1# 0$ 100$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *&$SunShaftAttenuationCoefficient_field+�� $��0��$��3��$
��Left=�$��Center=�#��[  4 m_stageSunShaftDirectionX#��� 4 #���  $��10(�  $��1��$��3��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SunShaftDirectionX_field+�� $��3��$��3��$
��Left=�$��Center=�#��[  5 m_stageSunShaftDirectionY#��� 5 #���  $��10(�  $��4��$��3��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SunShaftDirectionY_field+�� $��6��$��3��$
��Left=�$��Center=�#��[  6 m_stageSunShaftDirectionZ#��� 6 #���  $��10(�  $��7��$��3��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SunShaftDirectionZ_field+�� ���� #��[ $��Center=� 7 
m_stageDOF#��[7 #��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 �.+��� $��0��$
��Left=�$��Center=�#��[  8 m_stageDOFFocalLength#��� 8 #���  $��10(�  $��1��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *DOFFocalLength_field+�� $��3��$
��Left=�$��Center=�#��[  9 m_stageDOFShortDistance#��� 9 #���  $��10(�  $��4��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *DOFShortDistance_field+�� $��6��$
��Left=�$��Center=�#��[  : m_stageDOFLongDistance#��� : #���  $��10(�  $��7��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *DOFLongDistance_field+�� $��9��$
��Left=�$��Center=�#��[  ; m_stageDOFAlpha#��� ; #���  $��10(�  $��10��$��35��! 1# 0$ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *DOFAlpha_field+�� $��1��$��3��$��Center=�$
��Left=�  �� *EnableDOFBlur_field+.����  < m_stageDOFEnableBlur#��[< #���  $��Center=�$��Stretch=�#��[ $��10(��� $��2��$��3��$��3��$��Center=�$	��Top=�$
��Left=�  �� *EnableDOFEdgeBlur_field+.����  = m_stageDOFEnableEdgeBlur#��[= #���  $��Center=�$��Stretch=�#��[ $��10(��� ���� #��[ $��Center=� > m_stageLightPoint#��[> #��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$
��Left=�$��Center=�#��[  ? m_stageLightPointDirectionX#��� ? #���  $��10(�  $��1��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *LightPointDirectionX_field+�� $��3��$
��Left=�$��Center=�#��[  @ m_stageLightPointDirectionY#��� @ #���  $��10(�  $��4��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *LightPointDirectionY_field+�� $��6��$
��Left=�$��Center=�#��[  A m_stageLightPointDirectionZ#��� A #���  $��10(�  $��7��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *LightPointDirectionZ_field+�� ���� #��[ $��Center=� B m_stageColors#��[B #��[ ���  �� $��1* ��� $��5 ��� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$
��Left=�$��Center=�#��[  C m_stagePlayerAmbientColor#��� C #���  $��10(�# 	 Xceed.Wpf.Toolkit.ColorPicker  $��1��$��0��
���   �#��[ #���  #���  $��1q�%   SelectedColor% �� *PlayerAmbientColor_field+$ TwoWay=�& �� 	Converter#& [ �� $��3��$��0��$
��Left=�$��Center=�#��[  D m_stageEffectAmbientColor#��� D #���  $��10(�  $��4��$��0��
���   �#��[ #���  #���  $��1q�% �� *EffectAmbientColor_field+$ TwoWay=�#& [ �� $��6��$��0��$
��Left=�$��Center=�#��[  E m_stageParallelAmbientColor#��� E #���  $��10(�  $��7��$��0��
���   �#��[ #���  #���  $��1q�% �� *ParallelAmbientColor_field+$ TwoWay=�#& [ �� $��9��$��0��$
��Left=�$��Center=�#��[  F m_stageRayCutOffShadeColor#��� F #���  $��10(�  $��10��$��0��
���   �#��[ #���  #���  $��1q�% �� *RayCutOffShadeColor_field+$ TwoWay=�#& [ �� $��0��$��2��$
��Left=�$��Center=�#��[  G m_stageRayCutOffNormalColor#��� G #���  $��10(�  $��1��$��2��
���   �#��[ #���  #���  $��1q�% �� *RayCutOffNormalColor_field+$ TwoWay=�#& [ �� $��3��$��2��$
��Left=�$��Center=�#��[  H m_stageFogColor#��� H #���  $��10(�  $��4��$��2��
���   �#��[ #���  #���  $��1q�% �� *FogColor_field+$ TwoWay=�#& [ �� $��6��$��2��$
��Left=�$��Center=�#��[  I m_stageRockColor#��� I #���  $��10(�  $��7��$��2��
���   �#��[ #���  #���  $��1q�% �� *RockColor_field+$ TwoWay=�#& [ �� $��9��$��2��$
��Left=�$��Center=�#��[  J m_stageSunShaftColor#��� J #���  $��10(�  $��10��$��2��
���   �#��[ #���  #���  $��1q�% �� *SunShaftColor_field+$ TwoWay=�#& [ �� $��0��$��4��$
��Left=�$��Center=�#��[  K m_stageUnknownColor#��� K #���  $��10(�  $��1��$��4��
���   �#��[ #���  #���  $��1q�% �� *UnknownColor_field+$ TwoWay=�#& [ �� $��3��$��4��$
��Left=�$��Center=�#��[  L m_stageShadowColor#��� L #���  $��10(�  $��4��$��4��
���   �#��[ #���  #���  $��1q�% �� *ShadowColor_field+$ TwoWay=�#& [ �� $��5��$��4��$��3��$��Center=�$	��Top=�$
��Left=�  �� *EnableShadowColor_field+.����  M m_stageEnableShadowColor#��[M #���  $��Center=�$��Stretch=�#��[ $��10(��� ���� $��6��$��Center=�$
��Left=�  �� *EnableLensFlare_field+.���� #��[  N m_stageLensFlare#��[N $��Center=�$��Stretch=�#��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��3��$��0��$
��Left=�$��Center=�#��[  O m_stageLensFlareAlpha#��� O #���  $��10(�  $��4��$��0��$��35��! 1# 0$ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *LensFlareAlpha_field+�� $��0��$��2��$
��Left=�$��Center=�#��[  P m_stageLensFlarePositionX#��� P #���  $��10(�  $��1��$��2��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *LensFlarePositionX_field+�� $��3��$��2��$
��Left=�$��Center=�#��[  Q m_stageLensFlarePositionY#��� Q #���  $��10(�  $��4��$��2��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *LensFlarePositionY_field+�� $��6��$��2��$
��Left=�$��Center=�#��[  R m_stageLensFlarePositionZ#��� R #���  $��10(�  $��7��$��2��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *LensFlarePositionZ_field+�� $��0��$��0��$
��Left=�$��Center=�#��[ #��� N #���  $��10(��� $��0��$��1��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q� �� *LensFlare_field+.@��� .����  S m_stageLensFlare_1#��[S #���  $��Stretch=�$��Stretch=�#��[ �� .����  T m_stageLensFlare_2#��[T #���  $��Stretch=�$��Stretch=�#��[ �� .����  U m_stageLensFlare_3#��[U #���  $��Stretch=�$��Stretch=�#��[ �� .����  V m_stageLensFlare_4#��[V #���  $��Stretch=�$��Stretch=�#��[ �� .����  W m_stageLensFlare_5#��[W #���  $��Stretch=�$��Stretch=�#��[ �� .����  X m_stageLensFlare_6#��[X #���  $��Stretch=�$��Stretch=�#��[ �� ���� $��Center=�$
��Left=�  �� *" EnableBrightnessAdjustment_field+.���� #��[   Y m_stageBrightnessAndContrast#��[Y $��Center=�$��Stretch=�#��[ ���  �� $��1* ��� $��5 ��� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 �.+��� $��0��$
��Left=�$��Center=�#��[  Z m_stageBrightness#��� Z #���  $��10(�  $��1��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Brightness_field+�� $��3��$
��Left=�$��Center=�#��[  [ m_stageContrast#��� [ #���  $��10(�  $��4��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Contrast_field+� $��5��$��2��$��3�� �� $��* ��� $��5 ��� $��40 �.+��� $��0��$��3��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveObjectEntryCommand+� #���  .+��� $��1q�#���  �� $��0,2,0,0q�
���   ����� $ 0.5,1&�$ 0.5,0&�.��� $ Transparent��$ 0Q�� $ Transparent��$ 1Q�.@��� ���� #��[  \ m_stageObjectSettings#��[\ #��[ ��� $��5q� �� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0�� ] m_stageObjectPath#��� ] $
��Left=�#��[ #���  $��10(��� $��0��$��1��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *StagePathComboBoxList+ �� *ObjectPathComboBoxIndex+�� $��3�� ^ m_stageObjectName#��� ^ $
��Left=�#��[ #���  $��10(��� $��4��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *ObjectName_field+�� $��6�� _ m_stageObjectPosPath#��� _ $
��Left=�#��[ #���  $��10(��� $��0��$��7��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *StagePathComboBoxList+ �� *!ObjectPositionPathComboBoxIndex+�� $��9�� ` m_stageObjectPosBone#��� ` $
��Left=�#��[ #���  $��10(��� $��10��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *PositionBoneName_field+�� $��12�� a m_stageObjectAnimationSpeed#��� a $
��Left=�$��Center=�#��[ #���  $��10(�  $��13��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *AnimationSpeed_field+�� $��15��$��Center=�$	��Top=�$
��Left=�  �� *EnableCameraHideObject_field+.����  b m_stageObjectHideCameraMesh#��[b #���  $��Center=�$��Stretch=�#��[ $��10(��� $��17��$��Center=�$	��Top=�$
��Left=�  �� *IsRigidBody_field+.����  c m_stageObjectRigidBody#��[c #���  $��Center=�$��Stretch=�#��[ $��10(��� ���� #��[  "d m_stageBreakableObjectSettings#��[d #��[ ��� $��5q� �� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0�� e m_stageBreakableObjectPath#��� e $
��Left=�#��[ #���  $��10(��� $��0��$��1��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *StagePathComboBoxList+ �� *" BreakableObjectPathComboBoxIndex+�� $��3�� "f m_stageBreakableObjectEffect_1#��� f $
��Left=�#��[ #���  $��10(��� $��4��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *BreakableObjectEffect01_field+�� $��6�� "g m_stageBreakableObjectEffect_2#��� g $
��Left=�#��[ #���  $��10(��� $��7��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *BreakableObjectEffect02_field+�� $��9�� "h m_stageBreakableObjectEffect_3#��� h $
��Left=�#��[ #���  $��10(��� $��10��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *BreakableObjectEffect03_field+�� $��12�� *i &m_stageBreakableObjectAnimationSpeed_1#��� i $
��Left=�$��Center=�#��[ #���  $��10(�  $��13��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BreakableObjectSpeed01_field+�� $��15�� *j &m_stageBreakableObjectAnimationSpeed_2#��� j $
��Left=�$��Center=�#��[ #���  $��10(�  $��16��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BreakableObjectSpeed02_field+�� $��18�� *k &m_stageBreakableObjectAnimationSpeed_3#��� k $
��Left=�$��Center=�#��[ #���  $��10(�  $��19��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BreakableObjectSpeed03_field+�� ���� #��[   l m_stageBreakableWallSettings#��[l #��[ ��� $��5q� �� $��1* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��  m m_stageBreakableWallEffect_1#��� m $
��Left=�#��[ #���  $��10(��� $��1��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *BreakableWallEffect01_field+�� $��3��  n m_stageBreakableWallEffect_2#��� n $
��Left=�#��[ #���  $��10(��� $��4��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *BreakableWallEffect02_field+�� $��6��  o m_stageBreakableWallEffect_3#��� o $
��Left=�#��[ #���  $��10(��� $��7��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *BreakableWallEffect03_field+�� $��9�� p m_stageBreakableWallSound#��� p $
��Left=�#��[ #���  $��10(��� $��10��#��[ #���  $��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *BreakableWallSound_field+�� $��12�� q m_stageBreakableWallVolume#��� q $
��Left=�$��Center=�#��[ #���  $��10(�  $��13��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BreakableWallVolume_field+�� $��15�� #r m_stageBreakableWallCondition_1#��� r $
��Left=�$��Center=�#��[ #���  $��10(�  $��16��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BreakableWallValue1_field+�� $��18�� #s m_stageBreakableWallCondition_2#��� s $
��Left=�$��Center=�#��[ #���  $��10(�  $��19��$��35��! 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BreakableWallValue2_field+� $��10��$��10��' K� ZIndex$' 20��
������ y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)	   #NSC_Toolbox.Controls.LoadingControl	  $��2��$��2��( 	  LoadingState( �� *LoadingStatePlay+