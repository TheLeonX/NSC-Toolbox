   M S B A M L   `   `   `  ���� F  BNSC-Toolbox, Version=1.6.2.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  (    "NSC_Toolbox.Controls.KuramaControl   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     4local"clr-namespace:NSC_Toolbox.Controls       � 	Resources     KuramaTailAnimation �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value N� EnterActions �� TargetProperty	 W� From	
 W� To g� Duration g� AccelerationRatio g� DecelerationRatio g� RepeatBehavior g� AutoReverse  KuramaTailAnimation_2  KuramaTailAnimation_3  NoChromeButton �� 
TargetType �Name J� SnapsToDevicePixels �� Triggers��%�  &	        &	 �     &	 z    &	 8    �� " ��.���  � z� ��  P�  � {�$
 True�� �� .���� .��W� $ RenderTransform.Angle�	 -10
 10$ 0:0:1.5D�$	 0.2Q�$	 0.2Q�$ Forever��$
 True���� " ��.���  � z� ��  P�  � {�$
 True�� �� .���� .��W� $ RenderTransform.Angle�	 10
 -10$ 0:0:2D�$	 0.3Q�$	 0.3Q�$ Forever��$
 True���� " ��.���  � z� ��  P�  � {�$
 True�� �� .���� .��W� $ RenderTransform.Angle�	 -14
 15$ 0:0:2.4D�$	 0.3Q�$	 0.3Q�$ Forever��$
 True���� " ��.���  � ��
 ���� ��  � ��$ 0q���  � ��
 ���� ��  � ��$ Center=���  � ��$ Center=���  � ��$ 1q���  � �� �� " ��.R�� $ Chrome��#��z��$
 true��.+��� #��z��#��z��$
��True��# z #��z�� P�  � ��$
 True�� �� .���� .��W� $ Height�	 220
 210$ 0:0:0.1D�$
 True��.��� $	��300��$	��200��.+��� -    ��Name$ KuramaTailImage_3��#��[ $	��180��$	��150��$��Uniform=�  KuramaTail_4#���   �� BitmapScalingMode$ HighQuality=� K� ZIndex$ 0�� J� RenderTransformOrigin$ 0.501,0.848&�$��	0,-60,0,0q��� -   $ KuramaTailImage_2��#��[  $	��180��$	��150��$��Uniform=�  KuramaTail_3#���  $ HighQuality=�$ 0��$ 0.937,0.675&�$��-116,0,0,-27q��� #��[ $ 10��$	��220��$	��220��.���� -   $ KuramaBodyImage��$��Uniform=�  
KuramaBody#���  $ HighQuality=�$ 1���� -   $ KuramaTailImage��#��[ $	��180��$	��150��$��Uniform=�  KuramaTail_2#���  $ HighQuality=�$ 0��$ 0.008,0.708&�$��0,0,-145,-24q