   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  8    2NSC_Toolbox.View.PlayerDoubleEffectParamEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $	��850��$	��850��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True�� #  m_playerDoubleEffectParamEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z 	 �� Path$	 StretchMode�.��� $	��850��$	��850��
 � ColumnDefinitions
 �� $��5 ��� $��* ��� $��5 � � RowDefinitions �� $��50 ��� $��* ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ #���   �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ #���   �� *SaveFileAsCommand+� $��1��$��1��
 �� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 � �� $��5 ��� $��* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1�� % !Toolbox_button_background_color_1#���   !	 Toolbox_button_border_color_1#��� 	 $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *PlayerDoubleEffectParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *!SelectedPlayerDoubleEffectParam+ �� SelectedIndex �� *&$SelectedPlayerDoubleEffectParamIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� $��Characode ID: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *CharacodeID+$ OneWay=�$ PropertyChanged=��� $�� Bone: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *
AttachBone+$ OneWay=�$ PropertyChanged=��� $�� Sound: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *	SoundID+� $��1��$��3��$��3��#���   �� $��5 ��� $��* ��� $��5 �
 �� $��5 ��� $��* ��� $��5 �.+��� 
�������$��1,1,1,0q�$��10��$��10��� $��1��$��1�� �� $
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
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 �
 �� $��* ��� $��5 ��� $��* �.+��� $��0��$
��Left=�$��3��#��[  
 m_Characode#��� 
 #���  $��10(�% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��1��$��30��$��3��#��[ #���  #��� 	 $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Maximum	 65535   Minimum 0#���     Value �� *CharacodeID_field+�� $��3��$��3��$
��Left=�#��[  - )m_playerDoubleEffectParamEditorAttachBone#���  #���  $��10(��� $��4��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *AttachBone_field+�� $��6��$��3��$
��Left=�#��[  . *m_playerDoubleEffectParamEditorEffectEntry#���  #���  $��10(��� $��7��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *EffectEntry_field+�� $��9��$��3��$
��Left=�#��[  ) %m_playerDoubleEffectParamEditorPlAnm1#���  #���  $��10(��� $��10��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *PlAnmEntry1_field+�� $��12��$��3��$
��Left=�#��[  ) %m_playerDoubleEffectParamEditorPlAnm2#���  #���  $��10(��� $��13��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *PlAnmEntry2_field+�� $��15��$��3��$
��Left=�#��[  ) %m_playerDoubleEffectParamEditorPlAnm3#���  #���  $��10(��� $��16��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *PlAnmEntry3_field+�� $��18��$��3��$
��Left=�#��[  ) %m_playerDoubleEffectParamEditorPlAnm4#���  #���  $��10(��� $��19��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *PlAnmEntry4_field+�� $��21��$��3��$
��Left=�#��[  ) %m_playerDoubleEffectParamEditorPlAnm5#���  #���  $��10(��� $��22��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *PlAnmEntry5_field+�� $��24��$��3��$
��Left=�#��[  . *m_playerDoubleEffectParamEditorHeightSpawn#���  #���  $��10(�$ 	 Xceed.Wpf.Toolkit.DoubleUpDown  $��3��$��25��$��30��#��[ #���  #��� 	 $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1#���  �	 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] 	  Value �� *HeightSpawn_field+�� $��27��$��3��$
��Left=�#��[   	m_unknown#���  #���  $��10(�  $��3��$��28��$��30��#��[ #���  #��� 	 $��1q� 1#���   �� *
Unk2_field+�� $��30��$��3��$
��Left=�#��[  * &m_playerDoubleEffectParamEditorSoundID#���  #���  $��10(��� $��0��$��31��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 	 $��1q����� *
Sound_List+ �� *SoundID_field+�� $��33��$
��Left=�#��[ #���  #���  $��10(�  $��34��$��30��#��[ #���  #��� 	 $��1q� 1	 65535 -1#���   �� *
Unk1_field+�� $��33��$��2��$
��Left=�#��[ #���  #���  $��10(�  $��2��$��34��$��30��#��[ #���  #��� 	 $��1q� 1	 65535 -1#���   �� *
Unk4_field+�� $��36��$ 
Horizontal=�$��3��.+��� $��Center=�$
��Left=� d� 	IsChecked �� *PlayAtStart_field+.����  . *m_playerDoubleEffectParamEditorPlayAtStart#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��Center=�$
��Left=� �� *PlayAtEnd_field+.����  , (m_playerDoubleEffectParamEditorPlayAtEnd#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��3��$��38��$��Center=�$
��Left=� �� *EnableNearestGroundPos_field+.����  8 4m_playerDoubleEffectParamEditorNearestGroundPosition#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��3��$��40��$��Center=�$
��Left=� �� *
Unk3_field+.���� #��[ #���  $��Center=�$��Stretch=�#��[ $��10(�� $��1��$��3��$��2��
 �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0��  m_AddDupEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #��� 	 #��[ #���  $��12(����� *AddDupEntryCommand+��   m_DeleteEntry#���  $��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #��� 	 #��[ #���  $��12(����� *DeleteEntryCommand+��   m_SearchEntry#���  $��2��$��1��$��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SearchEntryCommand+  $��1��$��30��#��[ #���  #��� 	 $��1q� 1	 65535 0#���   �� *SearchIndex_field+�� $��4��$��3��  m_SaveEntry#���  $��Stretch=�$��Stretch=�#���  #��� 	 #��[ #���  $��12(����� *SaveEntryCommand+