   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  )clr-namespace:NSC_ToolboxNSC_Toolbox  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter      NSC_Toolbox.MainWindow   /Controls"clr-namespace:NSC_Toolbox.Controls  W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     +localclr-namespace:NSC_Toolbox     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 3	converter#clr-namespace:NSC_Toolbox.Converter 
 0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_Title � Title# �   $	��800��$	��900������   TitleBackground �� ImageSource# �   j� Stretch$ UniformToFill=� � 	Resources   NoChromeButton �� 
TargetType �� Property �� Value �� 
TargetType	 �Name
 J� SnapsToDevicePixels �� Triggers P� Property P� Value N� EnterActions �� TargetProperty W� From	 W� To g� Duration g� AutoReverse��%�  &	       �� " ��.���  � ��
 ���� ��  � ��$ 0q���  � ��
 ���� ��  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� $	 Chrome��#��z��$

 true��.+��� #��z��#��z��$
��True��#
 z
 #��z�� P�  � ��$
 True�� �� .���� .��W� $ MinWidth� 330 340$ 0:0:0.1D�$
 True��.��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default �� Source# Z  �� Path$ StretchMode�.��� .+��  � ShowGridLines$ False��$
��1000��$
��1000��y��� *MainWindowVisibility+ � ColumnDefinitions �� $��1* ��� $��2* � � RowDefinitions �� $��6* ��� $��70 ��� $��1* �.+�� $��1�� �� $��50 ��� $��* �.+��� $��0��
�������$��0,0,0,1q�o� $��Stretch=�  
NarutoFont#��[ .@�m�   m_mainWindow_006#���    Toolbox_button_text_color_1#���  .@�m�   m_mainWindow_010#���  #���   m� Command �� *InstallModdingAPICommand+m�   m_mainWindow_011#���  #���   �� *DeleteModdingAPICommand+m� #���   �� *VisitModdingGroupCommand+����  �� Orientation$ 
Horizontal=�.+�F� $��Center=����	#FF4B1C67#���    Discord_logo#���  �� $��5,0,0,0q� �� TextAlignment$
 Left=�$��Center=� 	 m_mainWindow_007#��� 	 m�  
 m_mainWindow_012#��� 
 #���   �� *BoostyCommand+m�   m_mainWindow_013#���  #���   �� *VisitGitHubPageCommand+m�   m_mainWindow_008#���  #���   �� *CreditsCommand+m�   m_mainWindow_005#���  #���   �� *OptionsCommand+� $��1��$��20q� % !Toolbox_button_background_color_1#���  y��� *CharacterManagementVisibility+.+��� -   $��1��$��1��$��Stretch=�$��Center=�$��Stretch=�$��50�� % !Toolbox_button_background_color_2#���   ! Toolbox_button_border_color_2#���  #��[ #���  $��14(����� *CharacodeRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_001#���  �� -   $��1��$��3��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *'%DuelPlayerParamEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_002#���  �� -   $��1��$��5��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *$"PlayerSettingParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_003#���  �� -   $��1��$��7��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *&$CharacterSelectParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_004#���  �� -   $��1��$��9��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *+)SkillCustomizeParamEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_005#���  �� -   $��1��$��11��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *#!AfterAttachObjectRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_006#���  �� -   $��1��$��13��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *PRMEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_007#���  �� -   $��1��$��15��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *CostumeParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_008#���  �� -	   $��1��$��17��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *)'PlayerDoubleEffectParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_018#���  �� -
   $��1��$��19��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� * cmnparamEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_017#���  �� -   $��1��$��21��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *$"SupportActionParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_025#���  �� -   $��3��$��1��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *PlayerIconRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_009#���  �� -   $��3��$��3��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *AwakeAuraRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_010#���  �� -   $��3��$��5��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *AppearanceAnmRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_013#���  �� -   $��3��$��7��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *'%SpSkillCustomizeParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�  m_mainWindowTool_012#���  �� -   $��3��$��9��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *.,SkillIndexSettingParamEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=�   m_mainWindowTool_011#���   �� -   $��3��$��11��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *PRMLoadEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� ! m_mainWindowTool_014#��� ! �� -   $��3��$��13��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *$"SpTypeSupportParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� " m_mainWindowTool_015#��� " �� -   $��3��$��15��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *PrivateCameraRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� # m_mainWindowTool_016#��� # �� -   $��3��$��17��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *#!CostumeBreakParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� $ m_mainWindowTool_019#��� $ �� -   $��3��$��19��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *(&CostumeBreakColorParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� % m_mainWindowTool_020#��� % �� -   $��3��$��21��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��12(����� *0.SupportSkillRecoverySpeedParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� & m_mainWindowTool_026#��� & �� $��20��$��50��
