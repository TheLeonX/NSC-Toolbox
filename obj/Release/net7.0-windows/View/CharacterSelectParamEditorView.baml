   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null3clr-namespace:NSC_Toolbox.ViewNSC_Toolbox.View  =#clr-namespace:NSC_Toolbox.ConverterNSC_Toolbox.Converter  ;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  ?$clr-namespace:NSC_Toolbox.PropertiesNSC_Toolbox.Properties  U QSystem.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3aS:clr-namespace:System.Globalization;assembly=System.RuntimeSystem.Globalization 5    /NSC_Toolbox.View.CharacterSelectParamEditorView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     0localclr-namespace:NSC_Toolbox.View     9	converter#clr-namespace:NSC_Toolbox.Converter     D @ModernWpf, Version=0.9.6.0, Culture=neutral, PublicKeyToken=nullM	 IModernWpf.Controls, Version=0.9.6.0, Culture=neutral, PublicKeyToken=null,ui!http://schemas.modernwpf.com/2019  	 ]
 YXceed.Wpf.Toolkit.NET5, Version=4.5.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit 
 5xcdg*http://schemas.xceed.com/wpf/xaml/datagrid 
 U QWpfAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=9e7cd3b544a090dc,gif"http://wpfanimatedgif.codeplex.com  1Controls"clr-namespace:NSC_Toolbox.Controls  5
properties$clr-namespace:NSC_Toolbox.Properties  NGlobalization:clr-namespace:System.Globalization;assembly=System.Runtime  $	��750��$	��900��0  *ModernWpf.Controls.Primitives.WindowHelper    UseModernWindowStyle$
  True��    m_CharacterSelectParamEditor � Title# �   ����   TitleBackground �� ImageSource# �   j� ViewboxUnits$ RelativeToBoundingBox=� j� ViewportUnits$ RelativeToBoundingBox=� j� Stretch$ UniformToFill=� � 	Resources .  (NSC_Toolbox.Converter.PageIndexConverter  PageIndexConverter��%   &	         .��(�  (� Stretch �� %   NSC_Toolbox.Properties.Settings   Default	 �� Source#	 Z 
 �� Path$
 StretchMode�.��� $
��1000��$
��1230��.+��  � ColumnDefinitions �� $��5 ��� $��3* ��� $��5 ��� $��* ��� $��5 ��� $��2* ��� $��5 � � RowDefinitions �� $��50 ��� $��4* ��� $��2* ��� $��5 ��� $��50 ��� $��5 ��� $��50 ��� $��5 �.+�o� $��0��$��5��$��Stretch=�$��Stretch=�  
NarutoFont#��[   Toolbox_button_text_color_1#���  .@�m�  
 m_File#���  #��[ #���  .@�m�   
m_OpenFile#���  #��[ 
������� m� Command �� *OpenFileCommand+m�   
m_SaveFile#���  #��[ 
������� �� *SaveFileCommand+m�   m_SaveAsFile#���  #��[ 
������� �� *SaveFileAsCommand+m�  	 m_CSP_SortEntries#��� 	 #��[ #���   �� *SortEntriesCommand+� $��1��$��3�� %
 !Toolbox_button_background_color_1#��� 
 $��Stretch=�$��Stretch=� �� $��* ��� $��* ��� $��* � �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��10��$��10�� ! Toolbox_button_border_color_1#���  $��1q��� $��0��$��0�� K� ZIndex$ 0������  �� 
