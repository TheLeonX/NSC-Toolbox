   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  F BNodeNetwork, Version=6.0.0.0, Culture=neutral, PublicKeyToken=nullJ4clr-namespace:NodeNetwork.Views;assembly=NodeNetworkNodeNetwork.Views M INodeNetworkToolkit, Version=6.0.0.0, Culture=neutral, PublicKeyToken=nullgFclr-namespace:NodeNetwork.Toolkit.NodeList;assembly=NodeNetworkToolkitNodeNetwork.Toolkit.NodeList =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  $    NSC_Toolbox.View.PRMEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     Lnodenetwork4clr-namespace:NodeNetwork.Views;assembly=NodeNetwork     [nodeListFclr-namespace:NodeNetwork.Toolkit.NodeList;assembly=NodeNetworkToolkit     9	converter#clr-namespace:NSC_Toolbox.Converter     D	 @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM
 IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019 	 
 ] YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  1Controls"clr-namespace:NSC_Toolbox.Controls  5
properties$clr-namespace:NSC_Toolbox.Properties  $
��1200��$	��850��0 	 *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_PRMEDitor � Title# �    � 	Resources   TabItemText �� 
TargetType �� Triggers �� Binding �� RelativeSource �� AncestorType �� Value	 �� Property
 �� Value2  ,NSC_Toolbox.Converter.FunctionIndexConverter  FunctionIndexConverter3  -NSC_Toolbox.Converter.CollisionStateConverter  CollisionStateConverter2  ,NSC_Toolbox.Converter.CollisionTypeConverter  CollisionTypeConverter2  ,NSC_Toolbox.Converter.MovementIndexConverter  MovementIndexConverter��%  &	       &	 �     &	 �     &	 �     &	 �     �� " �� ��  �� *
IsSelected+ ��  TabItem True.a��� 	 � ��

 �������  �� *
IsSelected+ ��  TabItem	 False.a��� 	 � ��

 �����        ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=�.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z  �� Path$ StretchMode�.��� $
��1350��$	��950�� � ColumnDefinitions �� $��5 ��� $��* ��� $��5 ��� $
��2.5* ��� $��5 � � RowDefinitions �� $��50 ��� $
��1.5* ��� $��5 ��� $��2* ��� $��5 ��� $	��100 ��� $��5 �.+�o� $��0��$��4��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
	 m_File#��� 	 #��[ #���  .@�m�  
 
m_OpenFile#��� 
 #��[ #���   m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ #���   �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ #���   �� *SaveFileAsCommand+�� $��3��$��0�� �� Orientation$ 
