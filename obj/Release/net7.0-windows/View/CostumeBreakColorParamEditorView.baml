   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  7    1NSC_Toolbox.View.CostumeBreakColorParamEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $	��650��$	��550��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True�� !  m_costumBreakColorParamEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources 3  -NSC_Toolbox.Converter.ColorToStringConverter2  ColorToStringConverter��%   &	         .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $	��650��$	��550�� � ColumnDefinitions �� $��5 ��� $��* ��� $��5 � � RowDefinitions �� $��50 ��� $��* ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ #���   �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ #���   �� *SaveFileAsCommand+� $��1��$��1�� �� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 � �� $��5 ��� $��* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1�� %	 !Toolbox_button_background_color_1#��� 	  !
 Toolbox_button_border_color_1#��� 
 $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *CostumeBreakColorParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� * SelectedCostumeBreakColorParam+ �� SelectedIndex �� *%#SelectedCostumeBreakColorParamIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��PlayerSettingParam ID: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *PlayerSettingParamID+$ OneWay=�$ PropertyChanged=�� $��1��$��3��$��3�� �� $
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
��Auto �.+��� $��0��$
��Left=�#��[   m_playerSettingParamID#���  #���  $��10(�% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��1��$��30��#��[ #��� 	 #��� 
 $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 65535   Minimum 0#���     Value �� *PlayerSettingParamID_field+�� $��3��$��0��$
��Left=�$��Center=�#��[  $  m_costumBreakColorParamAltColor1#���  #���  $��10(�# 	 Xceed.Wpf.Toolkit.ColorPicker  $��4��$��30��$��0��
���   �#��[ #��� 	 #��� 
 $��1q�   SelectedColor �� *AltColor1_field+$ TwoWay=� �� 	Converter# [ �� $��6��$��0��$
��Left=�$��Center=�#��[  $  m_costumBreakColorParamAltColor2#���  #���  $��10(�  $��7��$��30��$��0��
���   �#��[ #��� 	 #��� 
 $��1q� �� *AltColor2_field+$ TwoWay=�# [ �� $��9��$��0��$
��Left=�$��Center=�#��[  $  m_costumBreakColorParamAltColor3#���  #���  $��10(�  $��10��$��30��$��0��
���   �#��[ #��� 	 #��� 
 $��1q� �� *AltColor3_field+$ TwoWay=�# [ �� $��12��$��0��$
��Left=�$��Center=�#��[  $  m_costumBreakColorParamAltColor4#���  #���  $��10(�  $��13��$��30��$��0��
���   �#��[ #��� 	 #��� 
 $��1q� �� *AltColor4_field+$ TwoWay=�# [ � $��1��$��3��$��2�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��  m_AddDupEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #��� 
 #��[ #���  $��12(����� *AddDupEntryCommand+��   m_DeleteEntry#���  $��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #��� 
 #��[ #���  $��12(����� *DeleteEntryCommand+��   m_SearchEntry#���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #��� 
 #��[ #���  $��12(����� *SearchEntryCommand+  $��1��$��30��#��[ #��� 	 #��� 
 $��1q� 1	 65535 0#���   �� *SearchIndex_field+�� $��4��$��3��  m_SaveEntry#���  $��Stretch=�$��Stretch=�#���  #��� 
 #��[ #���  $��12(����� *SaveEntryCommand+