TargetType" ��.���  �� Property � ��  charsel_empty_icon �� Value# �   �� Triggers ��  �� Binding �� *SlotIndex_field+ �� Value 1.a���  � ��  charsel_brt_icon# �  �� $��0��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 2.a���  � ��# �  �� $��0��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 3.a���  � ��# �  �� $��1��$��0��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 4.a���  � ��# �  �� $��1��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 5.a���  � ��# �  �� $��1��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 6.a���  � ��# �  �� $��2��$��0��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 7.a���  � ��# �  �� $��2��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 8.a���  � ��# �  �� $��2��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 9.a���  � ��# �  �� $��3��$��0��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 10.a���  � ��# �  �� $��3��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 11.a���  � ��# �  �� $��3��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 12.a���  � ��# �  �� $��4��$��0��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 13.a���  � ��# �  �� $��4��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 14.a���  � ��# �  �� $��4��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 15.a���  � ��# �  �� $��5��$��0��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 16.a���  � ��# �  �� $��5��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 17.a���  � ��# �  �� $��5��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 18.a���  � ��# �  �� $��6��$��0��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 19.a���  � ��# �  �� $��6��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 20.a���  � ��# �  �� $��6��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 21.a���  � ��# �  �� $��7��$��0��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 22.a���  � ��# �  �� $��7��$��1��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 23.a���  � ��# �  �� $��7��$��2��$ 0������ " ��.���  � ��# �   ��  �� *SlotIndex_field+ 24.a���  � ��# �  �� $��3��$��10��$��Bottom=�$��Center=�$��	0,0,0,-30q�.����  �� Orientation$ 
Horizontal=�.+��� #��[ #���  ���� *PageIndex_field+ �� 	Converter# [  �� StringFormat$ 
<Page {0}>�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 10Q�   ShadowDepth$ 0Q�   Opacity$ 1Q�   Color$ Orange��)clr-namespace:NSC_ToolboxNSC_Toolbox  �� -WpfExtensionsclr-namespace:NSC_Toolbox  -   $��2��$ �� IsSynchronizedWithCurrentItem$
 TrueY�$��1��$��1��#��� 
 #���  $��1q�$��Stretch=�$��Stretch=� J� 	AllowDrop$
 True��#   NSC_Toolbox.DragDropExtension   ScrollOnDragDrop$
 True������ *CharacterSelectParamList+  �� Mode$  OneWay=�! �� UpdateSourceTrigger$! PropertyChanged=�" �� SelectedItem" �� *SelectedCSP+# �� SelectedIndex# �� *SelectedCSPIndex+���� .R��� $ 
