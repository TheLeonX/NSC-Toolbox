   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  .    (NSC_Toolbox.View.AppearanceAnmEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $	��950��$	��770��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_appearanceAnmEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z 	 �� Path$	 StretchMode�.��� $	��950��$	��770��
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
 True������ *AppearanceAnmList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedAppearanceAnm+ �� SelectedIndex �� *SelectedAppearanceAnmIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��Characode ID: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *CharacodeID+$ OneWay=�$ PropertyChanged=��� $�� Chunk: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *	ChunkName+$ OneWay=�$ PropertyChanged=�� $��3��$��1��$��3��#���  
 �� $��5 ��� $��* ��� $��5 � �� $��5 ��� $��* ��� $��5 �.+��� 
�������$��1,1,1,0q�$��10��$��10��� $��1��$��1�� �� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 �
 �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* �.+��� $��0��$
��Left=�#��[  
 m_Characode#��� 
 #���  $��10(�% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��1��$��30��$��7��#��[ #���  #��� 	 $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 65535   Minimum 0#���     Value �� *CharacodeID_field+�� $��3��$��0��  m_afterAttachObjectType#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��4��$��0��$��3��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #��� 	 $��1q� �� *ChunkType_field+.@��� .����   m_appearanceAnmEditorType_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_appearanceAnmEditorType_2#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_appearanceAnmEditorType_3#��[ #���  $��Stretch=�$��Stretch=�#��[ �� $��3��$��4��$
��Left=�$��Center=�#��[ #���    m_appearanceAnmEditorBlend#���  $��10(�$ 	 Xceed.Wpf.Toolkit.DoubleUpDown  $��4��$��4��$��3��� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1�	 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] 	  Maximum 1 	  Minimum 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #��� 	 $��1q� 	  Value �� *BlendValue_field+�� $��6��$��0��   m_afterAttachObjectChunkName#���  $
��Left=�$��Center=�$��12(�#��[ #���  �� $��7��$��0��$��3��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *ChunkName_field+%
  ModernWpf.Controls.ToggleSwitch
  $��7��$��4��$��3�� ' #m_appearanceAnmEditorToggleEntryOff 
  
OffContent# �   & "m_appearanceAnmEditorToggleEntryOn 
  	OnContent# �  #���  #��[  
  IsOn �� *ToggleEntry_field+�� $��9��$��0��$
��Left=�$��Center=�#��[ #���   ! m_appearanceAnmEditorCostumes#���  $��10(��� $��10��$��0��$��3�� " m_appearanceAnmEditorEnableAll#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #��� 	 #��[ #���  $��12(����� *EnableSlotsCommand+�� $��10��$��4��$��3�� # m_appearanceAnmEditorDisableAll#���  $��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *DisableSlotsCommand+�� $��12��$��Center=�$
��Left=�  d� 	IsChecked  �� *EnableSlot1_field+.����   m_appearanceAnmEditorSlot1#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��14��$��Center=�$
��Left=�  �� *EnableSlot2_field+.����   m_appearanceAnmEditorSlot2#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��16��$��Center=�$
��Left=�  �� *EnableSlot3_field+.����   m_appearanceAnmEditorSlot3#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��18��$��Center=�$
��Left=�  �� *EnableSlot4_field+.����   m_appearanceAnmEditorSlot4#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��20��$��Center=�$
��Left=�  �� *EnableSlot5_field+.����   m_appearanceAnmEditorSlot5#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��12��$��2��$��Center=�$
��Left=�  �� *EnableSlot6_field+.����   m_appearanceAnmEditorSlot6#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��14��$��2��$��Center=�$
��Left=�  �� *EnableSlot7_field+.����   m_appearanceAnmEditorSlot7#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��16��$��2��$��Center=�$
��Left=�  �� *EnableSlot8_field+.����   m_appearanceAnmEditorSlot8#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��18��$��2��$��Center=�$
��Left=�  �� *EnableSlot9_field+.����   m_appearanceAnmEditorSlot9#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��20��$��2��$��Center=�$
��Left=�  �� *EnableSlot10_field+.����    m_appearanceAnmEditorSlot10#��[  #���  $��Center=�$��Stretch=�#��[ $��10(��� $��12��$��4��$��Center=�$
��Left=�  �� *EnableSlot11_field+.����  ! m_appearanceAnmEditorSlot11#��[! #���  $��Center=�$��Stretch=�#��[ $��10(��� $��14��$��4��$��Center=�$
��Left=�  �� *EnableSlot12_field+.����  " m_appearanceAnmEditorSlot12#��[" #���  $��Center=�$��Stretch=�#��[ $��10(��� $��16��$��4��$��Center=�$
��Left=�  �� *EnableSlot13_field+.����  # m_appearanceAnmEditorSlot13#��[# #���  $��Center=�$��Stretch=�#��[ $��10(��� $��18��$��4��$��Center=�$
��Left=�  �� *EnableSlot14_field+.����  $ m_appearanceAnmEditorSlot14#��[$ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��20��$��4��$��Center=�$
��Left=�  �� *EnableSlot15_field+.����  % m_appearanceAnmEditorSlot15#��[% #���  $��Center=�$��Stretch=�#��[ $��10(��� $��12��$��6��$��Center=�$
��Left=�  �� *EnableSlot16_field+.����  & m_appearanceAnmEditorSlot16#��[& #���  $��Center=�$��Stretch=�#��[ $��10(��� $��14��$��6��$��Center=�$
��Left=�  �� *EnableSlot17_field+.����  ' m_appearanceAnmEditorSlot17#��[' #���  $��Center=�$��Stretch=�#��[ $��10(��� $��16��$��6��$��Center=�$
��Left=�  �� *EnableSlot18_field+.����  ( m_appearanceAnmEditorSlot18#��[( #���  $��Center=�$��Stretch=�#��[ $��10(��� $��18��$��6��$��Center=�$
��Left=�  �� *EnableSlot19_field+.����  ) m_appearanceAnmEditorSlot19#��[) #���  $��Center=�$��Stretch=�#��[ $��10(��� $��20��$��6��$��Center=�$
��Left=�  �� *EnableSlot20_field+.����  * m_appearanceAnmEditorSlot20#��[* #���  $��Center=�$��Stretch=�#��[ $��10(��� $��21��
�������$��0,1,0,0q�$��1��$��10���� $��22��$��0��$��3��$��Center=�$
��Left=�  �� *EnableNormalState_field+.����  $+  m_appearanceAnmEditorNormalState#��[+ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��22��$��4��$��3��$��Center=�$
��Left=�  �� *EnableAwakeningState_field+.����  ', #m_appearanceAnmEditorAwakeningState#��[, #���  #��[ $��Center=�$��Stretch=�$��10(��� $��24��$��0��$��10��$
��Left=�$��Center=�#��[ #���   - m_appearanceAnmEditorTiming#��� - $��10(�  $��0��$��25��$��10�� 1 -1	 65565$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #��� 	 $��1q� �� *Timing_field+
  $��27��$��3��  . m_appearanceAnmEditorReverse! 
  Header#! � .  !/ m_appearanceAnmEditorDisabled# � /   0 m_appearanceAnmEditorEnabled# � 0 #���  #��[  �� *#!ToggleReverseAfterAwakening_field+
  $��29��$��3�� 1 m_appearanceAnmEditorCutNC#! � 1 # � / # � 0 #���  #��[  �� *ToggleSpAtkCutNC_field+
  $��31��$��3�� 2 m_appearanceAnmEditorSplAtk#! � 2 # � / # � 0 #���  #��[  �� *ToggleSpAtk_field+
  $��27��$��3��$��4�� 3 m_appearanceAnmEditorWin#! � 3 # � / # � 0 #���  #��[  �� *ToggleWin_field+
  $��29��$��3��$��4�� #4 m_appearanceAnmEditorArmorBreak#! � 4 # � / # � 0 #���  #��[  �� *ToggleArmorBreak_field+� $��1��$��3��$��2��
 �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0�� 5 m_AddDupEntry#��� 5 $��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *AddDupEntryCommand+��  6 m_DeleteEntry#��� 6 $��1��$��Stretch=�$��Stretch=� %7 !Toolbox_button_background_color_3#��� 7 #��� 	 #��[ #���  $��12(����� *DeleteEntryCommand+��  8 m_SearchEntry#��� 8 $��2��$��1��$��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SearchEntryCommand+  $��1��$��30��#��[ #���  #��� 	 $��1q� 1	 65535 0#���   �� *SearchIndex_field+�� $��4��$��3�� 9 m_SaveEntry#��� 9 $��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��
������ y��� *LoadingStatePlay+
 �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��"   LoadingState" �� *LoadingStatePlay+