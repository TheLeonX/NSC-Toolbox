   M S B A M L   `   `   `  ����F  BNSC-Toolbox, Version=1.6.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  5   	   =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  5   	   ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  5   8   ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  5   	   7    1NSC_Toolbox.View.CostumeBreakColorParamEditorView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NSC_Toolbox.View     5   	   9	converter#clr-namespace:NSC_Toolbox.Converter     5   	   D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5	   	   5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5
   	   U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 5   	   1Controls"clr-namespace:NSC_Toolbox.Controls 
 68   5
properties$clr-namespace:NSC_Toolbox.Properties 
 5   	   $	��750��5   	   $	��550��6   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��5   	    !  m_costumBreakColorParamEditor � Title# �   5   	   ��5      �� 5   
     TitleBackground �� ImageSource# �  6    j� ViewboxUnits$ RelativeToBoundingBox=�6Q    j� ViewportUnits$ RelativeToBoundingBox=�6v    j� Stretch$ UniformToFill=�6�    � 	Resources 5      3  -NSC_Toolbox.Converter.ColorToStringConverter2  ColorToStringConverter��%   &	         5   
   6,   5      .��5      (�  (� Stretch 6   �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��5   
   � $	��750��6   $	��550��6    % !Toolbox_button_background_color_1#���  6(    � ColumnDefinitions 5      �� 5      $��5 �6#   �� 5      $��* �6#   �� 5      $��5 �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5       $��* �6    �� 5!      $��5 �6    .+�5#      o� $��0��6   $��5��6#   $��Stretch=�67   $��Stretch=�6U     
NarutoFont#��[ 6q     Toolbox_button_text_color_1#���  6�   .@�5$      m�  
 m_File#���  6   #��[ 6=   #���  6f   .@�5%      m�   
m_OpenFile#���  6C   #��[ 6i   #���  6�    m� Command 6   �� *OpenFileCommand+6�   m� 5&        
m_SaveFile#���  6C   #��[ 6i   #���  6�    6   �� *SaveFileCommand+6�   m� 5'       	 m_SaveAsFile#��� 	 6E   #��[ 6m   #���  6�    6   �� *SaveFileAsCommand+6�   5(      5)      � 5*      $��1��6   $��1��6     5+      �� 5,      $��5 �6'   �� 5-      $��* �6'   �� 5.      $��5 �6'   �� 5/      $��* �6'   �� 50      $��5 �6'    52      �� 53      $��5 �6$   �� 54      $��* �6$   �� 55      $��5 �6$   �� 56      $��50 �6$   �� 57      $��50 �6$   �� 58      $��5 �6$   .+�5:      )clr-namespace:NSC_ToolboxNSC_Toolbox  6�  �� 6   -WpfExtensionsclr-namespace:NSC_Toolbox 
 6�  -   5        $ �� IsSynchronizedWithCurrentItem$
 TrueY�5:      $��1��6  $��1��6  #���  6$   !
 Toolbox_button_border_color_1#��� 
 6e  $��1q�6�  $��Stretch=�6�  $��Stretch=�6�   J� 	AllowDrop$
 True��6u  #   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True��6�  ��6j   �� *CostumeBreakColorParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� * SelectedCostumeBreakColorParam+ �� SelectedIndex 6�  �� *%#SelectedCostumeBreakColorParamIndex+��5;      �� 5<      .R�5=      ��  �� Orientation$ 
Horizontal=�6)   .+�5>   "   �� $��PlayerSettingParam ID: ��6,   #��[ 6K   
��� ���$��16(�6�   �� 5?   "   #��[ 6�   #���  6�   $��16(�6�   ��6,   �� *PlayerSettingParamID+$ OneWay=�$ PropertyChanged=�6�   5@      5A      5C      � 5D      $��1��6   $��3��6$   $��3��64    5E      �� 5F      $
��Auto �6(   �� 5G      $
��Auto �6(   �� 5H      $��5 �6(   �� 5I      $
��Auto �6(   �� 5J      $
��Auto �6(   �� 5K      $��5 �6(   �� 5L      $
��Auto �6(   �� 5M      $
��Auto �6(   �� 5N      $��5 �6(   �� 5O      $
��Auto �6(   �� 5P      $
��Auto �6(   �� 5Q      $��5 �6(   �� 5R      $
��Auto �6(   �� 5S      $
��Auto �6(   �� 5T      $��5 �6(   �� 5U      $
��Auto �6(   �� 5V      $
��Auto �6(   .+�5X      �� $��0��6   $
��Left=�6)   #��[ 6D     m_playerSettingParamID#���  6m   #���  6�   $��14(�6�   % 	 Xceed.Wpf.Toolkit.IntegerUpDown  5Y      $��1��6)   $��30��66   #��[ 6r   #���  6�   #��� 
 6�   $��1q�6  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 16/  � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 655356=     Minimum 06M  #���  6Y     Value 6E   �� *PlayerSettingParamID_field+6Y  �� 5Z      $��3��6   $��0��6)   $
��Left=�69   $��Center=�6T   #��[ 6p    $  m_costumBreakColorParamAltColor1#���  6�   #���  6�   $��14(�6  # 	 Xceed.Wpf.Toolkit.ColorPicker  5[      $��4��6'   $��30��64   $��0��6C   
���   �#��[ 6f   #���  6�   #��� 
 6�   $��1q�6     SelectedColor 6"  �� *AltColor1_field+$ TwoWay=� �� 	Converter# [ �� 5\      $��6��6   $��0��6)   $
��Left=�69   $��Center=�6T   #��[ 6p    $  m_costumBreakColorParamAltColor2#���  6�   #���  6�   $��14(�6    5]      $��7��6'   $��30��64   $��0��6C   
���   �#��[ 6f   #���  6�   #��� 
 6�   $��1q�6   6"  �� *AltColor2_field+$ TwoWay=�# [ �� 5^      $��9��6   $��0��6)   $
��Left=�69   $��Center=�6T   #��[ 6p    $  m_costumBreakColorParamAltColor3#���  6�   #���  6�   $��14(�6    5_      $��10��6'   $��30��65   $��0��6D   
���   �#��[ 6g   #���  6�   #��� 
 6�   $��1q�6   6#  �� *AltColor3_field+$ TwoWay=�# [ �� 5`      $��12��6   $��0��6*   $
