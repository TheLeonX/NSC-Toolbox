   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  ,    &NSC_Toolbox.View.MessageInfoEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $
��1200��$	��800��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_messageInfoEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources 1  +NSC_Toolbox.Converter.ByteToStringConverter  ByteToStringConverter5  /NSC_Toolbox.Converter.ByteToStringUTF8Converter  ByteToStringUTF8Converter��%   &	       &	          .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $
��1200��$	��800�� � ColumnDefinitions �� $��5 ��� $��* ��� $��5 ��� $
��1.5* ��� $��5 � � RowDefinitions �� $��50 ��� $��3* ��� $��5 ��� $��75 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�   m_SaveAsFile#���  #��[ #���   �� *SaveFileAsCommand+� $��1��$��1�� �� $��35 ��� $��* �.+��� $��0��$��0��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[  %	 !Toolbox_button_background_color_1#��� 	  !
 Toolbox_button_border_color_1#��� 
 $��1q� �� SelectedIndex �� *SelectedMessageInfoIndex+.@��� .����   m_lang_1#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_2#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_3#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_4#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_5#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_6#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_7#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_8#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_lang_9#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   	m_lang_10#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   	m_lang_11#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   	m_lang_12#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   	m_lang_13#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   	m_lang_14#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   	m_lang_15#��[ #���  $��Stretch=�$��Stretch=�#��[ )clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $��1��$ �� IsSynchronizedWithCurrentItem$
 TrueY�#��� 	 #��� 
 $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *MessageInfo_preview_List+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� *SelectedMessageIndex+ �� SelectedItem �� *SelectedMessageInfo+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��Center=�$��CRC32: ��#��[ 
