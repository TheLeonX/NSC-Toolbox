   M S B A M L   `   `   `  ����F  BNSC-Toolbox, Version=1.6.5.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  5   	   )clr-namespace:NSC_ToolboxNSC_Toolbox  5   	   =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  5   	   ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  5   8   ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  5   	   /    )NSC_Toolbox.View.AddTeamUltimateJutsuView   5   	   W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:NSC_Toolbox.View     5   	   ,local2clr-namespace:NSC_Toolbox     5   	   9	converter#clr-namespace:NSC_Toolbox.Converter     5   	   D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019   5	   	   ]	 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 	 5
   	   5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 	 5   	   U
 QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com 
 5   	   1Controls"clr-namespace:NSC_Toolbox.Controls 
 68   5
properties$clr-namespace:NSC_Toolbox.Properties 
 5   	   0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��5   	      m_addTUJ � Title# �   5   	   $	��800��6,   $	��900��69   ��5      �� 5   
     TitleBackground �� ImageSource# �  6    j� ViewboxUnits$ RelativeToBoundingBox=�6Q    j� ViewportUnits$ RelativeToBoundingBox=�6v    j� Stretch$ UniformToFill=�6�    � 	Resources 5      4  .NSC_Toolbox.Converter.GetNameFromPathConverter  GetNameFromPathConverter*  $NSC_Toolbox.Converter.BitImageLoader  BitImageLoader4   .NSC_Toolbox.Converter.CharacodeToNameConverter  CharacodeToNameConverter��%W   &	       &	      &	 &       5   
   6-     5   
   6#     5   
   6-   5      .��5      (�  (� Stretch 6   �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��5   
   � $	��800��6   $	��900��6   .+�5       	 Xceed.Wpf.Toolkit.Wizard     FinishButtonClosesWindow$
 True��6      HelpButtonVisibility$ Hidden=�6:     
NarutoFont#��[ 6Y   $	��800��6�   $	��900��6�   .@�5      " 	 Xceed.Wpf.Toolkit.WizardPage  -   5          Name$ 	IntroPage��5   "     m_addTUJ_intro_title   Title# �  5   )     m_addTUJ_intro_desc   Description# �  5   )   
�������   BackButtonVisibility$ Hidden=�5!   )    % !Toolbox_button_background_color_1#���  5#   )      NextPage 5"   )   ��  �� ElementName$ Page1��   ExteriorPanelBackground 5$      �� 5%      $= 7/Resources/Styles/UI/background/wizard_background_1.png��6%   $ RelativeToBoundingBox=�6k   $ RelativeToBoundingBox=�6�   $ UniformToFill=�6�   .��5'      �� 2  ,System.Windows.Markup.XmlAttributeProperties  XmlSpace preserve6  $��3��66   $��0��6D   $��WrapWithOverflow=�6T   $
��Left=�6t   $	��Top=�6�   #��[ 6�   
������� 	 m_addTUJ_warning#��� 	 6�   $��14(�6  5)        5*      -   5        $ Page1��5*   "   
�������#���  5,   )   # �  5-   )    
 m_addTUJ_page1_desc# � 
 5.   )    5/   )   �� $ Page2��   PreviousPage 50   )   �� $ 	IntroPage��   CanSelectNextPage 51   )   �� *IsRootFolderExist+ 52      �� 53      $= 7/Resources/Styles/UI/background/wizard_background_1.png��6%   $ RelativeToBoundingBox=�6k   $ RelativeToBoundingBox=�6�   $ UniformToFill=�6�   .��55      �  � RowDefinitions 56      �� 57      $
��Auto �6,   �� 58      $��35 �6,   �� 59      $��5 �6,   �� 5:      $
��Auto �6,    � ColumnDefinitions 5<      �� 5=      $
��1.2* �6/   �� 5>      $��5 �6/   �� 5?      $
��1.4* �6/   .+�5A      � $��1��6   $��3��6,    5B      �� 5C   "   $��2* �63   �� 5D   "   $��5 �63   �� 5E   "   $��* �63   .+�5H      �� $��4��6Q   $��0��6^   $��1��6n     m_addTUJ_page1_002#���  6�   $��Stretch=�6�   $��Stretch=�6�    % !Toolbox_button_background_color_2#���  6�    ! Toolbox_button_border_color_1#���  6.  #��[ 6l    Toolbox_button_text_color_1#���  6�  $��16(�6�  ��6%   �� *SelectRootFolderCommand+6�  �� 5I      $��4��6R   $��2��6_   $��1��6o     m_addCostume_page2_011#���  6�   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #���  63  #��[ 6q  #���  6�  $��16(�6�  ��6%   �� *RefreshRootFolderCommand+6�  5J      �� 5K      $��0��6    $��0��6.   $
��Left=�6?   $��Center=�6Z   #��[ 6v   #���  6�     m_addTUJ_page1_001#���  6�   $��16(�6
  �� 5L      $��1��6"   $��0��6/   #���  6e   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #���  6D  $��1q�6�  ��6?   �� *RootFolderPath_field+6�  �� 5M      $��3��6$   $��0��62   $��3��6B   $��WrapWithOverflow=�6V   $
��Left=�6v   $��Stretch=�6�   #��[ 6�   
���  �� �� TextAlignment$
 Left=�6  $��14(�6   ��6�   �� *MissingFiles_field+6   5O      5P        5Q      -   5        $ Page2��5Q   "   
�������#���  5S   )   # �  5T   )     m_addTUJ_page2_desc# �  5U   )   	 False5W   )      NextButtonVisibility$ Hidden=�5X   "    5V   )   �� $ Page1�� 5Y      �� 5Z      $= 7/Resources/Styles/UI/background/wizard_background_1.png��6%   $ RelativeToBoundingBox=�6k   $ RelativeToBoundingBox=�6�   $ UniformToFill=�6�   .��5\      �  5]      �� 5^      $
��Auto �6,   �� 5_      $��* �6,   �� 5`      $��5 �6,   �� 5a      $
��Auto �6,   �� 5b      $
��Auto �6,   �� 5c      $��5 �6,   �� 5d      $
��Auto �6,   �� 5e      $��5 �6,   �� 5f      $
��Auto �6,    5h      �� 5i      $��1* �6/   �� 5j      $��5 �6/   �� 5k      $��1* �6/   .+�5m      �� $��0��6    $��3��6.     m_addTUJ_page2_001#���  6>   $
��Left=�6n   $��Center=�6�   #��[ 6�   #���  6�   $��16(�6
  �� 5n      -   5        $��1��5n   "   $��2��6/   $ �� IsSynchronizedWithCurrentItem$
 TrueY�5o   
   #���  5r   
   #���  5s   
   $��1q�5t   
   $��Stretch=�5u   
   $��Stretch=�5v   
   ��5q   
   �� *CharacodeIDList+ �� Mode$ OneWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex 5w   
   �� *SelectedCharacodeIDIndex+��5x      �� 5y   "   .R�5z   &   ��  �� Orientation$ Vertical=�61   .+�5{   *   �� $ 
