   M S B A M L   `   `   `  ����F  BNSC-Toolbox, Version=1.6.3.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  5   	   =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  5   	   ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  5   8   ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  5   	   *    $NSC_Toolbox.View.DamageEffEditorView   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NSC_Toolbox.View     5   	   9	converter#clr-namespace:NSC_Toolbox.Converter     5   	   D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5   	   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5	   	   5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5
   	   U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 5   	   1Controls"clr-namespace:NSC_Toolbox.Controls 
 68   5
properties$clr-namespace:NSC_Toolbox.Properties 
 5   	   $	��750��5   
   $	��650��6   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��5   	      m_damageEffEditor � Title# �   5   	   ��5      �� 5   
     TitleBackground �� ImageSource# �  6    j� ViewboxUnits$ RelativeToBoundingBox=�6Q    j� ViewportUnits$ RelativeToBoundingBox=�6v    j� Stretch$ UniformToFill=�6�    � 	Resources 5      /  )NSC_Toolbox.Converter.SoundIndexConverter  SoundIndexConverter��%   &	         5   
   6(   5      .��5      (�  (� Stretch 6   �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��5   
   � $	��750��6   $	��650��6    % !Toolbox_button_background_color_1#���  6(    � ColumnDefinitions 5      �� 5      $��5 �6#   �� 5      $��* �6#   �� 5      $��5 �6#    � RowDefinitions 5      �� 5       $��50 �6    �� 5!      $��* �6    �� 5"      $��5 �6    .+�5$      o� $��0��6   $��5��6#   $��Stretch=�67   $��Stretch=�6U     
NarutoFont#��[ 6q     Toolbox_button_text_color_1#���  6�   .@�5%      m�  
 m_File#���  6   #��[ 6=   #���  6f   .@�5&      m�   
m_OpenFile#���  6C   #��[ 6i   #���  6�    m� Command 6   �� *OpenFileCommand+6�   m� 5'        
m_SaveFile#���  6C   #��[ 6i   #���  6�    6   �� *SaveFileCommand+6�   m� 5(       	 m_SaveAsFile#��� 	 6E   #��[ 6m   #���  6�    6   �� *SaveFileAsCommand+6�   5)      5*      � 5+      $��1��6   $��1��6     5,      �� 5-      $��5 �6'   �� 5.      $��* �6'   �� 5/      $��5 �6'   �� 50      $��* �6'   �� 51      $��5 �6'    53      �� 54      $��5 �6$   �� 55      $��* �6$   �� 56      $��5 �6$   �� 57      $��50 �6$   �� 58      $��50 �6$   �� 59      $��5 �6$   .+�5;      )clr-namespace:NSC_ToolboxNSC_Toolbox  6_  �� 6   -WpfExtensionsclr-namespace:NSC_Toolbox 
 6_  -   5        $ �� IsSynchronizedWithCurrentItem$
 TrueY�5;      $��1��6�   $��1��6�   #���  6
   !
 Toolbox_button_border_color_1#��� 
 6K  $��1q�6�  $��Stretch=�6�  $��Stretch=�6�   J� 	AllowDrop$
 True��6N  #   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True��6�  ��6j   �� *DamageEffList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *SelectedDamageEff+ �� SelectedIndex 6�  �� *SelectedDamageEffIndex+��5<      �� 5=      .R�5>      ��  �� Orientation$ 
Horizontal=�6)   .+�5?   "   �� $
��ID: ��6,   #��[ 68   
��� ���$��16(�6u   �� 5@   "   #��[ 6{   #���  6�   $��16(�6�   ��6,   �� *DamageEffID+$ OneWay=�$ PropertyChanged=�6�   �� 5A   "   $��	 Effect: ��6,   #��[ 6=   
��� ���$��16(�6z   �� 5B   "   #��[ 6{   #���  6�   $��16(�6�   ��6,   �� *EffectPrmID+$ OneWay=�$ PropertyChanged=�6�   �� 5C   "   $�� Sound: ��6,   #��[ 6<   
��� ���$��16(�6y   �� 5D   "   #��[ 6u   #���  6�   $��16(�6�   ��6,   �� *	SoundID+ �� 	Converter# [ 6�   5E   #   5F      5H      � 5I      $��1��6   $��3��6$   $��3��64    5J      �� 5K      $
��Auto �6(   �� 5L      $
��Auto �6(   �� 5M      $��5 �6(   �� 5N      $
��Auto �6(   �� 5O      $
��Auto �6(   �� 5P      $��5 �6(   �� 5Q      $
��Auto �6(   �� 5R      $
��Auto �6(   �� 5S      $��5 �6(   �� 5T      $
��Auto �6(   �� 5U      $
��Auto �6(   �� 5V      $��5 �6(   �� 5W      $
��Auto �6(   �� 5X      $
��Auto �6(   �� 5Y      $��5 �6(   �� 5Z      $
��Auto �6(   �� 5[      $
��Auto �6(   �� 5\      $��5 �6(   �� 5]      $
��Auto �6(   �� 5^      $
��Auto �6(   �� 5_      $��5 �6(   �� 5`      $
��Auto �6(   �� 5a      $
��Auto �6(   �� 5b      $��5 �6(   .+�5d      �� $��0��6   $
��Left=�6)   #��[ 6D     m_damageEffEditorID#���  6m   #���  6�   $��14(�6�   % 	 Xceed.Wpf.Toolkit.IntegerUpDown  5e      $��1��6)   $��30��66   #��[ 6i   #���  6�   #��� 
 6�   $��1q�6  � 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 16&  � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 6553564     Minimum 06D  #���  6P     Value 6E   �� *DamageEffID_field+6P  �� 5f      $��3��6   $
��Left=�6)   #��[ 6D     m_damageEffEditorExtraID#���  6m   #���  6�   $��14(�6�     5g      $��4��6)   $��30��66   #��[ 6n   #���  6�   #��� 
 6�   $��1q�6   16+  	 6553569   06I  #���  6U   6E   �� *ExtraDamageEffID_field+6U  �� 5h      $��6��6   $
��Left=�6)   #��[ 6D      m_damageEffEditorEffectPrmID#���  6m   #���  6�   $��14(�6�     5i      $��7��6)   $��30��66   #��[ 6i   #���  6�   #��� 
 6�   $��1q�6   16&  	 6553564   06D  #���  6P   6E   �� *EffectPrmID_field+6P  �� 5j      $��9��6   $