Horizontal=�$��Right=�$��3q�.+���   m_PRMEDitorFormat#���  $
��Left=�$��Center=�#��[ #���  $��14(��� $��5,0,0,0q�$	��200��$	��200��#���  $��Stretch=�$��Stretch=�#��[  % !Toolbox_button_background_color_1#���   ! Toolbox_button_border_color_1#���  $��1q� �� SelectedIndex �� *SelectedFormatIndex+.@��� .���� $��Storm 1��#���  $��Stretch=�$��Stretch=�#��[ �� .���� $��Storm 2/Generations��#���  $��Stretch=�$��Stretch=�#��[ �� .���� $��Storm 3 (Old)��#���  $��Stretch=�$��Stretch=�#��[ �� .���� $��Storm 3 (HD)��#���  $��Stretch=�$��Stretch=�#��[ �� .���� $��Storm Revolution��#���  $��Stretch=�$��Stretch=�#��[ �� .���� $��Storm 4/Connections��#���  $��Stretch=�$��Stretch=�#��[ �� .���� $3��-Hack Versus (doesn't work with 2 prms inside)��#���  $��Stretch=�$��Stretch=�#��[ �� $��3��$��0��$ 
Horizontal=�$��Right=�$��3q�.+��� $
��Left=�$��Center=�#��[ #���    m_Characode#���  $��14(��� $��5,0,0,0q�$	��100�� �� 	MaxLength$ 15��#���  $��Stretch=�$��Stretch=�$��Center=�$
��Left=�#��[ #���  #���  $��1q����� *CharacodeBinName_field+�� $��5,0,0,0q�$��2��$��2��$��1��  m_PRMEDitor_saveCharacode#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #���  #��[ #���  $��12(����� *ChangeCharacodeCommand+� $��1��$��1�� �� $��* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��35 ��� $��5 ��� $��35 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox  -   $��3��#���  #���  $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *	VerList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedVer+ �� *SelectedVerIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *	BinName+$ OneWay=�$ PropertyChanged=��� $��0��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q� �� *SelectedVerTypeIndex+.@��� .����   m_PRMEDitor_VER_prm_mot#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_awa#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_awa2#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_motcmn#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_skl#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_spl#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����  ! m_PRMEDitor_VER_prm_upgrade01#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����  ! m_PRMEDitor_VER_prm_upgrade02#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����  ! m_PRMEDitor_VER_prm_upgrade03#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_boss#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_boss01#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_boss02#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����   m_PRMEDitor_VER_prm_boss03#��[ #���  $��Stretch=�$��Stretch=�#��[ �� .����    m_PRMEDitor_VER_prm_boss04#��[  #���  $��Stretch=�$��Stretch=�#��[ �� $��2��$��2��$��1�� ! 
m_AddEntry#��� ! $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddVerEntryCommand+�� $��4��$��2��$��1�� " m_DeleteEntry#��� " $��Stretch=�$��Stretch=� %# !Toolbox_button_background_color_3#��� # #���  #��[ #���  $��12(����� *DeleteVerEntryCommand+�� $��4��$��0��$��1�� $ m_SaveEntry#��� $ $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SaveVerEntryCommand+)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox  -   $��3��$��1��#���  #���  $��1q�$��Stretch=�$��Stretch=�$
 True��$
 True������ *PL_ANM_List+$ OneWay=�$ PropertyChanged=� �� *SelectedPL_ANM+ �� *SelectedPL_ANMIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *PL_ANM_current_name+$ OneWay=�$ PropertyChanged=�� $��1��$��3��$��5��#���  $��Stretch=�$��Stretch=�.+��� $��1q�#���  �� $��0,2,0,0q�
���   �����  �� EndPoint$ 0.5,1&� �� 
StartPoint$ 0.5,0&�.���   � Color$  Transparent��! � Offset$! 0Q�� $  Transparent��$! 1Q�.@��� ����  % m_PRMEDitor_Moveset#��[% #��[ #��[ ���  �� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��2* ��� $��5 � �� $��5 ��� $
��3.6* ��� $��5 ��� $��7* ��� $��5 ��� $��0.75* ��� $��5 ��� $��0.75* ��� $��5 ��� $��0.85* ��� $��5 �.+��� $��1��$��3��$��3��$��Center=�$	��Top=�$��	0,-15,0,0q�#��[ #���   & m_PRMEDitor_FunctionList#��� & $��10(�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox  -   $��3��$��1��$��3��#���  #���  $��1q�$��Stretch=�$��Stretch=�$
 True��$
 True������ *FunctionList+$ OneWay=�$ PropertyChanged=� �� *SelectedFunction+ �� *SelectedFunctionIndex+���� .R��� $ 
Horizontal=�.+��� $��Timing: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *FunctionTiming+$ OneWay=�$ PropertyChanged=��� $�� Function: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *
FunctionID+" �� 	Converter#" [ � $��1��$��1��$��5�� �� $��2* ��� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��2* ��� $��5 ��� $��2* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��0��$
��Left=�$��Center=�#��[ #���   ' m_PRMEDitor_PLANM#��� ' $��10(��� $ 31��$��0��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *PL_ANM_current_name_field+�� $��0��$��3��$
��Left=�$��Center=�#��[  ( m_PRMEDitor_PLANM_Previous#��� ( #���  $��10(��� $ 31��$��0��$��4��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *PL_ANM_previous_name_field+�� $��0��$��6��$
��Left=�$��Center=�#��[  ) m_PRMEDitor_PLANM_Next#��� ) #���  $��10(��� $ 31��$��0��$��7��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *PL_ANM_next_name_field+�� $��0��$��9��$
��Left=�$��Center=�#��[  * m_PRMEDitor_PLANM_DMG#��� * #���  $��10(��� $ 31��$��0��$��10��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *PL_ANM_DMG_name_field+�� $��6��$��0��$��1��$
��Left=�$��Center=�#��[  + m_PRMEDitor_Direction#��� + #���  $��10(��� $��6��$��1��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q� �� *Direction_field+.@��� .����  !, m_PRMEDitor_Direction_Neutral#��[, #���  $��Stretch=�$��Stretch=�#��[ �� .����  - m_PRMEDitor_Direction_All#��[- #���  $��Stretch=�$��Stretch=�#��[ �� .����  . m_PRMEDitor_Direction_Up#��[. #���  $��Stretch=�$��Stretch=�#��[ �� .����  / m_PRMEDitor_Direction_Down#��[/ #���  $��Stretch=�$��Stretch=�#��[ �� .����  0 m_PRMEDitor_Direction_Side#��[0 #���  $��Stretch=�$��Stretch=�#��[ �� $��2��$��3��$
��Left=�$��Center=�#��[  1 m_PRMEDitor_PressStart#��� 1 #���  $��10(�#  Xceed.Wpf.Toolkit.ShortUpDown  $��2��$��4���	  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int16, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]# 	  	Increment# 1�
  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int16, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]$ 
  Minimum$ -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% 
  Value% �� *Press_start_field+�� $��4��$��3��$
