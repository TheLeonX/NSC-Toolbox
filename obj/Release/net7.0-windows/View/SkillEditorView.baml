   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  &     NSC_Toolbox.View.SkillEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��$
��1250��$	��900��   m_skillEditor_title � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources   TabItemText �� 
TargetType �� Triggers	 �� Binding
 �� RelativeSource �� AncestorType �� Value �� Property �� Value2  ,NSC_Toolbox.Converter.ColorToStringConverter  ColorToStringConverter��%�   &	       &	 �     �� " �� �� 	 �� *
IsSelected+
 ��  TabItem True.a���  � ��
 ������� 	 �� *
IsSelected+
 ��  TabItem	 False.a���  � ��
 �����  .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z  �� Path$ StretchMode�.��� $
��1600��$
��1130�� � ColumnDefinitions �� $��10 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��3* ��� $��10 � � RowDefinitions �� $
��Auto ��� $��5 ��� $
��1.2* ��� $��5 ��� $��4* ��� $��5 ��� $��50 ��� $��5 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ #���   m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ #���   �� *SaveFileCommand+m�  	 m_SaveAsFile#��� 	 #��[ #���   �� *SaveFileAsCommand+� $��2��$��1��$��3�� �� $
��Auto ��� $��* �.+��� $��0��$��1�� 
 m_skillEditor_001#��� 
 $
��Left=�$��Center=�#��[ #���  $��10(�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $��1��$ �� IsSynchronizedWithCurrentItem$
 TrueY� % !Toolbox_button_background_color_1#���   ! Toolbox_button_border_color_1#���  $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *	SkillList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem �� *SelectedSkill+ �� SelectedIndex �� *SelectedSkillIndex+���� .R���  �� Orientation$ 
Horizontal=�.+��� #��[ #���  $��12(����� *	ChunkName+$ OneWay=�$ PropertyChanged=�� $��2��$��3��$��3�� �� $
��1.4* ��� $��2* �.+�� $��0�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��* ��� $
��Auto ��� $
��Auto � �� $��* ��� $��* �.+��� $��0��$��0��$��5��  m_skillEditor_003#���  $
��Left=�$��Center=�#��[ #���  $��10(��� $��0��$��1��$��5��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ChunkName_field+�� $��3��$��3��  m_skillEditor_002#���  $
��Left=�$��Center=�#��[ #���  $��10(��� -   $��4��$��5��$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=����� *FilePathList+$ OneWay=�$ PropertyChanged=� �� *SelectedFilePath+ �� *SelectedFilePathIndex+�� $��5��$��0��$��5��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *FilePathTextBox_field+�� $��6��$��0��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���  #���  ���� *AddFilePathCommand+.����   
m_AddEntry#���  #��[ #���  $��12(�$��WrapWithOverflow=� �� TextAlignment$ Center=��� $��6��$��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #���  ���� *DeleteFilePathCommand+.����   m_DeleteEntry#���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=�� $��2�� �� $
��Auto ��� $��* ��� $��5 ��� $
��Auto � �� $��* ��� $��* �.+��� $��0��$��2��  m_skillEditor_004#���  $
��Left=�$��Center=�#��[ #���  $��10(�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $��1��$��2��$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=�$
 True��$
 True������ *
