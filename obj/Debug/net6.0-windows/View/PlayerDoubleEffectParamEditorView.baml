   M S B A M L   `   `   `  ����F  BNSC-Toolbox, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  5   	   =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  5   	   ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  5   8   ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  5   	   8    2NSC_Toolbox.View.PlayerDoubleEffectParamEditorView   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NSC_Toolbox.View     5   	   9	converter#clr-namespace:NSC_Toolbox.Converter     5   	   D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5	   	   5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5
   	   U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 5   	   1Controls"clr-namespace:NSC_Toolbox.Controls 
 68   5
properties$clr-namespace:NSC_Toolbox.Properties 
 5   	   $	��850��5   	   $	��850��6   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��5   	    #  m_playerDoubleEffectParamEditor � Title# �   5   	   ��5      �� 5   
     TitleBackground �� ImageSource# �  6    j� ViewboxUnits$ RelativeToBoundingBox=�6Q    j� ViewportUnits$ RelativeToBoundingBox=�6v    j� Stretch$ UniformToFill=�6�   .��5      (�  (� Stretch 6   �� %  NSC_Toolbox.Properties.Settings   Default �� Source# Z 	 �� Path$	 StretchMode�.��5   
   � $	��850��6   $	��850��6   
 � ColumnDefinitions
 5      �� 5      $��5 �6#   �� 5      $��* �6#   �� 5      $��5 �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��5 �6    .+�5       o� $��0��6   $��5��6#   $��Stretch=�67   $��Stretch=�6U     
NarutoFont#��[ 6q     Toolbox_button_text_color_1#���  6�   .@�5!      m�  
 m_File#���  6   #��[ 6=   #���  6f   .@�5"      m�   
m_OpenFile#���  6C   #��[ 6i   #���  6�    m� Command 6   �� *OpenFileCommand+6�   m� 5#        
m_SaveFile#���  6C   #��[ 6i   #���  6�    6   �� *SaveFileCommand+6�   m� 5$        m_SaveAsFile#���  6E   #��[ 6m   #���  6�    6   �� *SaveFileAsCommand+6�   5%      5&      � 5'      $��1��6   $��1��6    
 5(      �� 5)      $��5 �6'   �� 5*      $��* �6'   �� 5+      $��5 �6'   �� 5,      $��* �6'   �� 5-      $��5 �6'    5/      �� 50      $��5 �6$   �� 51      $��* �6$   �� 52      $��5 �6$   �� 53      $��50 �6$   �� 54      $��50 �6$   �� 55      $��5 �6$   .+�57      )clr-namespace:NSC_ToolboxNSC_Toolbox  6�  �� 6   -WpfExtensionsclr-namespace:NSC_Toolbox 
 6�  -   5        $ �� IsSynchronizedWithCurrentItem$
 TrueY�57      $��1��6	  $��1��6   % !Toolbox_button_background_color_1#���  6&   !	 Toolbox_button_border_color_1#��� 	 6g  $��1q�6�  $��Stretch=�6�  $��Stretch=�6�   J� 	AllowDrop$
 True��6x  #   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True��6�  ��6j   �� *PlayerDoubleEffectParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *!SelectedPlayerDoubleEffectParam+ �� SelectedIndex 6�  �� *&$SelectedPlayerDoubleEffectParamIndex+��58      �� 59      .R�5:      ��  �� Orientation$ 
Horizontal=�6)   .+�5;   "   �� $��Characode ID: ��6,   #��[ 6B   
��� ���$��12(�6   �� 5<   "   #��[ 6{   #���  6�   $��12(�6�   ��6,   �� *CharacodeID+$ OneWay=�$ PropertyChanged=�6�   �� 5=   "   $�� Bone: ��6,   #��[ 6;   
��� ���$��12(�6x   �� 5>   "   #��[ 6z   #���  6�   $��12(�6�   ��6,   �� *
AttachBone+$ OneWay=�$ PropertyChanged=�6�   5?      5@      5B      � 5C      $��1��6   $��3��6$   $��3��64   #���  6E    5D      �� 5E      $��5 �6(   �� 5F      $��* �6(   �� 5G      $��5 �6(   
 5I      �� 5J      $��5 �6+   �� 5K      $��* �6+   �� 5L      $��5 �6+   .+�5N      �� 
�������$��1,1,1,0q�61   $��10��6K   $��10��6]   � 5O      $��1��6   $��1��6(    5P      �� 5Q      $
��Auto �6,   �� 5R      $
��Auto �6,   �� 5S      $��5 �6,   �� 5T      $
��Auto �6,   �� 5U      $
��Auto �6,   �� 5V      $��5 �6,   �� 5W      $
��Auto �6,   �� 5X      $
��Auto �6,   �� 5Y      $��5 �6,   �� 5Z      $
��Auto �6,   �� 5[      $
��Auto �6,   �� 5\      $��5 �6,   �� 5]      $
��Auto �6,   �� 5^      $
��Auto �6,   �� 5_      $��5 �6,   �� 5`      $
��Auto �6,   �� 5a      $
��Auto �6,   �� 5b      $��5 �6,   �� 5c      $
��Auto �6,   �� 5d      $
��Auto �6,   �� 5e      $��5 �6,   �� 5f      $
��Auto �6,   �� 5g      $
��Auto �6,   �� 5h      $��5 �6,   �� 5i      $
��Auto �6,   �� 5j      $
��Auto �6,   �� 5k      $��5 �6,   �� 5l      $
��Auto �6,   �� 5m      $
��Auto �6,   �� 5n      $��5 �6,   �� 5o      $
��Auto �6,   �� 5p      $
��Auto �6,   �� 5q      $��5 �6,   �� 5r      $
��Auto �6,   �� 5s      $
��Auto �6,   �� 5t      $��5 �6,   �� 5u      $
��Auto �6,   �� 5v      $��5 �6,   �� 5w      $
��Auto �6,   �� 5x      $��5 �6,   �� 5y      $
��Auto �6,   �� 5z      $��5 �6,   .+�5|      �� $��0��6    $
��Left=�6-   #��[ 6H    
 m_Characode#��� 
 6q   #���  6�   $��10(�6�   % 	 Xceed.Wpf.Toolkit.IntegerUpDown  5}      $��1��6-   $��30��6:   #��[ 6m   #���  6�   #��� 	 6�   $��1q�6  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 16*  � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 6553568     Minimum 06H  #���  6T     Value 6I   �� *CharacodeID_field+6T  �� 5~      $��3��6    $