��Left=�$��Center=�#��[  2 m_PRMEDitor_PressEnd#��� 2 #���  $��10(�  $��4��$��4��# 1$ -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *Press_end_field+�� $��2��$��6��$��3��$
��Left=�$��Center=�#��[  3 m_PRMEDitor_Interpolation#��� 3 #���  $��10(�%  Xceed.Wpf.Toolkit.IntegerUpDown  $��2��$��7��$��3���  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]&   	Increment& 1�  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]'   Minimum' 0(   Maximum	( 65565$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�)   Value) �� *Interpolation_field+�� $��2��$��9��$��3��$
��Left=�$��Center=�#��[  4 m_PRMEDitor_PLANM_Type#��� 4 #���  $��10(�  $��2��$��10��$��3��& 1' 0	( 65565$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�) �� *
Type_field+�� $��2��$��0��$��3��$
��Left=�$��Center=�#��[  5 m_PRMEDitor_Animation#��� 5 #���  $��10(��� $ 31��$��2��$��1��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *PL_ANM_animation_field+�� $��6��$��3��$
��Left=�$��Center=�#��[  6 m_PRMEDitor_LinkCondition#��� 6 #���  $��10(��� $��6��$��4��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *LINKCOND_List+ �� *Link_condition_field+�� $��6��$��6��$
��Left=�$��Center=�#��[  !7 m_PRMEDitor_TriggerCondition1#��� 7 #���  $��10(��� $��6��$��7��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *	COND_List+ �� *Trigger_condition_1_field+�� $��6��$��9��$
��Left=�$��Center=�#��[  !8 m_PRMEDitor_TriggerCondition2#��� 8 #���  $��10(��� $��6��$��10��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *
COND2_List+ �� *Trigger_condition_2_field+�� $ Vertical=�$��0��$��8��$��12��.+��� $��Center=�$
��Left=�* d� 	IsChecked* �� *EnableFaceAnim_field+.����  9 m_PRMEDitor_EnableFaceAnim#��[9 #���  $��Center=�$��Stretch=�#��[ $��10(��� $��Center=�$
��Left=�* �� *EnableCubeMan_field+.����  : m_PRMEDitor_EnableCubeMan#��[: #���  $��Center=�$��Stretch=�#��[ $��10(��� $��Center=�$
��Left=�* �� *DisableInterpolation_field+.����  $;  m_PRMEDitor_DisableInterpolation#��[; #���  $��Center=�$��Stretch=�#��[ $��10(��� $��Center=�$
��Left=�* �� *EnableAnimPosFix_field+.����  < m_PRMEDitor_FixAnimationPos#��[< #���  $��Center=�$��Stretch=�#��[ $��10(��� $��Center=�$
��Left=�* �� *EnableBackwardFacingFix_field+.����  != m_PRMEDitor_FixBackwardFacing#��[= #���  $��Center=�$��Stretch=�#��[ $��10(�� $��3��$��5�� �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* � �� $
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
��Auto �.+��� $��0��$��0��$��5��$
��Left=�$��Center=�#��[  > m_PRMEDitor_Function#��� > #���  $��10(��� $��0��$��1��$��5��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *	FUNC_List+ �� *FunctionID_field+�� $��2��$��3��$��3��$
��Left=�$��Center=�#��[  ? m_PRMEDitor_StringParam#��� ? #���  $��10(��� $��2��$��4��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�$ 31������ *StringParam_field+�� $��0��$��3��$��3��$
��Left=�$��Center=�#��[  @ m_PRMEDitor_FuncTiming#��� @ #���  $��10(�  #���  $��30��$��0��$��1��$��4��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *FunctionTiming_field+�� $��0��$��6��$��1��$
��Left=�$��Center=�#��[  A m_PRMEDitor_Param1#��� A #���  $��10(�  #���  $��30��$��0��$��1��$��7��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *FunctionParam1_field+�� $��2��$��6��$��1��$
��Left=�$��Center=�#��[  B m_PRMEDitor_Param2#��� B #���  $��10(�  #���  $��30��$��2��$��1��$��7��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *FunctionParam2_field+�� $��4��$��6��$��1��$
��Left=�$��Center=�#��[  C m_PRMEDitor_Param3#��� C #���  $��10(�  #���  $��30��$��4��$��1��$��7��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *FunctionParam3_field+�� $��0��$��9��$��3��$
��Left=�$��Center=�#��[  D m_PRMEDitor_Param4#��� D #���  $��10(�$  Xceed.Wpf.Toolkit.DoubleUpDown  #���  $��30��$��0��$��5��$��10���  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]+   	Increment+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]],   Value, �� *FunctionParam4_field+�� $��0��$��12��$��5��$
��Left=�$��Center=�#��[  E m_PRMEDitor_DamageCode#��� E #���  $��10(��� $��0��$��13��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�$ 47������ *DamageCode_field+�� $��0��$��15��$��1��$
��Left=�$��Center=�#��[  F m_PRMEDitor_DamageHitEffect#��� F #���  $��10(�  #���  $��30��$��0��$��1��$��16��# 1$ 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *DamageHitEffectID_field+�� $��2��$��15��$��1��$
��Left=�$��Center=�#��[  "G m_PRMEDitor_DamageHitCondition#��� G #���  $��10(��� $��2��$��16��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *DMGCOND_List+ �� *DamageCondition_field+�� $��4��$��12��$��1��$
��Left=�$��Center=�#��[  H m_PRMEDitor_DamageAmount#��� H #���  $��10(�  #���  $��30��$��4��$��1��$��13��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�, �� *DamageAmount_field+�� $��4��$��15��$��1��$
��Left=�$��Center=�#��[  I m_PRMEDitor_DamageHitSound#��� I #���  $��10(�  #���  $��30��$��4��$��1��$��16��# 1$ -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *DamageHitSoundID_field+�� $��0��$��18��$��1��$
��Left=�$��Center=�#��[  J m_PRMEDitor_HorizontalPush#��� J #���  $��10(�  #���  $��30��$��0��$��1��$��19��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�, �� *DamageHorizontalPush_field+�� $��2��$��18��$��1��$
��Left=�$��Center=�#��[  K m_PRMEDitor_VerticalPush#��� K #���  $��10(�  #���  $��30��$��2��$��1��$��19��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�, �� *DamageVerticalPush_field+�� $��4��$��18��$��1��$
��Left=�$��Center=�#��[  L m_PRMEDitor_GuardDamage#��� L #���  $��10(�  #���  $��30��$��4��$��1��$��19��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�, �� *DamageGuard_field+�� $��0��$��21��$��3��$
��Left=�$��Center=�#��[  M m_PRMEDitor_HitAmount#��� M #���  $��10(�  #���  $��30��$��0��$��1��$��22��# 1$ 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *DamageHitAmount_field+�� $��2��$��21��$��3��$
��Left=�$��Center=�#��[  N m_PRMEDitor_HitFrequency#��� N #���  $��10(�  #���  $��30��$��2��$��1��$��22��# 1$ 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *DamageHitFrequency_field+�� $��4��$��21��$��3��$
��Left=�$��Center=�#��[  O m_PRMEDitor_FreezeTime#��� O #���  $��10(�  #���  $��30��$��4��$��1��$��22��# 1$ 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  $��1q�% �� *DamageFreezeTime_field+�� $��5��$��1��$��1�� P m_PRMEDitor_FunctionCopy#��� P $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *CopyFunctionEntryCommand+�� $��5��$��3��$��1�� Q m_PRMEDitor_FunctionPaste#��� Q $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *PasteFunctionEntryCommand+�� $��7��$��1��$��Stretch=�$��Stretch=�#���  #���  ���� *AddDupFunctionEntryCommand+.����  R m_AddDupEntry#��� R #��[ #���  $��12(�$��WrapWithOverflow=�- �� TextAlignment$- Center=��� $��7��$��3��$��Stretch=�$��Stretch=�#��� # #���  ���� *DeleteFunctionEntryCommand+.���� #��� " #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��7��$��5��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveFunctionEntryCommand+.���� #��� $ #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��9��$��1��$��5�� S m_PRMEDitor_SavePL_ANM#��� S $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *SavePLANMEntryCommand+�� ���� #��[  T m_PRMEDitor_Projectile#��[T #��[ ��� $��5q� �� $��1* ��� $��5 ��� $��1* � �� $��* ��� $��5 ��� $��50 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox  -   $��0��$��0��#���  #���  $��1q�$
 True��$
 True������ *ProjectileList+$ OneWay=�$ PropertyChanged=� �� *SelectedProjectile+ �� *SelectedProjectileIndex+���� .R��� $ 