ActionList+$ OneWay=�$ PropertyChanged=� �� *SelectedAction+ �� *SelectedActionIndex+���� .R��� $��0��$ 
Horizontal=�.+��� $��Action ��#��[ #���  $��12(��� #��[ #���  $��12(����� *
ActionID+$ OneWay=�$ PropertyChanged=��� $	�� - ��#��[ #���  $��12(��� #��[ #���  $��12(����� *
ActionType+$ OneWay=�$ PropertyChanged=��� $��3��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddActionCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��3��$��1��$��Stretch=�$��Stretch=�#���  #���  ���� *DeleteActionCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=�� $��2��$��5��$��1��#���   �� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* � �� $
��1.2* ��� $��5 ��� $
��0.7* ��� $��5 ��� $
��2.5* ��� $��5 ��� $
��0.7* �.+��� $��0��$��0��$��1��  m_skillEditor_006#���  $
��Left=�$��Center=�#��[ #���  $��10(��� $��1��$��0��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *SkillType_List+ �� *SkillTypeIndex_field+�� $��3��$��0��$��1��  m_skillEditor_005#���  $
��Left=�$��Center=�#��[ #���  $��10(��� $��4��$��0��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ClassName_field+�� $��6��$��2��$��0��$��Center=�$
��Left=�$	��Top=� d� 	IsChecked �� *SkillEnableHit_field+.����   m_skillEditor_007#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��0��$��2��$��1��  m_skillEditor_008#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+$ 	 Xceed.Wpf.Toolkit.DoubleUpDown  $��2��$��1��� 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]    	Increment  1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]!   Minimum! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�"   Value" �� *SkillHitRadius_field+y��� *ProjectileHitVisibility+�� $��3��$��2��$��1��  m_skillEditor_009#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+  $��2��$��4��  1! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SkillHitVerticalLimit_field+y��� *ProjectileHitVisibility+�� $��6��$��2��$��1��  m_skillEditor_010#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+  $��2��$��7��  1! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SkillHitHorizontalLimit_field+y��� *ProjectileHitVisibility+�� $��9��$��2��$��1��  m_skillEditor_011#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+  $��2��$��10��  1! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *SkillHitWorldRadius_field+y��� *ProjectileHitVisibility+�� $��0��$��4��$��1��  m_skillEditor_012#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+�� $��1��$��4��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *PriorityCategory_List+y��� *ProjectileHitVisibility+ �� *%#SkillHitPriorityCategoryIndex_field+�� $��3��$��4��$��1��  m_skillEditor_013#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��4��$��4���	 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]# 	  	Increment# 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q��
 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]$ 
  Value$ �� *SkillHitPriorityOffset_field+y��� *ProjectileHitVisibility+�� $��6��$��4��$��1��  m_skillEditor_014#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+�� $��7��$��4��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *SkillHitDamageID_field+y��� *ProjectileHitVisibility+�� $��9��$��4��$��1��  m_skillEditor_015#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+�� $��10��$��4��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *Attribute_List+y��� *ProjectileHitVisibility+ �� *" SkillHitAttributeTypeIndex_field+�� $��0��$��6��$��1��  m_skillEditor_016#���  $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+  $��6��$��1��# 1% 
  Minimum% -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *SkillHitPoint_field+y��� *ProjectileHitVisibility+�� $��3��$��6��$��1��   m_skillEditor_017#���   $
