   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  0    *NSC_Toolbox.View.DuelPlayerParamEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5
properties$clr-namespace:NSC_Toolbox.Properties 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_DuelPlayerParamEditor � Title# [  $
��1200��$	��900�� � 	Resources -   'NSC_Toolbox.Converter.IntToHexConverter  IntToHexConvert*   $NSC_Toolbox.Converter.IndexConverter  IndexConverter��%   &	       &	          ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $
��1450��$
��1080�� � ColumnDefinitions �� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��2* ��� $��5 � � RowDefinitions �� $��50 ��� $��3* ��� $��5 ��� $��50 ��� $��5 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[ .@�m�  
 m_File#���  #��[   Toolbox_button_text_color_1#���  .@�m�   
m_OpenFile#���  #��[ 
������� m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ 
������� �� *SaveFileCommand+m�  	 m_SaveAsFile#��� 	 #��[ 
������� �� *SaveFileAsCommand+)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1�� %
 !Toolbox_button_background_color_1#��� 
  ! Toolbox_button_border_color_1#���  $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *DuelPlayerParamList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedDPP+ �� SelectedIndex �� *SelectedDPPIndex+���� .R��� #��[ #���  $��12(����� $
 BinName�� $��3��$��1��$��3�� �� $��* � �� $��20 ��� $��* ��� $��5 ��� $
��Auto ��� $��50 ��� $��5 ��� $��20 ��� $��* ��� $��5 ��� $
��Auto ��� $��50 �.+��� $��0��$��Center=�#��[   m_baseCostumeList#���  #���  $��14(�$��	0,-20,0,0q��� -    ��Name$ baseCostumeListPreview�� �� AlternationCount$ 20��$��0��$��2��#��� 
 #���  $��1q�$��Stretch=�$��Stretch=����� *BaseCostumesList+$ PropertyChanged=� �� *SelectedBaseCostume+ �� *SelectedBaseCostumeIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� #��[ #���  $��12(����� $
 CostumeIndex��� $	�� - ��#��[ #���  $��12(��� #��[ #���  $��12(����� $
 CostumeName�� $��3��$��Stretch=�.+��� -    ��Name$ ChaDescriptionName�� �� 	MaxLength$ 7��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *BaseCostume_field+��  J� IsHitTestVisible$ False��  m_modelCode#���  $��Center=�$
��Left=�$��	10,0,10,0q����	#FF6D6D6D#��[ ����  �� 
TargetType" ��.���  �� Property � y� �� Value$ 	Collapsed=� �� Triggers ��  �� Binding �� *Text+  �� ElementName$  ChaDescriptionName��! �� Value!  .a���  � y�$ Visible=��� $��4��$��0��  m_SaveEntry#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #���  #��[ #���  $��12(����� *SaveBaseCostumeEntryCommand+�� $��6��$��Center=�#��[   m_awakeningCostumeList#���  #���  $��14(��� $ 20��$��7��#��� 
 #���  $��1q�$��Stretch=�$��Stretch=����� *AwakeCostumesList+$ OneWay=�$ PropertyChanged=� �� *SelectedAwakeCostume+ �� *SelectedAwakeCostumeIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� $
 CostumeIndex��� $	�� - ��#��[ #���  $��12(��� #��[ #���  $��12(����� $
 CostumeName�� $��9��$��Stretch=�.+��� -   $ ChaDescriptionName1��$ 7��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *AwakeCostume_field+�� $ False��#���  $��Center=�$
��Left=�$��	10,0,10,0q����	#FF6D6D6D#��[ ���� " ��.���  � y�$ 	Collapsed=� ��  �� *Text+$  ChaDescriptionName1��!  .a���  � y�$ Visible=��� $��10��$��0��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveAwakeCostumeEntryCommand+� $��1��$��5��$��3��#��� 
  �� $��* ��� $��5 ��� $��* � �� $
