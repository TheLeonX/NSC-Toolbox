   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  *    $NSC_Toolbox.View.AwakeAuraEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $	��850��$	��600��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_awakeAuraEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z 	 �� Path$	 StretchMode�.��� $	��850��$	��600��
 � ColumnDefinitions
 �� $��5 ��� $
��2.3* ��� $��5 ��� $��3* ��� $��5 � � RowDefinitions �� $��50 ��� $��3* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ #���   �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ #���   �� *SaveFileAsCommand+)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1�� % !Toolbox_button_background_color_1#���   !	 Toolbox_button_border_color_1#��� 	 $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *AwakeAuraList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedAwakeAura+ �� SelectedIndex �� *SelectedAwakeAuraIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��Characode: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *	Characode+$ OneWay=�$ PropertyChanged=��� $�� Bones: ��#��[ 
��� ���$��12(��� #��[ 
����p��$��12(����� *
MainBone+$ OneWay=�$ PropertyChanged=��� $�� ��#��[ 
��� ���$��12(��� #��[ 
�����_�$��12(����� *SecondaryBone+$ OneWay=�$ PropertyChanged=�� $��1��$��3��$��3�� �� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $��* ��� $��5 �
 �� $��2* ��� $��5 ��� $��* �.+��� $��0��$��0�� 
 m_awakeAuraCharacode#��� 
 $
��Left=�$��Center=�$��12(�#��[ #���  ��  �� 	MaxLength$ 7��$��1��$��0��$��3��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *Characode_field+�� $��3��$��0��  m_awakeAuraSkillFile#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��4��$��0��$��3��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *SkillFile_field+�� $��6��$��0��  m_awakeAuraSkillEntry#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��7��$��0��$��3��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *SkillEntryName_field+�� $��9��$��0��  m_awakeAuraMainBone#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��10��$��0��$��1��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *MainBone_field+�� $��12��$��0��  m_awakeAuraSecondaryBone#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��13��$��0��$��1��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *SecondaryBone_field+�� $��15��$��0��  m_awakeAuraState#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��16��$��0��$��3��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #��� 	 $��1q� �� *State_field+.@��� .����   m_awakeAuraState_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_awakeAuraState_2#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_awakeAuraState_3#��[ #���  $��Stretch=�$��Stretch=�#��[ �� $��18��$��0��  m_awakeAuraCondition#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��19��$��0��$��3��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #��� 	 $��1q� �� *Condition_field+.@��� .����   m_awakeAuraCondition_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_awakeAuraCondition_2#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_awakeAuraCondition_3#��[ #���  $��Stretch=�$��Stretch=�#��[ �� $��21��$��Center=�$
��Left=� d� 	IsChecked �� *
Unk1_field+.����   	m_unknown#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��10��$��2��$��Center=�$
��Left=� �� *MainBoneUsePlayerModel_field+.����    m_awakeAuraEnablePlayerModel#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��13��$��2��$��Center=�$
��Left=� �� *#!SecondaryBoneUsePlayerModel_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(�� $��1��$��3��$��2��
 �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��  m_AddDupEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #��� 	 #��[ #���  $��12(����� *AddDupEntryCommand+��   m_DeleteEntry#���  $��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #��� 	 #��[ #���  $��12(����� *DeleteEntryCommand+��   m_SearchEntry#���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SearchEntryCommand+�� #���  #��[ $��2��$��0��$��Stretch=�$��Stretch=�$��Center=�#���  #��� 	 $��1q����� *SearchTextBox_field+�� $��4��$��3��  m_SaveEntry#���  $��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��
������ y��� *LoadingStatePlay+
 �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��   LoadingState �� *LoadingStatePlay+