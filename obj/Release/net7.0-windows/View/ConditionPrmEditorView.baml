   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  -    'NSC_Toolbox.View.ConditionPrmEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 $	��850��$	��919��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   	m_condPrm � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources 3  -NSC_Toolbox.Converter.ColorToStringConverter2  ColorToStringConverter25   /NSC_Toolbox.Converter.ConditionEntryIDConverter  ConditionEntryIDConverter��%   &	       &	          .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $	��850��$	��910�� % !Toolbox_button_background_color_1#���   � ColumnDefinitions �� $��5 ��� $
��2.3* ��� $��5 ��� $��3* ��� $��5 � � RowDefinitions �� $��50 ��� $��3* ��� $��5 ��� $��50 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�  	 
m_SaveFile#��� 	 #��[ #���   �� *SaveFileCommand+m�  
 m_SaveAsFile#��� 
 #��[ #���   �� *SaveFileAsCommand+�� -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1��#���   ! Toolbox_button_border_color_1#���  $��1q�$��Stretch=�$��Stretch=����� *ConditionList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedCondition+ �� SelectedIndex �� *SelectedConditionIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� #��[ 
�������$��12(���`�  `� 	Converter# [ .1��� $
 .��� $
 DataContext.ConditionList� �� RelativeSource ��  �� AncestorType
 Window�� #��[ #���  $��12(����� *ConditionName+$ OneWay=�$ PropertyChanged=�� $��1��$��3��$��3�� �� $��* ��� $��5 ��� $��* � �� $
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
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$��0��$��3��  m_condPrm_Name#���  $
��Left=�$��Center=�$��12(�#��[ #���  ��  �� 	MaxLength$ 47��$��1��$��0��$��3��$��Center=�#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ConditionName_field+�� $��3��$��0��$��1��  m_condPrm_Duration#���  $
��Left=�$��Center=�$��12(�#��[ #���  % 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��0��$��4��$��1��� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   Minimum -1#���  $��30��� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]   	Increment 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�   Value �� *ConditionDuration_field+�� $��3��$��2��$��3��  m_condPrm_ChakraUnk#���  $
��Left=�$��Center=�$��12(�#��[ #���  $ 	 Xceed.Wpf.Toolkit.DoubleUpDown  $��2��$��4��$��1��#���  $��30���	 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] 	  	Increment 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q��
 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]] 
  Value �� *ConditionChakra_unk_field+�� $��6��$��0��$��3��  m_condPrm_ATK#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��7��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionATK_field+�� $��6��$��2��$��3��  m_condPrm_ChakraRecover#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��7��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionChakra_recover_field+�� $��9��$��0��$��3��  m_condPrm_DEF#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��10��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionDEF_field+�� $��9��$��2��$��3��  m_condPrm_ChakraShave#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��10��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionChakra_shave_field+�� $��12��$��0��$��3��  m_condPrm_SPD#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��13��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionSPD_field+�� $��12��$��2��$��3��  m_condPrm_ChakraRevival#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��13��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionChakra_revival_field+�� $��15��$��0��$��3��  m_condPrm_SupportATK#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��16��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionSPT_ATK_field+�� $��15��$��2��$��3��  m_condPrm_ChakraDrain#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��16��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionChakra_Drain_field+�� $��18��$��0��$��3��  m_condPrm_HPRecover#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��19��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionHP_Recover_field+�� $��18��$��2��$��3��  m_condPrm_Chakra#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��19��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionChakra_field+�� $��21��$��0��$��3��  m_condPrm_Poison#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��22��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionPoison_field+�� $��21��$��2��$��3��  m_condPrm_ChakraUsage#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��22��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionChakra_Usage_field+�� $��24��$��0��$��3��  m_condPrm_Support#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��25��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionSupport_field+�� $��24��$��2��$��3��  m_condPrm_GuardBreak#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��25��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionGuardBreak_field+�� $��27��$��0��$��3��  m_condPrm_Team#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��28��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionTeam_field+�� $��27��$��2��$��3��  m_condPrm_Dodge#���  $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��28��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionDodge_field+� $��30��$��3�� � Orientation$ 
Horizontal=� � 	ItemWidth$	 150��.+���   m_condPrm_Projectile#���  $��0,0,5,0q� d� 	IsChecked �� *ConditionProjectile_field+��    m_condPrm_Seal#���   $��0,0,5,0q� �� *ConditionSeal_field+��  ! m_condPrm_Stun#��� ! $��0,0,5,0q� �� *ConditionStun_field+��  " m_condPrm_AutoDodge#��� " $��0,0,5,0q� �� *ConditionAutoDodge_field+��  # m_condPrm_Sleep#��� # $��0,0,5,0q� �� *ConditionSleep_field+�� $��32��$��0��$��3�� $ m_condPrm_FlashEffect#��� $ $
��Left=�$��Center=�$��12(�#��[ #���  �� $��33��$��0��$��3��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q� �� *ConditionFlashType_field+.@��� .����   % m_condPrm_FlashEffectDisable#��[% #���  $��Stretch=�$��Stretch=�#��[ �� .����  & 	m_unknown#��[& #���  $��Stretch=�$��Stretch=�#��[ �� .����  ' m_condPrm_FlashEffectEnable#��[' #���  $��Stretch=�$��Stretch=�#��[ �� .����  $(  m_condPrm_FlashEffectStaticColor#��[( #���  $��Stretch=�$��Stretch=�#��[ �� $��35��$��0��$��1�� ) m_condPrm_FlashInterval#��� ) $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��36��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionFlash_interval_field+�� $��35��$��2��$��1�� * m_condPrm_FlashOpacity#��� * $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��36��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionFlash_opacity_field+�� $��38��$��0��$��1��#��� & $
��Left=�$��Center=�$��12(�#��[ #���    $��0��$��39��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionFlash_unk1_field+�� $��38��$��2��$��1��#��� & $
��Left=�$��Center=�$��12(�#��[ #���    $��2��$��39��$��1��#���  $��30�� 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *ConditionFlash_unk2_field+�� $��41��$��0��$��3�� + m_condPrm_FlashColor#��� + $
��Left=�$��Center=�$��12(�#��[ #���  # 	 Xceed.Wpf.Toolkit.ColorPicker  $��42��$��0��$��3��$��30��
���   �#��[ #���  #���  $��1q�    SelectedColor  �� *ConditionFlashColor_field+$ TwoWay=�! �� 	Converter#! [ � $��1��$��3��$��2�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0�� , m_AddDupEntry#��� , $��Stretch=�$��Stretch=� %- !Toolbox_button_background_color_2#��� - #���  #��[ #���  $��12(����� *AddDupEntryCommand+��  . m_DeleteEntry#��� . $��1��$��Stretch=�$��Stretch=� %/ !Toolbox_button_background_color_3#��� / #���  #��[ #���  $��12(����� *DeleteEntryCommand+��  0 m_SearchEntry#��� 0 $��2��$��1��$��Stretch=�$��Stretch=�#��� - #���  #��[ #���  $��12(����� *SearchEntryCommand+�� #���  #��[ $��2��$��0��$��Stretch=�$��Stretch=�$��Center=�#���  #���  $��1q����� *SearchTextBox_field+�� $��4��$��3�� 1 m_SaveEntry#��� 1 $��Stretch=�$��Stretch=�#��� - #���  #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��
������ y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��"   LoadingState" �� *LoadingStatePlay+