   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  )    #NSC_Toolbox.View.cmnparamEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $	��750��$	��850��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_cmnparamEditor � Title# �    � 	Resources   TabItemText �� 
TargetType �� Triggers �� Binding �� RelativeSource �� AncestorType �� Value	 �� Property
 �� Value��%�   &	       �� " �� ��  �� *
IsSelected+ ��  TabItem True.a��� 	 � ��

 �������  �� *
IsSelected+ ��  TabItem	 False.a��� 	 � ��

 ���������   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z  �� Path$ StretchMode�.��� $	��750��$	��850�� � ColumnDefinitions �� $��5 ��� $��* ��� $��5 � � RowDefinitions �� $��50 ��� $��* ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ #���   �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ #���   �� *SaveFileAsCommand+�� $��0,2,0,0q�
���   �$��1��$��1������  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���  � Color$ Transparent�� � Offset$ 0Q�� $ Transparent��$ 1Q�.@��� ����  	 m_cmnparamEditor_tab_1#��[	 #��[ #��[ ���  �� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 � �� $��5 ��� $��* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1�� %
 !Toolbox_button_background_color_1#��� 
  ! Toolbox_button_border_color_1#���  $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *PairSplList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedPairSpl+  �� SelectedIndex  �� *SelectedPairSplIndex+���� .R��� ! �� Orientation$! 
Horizontal=�.+��� $��TUJ ID: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *	PairSplID+$ OneWay=�$ PropertyChanged=��� $�� Sound Event Name: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *PairSoundEvFileName+$ OneWay=�$ PropertyChanged=�� $��1��$��3��$��3�� �� $
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
��Left=�#��[   m_cmnparamEditor_pairSplID#���  #���  $��10(�% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��1��$��30��#��[ #��� 
 #���  $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]"   	Increment" 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]#   Maximum	# 65535$   Minimum$ 0#���  %   Value% �� *PairSplID_field+�� $��3��$
��Left=�#��[  & "m_cmnparamEditor_pairSndEvFileName#���  #���  $��10(��� & �� 	MaxLength$& 31��$��4��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PairSoundEvFileName_field+�� $��6��$
��Left=�#��[  ' #m_cmnparamEditor_pairCutInChunkName#���  #���  $��10(��� $& 31��$��7��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PairCutInChunkName_field+�� $��9��$
��Left=�#��[  % !m_cmnparamEditor_pairAtkChunkName#���  #���  $��10(��� $& 31��$��10��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PairAtkChunkName_field+�� $��12��$
��Left=�#��[   m_cmnparamEditor_pairName1#���  #���  $��10(��� $& 31��$��13��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PairSplName1_field+�� $��15��$
��Left=�#��[   m_cmnparamEditor_pairName2#���  #���  $��10(��� $& 31��$��16��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PairSplName2_field+� $��1��$��3��$��2�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��  m_AddDupEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #���  #��[ #���  $��12(����� *AddDupPairSplEntryCommand+��   m_DeleteEntry#���  $��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #���  #��[ #���  $��12(����� *DeletePairSplEntryCommand+��   m_SearchEntry#���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SearchPairSplEntryCommand+�� $��1��#���  $��Stretch=�$��Stretch=�$��Center=�#��[ #��� 
 #���  $��1q����� *SearchPairSpl_field+�� $��4��$��3��  m_SaveEntry#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SavePairSplEntryCommand+�� ����   m_cmnparamEditor_tab_2#��[ #��[ #��[ ���  �� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 � �� $��5 ��� $��* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $
 TrueY�$��1��$��1��#��� 
 #���  $��1q�$��Stretch=�$��Stretch=�$
 True��$
 True������ *PlayerSndList+$ OneWay=�$ PropertyChanged=� �� *SelectedPlayerSnd+  �� *SelectedPlayerSndIndex+���� .R��� $! 