��Left=�6)   #��[ 6D    % !m_damageEffEditorExtraEffectPrmID#���  6m   #���  6�   $��14(�6�     5k      $��10��6)   $��30��67   #��[ 6o   #���  6�   #��� 
 6�   $��1q�6   16,  	 655356:   06J  #���  6V   6F   �� *ExtraEffectPrmID_field+6V  �� 5l      $��12��6   $
��Left=�6*   #��[ 6E     m_damageEffEditorSoundID#���  6n   #���  6�   $��14(�6�   �� 5m      $��0��6   $��13��6/   #���  6�   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6'  #��� 
 6h  $��1q�6�  ��6=   �� *Sound1_List+ 6a   �� *SoundID_field+6�  �� 5n      $��15��6   $
��Left=�6*   #��[ 6E    ! m_damageEffEditorExtraSoundID#���  6n   #���  6�   $��14(�6�   �� 5o      $��0��6   $��16��6/   #���  6�   $��Stretch=�6�   $��Stretch=�6�   #��[ 6  #���  6,  #��� 
 6m  $��1q�6�  ��6=   �� *Sound2_List+ 6a   �� *ExtraSoundID_field+6�  �� 5p      $��18��6   $
��Left=�6*   #��[ 6E     	m_unknown#���  6n   #���  6�   $��14(�6�     5q      $��19��6)   $��30��67   #��[ 6c   #���  6�   #��� 
 6�   $��1q�6   16   	 655356.   06>  #���  6J   6F   �� *
Unk1_field+6J  �� 5r      $��21��6   $
��Left=�6*   #��[ 6E   #���  6n   #���  6�   $��14(�6�     5s      $��22��6)   $��30��67   #��[ 6c   #���  6�   #��� 
 6�   $��1q�6   16   	 655356.   06>  #���  6J   6F   �� *
Unk2_field+6J  5u      � 5v      $��1��6   $��3��6'   $��2��64    5w      �� 5x      $��* �6+   �� 5y      $��* �6+    5{      �� 5|      $��* �6(   �� 5}      $��* �6(   .+�5      �� $��0��6D     m_AddDupEntry#���  6T   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_2#���  6�   #��� 
 6�   #��[ 69  #���  6b  $��16(�6�  ��6   �� *AddDupEntryCommand+6�  �� 5�        m_DeleteEntry#���  6D   $��1��6o   $��Stretch=�6   $��Stretch=�6�    % !Toolbox_button_background_color_3#���  6�   #��� 
 6�   #��[ 69  #���  6b  $��16(�6�  ��6   �� *DeleteEntryCommand+6�  �� 5�        m_SearchEntry#���  6D   $��2��6n   $��1��6|   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 
 6  #��[ 6F  #���  6o  $��16(�6�  ��6   �� *SearchEntryCommand+6�    5�      $��1��6)   $��30��66   #��[ 6i   #���  6�   #��� 
 6�   $��1q�6   16&  	 6553564   06D  #���  6P   6E   �� *SearchIndex_field+6P  5�      �� 5�      $��4��6?   $��3��6L     m_SaveEntry#���  6\   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #��� 
 6   #��[ 6>  #���  6g  $��16(�6�  ��6   �� *SaveEntryCommand+6�  5�      5�      5�      5�      