��Auto ��� $��5 ��� $��20 ��� $��2* ��� $��5 ��� $��20 ��� $��* ��� $��5 ��� $��20 ��� $
��0.8* �.+�� $��0��$��3�� �� $
��Auto ��� $��* ��� $
��Auto ��� $��* �.+��� $��0��$��0��$
��Left=�$��Center=�#��[   m_dppCharacode#���  #���  $��14(��� $��0��$��1��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *Characode_field+�� $��0��$��2��$
��Left=�$��Center=�#��[   m_dppMotionCode#���  #���  $��14(��� $��0��$��3��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *MotionCode_field+�� $��0��$��5��$��Center=�$��Center=�#��[   m_items#���  #���  $��14(�� $��0��$��2��$��3�� �� $��* ��� $��* ��� $��* �.+��� $��1��$��Center=�$��Center=�#��[   m_baseState#���  #���  $��14(��� $��2��$��Center=�$��Center=�#��[   m_awakeningState#���  #���  $��14(��� $��0��$��3��$��3��.���  �� $
��Auto ��� $��5 ��� $��* ��� $��* ��� $��20 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��1��$��Right=�$��Center=�#��[   m_SpeedValue#���  #���  $��12(��� $��0��$��2��$��Right=�$��Center=�#��[   m_ChakraDashSpeedValue#���  #���  $��12(��� $��0��$��3��$��Right=�$��Center=�#��[   m_GuardDamageMultiplier#���  #���  $��12(��� $��0��$��4��$��Right=�$��Center=�#��[   m_AirChakraDashSpeed#���  #���  $��12(��� $��0��$��5��$��Right=�$��Center=�#��[   m_AttackValue#���  #���  $��12(��� $��0��$��6��$��Right=�$��Center=�#��[   m_DefenseValue#���  #���  $��12(��� $��0��$��7��$��Right=�$��Center=�#��[   m_AssistDamage#���  #���  $��12(��� $��0��$��8��$��Right=�$��Center=�#��[   m_AwakeActionRecoverySpeed#���  #���  $��12(��� $��0��$��9��$��Right=�$��Center=�#��[   m_ChakraChargeSpeed#���  #���  $��12(��� $��0��$��10��$��Right=�$��Center=�#��[   m_AirDashSpeed#���  #���  $��12(��� $��0��$��11��$��Right=�$��Center=�#��[    m_AirDashDuration#���   #���  $��12(��� $��0��$��12��$��Right=�$��Center=�#��[  ! m_ChakraDashDuration#��� ! #���  $��12(��� $��0��$��13��$��Right=�$��Center=�#��[  " m_CameraHeight#��� " #���  $��12(�$ 	 Xceed.Wpf.Toolkit.DoubleUpDown  $��2��$��1��$��30��#��[ #��� 
 #���  $��1q�� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]"   	Increment" .001#���  � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]#   Value# �� *BaseMovementSpeed_field+  $��3��$��1��$��30��#��[ #��� 
 #���  $��1q�" .001#���  # �� *AwakeMovementSpeed_field+  $��2��$��2��$��30��#��[ #��� 
 #���  $��1q�" .001#���  # �� *BaseChakraDashSpeed_field+  $��3��$��2��$��30��#��[ #��� 
 #���  $��1q�" .001#���  # �� *AwakeChakraDashSpeed_field+  $��2��$��3��$��30��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *GuardPressure_field+  $��2��$��4��$��30��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *AirDashSpeed_field+  $��2��$��5��$��30��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *Attack_field+  $��2��$��6��$��30��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *Defense_field+  $��2��$��7��$��30��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *AssistDamage_field+  $��2��$��8��$��30��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *" AwakeningActionChargeSpeed_field+  $��2��$��9��$��30��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *ChakraChargeSpeed_field+%	 	 Xceed.Wpf.Toolkit.IntegerUpDown	  $��2��$��10��$��30��#��[ #��� 
 #���  $��1q��
 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]$ 
  	Increment$ 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]%   Maximum	% 65535&   Minimum& 0#���  '   Value' �� *BaseNinjaDashSpeed_field+	  $��2��$��11��$��30��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *BaseAirDashDuration_field+	  $��2��$��12��$��30��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *&$BaseGroundedChakraDashDuration_field+	  $��3��$��10��$��30��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *AwakeNinjaDashSpeed_field+	  $��3��$��11��$��30��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *AwakeAirDashDuration_field+	  $��3��$��12��$��30��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *'%AwakeGroundedChakraDashDuration_field+	  $��2��$��13��$��2��$��30��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *CameraDistance_field+� $��6�� �� $