Horizontal=�.+��� $��Characode: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *PlayerCharacode+$ OneWay=�$ PropertyChanged=��� $��1��$��3��$��3��.���  �� $��* ��� $��20 � �� $
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
��Auto �.+��� $��0��$
��Left=�#��[  $  m_cmnparamEditor_playerCharacode#���  #���  $��10(��� $��1��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PlayerCharacode_field+�� $��3��$
��Left=�#��[  # m_cmnparamEditor_playerFileName#���  #���  $��10(��� $��4��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PlayerSndBaseFileName_field+�� $��6��$
��Left=�#��[  - )m_cmnparamEditor_playerFileNameAwakening1#���  #���  $��10(��� $��7��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PlayerSndAwa1FileName_field+�� $��9��$
��Left=�#��[  - )m_cmnparamEditor_playerFileNameAwakening2#���  #���  $��10(��� $��10��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PlayerSndAwa2FileName_field+�� $��12��$
��Left=�#��[  ( $m_cmnparamEditor_playerSndEvFileName#���  #���  $��10(��� $��13��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *PlayerSndEventFileName_field+�� $��15��$
��Left=�#��[  + 'm_cmnparamEditor_playerSplSndEvFileName#���  #���  $��10(��� $��16��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� * PlayerSndUJEventFileName_field+�� $��18��$
��Left=�#��[  0 ,m_cmnparamEditor_playerSpl_1_CutIn_ChunkName#���  #���  $��10(��� $��19��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *%#PlayerSndUJ_1_CutIn_ChunkName_field+�� $��21��$
��Left=�#��[  .  *m_cmnparamEditor_playerSpl_1_Atk_ChunkName#���   #���  $��10(��� $��22��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *#!PlayerSndUJ_1_Atk_ChunkName_field+�� $��24��$
��Left=�#��[  0! ,m_cmnparamEditor_playerSpl_2_CutIn_ChunkName#��� ! #���  $��10(��� $��25��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *%#PlayerSndUJ_2_CutIn_ChunkName_field+�� $��27��$
��Left=�#��[  ." *m_cmnparamEditor_playerSpl_2_Atk_ChunkName#��� " #���  $��10(��� $��28��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *#!PlayerSndUJ_2_Atk_ChunkName_field+�� $��30��$
��Left=�#��[  0# ,m_cmnparamEditor_playerSpl_3_CutIn_ChunkName#��� # #���  $��10(��� $��31��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *%#PlayerSndUJ_3_CutIn_ChunkName_field+�� $��33��$
��Left=�#��[  .$ *m_cmnparamEditor_playerSpl_3_Atk_ChunkName#��� $ #���  $��10(��� $��34��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *#!PlayerSndUJ_3_Atk_ChunkName_field+�� $��36��$
��Left=�#��[  2% .m_cmnparamEditor_playerSpl_alt_CutIn_ChunkName#��� % #���  $��10(��� $��37��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *'%PlayerSndUJ_alt_CutIn_ChunkName_field+�� $��39��$
��Left=�#��[  0& ,m_cmnparamEditor_playerSpl_alt_Atk_ChunkName#��� & #���  $��10(��� $��40��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *%#PlayerSndUJ_alt_Atk_ChunkName_field+�� $��42��$
��Left=�#��[  "' m_cmnparamEditor_playerPartner#��� ' #���  $��10(��� $��43��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *" PlayerPartnerCharacodeBase_field+�� $��45��$
��Left=�#��[  %( !m_cmnparamEditor_playerAwaPartner#��� ( #���  $��10(��� $��46��$& 31��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *#!PlayerPartnerCharacodeAwake_field+� $��1��$��3��$��2�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddDupPlayerSndEntryCommand+�� #���  $��1��$��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *DeletePlayerSndEntryCommand+�� #���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SearchPlayerSndEntryCommand+�� $��1��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *SearchPlayerSnd_field+�� $��4��$��3��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SavePlayerSndEntryCommand+