��� ���$��12(��� $��Center=�#��[ #���  $��12(����� *	CRC32Code+ �� 	Converter# [ $ OneWay=�$ PropertyChanged=��� $��Center=�$�� Text: ��#��[ 
��� ���$��12(���  �� 
IsReadOnly$
 True��$��Center=�$��Stretch=�$��Center=�#��[ #���  $��12(����� *SecondaryText+# [ $ OneWay=�$ PropertyChanged=��� $��1��$��3��.���  �� $
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
��Auto � �� $
��Auto ��� $��5 ��� $��2* ��� $��5 ��� $��* ��� $��5 ��� $��* �.+��� $��0��$��1��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��4��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��7��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��10��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��13��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��16��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��19��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��22��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��25��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��28��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��31��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��34��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��37��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��40��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��0��$��43��$��Right=�$��Center=�#��[ #���  #���  $��10(��� $��2��$��0��$��Center=�$��Center=�#��[   
m_MainText#���  #���  $��10(��� $��4��$��0��$��Center=�$��Center=�#��[   m_additionalText#���  #���  $��10(��� $��6��$��0��$��Center=�$��Center=�#��[   	m_speaker#���  #���  $��10(��� $��2��$��1�� �� TextWrapping$ NoWrap=� �� MaxLines$ 3�� �� AcceptsReturn$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_1_field+�� $��4��$��1��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_1_field+�� $��6��$��1��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_1_field+�� $��2��$��4��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_2_field+�� $��4��$��4��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_2_field+�� $��6��$��4��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_2_field+�� $��2��$��7��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_3_field+�� $��4��$��7��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_3_field+�� $��6��$��7��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_3_field+�� $��2��$��10��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_4_field+�� $��4��$��10��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_4_field+�� $��6��$��10��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_4_field+�� $��2��$��13��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_5_field+�� $��4��$��13��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_5_field+�� $��6��$��13��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_5_field+�� $��2��$��16��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_6_field+�� $��4��$��16��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_6_field+�� $��6��$��16��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_6_field+�� $��2��$��19��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_7_field+�� $��4��$��19��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_7_field+�� $��6��$��19��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_7_field+�� $��2��$��22��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_8_field+�� $��4��$��22��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_8_field+�� $��6��$��22��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_8_field+�� $��2��$��25��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_9_field+�� $��4��$��25��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_9_field+�� $��6��$��25��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_9_field+�� $��2��$��28��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_10_field+�� $��4��$��28��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_10_field+�� $��6��$��28��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_10_field+�� $��2��$��31��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_11_field+�� $��4��$��31��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_11_field+�� $��6��$��31��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_11_field+�� $��2��$��34��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_12_field+�� $��4��$��34��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_12_field+�� $��6��$��34��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_12_field+�� $��2��$��37��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_13_field+�� $��4��$��37��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_13_field+�� $��6��$��37��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_13_field+�� $��2��$��40��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_14_field+�� $��4��$��40��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_14_field+�� $��6��$��40��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_14_field+�� $��2��$��43��$ NoWrap=�$ 3��$
 true��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *MainText_lang_15_field+�� $��4��$��43��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SecondaryText_lang_15_field+�� $��6��$��43��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *Speaker_lang_15_field+� $��1��$��3��$��2�� �� $��* ��� $��* ��� $��* � �� $��2* ��� $��* ��� $��* �.+��� $��0��  
m_AddEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #��� 
 #��[ #���  $��12(����� *AddEntryCommand+�� $��1��  
m_DupEntry#���  $��Stretch=�$��Stretch=�#���  #��� 
 #��[ #���  $��12(����� *DupEntryCommand+��    m_DeleteEntry#���   $��2��$��Stretch=�$��Stretch=� %! !Toolbox_button_background_color_3#��� ! #��� 
 #��[ #���  $��12(����� *DeleteEntryCommand+��  " m_searchCRC32#��� " $��1��$��2��$��Stretch=�$��Stretch=�#���  #��� 
 #��[ #���  $��12(����� *SearchCRC32EntryCommand+��  # m_searchText#��� # $��2��$��2��$��Stretch=�$��Stretch=�#���  #��� 
 #��[ #���  $��12(����� *SearchTextEntryCommand+�� $��0��$��1��$��2��$��2��$��35��#���  $��Stretch=�$��Stretch=�#��[ #��� 	 #��� 
 $��1q����� *SearchEntry_field+�� $��4��$��3�� $ m_saveTextAndCRC32#��� $ $��Stretch=�$��Stretch=�#���  #��� 
 #��[ #���  $��12(����� *SaveEntryCommand+� $��3��$��3�� �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* � �� $��* ��� $
��Auto ��� $
��Auto ��� $��5 �.+��� $��0��$��1��$
��Left=�$��Center=�#��[  % 	m_ACBFile#��� % #���  $��10(��� $��0��$��2��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #��� 	 #��� 
 $��1q� �� *ACBFileID_field+.@��� .����  & m_ACBFile_none#��[& #���  $��Stretch=�$��Stretch=�#��[ �� .����  ' m_ACBFile_0#��[' #���  $��Stretch=�$��Stretch=�#��[ �� .����  ( m_ACBFile_1#��[( #���  $��Stretch=�$��Stretch=�#��[ �� .����  ) m_ACBFile_2#��[) #���  $��Stretch=�$��Stretch=�#��[ �� .����  * m_ACBFile_3#��[* #���  $��Stretch=�$��Stretch=�#��[ �� .����  + m_ACBFile_4#��[+ #���  $��Stretch=�$��Stretch=�#��[ �� .����  , m_ACBFile_5#��[, #���  $��Stretch=�$��Stretch=�#��[ �� .����  - m_ACBFile_6#��[- #���  $��Stretch=�$��Stretch=�#��[ �� .����  . m_ACBFile_7#��[. #���  $��Stretch=�$��Stretch=�#��[ �� .����  / m_ACBFile_8#��[/ #���  $��Stretch=�$��Stretch=�#��[ �� .����  0 m_ACBFile_9#��[0 #���  $��Stretch=�$��Stretch=�#��[ �� .����  1 m_ACBFile_10#��[1 #���  $��Stretch=�$��Stretch=�#��[ �� .����  2 m_ACBFile_11#��[2 #���  $��Stretch=�$��Stretch=�#��[ �� .����  3 m_ACBFile_12#��[3 #���  $��Stretch=�$��Stretch=�#��[ �� .����  4 m_ACBFile_13#��[4 #���  $��Stretch=�$��Stretch=�#��[ �� .����  5 m_ACBFile_14#��[5 #���  $��Stretch=�$��Stretch=�#��[ �� .����  6 m_ACBFile_15#��[6 #���  $��Stretch=�$��Stretch=�#��[ �� .����  7 m_ACBFile_16#��[7 #���  $��Stretch=�$��Stretch=�#��[ �� .����  8 m_ACBFile_17#��[8 #���  $��Stretch=�$��Stretch=�#��[ �� $��2��$��1��$
��Left=�$��Center=�#��[  9 m_cue_ID#��� 9 #���  $��10(�# 	 Xceed.Wpf.Toolkit.ShortUpDown  $��2��$��2��� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int16, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int16, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Minimum -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #��� 	 #��� 
 $��1q�   Value �� *CueID_field+�� $��Center=�$
��Left=�$��4��$��2�� d� 	IsChecked �� *DisableText_field+.����  : m_DisableText#��[: #���  $��Center=�$��Stretch=�#��[ $��10(�� $��10��$��10��
������ y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)	   #NSC_Toolbox.Controls.LoadingControl	  $��2��$��2�� 	  LoadingState �� *LoadingStatePlay+