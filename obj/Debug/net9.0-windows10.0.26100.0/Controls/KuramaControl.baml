   M S B A M L   `   `   `  ����F  BNSC-Toolbox, Version=1.6.5.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NSC_Toolbox.ControlsNSC_Toolbox.Controls  5      (    "NSC_Toolbox.Controls.KuramaControl   5      W SPresentationCore, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=9.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:NSC_Toolbox.Controls     5        � 	Resources  5         KuramaTailAnimation �� 
TargetType �� Property �� Value �� Triggers P� Property P� Value N� EnterActions �� TargetProperty	 W� From	
 W� To g� Duration g� AccelerationRatio g� DecelerationRatio g� RepeatBehavior g� AutoReverse  KuramaTailAnimation_2  KuramaTailAnimation_3  NoChromeButton �� 
TargetType �Name J� SnapsToDevicePixels �� Triggers��%�  &	        &	 �    &	 ,    &	 �    �� 5	   
   " ��6,   .�5
      ��  � z� 5      �� 5      5       5      P� 5       � {�$
 True��6/    5      �� 5      .��5      �� .��5   "   W� $ RenderTransform.Angle�5   )   	 -105   )   
 105   )   $ 0:0:1.5D�5   )   $	 0.2Q�5   )   $	 0.2Q�5   )   $ Forever��5   )   $
 True��5   )   5      5      5       5"      �� 5#   
   " ��6.   .�5$      ��  � z� 5%      �� 5&      5(       5)      P� 5*       � {�$
 True��6/    5+      �� 5,      .��5-      �� .��5.   "   W� $ RenderTransform.Angle�5/   )   	 1050   )   
 -1051   )   $ 0:0:2D�52   )   $	 0.3Q�53   )   $	 0.3Q�54   )   $ Forever��55   )   $
 True��56   )   57      58      5:      5<      �� 5=   
   " ��6.   .�5>      ��  � z� 5?      �� 5@      5B       5C      P� 5D       � {�$
 True��6/    5E      �� 5F      .��5G      �� .��5H   "   W� $ RenderTransform.Angle�5I   )   	 -145J   )   
 155K   )   $ 0:0:2.4D�5L   )   $	 0.3Q�5M   )   $	 0.3Q�5N   )   $ Forever��5O   )   $
 True��5P   )   5Q      5R      5T      5V      �� 5W   
   " ��6'   .�5X      ��  � ��
 ���� 6+   �� 5Y       � ��$ 0q�60   �� 5Z       � ��
 ���� 6+   �� 5[       � ��$ Center=�6;   �� 5\       � ��$ Center=�69   �� 5]       � ��$ 1q�6(   �� 5^       � �� 5_      �� 5`      " ��6&   .R�5a      � $ Chrome��6   #��z��6/   $
 true��6Y   .+�5b      �� #��z��6/   #��z��6r   $
��True��6�   # z 6�   #��z��6�   5c       5d      P� 5e       � ��$
 True��6;    5f   "   �� 5g   &   .��5h   *   �� .��5i   .   W� $ Height�5j   1   	 2205k   1   
 2105l   1   $ 0:0:0.1D�5m   1   $
 True��5n   1   5o   +   5p   '   5r      5t      5v      5w      5y      .��5z      � $	��300��6   $	��200��6   .+�5{   
   �� -   5         ��Name$ KuramaTailImage_3��5{   l   #��[ 6   $	��180��6A   $	��150��6N   $��Uniform=�6Z     KuramaTail_4#���  6�    �� BitmapScalingMode$ HighQuality=�6�    K� ZIndex$ 0��6�    J� RenderTransformOrigin$ 0.501,0.848&�6�   $��	0,-60,0,0q�6  �� 5|   
   -   5        $ KuramaTailImage_2��5|   i   #��[  6   $	��180��6>   $	��150��6K   $��Uniform=�6W     KuramaTail_3#���  6�   $ HighQuality=�6�   $ 0��6�   $ 0.937,0.675&�6�   $��-116,0,0,-27q�6  �� 5}   
   #��[ 6   $ 10��6:   $	��220��6L   $	��220��6Y   .��5~      �� -   5        $ KuramaBodyImage��5~   &   $��Uniform=�6     
KuramaBody#���  6?   $ HighQuality=�6q   $ 1��6�   5�      �� 5�   
   -   5        $ KuramaTailImage��5�   k   #��[ 6   $	��180��6@   $	��150��6M   $��Uniform=�6Y     KuramaTail_2#���  6�   $ HighQuality=�6�   $ 0��6�   $ 0.008,0.708&�6�   $��0,0,-145,-24q�6  5�      5�      