Horizontal=�.+��� $��Projectile name: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *ProjectileName+$ OneWay=�$ PropertyChanged=��� $�� Skill Entry: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *SkillEntryName+� $��0��$��2�� �� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��4��$��1��$
��Left=�$��Center=�#��[ #���   U m_PRMEDitor_Projectile_Name#��� U $��10(��� $ 31��$��0��$��2��#���  #��[ #���  #���  $��1q����� *ProjectileName_field+�� $��4��$��4��$
��Left=�$��Center=�#��[ #���   (V $m_PRMEDitor_Projectile_SkillFileName#��� V $��10(��� $ 31��$��4��$��5��#���  #��[ #���  #���  $��1q����� *SkillFileName_field+�� $��4��$��7��$
��Left=�$��Center=�#��[ #���   )W %m_PRMEDitor_Projectile_SkillEntryName#��� W $��10(��� $ 31��$��4��$��8��#���  #��[ #���  #���  $��1q����� *SkillEntryName_field+�� $��4��$��10��$
��Left=�$��Center=�#��[  X 	m_unknown#��� X #���  $��10(�$  Xceed.Wpf.Toolkit.SingleUpDown  $��4��$��30��$��11��$��2���  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Single, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]].   	Increment. 1$��Center=�#��[ #���  #���  #���  $��1q��  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Single, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]/   Maximum/ 2550   Minimum0 01   Value1 �� *	Unk_field+� $��0��$��2�� �� $��* ��� $��5 ��� $��* � �� $��* �.+��� $��0��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddDupProjectileEntryCommand+.���� #��� R #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��0��$��2��$��Stretch=�$��Stretch=�#��� # #���  ���� *DeleteProjectileEntryCommand+.���� #��� " #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��2��$��2��$��Stretch=�$��Stretch=�#���  #���  $��2������ *SaveProjectileEntryCommand+.���� #��� $ #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� ���� #��[  Y m_PRMEDitor_Collision#��[Y #��[ ��� $��5q� �� $��* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��50 �.+�� $��2�� �� $
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
��Auto �.+��� $��0��$
��Left=�$��Center=�#��[ #���   Z m_PRMEDitor_Collision_Type#��� Z $��10(��� $��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q� �� *TypeCollision_field+.@��� .����  [ m_PRMEDitor_Collision_Type1#��[[ #���  $��Stretch=�$��Stretch=�#��[ �� .����  \ m_PRMEDitor_Collision_Type2#��[\ #���  $��Stretch=�$��Stretch=�#��[ �� .����  ] m_PRMEDitor_Collision_Type3#��[] #���  $��Stretch=�$��Stretch=�#��[ �� $��3��$
��Left=�$��Center=�#��[ #���   ^ m_PRMEDitor_Collision_State#��� ^ $��10(�  $��30��$��4��$��1��& 1' 0	( 65565$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�) �� *StateCollision_field+�� $��6��$��Center=�$
��Left=�* �� *BoneEnablerCollision_field+.����  !_ m_PRMEDitor_Collision_UseBone#��[_ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��8��$
��Left=�$��Center=�#��[ #���   "` m_PRMEDitor_Collision_BoneName#��� ` $��10(��� $ 31��$��9��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *BoneNameCollision_field+�� $��11��$
��Left=�$��Center=�#��[ #���   'a #m_PRMEDitor_Collision_HurtboxRadius#��� a $��10(�  $��30��$��12��$��1��# 1$ 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *HurtboxRadiusCollision_field+�� $��14��$
��Left=�$��Center=�#��[ #���   %b !m_PRMEDitor_Collision_HurtboxYPos#��� b $��10(�  $��30��$��15��$��1��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *Hurtbox_Y_PosCollision_field+�� $��3��$��17��$
��Left=�$��Center=�#��[ #���   %c !m_PRMEDitor_Collision_HurtboxZPos#��� c $��10(�  $��3��$��30��$��18��$��1��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *Hurtbox_Z_PosCollision_field+)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox  -   $��0��$��0��#���  #���  $��1q�$��Stretch=�$��Stretch=�$
 True��$
 True������ *CollisionList+$ OneWay=�$ PropertyChanged=� �� *SelectedCollision+ �� *SelectedCollisionIndex+���� .R��� $ 