�������$��2,2,2,2q� �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 � �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 �� $��1��$��20q�#���  y��� *OtherToolsVisibility+.+��� -   $��1��$��1��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *!StageInfoEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� ' m_mainWindowTool_022#��� ' �� -   $��1��$��3��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *DamageEffRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� ( m_mainWindowTool_024#��� ( �� -   $y�Visible=�$��1��$��5��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *SkillEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� ) m_mainWindowTool_027#��� ) �� -   $��3��$��1��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *#!MessageInfoEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� * m_mainWindowTool_023#��� * �� -   $��3��$��3��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *EffectPrmRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� + m_mainWindowTool_021#��� + �� -   $��3��$��5��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *-+PairSpSkillCombinationParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� , m_mainWindowTool_028#��� , �� -   $��1��$��7��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *0.SpecialInteractionManagerParamRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� - m_mainWindowTool_029#��� - �� -   $��3��$��7��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��14(����� *$"ConditionprmEditorRunButtonCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� . m_mainWindowTool_030#��� . �� $��20��$��50��
�������$��2,2,2,2q� �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 � �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 �� $��1��$��20q�#���  y��� *OptionsVisibility+.+��� $��1��$��1��$��1��$
��Left=�$��Center=�#��[  / m_option001#��� / #���  $��10(��� $��1��$��2��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���   !0 Toolbox_button_border_color_1#��� 0 $��1q� �� SelectedIndex �� *StretchMode_field+.@��� .����  1 m_option002#��[1 #���  $��Stretch=�$��Stretch=�#��[ �� .����  2 m_option003#��[2 #���  $��Stretch=�$��Stretch=�#��[ �� .����  3 m_option005#��[3 #���  $��Stretch=�$��Stretch=�#��[ �� $��1��$��4��$��1��$
��Left=�$��Center=�#��[  4 m_option006#��� 4 #���  $��10(�# 	 Xceed.Wpf.Toolkit.ColorPicker  $��1��
���   �$��5��#��[ #���  #��� 0 $��1q�   SelectedColor �� *BackgroundColor_field+  �� Mode$  TwoWay=��� $��1��$��7��$��1��$
��Left=�$��Center=�#��[  5 m_option007#��� 5 #���  $��10(�  $��1��
���   �$��8��#��[ #���  #��� 0 $��1q� �� *ButtonColor_field+$  TwoWay=��� $��3��$��1��$
��Left=�$��Center=�#��[  6 m_option011#��� 6 #���  $��10(�  $��3��
���   �$��2��#��[ #���  #��� 0 $��1q� �� *TextColor_field+$  TwoWay=��� $��1��$��10��$
��Left=�$��Center=�#��[  7 m_option008#��� 7 #���  $��10(��� $��1��$��11��#���  $��Stretch=�$��Stretch=�#��[ #���  #��� 0 $��1q����� *BackgroundImagePath_field+�� $��3��$��1��$��11��$��Stretch=�$��Center=�$��Stretch=�#���  #���  #��[ #���  $��14(����� *SelectImageBackgroundCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� 8 m_option010#��� 8 �� $��1��$��13��$
��Left=�$��Center=�#��[  9 
m_language#��� 9 #���  $��10(��� $��1��$��14��$��1��#���  $��Stretch=�$��Stretch=�$
��Left=�#��[ #���  #��� 0 $��1q� �� *Language_field+.@��� .����  : m_language_en-US#��[: #���  $��Stretch=�$��Stretch=�#��[ �� .����  ; m_language_ru-RU#��[; #���  $��Stretch=�$��Stretch=�#��[ �� $��40��$��40��
�������$��2,2,2,2q��� $��1��$��1��$��34��$��Stretch=�$��Center=�$��Stretch=�#���  #���  #��[ #���  $��14(����� *SaveSettingsCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� < m_option004#��� < �� $��3��$��1��$��34��$��Stretch=�$��Center=�$��Stretch=�#���  #���  #��[ #���  $��14(����� *ResetSettingsCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� = m_option009#��� =  �� $��10 ��� $��* ��� $��10 ��� $��* ��� $��10 � �� $��10 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $��* ��� $��5 ��� $��* ��� $��10 ��� $��1��
�������$��1,0,0,1q�$��1���� ! K� ZIndex$! 5��.+��� $	��330��#��[ $��Center=�$��Center=�.����  > ToolboxLogo#��� > $��20q�" �� BitmapScalingMode$" HighQuality=��� $! 5��$��10q�$��Stretch=�$��50��#���  #��� 0 #��[  ? m_mainWindow_001#��� ? #���  $��23(����� *CharacterManagementCommand+�� $! 5��$��10q�$��Stretch=�$��50��#���  #��� 0 #��[  @ m_mainWindow_004#��� @ #���  $��23(����� *OtherToolsCommand+�� $! 5��$��10q�$��Stretch=�$��50��#���  #��� 0 #��[  A m_addCostume_title#��� A #���  $��23(����� *AddCostumeCommand+�� $! 5��$��10q�$��Stretch=�$��50��#���  #��� 0 #��[  B m_addTUJ#��� B #���  $��21(����� *AddTUJCommand+�� $! 5��$��10q�$��Stretch=�$��50��#���  #��� 0 #��[  C m_mainWindow_009#��� C #���  $��23(����� *ExportModCommand+(   "NSC_Toolbox.Controls.KuramaControl  $��0��$��3��$��Bottom=�$��Center=�$! 0��$��Stretch=�$��Stretch=�y��� *KyurutoVisibility+�� $��0��$��0�� D KuramaDialogNameBackground#��� D $" HighQuality=�$	��270��$��Right=�$��Bottom=�$��0,0,-131,-91q�� $��1��$��2��$��-120,0,20,10q�#���  $��Stretch=�.+��� $��1��
�������$��1,1,1,1q�$��5���� $
 Left=�$