��Left=�$��Center=�#��[ #���  $��10(�y��� *ProjectileHitVisibility+  $��6��$��4��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *SkillHitIntervalFrame_field+y��� *ProjectileHitVisibility+�� $��6��$��2��$��6��$��Center=�$
��Left=�$	��Top=� �� *SkillRigidBody_field+y��� *ProjectileHitVisibility+.����  ! m_skillEditor_087#��[! #���  $��Center=�$��Stretch=�#��[ $��10(�� $��4��$��5��$��1��#���   �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��2* ��� $��5 ��� $��2* �.+��� $��0��$��5�� " m_skillEditor_024#��� " $��Center=�$��Center=�#��[ #���  $��16(��� $��1��$��0��$��1�� # m_skillEditor_026#��� # $
��Left=�$��Center=�#��[ #���  $��10(�  $��0��$��2��# 1% -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *ActionID_field+�� $��1��$��2��$��1�� $ m_skillEditor_058#��� $ $
��Left=�$��Center=�#��[ #���  $��10(��� $��2��$��2��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *ActionType_List+ �� *ActionTypeIndex_field+�� $��4��$��0��$��1�� % m_skillEditor_096#��� % $
��Left=�$��Center=�#��[ #���  $��10(��� $��5��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *AnimationChunkName_field+�� $��2��$��2��$��5��$��Center=�$
��Left=�$	��Top=� �� *KeepPreviousAnimation_field+.����  & m_skillEditor_097#��[& #���  $��Center=�$��Stretch=�#��[ $��10(��� $��0,2,0,0q�
���   �$��5q�$��7��$��5������ & �� EndPoint$& 0.5,1&�' �� 
StartPoint$' 0.5,0&�.��� ( � Color$( Transparent��) � Offset$) 0Q�� $( Transparent��$) 1Q�.@��� ���� #��[ $��Center=� ' m_skillEditor_018#��[' #��[ ���  �� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* ��� $��5 ��� $��* � �� $
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
��Auto �.+��� $��0��$��0��$��1�� ( m_skillEditor_027#��� ( $
��Left=�$��Center=�#��[ #���  $��10(�  $��1��$��0��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Gravity_field+�� $��3��$��0��$��1�� ) m_skillEditor_028#��� ) $
��Left=�$��Center=�#��[ #���  $��10(�  $��4��$��0��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Restitution_field+�� $��6��$��0��$��1�� * m_skillEditor_029#��� * $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��0��$��35��  1*   Maximum* 360! -360$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *RandomDirection_field+�� $��9��$��0��$��1�� + m_skillEditor_030#��� + $
��Left=�$��Center=�#��[ #���  $��10(�  $��10��$��0��$��35��  1* 360! -360$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *RandomRoll_field+�� $��12��$��0��$��1�� , m_skillEditor_031#��� , $
��Left=�$��Center=�#��[ #���  $��10(�  $��13��$��0��$��35��  1* 360! -360$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *ViewingAngle_field+�� $��15��$��0��$��1�� - m_skillEditor_032#��� - $
��Left=�$��Center=�#��[ #���  $��10(�  $��16��$��0��$��35��  1! 0* 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Friction_field+�� $��18��$��0��$��1�� . m_skillEditor_036#��� . $
��Left=�$��Center=�#��[ #���  $��10(�  $��19��$��0��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BankStrong_field+�� $��21��$��0��$��1�� / m_skillEditor_042#��� / $
��Left=�$��Center=�#��[ #���  $��10(�  $��22��$��0��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Velocity_field+�� $��0��$��2��$��1�� 0 m_skillEditor_049#��� 0 $
��Left=�$��Center=�#��[ #���  $��10(��� $��1��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *HitAttach_field+�� $��3��$��2��$��1�� 1 m_skillEditor_050#��� 1 $
��Left=�$��Center=�#��[ #���  $��10(��� $��4��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *HitAttach2_field+�� $��6��$��2��$��1�� 2 m_skillEditor_051#��� 2 $
��Left=�$��Center=�#��[ #���  $��10(��� $��7��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *HitAttach3_field+�� $��9��$��2��$��1�� 3 m_skillEditor_052#��� 3 $
��Left=�$��Center=�#��[ #���  $��10(��� $��10��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *HitAttach4_field+�� $��12��$��2��$��1�� 4 m_skillEditor_053#��� 4 $
��Left=�$��Center=�#��[ #���  $��10(��� $��13��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *HitAttach5_field+�� $��15��$��2��$��1�� 5 m_skillEditor_047#��� 5 $
��Left=�$��Center=�#��[ #���  $��10(�  $��16��$��2��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *NumLimitNum_field+�� $��18��$��2��$��1�� 6 m_skillEditor_037#��� 6 $
��Left=�$��Center=�#��[ #���  $��10(�  $��19��$��2��$��35��  1* 360! -360$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BankRollMax_field+�� $��21��$��2��$��1�� 7 m_skillEditor_043#��� 7 $
��Left=�$��Center=�#��[ #���  $��10(�  $��22��$��2��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *VelocityRandomize_field+�� $��0��$��4��$��1�� 8 m_skillEditor_039#��� 8 $
��Left=�$��Center=�#��[ #���  $��10(�  $��1��$��4��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Amplitude_x_field+�� $��3��$��4��$��1�� 9 m_skillEditor_040#��� 9 $
��Left=�$��Center=�#��[ #���  $��10(�  $��4��$��4��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Amplitude_y_field+�� $��6��$��4��$��1�� : m_skillEditor_041#��� : $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��4��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Amplitude_z_field+�� $��9��$��4��$��1�� ; m_skillEditor_033#��� ; $
��Left=�$��Center=�#��[ #���  $��10(�  $��10��$��4��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Frequency_x_field+�� $��12��$��4��$��1�� < m_skillEditor_034#��� < $
��Left=�$��Center=�#��[ #���  $��10(�  $��13��$��4��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Frequency_y_field+�� $��15��$��4��$��1�� = m_skillEditor_035#��� = $
��Left=�$��Center=�#��[ #���  $��10(�  $��16��$��4��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Frequency_z_field+�� $��18��$��4��$��1�� > m_skillEditor_038#��� > $
��Left=�$��Center=�#��[ #���  $��10(�  $��19��$��4��$��35��  1! 0* 1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *BankSpring_field+�� $��21��$��4��$��1�� ? m_skillEditor_044#��� ? $
��Left=�$��Center=�#��[ #���  $��10(�  $��22��$��4��$��35��  1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *Inductivity_field+�� $��0��$��2��$��6��$��Center=�$
��Left=�$��Center=� �� *CharacterHitDisable_field+.����  @ m_skillEditor_045#��[@ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��3��$��2��$��6��$��Center=�$
��Left=�$��Center=� �� *WorldHitDisable_field+.����  A m_skillEditor_046#��[A #���  $��Center=�$��Stretch=�#��[ $��10(��� $��6��$��2��$��6��$��Center=�$
��Left=�$��Center=� �� *NumLimitEnable_field+.����  B m_skillEditor_048#��[B #���  $��Center=�$��Stretch=�#��[ $��10(��� $��9��$��2��$��6��$��Center=�$
��Left=�$��Center=� �� *FixedUp_field+.����  C m_skillEditor_054#��[C #���  $��Center=�$��Stretch=�#��[ $��10(��� $��12��$��2��$��6��$��Center=�$
��Left=�$��Center=� �� *SkillHitMine_field+.����  D m_skillEditor_055#��[D #���  $��Center=�$��Stretch=�#��[ $��10(��� $��15��$��2��$��6��$��Center=�$
��Left=�$��Center=� �� *AtkHitMine_field+.����  E m_skillEditor_056#��[E #���  $��Center=�$��Stretch=�#��[ $��10(��� $��18��$��6��$��1�� F m_skillEditor_057#��� F $
��Left=�$��Center=�#��[ #���  $��10(��� $��19��$��6��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *State_field+�� ���� $��Center=�$
��Left=� �� *ActionEnableHit_field+.���� #��[  G m_skillEditor_019#��[G $��Center=�$��Stretch=�#��[ ���  �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��* ��� $��50 � �� �� $��5 ��� �� $��5 ��� .+��� $��0��$��0��$��1��#���  $
��Left=�$��Center=�#��[ #���  $��10(�  $��0��$��1��$��35��  1! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *ActionHitRadius_field+�� $��3��$��0��$��1��#���  $
��Left=�$��Center=�#��[ #���  $��10(�  $��0��$��4��$��35��  1! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *ActionHitVerticalLimit_field+�� $��6��$��0��$��1��#���  $
��Left=�$��Center=�#��[ #���  $��10(�  $��0��$��7��$��35��  1! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� * ActionHitHorizontalLimit_field+�� $��9��$��0��$��1��#���  $
��Left=�$��Center=�#��[ #���  $��10(�  $��0��$��10��$��35��  1! -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *ActionHitWorldRadius_field+�� $��6��$��2��$��1��#���  $
��Left=�$��Center=�#��[ #���  $��10(��� $��7��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ActionHitDamageID_field+�� $��0��$��2��$��1��#���  $
��Left=�$��Center=�#��[ #���  $��10(�  $��2��$��1��$��35��# 1% -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *ActionHitPoint_field+�� $��3��$��2��$��1��#���   $
��Left=�$��Center=�#��[ #���  $��10(�  $��2��$��4��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *ActionHitIntervalFrame_field+�� ���� #��[ $��Center=� H m_skillEditor_020#��[H #��[ ���  �� $��1* ��� $��5 ��� $��1* ��� $��5 ��� $��4* � �� $��* ��� $��5 ��� $��50 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $��0��$��3��$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=�$
 True��$
 True������ *	SoundList+$ OneWay=�$ PropertyChanged=� �� *SelectedSound+ �� *SelectedSoundIndex+���� .R��� $ 
Horizontal=�.+��� $��Sound: ��#���  $��12(��� #��[ #���  $��12(����� *Code+$ OneWay=�$ PropertyChanged=�� $��0��$��4�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��1�� I m_skillEditor_059#��� I $
��Left=�$��Center=�#��[ #���  $��10(��� $��1��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *
Code_field+�� $��3��$��1�� J m_skillEditor_060#��� J $
��Left=�$��Center=�#��[ #���  $��10(�  $��4��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *Delay_field+�� $��6��$��1�� K m_skillEditor_061#��� K $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *Repeat_field+�� $��9��$��1�� L m_skillEditor_062#��� L $
��Left=�$��Center=�#��[ #���  $��10(�  $��10��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *Interval_field+�� $��2��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddSoundCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��2��$��2��$��Stretch=�$��Stretch=�#���  #���  ���� *DeleteSoundCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��2��$��4��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveSoundCommand+.����  M m_SaveEntry#��� M #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� ���� $��Center=�$
��Left=� �� *UseDecalCheckBox_field+.���� #��[  N m_skillEditor_021#��[N $��Center=�$��Stretch=�#��[ ���  �� $��* ��� $��5 ��� $��50 �.+�� $��0��$��4�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��1�� O m_skillEditor_064#��� O $
��Left=�$��Center=�#��[ #���  $��10(��� $��1��$��2��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *
Decal_List+ �� *SkillDecalTypeIndex_field+�� $��3��$��1�� P m_skillEditor_065#��� P $
��Left=�$��Center=�#��[ #���  $��10(��� $��4��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *DecalTextureName_field+�� $��6��$��1�� Q m_skillEditor_066#��� Q $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��35��  1! 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *DecalHeightScale_field+�� $��9��$��1�� R m_skillEditor_067#��� R $
��Left=�$��Center=�#��[ #���  $��10(�  $��10��$��35��  1! 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *DecalWidthScale_field+�� ���� $��Center=�$
��Left=� �� *UseSkillHoming_field+.���� #��[  S m_skillEditor_088#��[S $��Center=�$��Stretch=�#��[ ���  �� $��* ��� $��5 ��� $��50 �.+�� $��0��$��4�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��1�� T m_skillEditor_089#��� T $
��Left=�$��Center=�#��[ #���  $��10(��� $��1��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *SkillHomingSkillName_field+�� $��3��$��1�� U m_skillEditor_090#��� U $
��Left=�$��Center=�#��[ #���  $��10(��� $��4��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *SkillHomingDummy_field+�� $��6��$��1�� V m_skillEditor_091#��� V $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��35��# 1% -1$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *SkillHomingActionNum_field+�� $��9��$��1�� W m_skillEditor_092#��� W $
��Left=�$��Center=�#��[ #���  $��10(��� $��10��$��2��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *PlayerHomingDummy_field+�� $��12��$��2��$��0��$��Center=�$
��Left=�$	��Top=� �� *UseEnemyHoming_field+.����  X m_skillEditor_093#��[X #���  $��Center=�$��Stretch=�#��[ $��10(��� ���� $��Center=�$
��Left=� �� *UseCameraQuake_field+.���� #��[  Y m_skillEditor_022#��[Y $��Center=�$��Stretch=�#��[ ���  �� $��* ��� $��5 ��� $��50 �.+�� $��0��$��4�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��1�� Z m_skillEditor_069#��� Z $
��Left=�$��Center=�#��[ #���  $��10(�  $��1��$��35��  1! 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *HeightStrength_field+�� $��3��$��1�� [ m_skillEditor_070#��� [ $
��Left=�$��Center=�#��[ #���  $��10(�  $��4��$��35��  1! 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *WidthStrength_field+�� $��6��$��1�� \ m_skillEditor_071#��� \ $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��35��  1! 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *QuakeTime_field+�� $��9��$��1�� ] m_skillEditor_072#��� ] $
��Left=�$��Center=�#��[ #���  $��10(�  $��10��$��35��  1! 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�" �� *PerReduction_field+�� ���� #��[ $��Center=� ^ m_skillEditor_023#��[^ #��[ ���  �� $��1* ��� $��5 ��� $��1* ��� $��5 ��� $��3* � �� $��* ��� $��5 ��� $��40 �.+�)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox 
 -   $��0��$��3��$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=�$
 True��$
 True������ *	EventList+$ OneWay=�$ PropertyChanged=� �� *SelectedEvent+ �� *SelectedEventIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *	EventType+$ OneWay=�$ PropertyChanged=�� $��0��$��4�� �� $��1* ��� $��5 ��� $
��Auto ��� $
��1.4* ��� $��5 ��� $��40 � �� $��* ��� $��5 ��� $��* ��� $��5 ��� $
��3.5* �.+�� $��0��$��5�� �� $
��2.5* ��� $��5 ��� $��* � �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto �.+��� $��0��$��1�� _ m_skillEditor_081#��� _ $
��Left=�$��Center=�#��[ #���  $��10(��� $��1��$��0��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *
Event_List+ �� *EventTypeIndex_field+�� $��0��$��2��$��1�� ` m_skillEditor_082#��� ` $
��Left=�$��Center=�#��[ #���  $��10(�  $��1��$��2��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *EventArgument_field+�� $��3��$��1�� a m_skillEditor_083#��� a $
��Left=�$��Center=�#��[ #���  $��10(��� $��4��$��0��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *Command_List+ �� *EventCommandIndex_field+�� $��3��$��2��$��1�� b m_skillEditor_084#��� b $
��Left=�$��Center=�#��[ #���  $��10(�  $��4��$��2��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *EventCommandParameter_field+�� $��6��$��2��$��0��$��Center=�$
��Left=�$	��Top=� �� *EnableLoopCount_field+.����  c m_skillEditor_085#��[c #���  $��Center=�$��Stretch=�#��[ $��10(��� $��6��$��2��$��1�� d m_skillEditor_086#��� d $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��2��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *LoopCount_field+�� $��2��$��1�� e m_skillEditor_074#��� e $
��Left=�$��Center=�#��[ #���  $��10(��� -   $��3��$��3��$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=����� *
EffectList+$ OneWay=�$ PropertyChanged=� �� *SelectedEffect+ �� *SelectedEffectIndex+���� .R��� $ 
Horizontal=�.+��� #��[ #���  $��12(����� *
EffectName+$ OneWay=�$ PropertyChanged=�� $��3��$��4�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto � �� $��* ��� $��5 ��� $��* �.+��� $��0��$��3�� f m_skillEditor_075#��� f $
��Left=�$��Center=�#��[ #���  $��10(��� $��1��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *EffectName_field+�� $��3��$��1�� g m_skillEditor_076#��� g $
��Left=�$��Center=�#��[ #���  $��10(��� $��4��$��0��$��3��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #���  $��1q����� *ShotType_List+ �� *ShotTypeIndex_field+�� $��6��$��1�� h m_skillEditor_077#��� h $
��Left=�$��Center=�#��[ #���  $��10(�  $��7��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *ShotParam1_field+�� $��6��$��2��$��1�� i m_skillEditor_078#��� i $
��Left=�$��Center=�#��[ #���  $��10(�  $��2��$��7��$��35��# 1% 0$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�$ �� *ShotParam2_field+�� $��9��$��1�� j m_skillEditor_079#��� j $
��Left=�$��Center=�#��[ #���  $��10(��� $��10��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *Coord_field+�� $��9��$��2��$��2��.+��� $��Center=�$
��Left=�$��Center=� �� *TargetDir_field+.����  k m_skillEditor_080#��[k #���  $��Center=�$��Stretch=�#��[ $��10(��� $��Center=�$
��Left=�$��Center=� �� *PlaneDir_field+.����  l m_skillEditor_095#��[l #���  $��Center=�$��Stretch=�#��[ $��10(��� $��5��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddEffectCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��5��$��2��$��Stretch=�$��Stretch=�#���  #���  ���� *DeleteEffectCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��5��$��4��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveEffectCommand+.����  m m_skillEditor_100#��� m #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��2��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddEventCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��2��$��2��$��Stretch=�$��Stretch=�#���  #���  ���� *DeleteEventCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��2��$��4��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveEventCommand+.����  n m_skillEditor_099#��� n #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��8��$��5��$��1��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveSkillCommand+.����  o m_skillEditor_101#��� o #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=�� $��6��$��1��$��3��$��3�� �� $��2* ��� $��5 ��� $��2* ��� $��5 ��� $��* � �� $��* ��� $��5 ��� $��* �.+�� $��2��$��0��$��5�� �� $��1* ��� $��5 ��� $��1* ��� $��5 ��� $��1* �.+��� $��2��$��0��$��Stretch=�$��Stretch=�#���  #���  ���� *AddSkillCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��2��$��2��$��Stretch=�$��Stretch=�#���  #���  ���� *DeleteSkillCommand+.���� #���  #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��2��$��4��$��Stretch=�$��Stretch=�#���  #���  ���� *DuplicateSkillCommand+.����  p 
m_DupEntry#��� p #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��0��$��0��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *SkillTextBox_field+�� $��0��$��5��$��Stretch=�$��Stretch=�#���  #���  ���� *SearchSkillCommand+.����  q m_SearchEntry#��� q #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=��� $��6��$��5��$��Stretch=�$��Stretch=�#���  #���  ���� *SaveActionCommand+.����  r m_skillEditor_103#��� r #��[ #���  $��12(�$��WrapWithOverflow=�$ Center=