��Auto ��� $��5 ��� $��2* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$��Right=�$��Center=�#��[  # m_itemup#��� # #���  $��14(��� $��0��$��1��$��Right=�$��Center=�#��[  $ 
m_itemdown#��� $ #���  $��14(��� $��0��$��2��$��Right=�$��Center=�#��[  % 
m_itemleft#��� % #���  $��14(��� $��0��$��3��$��Right=�$��Center=�#��[  & m_itemright#��� & #���  $��14(��� $��0��$��4��$��Right=�$��Center=�#��[  ' m_itemsDuration#��� ' #���  $��14(��� $��2��$��0��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q�$��12(�$��Center=����� *Items1_field+�� $��2��$��1��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q�$��Center=����� *Items2_field+�� $��2��$��2��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q�$��Center=����� *Items3_field+�� $��2��$��3��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q�$��Center=����� *Items4_field+	  $��3��$��0��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *ItemsDuration1_field+	  $��3��$��1��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *ItemsDuration2_field+	  $��3��$��2��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *ItemsDuration3_field+	  $��3��$��3��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *ItemsDuration4_field+  $��2��$��4��$��2��#��[ #��� 
 #���  $��1q�" .001#���  # �� *ItemBuffDuration_field+�� $��0��$��8��$��Center=�$��Center=�#��[  ( m_victorySettings#��� ( #���  $��14(�� $��9�� �� $
��Auto ��� $��5 ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$��Right=�$��Center=�#��[  ) 	m_unknown#��� ) #���  $��12(��� $��0��$��1��$��Right=�$��Center=�#��[  * m_victoryCameraAngle#��� * #���  $��12(��� $��0��$��2��$��Right=�$��Center=�#��[ #��� ) #���  $��12(��� $��0��$��3��$��Right=�$��Center=�#��[ #��� ) #���  $��12(��� $��0��$��4��$��Right=�$��Center=�#��[ #��� ) #���  $��12(�	  $��3��$��0��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *
Unk1_field+	  $��3��$��1��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *VictoryCameraAngle_field+	  $��3��$��2��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *
Unk2_field+	  $��3��$��3��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *
Unk3_field+	  $��3��$��4��#��[ #��� 
 #���  $��1q�$ 1	% 65535& 0#���  ' �� *
Unk4_field+�� $��0��$��8��$��Center=�$��Center=�#��[ #��� ( #���  $��14(��� $��2��$��8��$��Center=�$��Center=�#��[  + m_assistSettings#��� + #���  $��14(�� $��9��$��2�� �� $
��Auto ��� $��5 ��� $��* � �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Right=�$��Center=�#��[  , m_sprt1#��� , #���  $��12(��� $��0��$��1��$��Right=�$��Center=�#��[  - m_sprt2#��� - #���  $��12(��� $��0��$��2��$��Right=�$��Center=�#��[  . 	m_partner#��� . #���  $��12(��� $��3��$��0��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *Support1_field+�� $��3��$��1��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *Support2_field+�� $��3��$��2��#���  $	��200��$��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *Partner_field+�� $��2��$��5��$��Center=�$��Center=�#��[  / m_awakeCondSettings#��� / #���  $��14(��� $��6��$��2��.���  �� $
��Auto ��� $��5 ��� $��2* ��� $��20 � �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$��Right=�$��Center=�#��[  0 m_awakeCond#��� 0 #���  $��12(��� $��0��$��1��$��Right=�$��Center=�#��[  1 	m_awakeHP#��� 1 #���  $��12(��� $��0��$��3��$��Right=�$��Center=�#��[  2 m_awakeLimitSpeed#��� 2 #���  $��12(��� $��0��$��4��$��Right=�$��Center=�#��[  3 m_awakeChakraCost#��� 3 #���  $��12(��� $��0��$��5��$��Right=�$��Center=�#��[  4 m_AwaBodyPriority#��� 4 #���  $��12(��� $��0��$��6��$��Right=�$��Center=�#��[  5 m_defaultAwaSkillIndex#��� 5 #���  $��12(��� $��2��$��0��#���  $��Stretch=�$��Stretch=�#��[ #��� 
 #���  $��1q����� *AwakeningCondition_field+  $��2��$��1��$��30��#��[ #��� 
 #���  $��1q�" .001(   Maximum( 100)   Minimum) 0#���  # �� *AwakeHPRequirement_field+  $��2��$��3��$��30��#��[ #��� 
 #���  $��1q�" .001#���  # �� * ChakraBlockRecoverySpeed_field+  $��2��$��4��$��30��#��[ #��� 
 #���  $��1q�" .001#���  # �� *ChakraCostAwakening_field+	  $��2��$��5��$��30��#��[ #��� 
 #���  $��1q�$ 1& -1	% 65565#���  ' �� *AwaBodyPriority_field+	  $��2��$��6��$��30��#��[ #��� 
 #���  $��1q�$ 1& -1% 6#���  ' �� *DefaultAwaSkillIndex_field+�� $ Vertical=�$��0��$��7��$��3��.+��� $��Center=�$
