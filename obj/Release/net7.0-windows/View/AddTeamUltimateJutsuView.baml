   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  )clr-namespace:NSC_ToolboxNSC_Toolbox  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  /    )NSC_Toolbox.View.AddTeamUltimateJutsuView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     ,local2clr-namespace:NSC_Toolbox     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 1Controls"clr-namespace:NSC_Toolbox.Controls 
 5
properties$clr-namespace:NSC_Toolbox.Properties 
 0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��   m_addTUJ � Title# �   $	��800��$	��900������   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources 4  .NSC_Toolbox.Converter.GetNameFromPathConverter  GetNameFromPathConverter*  $NSC_Toolbox.Converter.BitImageLoader  BitImageLoader4   .NSC_Toolbox.Converter.CharacodeToNameConverter  CharacodeToNameConverter��%-   &	       &	      &	 
           .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $	��800��$	��900��.+� 	 Xceed.Wpf.Toolkit.Wizard     FinishButtonClosesWindow$
 True��   HelpButtonVisibility$ Hidden=�  
NarutoFont#��[ $	��800��$	��900��.@�" 	 Xceed.Wpf.Toolkit.WizardPage  -     Name$ 	IntroPage��  m_addTUJ_intro_title   Title# �    m_addTUJ_intro_desc   Description# �  
�������   BackButtonVisibility$ Hidden=� % !Toolbox_button_background_color_1#���     NextPage ��  �� ElementName$ Page1��   ExteriorPanelBackground �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve$��3��$��0��$��WrapWithOverflow=�$
��Left=�$	��Top=�#��[ 
������� 	 m_addTUJ_warning#��� 	 $��14(�  -   $ Page1��
�������#���  # �   
 m_addTUJ_page1_desc# � 
  �� $ Page2��   PreviousPage �� $ 	IntroPage��   CanSelectNextPage �� *IsRootFolderExist+ �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  � RowDefinitions �� $
��Auto ��� $��35 ��� $��5 ��� $
��Auto � � ColumnDefinitions �� $��2* ��� $��5 ��� $��1* �.+�� $��1��$��3�� �� $��2* ��� $��5 ��� $��* �.+��� $��4��$��0��$��1��  m_addTUJ_page1_002#���  $��Stretch=�$��Stretch=� % !Toolbox_button_background_color_2#���   ! Toolbox_button_border_color_1#���  #��[   Toolbox_button_text_color_1#���  $��12(����� *SelectRootFolderCommand+�� $��4��$��2��$��1��  m_addCostume_page2_011#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *RefreshRootFolderCommand+�� $��0��$��0��$
��Left=�$��Center=�#��[ #���    m_addTUJ_page1_001#���  $��12(��� $��1��$��0��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *RootFolderPath_field+�� $��3��$��0��$��3��$��WrapWithOverflow=�$
��Left=�$��Stretch=�#��[ 
���  �� �� TextAlignment$
 Left=�$��14(����� *MissingFiles_field+  -   $ Page2��
�������#���  # �    m_addTUJ_page2_desc# �  	 False   NextButtonVisibility$ Hidden=� �� $ Page1�� �� $= 7/Resources/Styles/UI/background/wizard_background_1.png��$ RelativeToBoundingBox=�$ RelativeToBoundingBox=�$ UniformToFill=�.���  �� $
��Auto ��� $��* ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto � �� $��1* ��� $��5 ��� $��1* �.+��� $��0��$��3��  m_addTUJ_page2_001#���  $
��Left=�$��Center=�#��[ #���  $��12(��� -   $��1��$��2��$ �� IsSynchronizedWithCurrentItem$
 TrueY�#���  #���  $��1q�$��Stretch=�$��Stretch=����� *CharacodeIDList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex �� *SelectedCharacodeIDIndex+���� .R���  �� Orientation$ Vertical=�.+��� $ 
Horizontal=�.+��� $��Characode ID: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(����� �� $ 
Horizontal=�.+��� $��Name: ��#��[ 
��� ���$��12(��� #��[ #���  $��12(���`�   `� 	Converter#  [ .1��� $
 .��� $%
 DataContext.ImportCharacterList�! �� RelativeSource! �� " �� AncestorType
" Window�� $��3��$��3��  m_addCostume_page2_001#���  $
��Left=�$��Center=�#��[ #���  $��12(��� # �� DisplayMemberPath$# CharacodeName��$��3��$��4��$��1��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *ImportCharacterList+$ �� SelectedItem$ �� *ImportCharacterItem+� $��2��$��6�� �� $��* ��� $��* � �� $��* �.+��� $��0��$��0��  
m_AddEntry#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddCharacodeEntryCommand+��   m_DeleteEntry#���  $��1��$��Stretch=�$��Stretch=� % !Toolbox_button_background_color_3#���  #���  #��[ #���  $��12(����� *DeleteCharacodeEntryCommand+� $��0��$��0��$��7�� �� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 ��� $
��Auto ��� $��5 �.+��� $��0��$��0��$
��Left=�$��Center=�#��[ #���    m_addTUJ_page2_003#���  $��10(��� $��0��$��1��% �� 	MaxLength$% 15��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *TUJ_label_field+�� $��0��$��3��$
��Left=�$��Center=�#��[ #���    m_addTUJ_page2_004#���  $��10(��� $��0��$��4��#���  $��Stretch=�$��Stretch=�#��[ #���  #���  $��1q����� *TUJ_Name_field+�� $��6��$
��Left=�#��[   m_pairSpSkill_memberCount#���  #���  $��10(�%	 	 Xceed.Wpf.Toolkit.IntegerUpDown	  $��7��$��30��#��[ #���  #���  $��1q��
 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]& 
  	Increment& 1� 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]'   Maximum' 3(   Minimum( 1#���  )   Value) �� *MemberCount_field+��   m_pairSpSkill_flag1#���  $��9��$��0��* d� 	IsChecked* �� *Condition1_field+��   m_pairSpSkill_flag2#���  $��11��$��0��* �� *Condition2_field+�� $��9��$��0��$��50��$��3��  m_addTUJ_page2_002#���  $��Stretch=�$��Stretch=�#���  #���  #��[ #���  $��12(����� *AddTUJCommand+