Horizontal=�.+��� $��
PSP Code: ��#��[ 
����� �$��12(��� #��[ 
�������$��12(����� *
CSP_code+$  OneWay=�$! PropertyChanged=��� $�� Page: ��#��[ 
��� ���$��12(��� #��[ 
�������$��12(����� *	PageIndex+$  OneWay=�$! PropertyChanged=��� $�� Slot: ��#��[ 
�������$��12(��� #��[ 
�������$��12(����� *	SlotIndex+�� $��
 Costume: ��#��[ 
��� � �$��12(��� #��[ 
�������$��12(����� *CostumeIndex+$  OneWay=�$! PropertyChanged=�� $��1��$��5��$��4�� �� $��* ��� $��5 ��� $��3* �.+�� -   $ �Name$
$ grid��$��0��.+��� #��� 
 #���  $��1q�$��Stretch=�$��Stretch=�.��� ���� % �� ElementName$
% grid��$
 Width����� $
% grid��$
 Height� �� $��* ��� $��10 ��� $��* ��� $��15 � �� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto ��� $
��auto �.+���   m_csp_P1_NOT_SEL_X#���  $��0��$��0��$��Right=�$��Center=�#��[ $��10(�
����� ���   m_csp_P1_NOT_SEL_Y#���  $��0��$��1��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P1_NOT_SEL_Z#���  $��0��$��2��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P2_NOT_SEL_X#���  $��0��$��3��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P2_NOT_SEL_Y#���  $��0��$��4��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P2_NOT_SEL_Z#���  $��0��$��5��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P1_SEL_X#���  $��0��$��6��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P1_SEL_Y#���  $��0��$��7��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P1_SEL_Z#���  $��0��$��8��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P2_SEL_X#���  $��0��$��9��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P2_SEL_Y#���  $��0��$��10��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P2_SEL_Z#���  $��0��$��11��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P1_VSLOAD_X#���  $��0��$��12��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P1_VSLOAD_Y#���  $��0��$��13��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P1_VSLOAD_Z#���  $��0��$��14��$��Right=�$��Center=�#��[ 
����� �$��10(���   m_csp_P2_VSLOAD_X#���  $��0��$��15��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P2_VSLOAD_Y#���  $��0��$��16��$��Right=�$��Center=�#��[ 
����i��$��10(���   m_csp_P2_VSLOAD_Z#���  $��0��$��17��$��Right=�$��Center=�#��[ 
����i��$��10(���    m_csp_P1_NOT_SEL_ROT#���   $��0��$��18��$��Right=�$��Center=�#��[ 
����� �$��10(���  ! m_csp_P2_NOT_SEL_ROT#��� ! $��0��$��19��$��Right=�$��Center=�#��[ 
����i��$��10(���  " m_csp_P1_SEL_ROT#��� " $��0��$��20��$��Right=�$��Center=�#��[ 
����� �$��10(���  # m_csp_P2_SEL_ROT#��� # $��0��$��21��$��Right=�$��Center=�#��[ 
����i��$��10(���  $ m_csp_P1_VSLOAD_ROT#��� $ $��0��$��22��$��Right=�$��Center=�#��[ 
����� �$��10(���  % m_csp_P2_VSLOAD_ROT#��� % $��0��$��23��$��Right=�$��Center=�#��[ 
����i��$��10(���  & m_csp_P1_LIGHT_NOT_SEL_X#��� & $��0��$��24��$��Right=�$��Center=�#��[ 
����� �$��10(���  ' m_csp_P1_LIGHT_NOT_SEL_Y#��� ' $��0��$��25��$��Right=�$��Center=�#��[ 
����� �$��10(���  ( m_csp_P1_LIGHT_NOT_SEL_Z#��� ( $��0��$��26��$��Right=�$��Center=�#��[ 
����� �$��10(���  ) m_csp_P2_LIGHT_NOT_SEL_X#��� ) $��0��$��27��$��Right=�$��Center=�#��[ 
����i��$��10(���  * m_csp_P2_LIGHT_NOT_SEL_Y#��� * $��0��$��28��$��Right=�$��Center=�#��[ 
����i��$��10(���  + m_csp_P2_LIGHT_NOT_SEL_Z#��� + $��0��$��29��$��Right=�$��Center=�#��[ 
����i��$��10(���  , m_csp_P1_LIGHT_SEL_X#��� , $��0��$��30��$��Right=�$��Center=�#��[ 
����� �$��10(���  - m_csp_P1_LIGHT_SEL_Y#��� - $��0��$��31��$��Right=�$��Center=�#��[ 
����� �$��10(���  . m_csp_P1_LIGHT_SEL_Z#��� . $��0��$��32��$��Right=�$��Center=�#��[ 
����� �$��10(���  / m_csp_P2_LIGHT_SEL_X#��� / $��0��$��33��$��Right=�$��Center=�#��[ 
����i��$��10(���  0 m_csp_P2_LIGHT_SEL_Y#��� 0 $��0��$��34��$��Right=�$��Center=�#��[ 
����i��$��10(���  1 m_csp_P2_LIGHT_SEL_Z#��� 1 $��0��$��35��$��Right=�$��Center=�#��[ 
����i��$��10(���  2 m_csp_P1_LIGHT_VSLOAD_X#��� 2 $��0��$��36��$��Right=�$��Center=�#��[ 
����� �$��10(���  3 m_csp_P1_LIGHT_VSLOAD_Y#��� 3 $��0��$��37��$��Right=�$��Center=�#��[ 
����� �$��10(���  4 m_csp_P1_LIGHT_VSLOAD_Z#��� 4 $��0��$��38��$��Right=�$��Center=�#��[ 
����� �$��10(���  5 m_csp_P2_LIGHT_VSLOAD_X#��� 5 $��0��$��39��$��Right=�$��Center=�#��[ 
����i��$��10(���  6 m_csp_P2_LIGHT_VSLOAD_Y#��� 6 $��0��$��40��$��Right=�$��Center=�#��[ 
����i��$��10(���  7 m_csp_P2_LIGHT_VSLOAD_Z#��� 7 $��0��$��41��$��Right=�$��Center=�#��[ 
����i��$��10(���  8 m_csp_P1_CUSTOMIZATION_X#��� 8 $��0��$��42��$��Right=�$��Center=�#��[ 
����� �$��10(���  9 m_csp_P1_CUSTOMIZATION_Y#��� 9 $��0��$��43��$��Right=�$��Center=�#��[ 
����� �$��10(���  : m_csp_P1_CUSTOMIZATION_Z#��� : $��0��$��44��$��Right=�$��Center=�#��[ 
����� �$��10(���  ; m_csp_P1_CUSTOMIZATION_ROT#��� ; $��0��$��45��$��Right=�$��Center=�#��[ 
����� �$��10(���  "< m_csp_P1_LIGHT_CUSTOMIZATION_X#��� < $��0��$��46��$��Right=�$��Center=�#��[ 
����� �$��10(���  "= m_csp_P1_LIGHT_CUSTOMIZATION_Y#��� = $��0��$��47��$��Right=�$��Center=�#��[ 
����� �$��10(���  "> m_csp_P1_LIGHT_CUSTOMIZATION_Z#��� > $��0��$��48��$��Right=�$��Center=�#��[ 
����� �$��10(���  ? m_csp_P2_CUSTOMIZATION_X#��� ? $��0��$��49��$��Right=�$��Center=�#��[ 
����i��$��10(���  @ m_csp_P2_CUSTOMIZATION_Y#��� @ $��0��$��50��$��Right=�$��Center=�#��[ 
����i��$��10(���  A m_csp_P2_CUSTOMIZATION_Z#��� A $��0��$��51��$��Right=�$��Center=�#��[ 
����i��$��10(���  B m_csp_P2_CUSTOMIZATION_ROT#��� B $��0��$��52��$��Right=�$��Center=�#��[ 
����i��$��10(���  "C m_csp_P2_LIGHT_CUSTOMIZATION_X#��� C $��0��$��53��$��Right=�$��Center=�#��[ 
����i��$��10(���  "D m_csp_P2_LIGHT_CUSTOMIZATION_Y#��� D $��0��$��54��$��Right=�$��Center=�#��[ 
����i��$��10(���  "E m_csp_P2_LIGHT_CUSTOMIZATION_Z#��� E $��0��$��55��$��Right=�$��Center=�#��[ 
����i��$��10(�$ 
 Xceed.Wpf.Toolkit.DoubleUpDown  , 
 &Xceed.Wpf.Toolkit.Primitives.InputBase&   	Watermark#& �  $��2��$��0��#��[ #��� 
 #���  $��1q�� 
 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]'   	Increment' .001#���  $��8(��	 
 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Double, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]( 	  Value( �� *P1_not_sel_pos_x_field+  #& �  $��2��$��1��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_not_sel_pos_y_field+  #& �  $��2��$��2��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_not_sel_pos_z_field+  #& �  $��2��$��3��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_not_sel_pos_x_field+  #& �  $��2��$��4��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_not_sel_pos_y_field+  #& �  $��2��$��5��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_not_sel_pos_z_field+  #& �  $��2��$��6��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_sel_pos_x_field+  #& �  $��2��$��7��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_sel_pos_y_field+  #& �  $��2��$��8��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_sel_pos_z_field+  #& �  $��2��$��9��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_sel_pos_x_field+  #& �  $��2��$��10��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_sel_pos_y_field+  #& �  $��2��$��11��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_sel_pos_z_field+  #& �  $��2��$��12��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_vsload_x_field+  #& �  $��2��$��13��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_vsload_y_field+  #& �  $��2��$��14��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_vsload_z_field+  #& �  $��2��$��15��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_vsload_x_field+  #& �  $��2��$��16��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_vsload_y_field+  #& �  $��2��$��17��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_vsload_z_field+  #& �   $��2��$��18��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_not_sel_rot_field+  #& � ! $��2��$��19��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_not_sel_rot_field+  #& � " $��2��$��20��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_sel_rot_field+  #& � # $��2��$��21��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_sel_rot_field+  #& � $ $��2��$��22��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_vsload_rot_field+  #& � % $��2��$��23��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_vsload_rot_field+  #& � & $��2��$��24��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_not_sel_light_x_field+  #& � ' $��2��$��25��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_not_sel_light_y_field+  #& � ( $��2��$��26��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_not_sel_light_z_field+  #& � ) $��2��$��27��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_not_sel_light_x_field+  #& � * $��2��$��28��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_not_sel_light_y_field+  #& � + $��2��$��29��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_not_sel_light_z_field+  #& � , $��2��$��30��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_sel_light_x_field+  #& � - $��2��$��31��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_sel_light_y_field+  #& � . $��2��$��32��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_sel_light_z_field+  #& � / $��2��$��33��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_sel_light_x_field+  #& � 0 $��2��$��34��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_sel_light_y_field+  #& � 1 $��2��$��35��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_sel_light_z_field+  #& � 2 $��2��$��36��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_vsload_light_x_field+  #& � 3 $��2��$��37��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_vsload_light_y_field+  #& � 4 $��2��$��38��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_vsload_light_z_field+  #& � 5 $��2��$��39��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_vsload_light_x_field+  #& � 6 $��2��$��40��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_vsload_light_y_field+  #& � 7 $��2��$��41��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_vsload_light_z_field+  #& � 8 $��2��$��42��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_customization_pos_x_field+  #& � 9 $��2��$��43��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_customization_pos_y_field+  #& � : $��2��$��44��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_customization_pos_z_field+  #& � ; $��2��$��45��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P1_customization_rot_field+  #& � < $��2��$��46��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� * P1_customization_light_x_field+  #& � = $��2��$��47��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� * P1_customization_light_y_field+  #& � > $��2��$��48��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� * P1_customization_light_z_field+  #& � ? $��2��$��49��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_customization_pos_x_field+  #& � @ $��2��$��50��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_customization_pos_y_field+  #& � A $��2��$��51��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_customization_pos_z_field+  #& � B $��2��$��52��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� *P2_customization_rot_field+  #& � C $��2��$��53��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� * P2_customization_light_x_field+  #& � D $��2��$��54��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� * P2_customization_light_y_field+  #& � E $��2��$��55��#��[ #��� 
 #���  $��1q�' .001#���  $��8(�( �� * P2_customization_light_z_field+� $��2�� �� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 ��� $��1* ��� $��2* ��� $��5 �� $��2�� �� $
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
��Auto ��� $��* ��� $��5 �.+��� $��0��$
��Left=�#��[  F m_playerSettingParamID#��� F #���  $��10(��� -   ) ��Name$) CSPEntryCodeName��$��1��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *CSP_code_field+�� $��3��$
��Left=�#��[  G m_pageIndex#��� G #���  $��10(�%
 
 Xceed.Wpf.Toolkit.IntegerUpDown
  $��4��#��[ #��� 
 #���  $��1q�� 
 �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]*   	Increment* 1#���  � 
 �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]], System.Runtime, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a]]+   Value+ �� *PageIndex_field+�� $��6��$
��Left=�#��[  H m_SlotIndex#��� H #���  $��10(�
  $��7��#��[ #��� 
 #���  $��1q�* 1#���  + �� *SlotIndex_field+�� $��9��$
��Left=�#��[  I m_CostumeIndex#��� I #���  $��10(�
  $��10��#��[ #��� 
 #���  $��1q�* 1#���  + �� *CostumeIndex_field+�� $��12��$
��Left=�#��[  J m_CostumeDescription#��� J #���  $��10(��� -   $) CSPCostumeDescriptionName��$��13��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *CostumeDescription_field+�� $��15��$
��Left=�#��[  K m_CostumeName#��� K #���  $��10(��� -   $) CSPCostumeNameName��$��16��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *CostumeName_field+�� $��18��$
��Left=�#��[  L m_Accessory#��� L #���  $��10(��� -   $) CSPAccessoryName��$��19��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *Accessory_field+�� $��21��$
��Left=�#��[  M m_charselFile#��� M #���  $��10(��� -   $) CSPCharselFileName��$��22��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *CharselAnimation_field+�� $��24��$
��Left=�#��[  N m_dictionary#��� N #���  $��10(��� -   $) CSPDictionaryName��$��25��#���  #��[ $	��200��$��Stretch=�$��Stretch=�#��� 
 #���  $��1q����� *DictionaryCode_field+�� $��27��$
��Left=�#��[  O m_dictionaryIndex#��� O #���  $��10(�
  $��28��#��[ #��� 
 #���  $��1q�* 1#���  + �� *DictionaryIndex_field+�� $��30��$
��Left=�#��[  P 	m_unknown#��� P #���  $��10(�
  $��31��#��[ #��� 
 #���  $��1q�* 1#���  + �� *	Unk_field+� $��1��$��3��$��4�� �� $��* ��� $��* � �� $��* ��� $��* �.+��� $��0�� Q m_AddDupEntry#��� Q $��Stretch=�$��Stretch=� %R !Toolbox_button_background_color_2#��� R #���  #��[ #���  $��12(����� *AddDupEntryCommand+��  S m_DeleteEntry#��� S $��1��$��Stretch=�$��Stretch=� %T !Toolbox_button_background_color_3#��� T #���  #��[ #���  $��12(����� *DeleteEntryCommand+��  U m_SearchEntry#��� U $��2��$��1��$��Stretch=�$��Stretch=�#��� R #���  #��[ #���  $��12(����� *SearchEntryCommand+�� #���  #��[ $��2��$��0��$��Stretch=�$��Stretch=�$��Center=�#��� 
 #���  $��1q����� *SearchTextBox_field+�� $��5��$��3��$��2��$��3�� V m_SaveEntry#��� V $��Stretch=�$��Stretch=�#��� R #���  #��[ #���  $��12(����� *SaveEntryCommand+� $��10��$��10��y��� *LoadingStatePlay+ �� $��10 ��� $��* ��� $	��100 ��� $��10 � �� $��10 ��� $��* ��� $	��100 ��� $��10 �.+�)   #NSC_Toolbox.Controls.LoadingControl  $��2��$��2��,   LoadingState, �� *LoadingStatePlay+