   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  (    "NSC_Toolbox.View.PRMLoadEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5
properties$clr-namespace:NSC_Toolbox.Properties 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 $	��750��$	��580��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_PRMloadEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z 	 �� Path$	 StretchMode�.��� $	��750��$	��580��
 � ColumnDefinitions
 �� $��5 ��� $
��1.5* ��� $��5 ��� $��* ��� $��5 � � RowDefinitions �� $��50 ��� $��3* ��� $��5 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ 
������� m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ 
������� �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ 
������� �� *SaveFileAsCommand+�� $��0��$��0��$��4�� �� Orientation$ 
Horizontal=�$��Right=�$��3q�.+��� $
��Left=�$��Center=�#��[ #���    m_Characode#���  $��14(��� $��5,0,0,0q�$	��100�� �� 	MaxLength$ 15��#���  $��Stretch=�$��Stretch=�$��Center=�$
��Left=�#��[  %	 !Toolbox_button_background_color_1#��� 	  !
 Toolbox_button_border_color_1#��� 
 $��1q����� *CharacodeBinName+)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1��#��� 	 #��� 
 $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *PRMLoadList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedPRMLoad+ �� SelectedIndex �� *SelectedPRMLoadIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *
FilePath+$ OneWay=�$ PropertyChanged=��� $��/��#��[ #���  $��12(��� #��[ #���  $��12(����� *
FileName+�� $��.xfbin��#��[ #���  $��12(�� $��1��$��3�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 �.+��� $��0��$
��Left=�#��[   m_PRMloadFilePath#���  #���  $��10(��� $ 31��$��0��$��1��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *FilePath_field+�� $��3��$
��Left=�#��[   m_PRMloadFileName#���  #���  $��10(��� $ 31��$��0��$��4��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *FileName_field+�� $��6��$
��Left=�#��[   m_PRMloadFileType#���  #���  $��10(��� $��7��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #��� 	 #��� 
 $��1q� �� *
Type_field+.@��� .����   m_PRMloadFileType_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_2#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_3#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_4#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_5#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_6#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_7#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_8#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_9#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_10#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_11#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_12#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_13#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_14#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMloadFileType_15#��[ #���  $��Stretch=�$��Stretch=�#��[ �� $��9��$
��Left=�#��[   m_PRMloadCostumeIndex#���  #���  $��10(�% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��30��$��10��#��[ #��� 	 #��� 
 $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum 20   Minimum -1#���     Value �� *CostumeIndex_field+�� $��12��$
��Left=�#��[   m_PRMloadLoadCondition#���  #���  $��10(�� $��13��#��� 	 
 �� $��* ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+���   m_PRMloadLoadCondition_1#���  $��0��$��0�� d� 	IsChecked �� *IsConditionCommon+��    m_PRMloadLoadCondition_2#���   $��0��$��1�� �� *IsConditionSupport+��  ! m_PRMloadLoadCondition_4#��� ! $��1��$��0�� �� *IsConditionAwakening+��  " m_PRMloadLoadCondition_5#��� " $��1��$��1�� �� *IsConditionJutsu1+��  # m_PRMloadLoadCondition_6#��� # $��2��$��0�� �� *IsConditionJutsu2+��  $ m_PRMloadLoadCondition_7#��� $ $��2��$��1�� �� *IsConditionJutsu3+��  % m_PRMloadLoadCondition_8#��� % $��3��$��0�� �� *IsConditionJutsu4+��  & m_PRMloadLoadCondition_9#��� & $��3��$��1�� �� *IsConditionJutsu5+��  ' m_PRMloadLoadCondition_10#��� ' $��4��$��0�� �� *IsConditionJutsu6+��  ( m_PRMloadLoadCondition_11#��� ( $��4��$��1�� �� *IsConditionUltimateJutsu1+��  ) m_PRMloadLoadCondition_12#��� ) $��5��$��0�� �� *IsConditionUltimateJutsu2+��  * m_PRMloadLoadCondition_13#��� * $��5��$��1�� �� *IsConditionUltimateJutsu3+��  + m_PRMloadLoadCondition_14#��� + $��6��$��0�� �� *IsConditionUltimateJutsu4+� $��1��$��3��
 �� $��* ��� $��* � �� $��* �.+��� $��0�� , 
m_AddEntry#��� , $��Stretch=�$��Stretch=� %- !Toolbox_button_background_color_2#��� - #��� 
 #��[ #���  $��12(����� *AddEntryCommand+��  . m_DeleteEntry#��� . $��1��$��Stretch=�$��Stretch=� %/ !Toolbox_button_background_color_3#��� / #��� 
 #��[ #���  $��12(����� *DeleteEntryCommand+�� $��3��$��3�� 0 m_SaveEntry#��� 0 $��Stretch=�$��Stretch=�#��� - #��� 
 #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��
������ y��� *LoadingStatePlay+
 �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��   LoadingState �� *LoadingStatePlay+