��Left=�6:   $��Center=�6U   #��[ 6q    $  m_costumBreakColorParamAltColor4#���  6�   #���  6�   $��14(�6    5a      $��13��6'   $��30��65   $��0��6D   
���   �#��[ 6g   #���  6�   #��� 
 6�   $��1q�6   6#  �� *AltColor4_field+$ TwoWay=�# [ 5c      � 5d      $��1��6   $��3��6'   $��2��64    5e      �� 5f      $��* �6+   �� 5g      $��* �6+    5i      �� 5j      $��* �6(   �� 5k      $��* �6(   .+�5m      �� $��0��6D     m_AddDupEntry#���  6T   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_2#���  6�   #��� 
 6�   #��[ 69  #���  6b  $��16(�6�  ��6   �� *AddDupEntryCommand+6�  �� 5n        m_DeleteEntry#���  6D   $��1��6o   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_3#���  6�   #��� 
 6�   #��[ 69  #���  6b  $��16(�6�  ��6   �� *DeleteEntryCommand+6�  �� 5o        m_SearchEntry#���  6D   $��2��6n   $��1��6|   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 
 6  #��[ 6F  #���  6o  $��16(�6�  ��6   �� *SearchEntryCommand+6�    5p      $��1��6)   $��30��66   #��[ 6i   #���  6�   #��� 
 6�   $��1q�6   16&  	 6553564   06D  #���  6P   6E   �� *SearchIndex_field+6P  5r      �� 5s      $��4��6?   $��3��6L     m_SaveEntry#���  6\   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 
 6   #��[ 6>  #���  6g  $��16(�6�  ��6   �� *SaveEntryCommand+6�  5u      5v      5w      5x      