Horizontal=�.+��� $��Entry Type: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *Type+$ OneWay=�$ PropertyChanged=�#" [ �� $�� State: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *State+#" [ �� $�� Bone: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� *
BoneName+� $��0��$��2�� �� $��* ��� $��5 ��� $��* � �� $��* �.+��� $��0��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddDupCollisionEntryCommand+.���� #��� R #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��0��$��2��$��Stretch=�$��Stretch=�#��� # #���  ���� *DeleteCollisionEntryCommand+.���� #��� " #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��2��$��2��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveCollisionEntryCommand+.���� #��� $ #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� ���� #��[  d m_PRMEDitor_Etc#��[d #��[ ��� $��5q� �� $��* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��50 �.+�� $��2�� �� $
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
��Left=�$��Center=�#��[ #���   *e &m_PRMEDitor_Movement_FrameActionUnlock#��� e $��10(�  $��30��$��1��$��1��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *FrameActionUnlock_field+�� $��3��$
��Left=�$��Center=�#��[ #���   'f #m_PRMEDitor_Movement_ActionDuration#��� f $��10(�  $��30��$��4��$��1��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *ActionLength_field+�� $��6��$
��Left=�$��Center=�#��[ #���  #��� X $��10(�  $��30��$��7��$��1��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *
Unk1_field+�� $��9��$
��Left=�$��Center=�#��[ #���   'g #m_PRMEDitor_Movement_CircleVelocity#��� g $��10(�  $��30��$��10��$��1��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�, �� *CircleVelocity_field+�� $��12��$
��Left=�$��Center=�#��[ #���  #��� X $��10(�  $��30��$��13��$��1��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�, �� *
Unk2_field+�� $��15��$
��Left=�$��Center=�#��[ #���   /h +m_PRMEDitor_Movement_CircleVelocityStrength#��� h $��10(�  $��30��$��16��$��1��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�, �� *CircleVelocityStrength_field+�� $��18��$
��Left=�$��Center=�#��[ #���   *i &m_PRMEDitor_Movement_MovementFrequency#��� i $��10(�  $��30��$��19��$��1��# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�% �� *MovementFrequency_field+�� $��21��$
��Left=�$��Center=�#��[ #���   (j $m_PRMEDitor_Movement_ForwardVelocity#��� j $��10(�  $��30��$��22��$��1��+ 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�, �� *ForwardVelocity_field+�� $��0��$��0��#���  #���  $��1q�$��Stretch=�$��Stretch=����� *MovementList+$ OneWay=�$ PropertyChanged=� �� *SelectedMovement+ �� *SelectedMovementIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *MovementItemIndex+$ TwoWay=�$ PropertyChanged=�#" [ � $��0��$��2�� �� $��* ��� $��5 ��� $��* � �� $��* �.+��� $��0��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddDupMovementEntryCommand+.���� #��� R #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��0��$��2��$��Stretch=�$��Stretch=�#��� # #���  ���� *DeleteMovementEntryCommand+.���� #��� " #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��2��$��2��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveMovementEntryCommand+.���� #��� $ #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=�� $��1��$��5�� �� $��* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��* �.+��� $��0��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *CopyPLANMEntryCommand+.���� #��� P #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��0��$��2��$��Stretch=�$��Stretch=�#���  #���  ���� *PastePLANMEntryCommand+.���� #��� Q #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��2��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddDupPLANMEntryCommand+.���� #��� R #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=��� $��2��$��2��$��Stretch=�$��Stretch=�#��� # #���  ���� *DeletePLANMEntryCommand+.���� #��� " #��[ #���  $��12(�$��WrapWithOverflow=�$- Center=�� $��10��$��10��y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��2   LoadingState2 �� *LoadingStatePlay+