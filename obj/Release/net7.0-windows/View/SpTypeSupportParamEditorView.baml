   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  3    -NSC_Toolbox.View.SpTypeSupportParamEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $	��950��$	��880��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_spTypeSupportParamEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z 	 �� Path$	 StretchMode�.��� $	��950��$	��880��
 � ColumnDefinitions
 �� $��5 ��� $��2* ��� $��5 ��� $
��3.5* ��� $��5 � � RowDefinitions �� $��50 ��� $��3* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ #���   �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ #���   �� *SaveFileAsCommand+)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1�� % !Toolbox_button_background_color_1#���   !	 Toolbox_button_border_color_1#��� 	 $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *SpTypeSupportParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedSpTypeSupport+ �� SelectedIndex �� *SelectedSpTypeSupportIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��Characode ID: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *CharacodeID+$ OneWay=�$ PropertyChanged=�� $��1��$��3��$��3�� �� $
��Auto ��� $��5 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��5 �
 �� $��* �.+��� $��0��$��0��$��3��$ Vertical=�$��Center=�.+��� $
��Left=�$��12(�#��[  
 m_Characode#��� 
 #���  % 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��30��#��[ #���  #��� 	 $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 65535   Minimum 0#���     Value �� *CharacodeID_field+�� $
��Left=�$��12(�#��[   m_spTypeSupportParamState#���  #���  �� $
��Left=�$��0��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q� �� *State_field+.@��� .����   m_spTypeSupportParamState_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_spTypeSupportParamState_2#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_spTypeSupportParamState_3#��[ #���  $��Stretch=�$��Stretch=�#��[ �� $
��Left=�$��12(�#��[   m_spTypeSupportParamMode#���  #���  �� $
��Left=�$��0��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q� �� *Direction_field+.@��� .����   m_spTypeSupportParamMode_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_spTypeSupportParamMode_2#��[ #���  $��Stretch=�$��Stretch=�#��[ � $��2��$��0��#���   �� $
��Auto ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* �
 �� $��* ��� $��* ��� $��5 ��� $��2* �.+��� $��0,0,0,1q�
�������$��0��$��5���� $��0��$��0��$��4��$
��Left=�$��20(�#��[  % !m_spTypeSupportParamJutsuNameLeft#���  #���  �� $��2��$��0��$��4��$
��Left=�$��16(�#��[  ! m_spTypeSupportParamJutsuName#���  #���  �� $��3��$��0��$��2��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *LeftJutsuName_field+�� $��5��$��0��$��4��$
��Left=�$��16(�#��[   m_CostumeID#���  #���    $��6��$��0��$��2�� 1 -1 20$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #��� 	 $��1q� �� *LeftJutsuCostumeIndex_field+� $��1��$��3��$��6��$��Bottom=� �� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0��$��Center=�$
��Left=� d� 	IsChecked �� *LeftJutsuEnableOnGround_field+.����  & "m_spTypeSupportParamEnableOnGround#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��2��$��Center=�$
��Left=� �� *LeftJutsuEnableInAir_field+.����  # m_spTypeSupportParamEnableInAir#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��4��$��Center=�$
��Left=� �� *'%LeftJutsuEnableSpecialCondition_field+.����  . *m_spTypeSupportParamEnableSpecialCondition#��[ #���  $��Center=�$��Stretch=�#��[ $��10(�� $��4��$��0��#���   �� $
��Auto ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* �
 �� $��* ��� $��* ��� $��5 ��� $��2* �.+��� $��0,0,0,1q�
�������$��0��$��5���� $��0��$��0��$��4��$
��Left=�$��20(�#��[  & "m_spTypeSupportParamJutsuNameRight#���  #���  �� $��2��$��0��$��4��$
��Left=�$��16(�#��[ #���  #���  �� $��3��$��0��$��2��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *RightJutsuName_field+�� $��5��$��0��$��4��$
��Left=�$��16(�#��[ #���  #���     20 -1$��6��$��0��$��2�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #��� 	 $��1q� �� *RightJutsuCostumeIndex_field+� $��1��$��3��$��6��$��Bottom=� �� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0��$��Center=�$
��Left=� �� * RightJutsuEnableOnGround_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��2��$��Center=�$
��Left=� �� *RightJutsuEnableInAir_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��4��$��Center=�$
��Left=� �� *(&RightJutsuEnableSpecialCondition_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(�� $��6��$��0��#���   �� $
��Auto ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* �
 �� $��* ��� $��* ��� $��5 ��� $��2* �.+��� $��0,0,0,1q�
�������$��0��$��5���� $��0��$��0��$��4��$
��Left=�$��20(�#��[  # m_spTypeSupportParamJutsuNameUp#���  #���  �� $��2��$��0��$��4��$
��Left=�$��16(�#��[ #���  #���  �� $��3��$��0��$��2��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *UpJutsuName_field+�� $��5��$��0��$��4��$
��Left=�$��16(�#��[ #���  #���     20 -1$��6��$��0��$��2�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #��� 	 $��1q� �� *UpJutsuCostumeIndex_field+� $��1��$��3��$��6��$��Bottom=� �� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0��$��Center=�$
��Left=� �� *UpJutsuEnableOnGround_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��2��$��Center=�$
��Left=� �� *UpJutsuEnableInAir_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��4��$��Center=�$
��Left=� �� *%#UpJutsuEnableSpecialCondition_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(�� $��8��$��0��#���   �� $
��Auto ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* �
 �� $��* ��� $��* ��� $��5 ��� $��2* �.+��� $��0,0,0,1q�
�������$��0��$��5���� $��0��$��0��$��4��$
��Left=�$��20(�#��[  % !m_spTypeSupportParamJutsuNameDown#���  #���  �� $��2��$��0��$��4��$
��Left=�$��16(�#��[ #���  #���  �� $��3��$��0��$��2��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *DownJutsuName_field+�� $��5��$��0��$��4��$
��Left=�$��16(�#��[ #���  #���     20 -1$��6��$��0��$��2�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #��� 	 $��1q� �� *DownJutsuCostumeIndex_field+� $��1��$��3��$��6��$��Bottom=� �� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto �.+��� $��0��$��Center=�$
��Left=� �� *DownJutsuEnableOnGround_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��2��$��Center=�$
��Left=� �� *DownJutsuEnableInAir_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��4��$��Center=�$
��Left=� �� *'%DownJutsuEnableSpecialCondition_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(�� $��1��$��3��$��2��
 �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��  m_AddDupEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #��� 	 #��[ #���  $��12(����� *AddDupEntryCommand+��   m_DeleteEntry#���  $��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #��� 	 #��[ #���  $��12(����� *DeleteEntryCommand+��   m_SearchEntry#���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SearchEntryCommand+  $��1��$��0��#��[ #���  #��� 	 $��1q� 1	 65535 0#���   �� *SearchIndex_field+�� $��4��$��3��   m_SaveEntry#���   $��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��
������ y��� *LoadingStatePlay+
 �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��   LoadingState �� *LoadingStatePlay+