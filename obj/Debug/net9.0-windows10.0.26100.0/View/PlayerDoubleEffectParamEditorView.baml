   M S B A M L   `   `   `  ����F  BNSC-Toolbox, Version=1.6.5.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  5   	   =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  5   	   ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  5   8   ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  5   	   8    2NSC_Toolbox.View.PlayerDoubleEffectParamEditorView   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NSC_Toolbox.View     5   	   9	converter#clr-namespace:NSC_Toolbox.Converter     5   	   D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5	   	   5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5
   	   U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 5   	   1Controls"clr-namespace:NSC_Toolbox.Controls 
 68   5
properties$clr-namespace:NSC_Toolbox.Properties 
 5   	   $	��850��5   	   $	��850��6   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��5   	    #  m_playerDoubleEffectParamEditor � Title# �   5   	   ��5      �� 5   
     TitleBackground �� ImageSource# �  6    j� ViewboxUnits$ RelativeToBoundingBox=�6Q    j� ViewportUnits$ RelativeToBoundingBox=�6v    j� Stretch$ UniformToFill=�6�   .��5      (�  (� Stretch 6   �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z 	 �� Path$	 StretchMode�.��5   
   � $	��850��6   $	��850��6    % !Toolbox_button_background_color_1#���  6(   
 � ColumnDefinitions
 5      �� 5      $��5 �6#   �� 5      $��* �6#   �� 5      $��5 �6#    � RowDefinitions 5      �� 5      $��50 �6    �� 5      $��* �6    �� 5      $��5 �6    .+�5       o� $��0��6   $��5��6#   $��Stretch=�67   $��Stretch=�6U     
NarutoFont#��[ 6q     Toolbox_button_text_color_1#���  6�   .@�5!      m�  
 m_File#���  6   #��[ 6=   #���  6f   .@�5"      m�   
m_OpenFile#���  6C   #��[ 6i   #���  6�    m� Command 6   �� *OpenFileCommand+6�   m� 5#        
m_SaveFile#���  6C   #��[ 6i   #���  6�    6   �� *SaveFileCommand+6�   m� 5$        m_SaveAsFile#���  6E   #��[ 6m   #���  6�    6   �� *SaveFileAsCommand+6�   5%      5&      � 5'      $��1��6   $��1��6    
 5(      �� 5)      $��5 �6'   �� 5*      $��* �6'   �� 5+      $��5 �6'   �� 5,      $��* �6'   �� 5-      $��5 �6'    5/      �� 50      $��5 �6$   �� 51      $��* �6$   �� 52      $��5 �6$   �� 53      $��50 �6$   �� 54      $��50 �6$   �� 55      $��5 �6$   .+�57      )clr-namespace:NSC_ToolboxNSC_Toolbox  6�  �� 6   -WpfExtensionsclr-namespace:NSC_Toolbox 
 6�  -   5        $ �� IsSynchronizedWithCurrentItem$
 TrueY�57      $��1��6	  $��1��6  #���  6&   !	 Toolbox_button_border_color_1#��� 	 6g  $��1q�6�  $��Stretch=�6�  $��Stretch=�6�   J� 	AllowDrop$
 True��6x  #   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True��6�  ��6j   �� *PlayerDoubleEffectParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *!SelectedPlayerDoubleEffectParam+ �� SelectedIndex 6�  �� *&$SelectedPlayerDoubleEffectParamIndex+��58      �� 59      .R�5:      ��  �� Orientation$ 
Horizontal=�6)   .+�5;   "   �� $��Characode ID: ��6,   #��[ 6B   
��� ���$��16(�6   �� 5<   "   #��[ 6{   #���  6�   $��16(�6�   ��6,   �� *CharacodeID+$ OneWay=�$ PropertyChanged=�6�   �� 5=   "   $�� Bone: ��6,   #��[ 6;   
��� ���$��16(�6x   �� 5>   "   #��[ 6z   #���  6�   $��16(�6�   ��6,   �� *
AttachBone+$ OneWay=�$ PropertyChanged=�6�   �� 5?   "   $�� Sound: ��6,   #��[ 6<   
��� ���$��16(�6y   �� 5@   "   #��[ 6E   #���  6n   $��16(�6�   ��6,   �� *	SoundID+6�   5A      5B      5D      � 5E      $��1��6   $��3��6$   $��3��64   #���  6E    5F      �� 5G      $��5 �6(   �� 5H      $��* �6(   �� 5I      $��5 �6(   
 5K      �� 5L      $��5 �6+   �� 5M      $��* �6+   �� 5N      $��5 �6+   .+�5P      �� 
�������$��1,1,1,0q�61   $��10��6K   $��10��6]   � 5Q      $��1��6   $��1��6(    5R      �� 5S      $
��Auto �6,   �� 5T      $
��Auto �6,   �� 5U      $��5 �6,   �� 5V      $
��Auto �6,   �� 5W      $
��Auto �6,   �� 5X      $��5 �6,   �� 5Y      $
��Auto �6,   �� 5Z      $
��Auto �6,   �� 5[      $��5 �6,   �� 5\      $
��Auto �6,   �� 5]      $
��Auto �6,   �� 5^      $��5 �6,   �� 5_      $
��Auto �6,   �� 5`      $
��Auto �6,   �� 5a      $��5 �6,   �� 5b      $
��Auto �6,   �� 5c      $
��Auto �6,   �� 5d      $��5 �6,   �� 5e      $
��Auto �6,   �� 5f      $
��Auto �6,   �� 5g      $��5 �6,   �� 5h      $
��Auto �6,   �� 5i      $
��Auto �6,   �� 5j      $��5 �6,   �� 5k      $
��Auto �6,   �� 5l      $
��Auto �6,   �� 5m      $��5 �6,   �� 5n      $
��Auto �6,   �� 5o      $
��Auto �6,   �� 5p      $��5 �6,   �� 5q      $
��Auto �6,   �� 5r      $
��Auto �6,   �� 5s      $��5 �6,   �� 5t      $
��Auto �6,   �� 5u      $
��Auto �6,   �� 5v      $��5 �6,   �� 5w      $
��Auto �6,   �� 5x      $��5 �6,   �� 5y      $
��Auto �6,   �� 5z      $��5 �6,   �� 5{      $
��Auto �6,   �� 5|      $��5 �6,   
 5~      �� 5      $��* �6/   �� 5�      $��5 �6/   �� 5�      $��* �6/   .+�5�      �� $��0��6    $
��Left=�6-   $��3��6H   #��[ 6\    
 m_Characode#��� 
 6�   #���  6�   $��14(�6�   % 	 Xceed.Wpf.Toolkit.IntegerUpDown  5�      $��1��6-   $��30��6:   $��3��6I   #��[ 6�   #���  6�   #��� 	 6�   $��1q�6*  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 16>  � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 655356L     Minimum 06\  #���  6h     Value 6]   �� *CharacodeID_field+6h  �� 5�      $��3��6    $��3��6-   $
��Left=�6A   #��[ 6\    - )m_playerDoubleEffectParamEditorAttachBone#���  6�   #���  6�   $��14(�6  �� 5�      $��4��6#   $��3��60   #���  6f   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #��� 	 6E  $��1q�6�  ��6D   �� *AttachBone_field+6�  �� 5�      $��6��6    $��3��6-   $
��Left=�6A   #��[ 6\    . *m_playerDoubleEffectParamEditorEffectEntry#���  6�   #���  6�   $��14(�6  �� 5�      $��7��6#   $��3��60   #���  6g   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #��� 	 6F  $��1q�6�  ��6D   �� *EffectEntry_field+6�  �� 5�      $��9��6    $��3��6-   $
��Left=�6A   #��[ 6\    ) %m_playerDoubleEffectParamEditorPlAnm1#���  6�   #���  6�   $��14(�6  �� 5�      $��10��6"   $��3��60   #���  6g   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #��� 	 6F  $��1q�6�  ��6D   �� *PlAnmEntry1_field+6�  �� 5�      $��12��6    $��3��6.   $
��Left=�6B   #��[ 6]    ) %m_playerDoubleEffectParamEditorPlAnm2#���  6�   #���  6�   $��14(�6  �� 5�      $��13��6"   $��3��60   #���  6g   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #��� 	 6F  $��1q�6�  ��6D   �� *PlAnmEntry2_field+6�  �� 5�      $��15��6    $��3��6.   $
��Left=�6B   #��[ 6]    ) %m_playerDoubleEffectParamEditorPlAnm3#���  6�   #���  6�   $��14(�6  �� 5�      $��16��6"   $��3��60   #���  6g   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #��� 	 6F  $��1q�6�  ��6D   �� *PlAnmEntry3_field+6�  �� 5�      $��18��6    $��3��6.   $
��Left=�6B   #��[ 6]    ) %m_playerDoubleEffectParamEditorPlAnm4#���  6�   #���  6�   $��14(�6  �� 5�      $��19��6"   $��3��60   #���  6g   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #��� 	 6F  $��1q�6�  ��6D   �� *PlAnmEntry4_field+6�  �� 5�      $��21��6    $��3��6.   $
��Left=�6B   #��[ 6]    ) %m_playerDoubleEffectParamEditorPlAnm5#���  6�   #���  6�   $��14(�6  �� 5�      $��22��6"   $��3��60   #���  6g   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #��� 	 6F  $��1q�6�  ��6D   �� *PlAnmEntry5_field+6�  �� 5�      $��24��6    $��3��6.   $
��Left=�6B   #��[ 6]    . *m_playerDoubleEffectParamEditorHeightSpawn#���  6�   #���  6�   $��14(�6  $ 	 Xceed.Wpf.Toolkit.DoubleUpDown  5�      $��3��6,   $��25��6@   $��30��6N   #��[ 6�   #���  6�   #��� 	 6�   $��1q�6*  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 16>  #���  6L  �	 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] 	  Value 6]   �� *HeightSpawn_field+6L  �� 5�      $��27��6    $��3��6.   $
��Left=�6B   #��[ 6]     	m_unknown#���  6�   #���  6�   $��14(�6�     5�      $��3��6,   $��28��6@   $��30��6N   #��[ 6z   #���  6�   #��� 	 6�   $��1q�6#   167  #���  6E   6]   �� *
Unk2_field+6E  �� 5�      $��30��6    $��3��6.   $
��Left=�6B   #��[ 6]    * &m_playerDoubleEffectParamEditorSoundID#���  6�   #���  6�   $��14(�6  �� 5�      $��0��6#   $��31��63   $��3��6A   #���  6�   $��Stretch=�6�   $��Stretch=�6�   #��[ 6  #���  6>  #��� 	 6  $��1q�6�  ��6U   �� *
Sound_List+ 6x   �� *SoundID_field+6�  �� 5�      $��33��6    $
��Left=�6.   #��[ 6I   #���  6r   #���  6�   $��14(�6�     5�      $��34��6-   $��30��6;   #��[ 6g   #���  6�   #��� 	 6�   $��1q�6   16$  	 6553562   -16B  #���  6O   6J   �� *
Unk1_field+6O  �� 5�      $��33��6    $��2��6.   $
��Left=�6>   #��[ 6Y   #���  6�   #���  6�   $��14(�6�     5�      $��2��6-   $��34��6=   $��30��6K   #��[ 6w   #���  6�   #��� 	 6�   $��1q�6    164  	 655356B   -16R  #���  6_   6Z   �� *
Unk4_field+6_  �� 5�      $��36��6%   $ 
Horizontal=�63   $��3��6L   .+�5�      �� $��Center=�6'   $
��Left=�6I    d� 	IsChecked 6e   �� *PlayAtStart_field+.��5�   "   ��  . *m_playerDoubleEffectParamEditorPlayAtStart#��[ 6,   #���  6p   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��14(�6  5�      �� 5�      $��Center=�6'   $
��Left=�6I    6e   �� *PlayAtEnd_field+.��5�   "   ��  , (m_playerDoubleEffectParamEditorPlayAtEnd#��[ 6,   #���  6n   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��14(�6  5�      5�      �� 5�      $��3��6#   $��38��67   $��Center=�6F   $
��Left=�6h    6�   �� *EnableNearestGroundPos_field+.��5�      ��  8 4m_playerDoubleEffectParamEditorNearestGroundPosition#��[ 6(   #���  6v   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��14(�6  5�      �� 5�      $��3��6#   $��40��67   $��Center=�6F   $
��Left=�6h    6�   �� *
Unk3_field+.��5�      �� #��[ 6(   #���  6K   $��Center=�6�   $��Stretch=�6�   #��[ 6�   $��14(�6�   5�      5�      5�      � 5�      $��1��6   $��3��6'   $��2��64   
 5�      �� 5�      $��* �6+   �� 5�      $��* �6+    5�      �� 5�      $��* �6(   �� 5�      $��* �6(   .+�5�      �� $��0��6D     m_AddDupEntry#���  6T   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_2#���  6�   #��� 	 6�   #��[ 69  #���  6b  $��16(�6�  ��6   �� *AddDupEntryCommand+6�  �� 5�        m_DeleteEntry#���  6D   $��1��6o   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_3#���  6�   #��� 	 6�   #��[ 69  #���  6b  $��16(�6�  ��6   �� *DeleteEntryCommand+6�  �� 5�        m_SearchEntry#���  6D   $��2��6n   $��1��6|   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 	 6  #��[ 6F  #���  6o  $��16(�6�  ��6   �� *SearchEntryCommand+6�    5�      $��1��6)   $��30��66   #��[ 6i   #���  6�   #��� 	 6�   $��1q�6   16&  	 6553564   06D  #���  6P   6E   �� *SearchIndex_field+6P  5�      �� 5�      $��4��6?   $��3��6L     m_SaveEntry#���  6\   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 	 6   #��[ 6>  #���  6g  $��16(�6�  ��6   �� *SaveEntryCommand+6�  5�      5�      5�      5�      