��Left=�6-   #��[ 6H    - )m_playerDoubleEffectParamEditorAttachBone#���  6q   #���  6�   $��10(�6�   �� 5      $��4��6#   #���  6R   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6�   #��� 	 61  $��1q�6o  ��60   �� *AttachBone_field+6o  �� 5�      $��6��6    $
��Left=�6-   #��[ 6H    . *m_playerDoubleEffectParamEditorEffectEntry#���  6q   #���  6�   $��10(�6�   �� 5�      $��7��6#   #���  6S   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6�   #��� 	 62  $��1q�6p  ��60   �� *EffectEntry_field+6p  �� 5�      $��9��6    $
��Left=�6-   #��[ 6H    ) %m_playerDoubleEffectParamEditorPlAnm1#���  6q   #���  6�   $��10(�6�   �� 5�      $��10��6"   #���  6S   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6�   #��� 	 62  $��1q�6p  ��60   �� *PlAnmEntry1_field+6p  �� 5�      $��12��6    $
��Left=�6.   #��[ 6I    ) %m_playerDoubleEffectParamEditorPlAnm2#���  6r   #���  6�   $��10(�6�   �� 5�      $��13��6"   #���  6S   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6�   #��� 	 62  $��1q�6p  ��60   �� *PlAnmEntry2_field+6p  �� 5�      $��15��6    $
��Left=�6.   #��[ 6I    ) %m_playerDoubleEffectParamEditorPlAnm3#���  6r   #���  6�   $��10(�6�   �� 5�      $��16��6"   #���  6S   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6�   #��� 	 62  $��1q�6p  ��60   �� *PlAnmEntry3_field+6p  �� 5�      $��18��6    $
��Left=�6.   #��[ 6I    ) %m_playerDoubleEffectParamEditorPlAnm4#���  6r   #���  6�   $��10(�6�   �� 5�      $��19��6"   #���  6S   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6�   #��� 	 62  $��1q�6p  ��60   �� *PlAnmEntry4_field+6p  �� 5�      $��21��6    $
��Left=�6.   #��[ 6I    ) %m_playerDoubleEffectParamEditorPlAnm5#���  6r   #���  6�   $��10(�6�   �� 5�      $��22��6"   #���  6S   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6�   #��� 	 62  $��1q�6p  ��60   �� *PlAnmEntry5_field+6p  �� 5�      $��24��6    $
��Left=�6.   #��[ 6I    . *m_playerDoubleEffectParamEditorHeightSpawn#���  6r   #���  6�   $��10(�6�   $ 	 Xceed.Wpf.Toolkit.DoubleUpDown  5�      $��25��6,   $��30��6:   #��[ 6m   #���  6�   #��� 	 6�   $��1q�6  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 16*  #���  68  �	 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] 	  Value 6I   �� *HeightSpawn_field+68  �� 5�      $��27��6    $
��Left=�6.   #��[ 6I     	m_unknown#���  6r   #���  6�   $��10(�6�     5�      $��28��6,   $��30��6:   #��[ 6f   #���  6�   #��� 	 6�   $��1q�6   16#  #���  61   6I   �� *
Unk2_field+61  �� 5�      $��30��6    $
��Left=�6.   #��[ 6I    * &m_playerDoubleEffectParamEditorSoundID#���  6r   #���  6�   $��10(�6�     5�      $��31��6-   $��30��6;   #��[ 6j   #���  6�   #��� 	 6�   $��1q�6   16'  	 6553565   -16E  #���  6R   6J   �� *SoundID_field+6R  �� 5�      $��33��6    $
��Left=�6.   #��[ 6I   #���  6r   #���  6�   $��10(�6�     5�      $��34��6-   $��30��6;   #��[ 6g   #���  6�   #��� 	 6�   $��1q�6   16$  	 6553562   -16B  #���  6O   6J   �� *
Unk1_field+6O  �� 5�      $��36��6%   $ 
Horizontal=�63   .+�5�      �� $��Center=�6'   $
��Left=�6I    d� 	IsChecked 6e   �� *PlayAtStart_field+.��5�   "   ��  . *m_playerDoubleEffectParamEditorPlayAtStart#��[ 6,   #���  6p   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��10(�6  5�      �� 5�      $��Center=�6'   $
��Left=�6I    6e   �� *PlayAtEnd_field+.��5�   "   ��  , (m_playerDoubleEffectParamEditorPlayAtEnd#��[ 6,   #���  6n   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��10(�6  5�      5�      �� 5�      $��38��6#   $��Center=�62   $
��Left=�6T    6p   �� *EnableNearestGroundPos_field+.��5�      ��  8 4m_playerDoubleEffectParamEditorNearestGroundPosition#��[ 6(   #���  6v   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��10(�6  5�      �� 5�      $��40��6#   $��Center=�62   $
��Left=�6T    6p   �� *
Unk3_field+.��5�      �� #��[ 6(   #���  6K   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��10(�6�   5�      5�      5�      � 5�      $��1��6   $��3��6'   $��2��64   
 5�      �� 5�      $��* �6+   �� 5�      $��* �6+    5�      �� 5�      $��* �6(   �� 5�      $��* �6(   .+�5�      �� $��0��6D     m_AddDupEntry#���  6T   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_2#���  6�   #��� 	 6�   #��[ 69  #���  6b  $��12(�6�  ��6   �� *AddDupEntryCommand+6�  �� 5�        m_DeleteEntry#���  6D   $��1��6o   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_3#���  6�   #��� 	 6�   #��[ 69  #���  6b  $��12(�6�  ��6   �� *DeleteEntryCommand+6�  �� 5�        m_SearchEntry#���  6D   $��2��6n   $��1��6|   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 	 6  #��[ 6F  #���  6o  $��12(�6�  ��6   �� *SearchEntryCommand+6�    5�      $��1��6)   $��30��66   #��[ 6i   #���  6�   #��� 	 6�   $��1q�6   16&  	 6553564   06D  #���  6P   6E   �� *SearchIndex_field+6P  5�      �� 5�      $��4��6?   $��3��6L     m_SaveEntry#���  6\   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 	 6   #��[ 6>  #���  6g  $��12(�6�  ��6   �� *SaveEntryCommand+6�  5�      5�      5�      5�      