��Left=�* d� 	IsChecked* �� *Cond_flag_1_field+.����  6 m_dpp_cond_1#��[6 #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_2_field+.����  7 m_dpp_cond_2#��[7 #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_3_field+.����  8 m_dpp_cond_3#��[8 #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_4_field+.����  9 m_dpp_cond_4#��[9 #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_5_field+.����  : m_dpp_cond_5#��[: #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_6_field+.����  ; m_dpp_cond_6#��[; #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_7_field+.����  < m_dpp_cond_7#��[< #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_8_field+.����  = m_dpp_cond_8#��[= #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_9_field+.����  > m_dpp_cond_9#��[> #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_10_field+.����  ? m_dpp_cond_10#��[? #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_11_field+.����  @ m_dpp_cond_11#��[@ #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_12_field+.����  A m_dpp_cond_12#��[A #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_13_field+.����  B m_dpp_cond_13#��[B #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_14_field+.����  C m_dpp_cond_14#��[C #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_15_field+.����  D m_dpp_cond_15#��[D #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_16_field+.����  E m_dpp_cond_16#��[E #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_17_field+.����  F m_dpp_cond_17#��[F #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_18_field+.����  G m_dpp_cond_18#��[G #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_19_field+.����  H m_dpp_cond_19#��[H #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_20_field+.����  I m_dpp_cond_20#��[I #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_21_field+.����  J m_dpp_cond_21#��[J #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_22_field+.����  K m_dpp_cond_22#��[K #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_23_field+.����  L m_dpp_cond_23#��[L #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_24_field+.����  M m_dpp_cond_24#��[M #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_25_field+.����  N m_dpp_cond_25#��[N #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_26_field+.����  O m_dpp_cond_26#��[O #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_27_field+.����  P m_dpp_cond_27#��[P #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_28_field+.����  Q m_dpp_cond_28#��[Q #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_29_field+.����  R m_dpp_cond_29#��[R #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_30_field+.����  S m_dpp_cond_30#��[S #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_31_field+.����  T m_dpp_cond_31#��[T #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *Cond_flag_32_field+.����  U m_dpp_cond_32#��[U #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� *AwakeningDebuffEnabler_field+.����  V m_awakeDebuff#��[V #���  $��Center=�$��Stretch=�#��[ $��12(��� $��Center=�$
��Left=�* �� * EnableChakraDashPriority_field+.����  W m_enableChakraDashPrior#��[W #���  $��Center=�$��Stretch=�#��[ $��12(�� $��1��$��3��$��3�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0�� X m_AddDupEntry#��� X $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddDupEntryCommand+��  Y m_DeleteEntry#��� Y $��1��$��Stretch=�$��Stretch=� %Z !Toolbox_button_background_color_3#��� Z #���  #��[ #���  $��12(����� *DeleteEntryCommand+��  [ m_SearchEntry#��� [ $��2��$��1��$��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SearchEntryCommand+�� #���  #��[ $��2��$��0��$��Stretch=�$��Stretch=�$��Center=�#��� 
 #���  $��1q����� *SearchTextBox_field+�� $��3��$��5��$��3��#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��+   LoadingState+ �� *LoadingStatePlay+