Horizontal=�65   .+�5|   .   �� $��Characode ID: ��68   #��[ 5}       
��� ���$��16(�5       �� 5�   .   #��[ 5�       #���  5�       $��16(�5�       ��5�   8   �� 5�       5�   +   �� 5�   *   $ 
Horizontal=�65   .+�5�   .   �� $��Name: ��68   #��[ 5�       
��� ���$��16(�5�       �� 5�   .   #��[ 68   #���  5�      $��16(�5�      ��5�   2   `� 5�   6     `� 	Converter#  [ 6C   .1�5�   :   �� $
 .�6B   �� 5�   :   $%
 DataContext.ImportCharacterList�6B   ! �� RelativeSource! 5�      �� " �� AncestorType
" Window5�   7   5�   /   5�   +   5�   '   5�   #   5�      �� 5�      $��3��6    $��3��6.     m_addCostume_page2_001#���  6>   $
��Left=�6r   $��Center=�6�   #��[ 6�   #���  6�   $��16(�6  �� 5�      # �� DisplayMemberPath$# CharacodeName��6|   $��3��6�   $��4��6�   $��1��6�   #���  6�   $��Stretch=�6  $��Stretch=�6'  #��[ 6E  #���  6n  #���  6�  $��1q�6�  ��6#   �� *ImportCharacterList+$ �� SelectedItem$ 6O   �� *ImportCharacterItem+6�  � 5�      $��2��6   $��6��6/    5�      �� 5�   "   $��* �63   �� 5�   "   $��* �63    5�      �� 5�   "   $��* �60   .+�5�      �� $��0��6R   $��0��6b     
m_AddEntry#���  6o   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #���  6  #��[ 6Q  #���  6z  $��16(�6�  ��6%   �� *AddCharacodeEntryCommand+6�  �� 5�        m_DeleteEntry#���  6U   $��1��6�   $��Stretch=�6�   $��Stretch=�6�    % !Toolbox_button_background_color_3#���  6�   #���  6  #��[ 6J  #���  6s  $��16(�6�  ��6%   �� *DeleteCharacodeEntryCommand+6�  5�      � 5�      $��0��6   $��0��6/   $��7��6<    5�      �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60   �� 5�   "   $��5 �60   �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60   �� 5�   "   $��5 �60   �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60   �� 5�   "   $��5 �60   �� 5�   "   $
��Auto �60   �� 5�   "   $��5 �60   �� 5�   "   $
��Auto �60   �� 5�   "   $��5 �60   .+�5�      �� $��0��6$   $��0��65   $
��Left=�6B   $��Center=�6]   #��[ 6y   #���  6�     m_addTUJ_page2_003#���  6�   $��14(�6  �� 5�      $��0��6&   $��1��66   % �� 	MaxLength$% 15��6d   #���  6s   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #���  6R  $��1q�6�  ��6C   �� *TUJ_label_field+6�  �� 5�      $��0��6$   $��3��65   $
��Left=�6B   $��Center=�6]   #��[ 6y   #���  6�     m_addTUJ_page2_004#���  6�   $��14(�6  �� 5�      $��0��6&   $��4��66   #���  6c   $��Stretch=�6�   $��Stretch=�6�   #��[ 6�   #���  6  #���  6B  $��1q�6�  ��6C   �� *TUJ_Name_field+6�  �� 5�      $��6��6$   $
��Left=�61   #��[ 6L     m_pairSpSkill_memberCount#���  6u   #���  6�   $��14(�6�   %	 	 Xceed.Wpf.Toolkit.IntegerUpDown	  5�      $��7��61   $��30��6>   #��[ 6q   #���  6�   #���  6�   $��1q�6  �
 	 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]& 
  	Increment& 16.  � 	 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]'   Maximum' 36<  (   Minimum( 16H  #���  6T  )   Value) 6M   �� *MemberCount_field+6T  �� 5�        m_pairSpSkill_flag1#���  6(   $��9��6   $��0��6�   * d� 	IsChecked* 6X   �� *Condition1_field+6�   �� 5�        m_pairSpSkill_flag2#���  6(   $��11��6   $��0��6�   * 6X   �� *Condition2_field+6�   5�      �� 5�      $��9��6!   $��0��6.   $��50��6`   $��3��6o     m_addTUJ_page2_002#���  6�   $��Stretch=�6�   $��Stretch=�6�   #���  6�   #���  6/  #��[ 6m  #���  6�  $��16(�6�  ��6>   �� *AddTUJCommand+6�  5�      5�      5�      5�      5�      5�      