   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  3    -NSC_Toolbox.View.PlayerSettingParamEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5
properties$clr-namespace:NSC_Toolbox.Properties 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 $	��750��$	��880��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_PlayerSettingParamEditor � Title# �    � 	Resources -   'NSC_Toolbox.Converter.IntToHexConverter  IntToHexConvert*   $NSC_Toolbox.Converter.IndexConverter  IndexConverter��%   &	       &	          ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $	��750��$	��880�� � ColumnDefinitions �� $��5 ��� $��2* ��� $��5 ��� $��* ��� $��5 � � RowDefinitions �� $��50 ��� $��3* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ 
������� m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ 
������� �� *SaveFileCommand+m�  	 m_SaveAsFile#��� 	 #��[ 
������� �� *SaveFileAsCommand+)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1�� %
 !Toolbox_button_background_color_1#��� 
  ! Toolbox_button_border_color_1#���  $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *PlayerSettingParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedPSP+ �� SelectedIndex �� *SelectedPSPIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� $
��ID: ��#��[ 
��� ���$��12(��� #��[ 
�������$��12(����� *PSP_ID+ �� 	Converter# [ $ OneWay=�$ PropertyChanged=��� $�� Code: ��#��[ 
�������$��12(��� #��[ 
�������$��12(����� $
 PSP_code��� $�� Characode ID: ��#��[ 
��� � �$��12(��� #��[ 
�������$��12(����� *CharacodeID+# [ $ OneWay=�$ PropertyChanged=��� $�� Costume ID: ��#��[ 
�������$��12(��� #��[ 
�������$��12(����� *	CostumeID+# [ $ OneWay=�$ PropertyChanged=�� $��1��$��3��$��3�� �� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* �.+��� $��0��$
��Left=�#��[   
m_PresetID#���  #���  $��10(�% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��1��#��[ #��� 
 #���  $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 65535   Minimum 0#���     Value �� *PSP_ID_field+�� $��3��$
��Left=�#��[   m_Characode#���  #���  $��10(�  #��[ $��4��#��� 
 #���  $��1q� 1	 65535 0#���   �� *CharacodeID_field+�� $��6��$
��Left=�#��[   m_CostumeID#���  #���  $��10(�  #��[ $��7��#��� 
 #���  $��1q� 1	 65535 -1#���   �� *CostumeID_field+�� $��9��$
��Left=�#��[   	m_unknown#���  #���  $��10(�  #��[ $��10��#��� 
 #���  $��1q� 1	 65535 -1#���   �� *	Unk_field+�� $��12��$
��Left=�#��[   m_playerSettingParamID#���  #���  $��10(��� -    ��Name$ 	PSPIDName��$��13��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *PSP_code_field+�� $��15��$
��Left=�#��[   m_defaultJutsu#���  #���  $��10(�  #��[ $��16��#��� 
 #���  $��1q� 1 6 -1#���   �� *DefaultJutsu_field+�� $��18��$
��Left=�#��[   m_defaultUltJutsu#���  #���  $��10(�  #��[ $��19��#��� 
 #���  $��1q� 1 3 -1#���   �� *DefaultUltimateJutsu_field+�� $��21��$
��Left=�#��[   m_chaCharacterName#���  #���  $��10(��� -   $ ChaCharName��$��22��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *CharacterNameMessageID_field+�� $��24��$
��Left=�#��[   m_chaDescription#���  #���  $��10(��� -   $ ChaDescriptionName��$��25��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *#!CostumeDescriptionMessageID_field+�� $��27��$
��Left=�#��[   m_dlcID#���  #���  $��10(�  #��[ $��28��#��� 
 #���  $��1q� 1	 65535 -1#���   �� *DLC_ID_field+�� $��30��$
��Left=�#��[   m_ReferencePSPID#���  #���  $��10(�  #��[ $��31��#��� 
 #���  $��1q� 1	 65535 -1#���   �� *MainPSP_ID_field+�� $��33��$
��Left=�#��[   m_ReferenceCharacodeID#���  #���  $��10(�  #��[ $��34��#��� 
 #���  $��1q� 1	 65535 -1#���   �� *ReferenceCharacodeID_field+�� $��36��$
��Left=�#��[   m_PSP_IconCostume#���  #���  $��10(�  #��[ $��37��#��� 
 #���  $��1q� 1	 65535 -1#���   �� *
Unk1_field+� $��1��$��3��$��2�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��  m_AddDupEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #���  #��[ #���  $��12(����� *AddDupEntryCommand+��   m_DeleteEntry#���  $��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #���  #��[ #���  $��12(����� *DeleteEntryCommand+��   m_SearchEntry#���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SearchEntryCommand+�� #���  #��[ $��2��$��0��$��Stretch=�$��Stretch=�$��Center=�#��� 
 #���  $��1q����� *SearchTextBox_field+�� $��4��$��3��  m_SaveEntry#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)	   #NSC_Toolbox.Controls.LoadingControl	  $��2��$��2�� 	  LoadingState �� *LoadingStatePlay+