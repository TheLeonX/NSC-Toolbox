   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  )clr-namespace:NSC_ToolboxNSC_Toolbox  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  %    NSC_Toolbox.View.AddCostumeView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     ,local2clr-namespace:NSC_Toolbox     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_addCostume_title � Title# �   $	��800��$	��900������   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources 4  .NSC_Toolbox.Converter.GetNameFromPathConverter  GetNameFromPathConverter*  $NSC_Toolbox.Converter.BitImageLoader  BitImageLoader��%   &	       &	          .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $	��800��$	��900��.+� 	 Xceed.Wpf.Toolkit.Wizard     FinishButtonClosesWindow$
 True��   HelpButtonVisibility$ Hidden=�  
NarutoFont#��[ $	��800��$	��900��.@�" 	 Xceed.Wpf.Toolkit.WizardPage  -     Name$ 	IntroPage��  m_addCostume_intro_title   Title# �    m_addCostume_intro_desc   Description# �  
�������   BackButtonVisibility$ Hidden=� % !Toolbox_button_background_color_1#���     NextPage ��  �� ElementName$ Page1��   ExteriorPanelBackground �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve$��3��$��0��$��WrapWithOverflow=�$
��Left=�$	��Top=�#��[ 
�������  m_addCostume_warning#���  $��14(�  -   $ Page1��
�������#���  # �   	 m_addCostume_page1_desc# � 	  �� $ Page2��   PreviousPage �� $ 	IntroPage��   CanSelectNextPage �� *IsDataWin32Exist+ �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  � RowDefinitions �� $
��Auto ��� $��35 ��� $��5 ��� $
��Auto � � ColumnDefinitions �� $��2* ��� $��5 ��� $��1* �.+�� $��1��$��3�� �� $��2* ��� $��5 ��� $��* �.+��� $��4��$��0��$��1�� &
 "m_exportMod_page1_datawin32_select#��� 
 $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���   ! Toolbox_button_border_color_1#���  #��[   Toolbox_button_text_color_1#���  $��12(����� *SelectDataWin32Command+�� $��4��$��2��$��1��  m_addCostume_page2_011#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *RefreshDataWin32Command+�� $��0��$��0��$
��Left=�$��Center=�#��[ #���    m_exportMod_page1_datawin32#���  $��12(��� $��1��$��0��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *DataWin32Path_field+�� $��3��$��0��$��3��$��WrapWithOverflow=�$
��Left=�$��Stretch=�#��[ 
���  �� �� TextAlignment$
 Left=�$��14(����� *MissingFiles_field+  -   $ Page2��
�������#���  # �    m_addCostume_page2_desc# �  	 False   NextButtonVisibility$ Hidden=� �� $ Page1�� �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  �� $
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
��Auto ��� $��* ��� $
��Auto � �� $��1* ��� $��5 ��� $��1* �.+��� $��0��$��0��  m_addCostume_page2_001#���  $
��Left=�$��Center=�#��[ #���  $��12(���  �� DisplayMemberPath$ CharacodeName��$��0��$��1��$��3��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ImportCharacterList+ �� SelectedItem �� *ImportCharacterItem+�� $��3��$��0��  m_addCostume_page2_002#���  $
��Left=�$��Center=�#��[ #���  $��12(���  �� 	MaxLength$ 7��$��0��$��4��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *BaseCostumeCode_field+ �� UpdateSourceTrigger$ PropertyChanged=��� $��6��$��0��  m_addCostume_page2_003#���  $
��Left=�$��Center=�#��[ #���  $��12(��� $��0��$��7��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *BaseCostumeIcon_field+$ PropertyChanged=��� $��3��$��2��  m_addCostume_page2_004#���  $
��Left=�$��Center=�#��[ #���  $��12(��� $ 7��$��2��$��4��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *AwakeCostumeCode_field+$ PropertyChanged=��� $��6��$��2��  m_addCostume_page2_005#���  $
��Left=�$��Center=�#��[ #���  $��12(��� $��2��$��7��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *AwakeCostumeIcon_field+$ PropertyChanged=��� $��10��$��2��$��Center=�$
��Left=� d� 	IsChecked �� *EnableArmorBreak_field+$ PropertyChanged=�.����   m_addCostume_page2_007#��[ #���  $��Center=�$��Stretch=�#��[ $��10(��� $��9��$��0��  m_addCostume_page2_006#���  $
��Left=�$��Center=�#��[ #���  $��12(�% 	 Xceed.Wpf.Toolkit.IntegerUpDown  $��0��$��10��$��1���	 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]  	  	Increment  1�
 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]! 
  Minimum! 1" 
  Maximum" 4$��Center=�$��Stretch=�$��Stretch=�#��[ #���  #���  #���  $��1q�# 
  Value# �� *AltColorCount_field+$ PropertyChanged=��� $��12��$��2��  m_addCostume_page2_008#���  $
��Left=�$��Center=�#��[ #���  $��12(��� $��2��$��13��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *CostumeName_field+$ PropertyChanged=��� $��12��$��0��  m_addCostume_page2_009#���  $
��Left=�$��Center=�#��[ #���  $��12(��� $��0��$��13��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *CostumeDescription_field+$ PropertyChanged=��� $��15��$��0��$��3��$��WrapWithOverflow=�$
��Left=�$��Stretch=�#��[ 
�������  m_addCostume_page2_warning#���  $
 Left=�$��14(��� $��17��$��0��$��50��$��3��  m_addCostume_page2_010#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddCostumeCommand+� $��10��$��10��$ K� ZIndex$$ 10��
������ y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��%   LoadingState% �� *LoadingStatePlay+