��Left=�$	��Top=�$��
50,-47,0,0q�$��WrapWithOverflow=�#��[ #���  $��30(����� *
KuramaName+�� $	��740��$
 Left=�$
��Left=�$	��Top=�$��	20,10,0,0q�$��WrapWithOverflow=�#��[ #���  $��20(����� *KuramaDialog+� $ False��$
��1000��$
��1000��$��3��#���  y��� *Credits2024Visibility+ �� $
��0.3* ��� $��1* ��� $��1* ��� $��5* ��� $��1* ��� $��2* ��� $��10 ��� $��50 ��� $��10 � �� $��10 ��� $��3* ��� $
��0.2* ��� $��3* ��� $
��0.2* ��� $��3* ��� $��10 �.+��� $��1��$��1��$��5��$��Center=�$��Center=�#��[  E m_credits_001#��� E #���  $��45(��� $��1��$��2��$��5��$��Center=�$��Center=�#��[  F m_credits_002#��� F #���  $��40(��� $��1��$��3��.+��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Carrington Bennett��
���  ��$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��
justcamtro��
���  ��$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��EliteAce��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Chakra Warrior��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��
Halucygeno��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��little Damien��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��HydraBladeZ��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Jonathan Nefores��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Anime Knight��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��
Alex Olney��
��� ���$��25(��� $��3��$��3��.+��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Nate Roberts��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Shoii��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��	Steinixos��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��UltimateOmbuStorm��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Amritz kenzy��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Naggingclub5��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Jonas Martinez��
��� ���$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��N&D Productions��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��The Brothers��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Shoyo��
�������$��25(��� $��5��$��3��.+��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $
��G3ku��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Hunter Yang��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Aleksa Nikolić��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��	Ceaz Azce��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $!��Клим Сапранков��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��dark94��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��	许誉骞��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Fearless Intelligent��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Erik Petrosyan��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Moeru Storm��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Bully��
�������$��25(��� $��1��$��4��$��5��$��Center=�$��Center=�#��[  G m_credits_003#��� G #���  $��40(��� $��1��$��5��.+��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��HydraBladeZ��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��SutandoTsukai��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��ZealotTormunds��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $	��dei��
�������$��25(��� $��3��$��5��.+��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��
justcamtro��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Chakra Warrior��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $
��Xact��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Portable Productions��
�������$��27(��� $��5��$��5��.+��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��exavadeathwitch��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Xuân Thái��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��Dark Madara��
�������$��25(��� $��0��$��2��$��1��$��Center=�$��Center=�#��[ $��EliteAce��
�������$��25(��� $��3��$��7��$��1��$��Right=�$��Center=�#��[ $
��2024��
�������$��27(��� $��5��$��7��$��Stretch=�$��Center=�$��Stretch=�$��50��#���  #���  #��[ #���  $��20(����� *MainMenuCommand+.���� $��WrapWithOverflow=�$��Center=�$ Center=� H m_credits_004#��� H �� $��1��$��1��
�������$��1,1,1,1q�$��7��$��5��