   M S B A M L   `   `   `  ����F  BMagicMirror, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MagicMirror.ViewsMagicMirror.Views  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   
btnOpStyle  �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name J� SnapsToDevicePixels �� Triggers P� Property	 P� Value
 �� 
TargetName  HeaderCloseButton3   -System.Windows.Media.Effects.DropShadowEffect    Color    	Direction    ShadowDepth    
BlurRadius(   "MagicMirror.Views.MessageBoxWindow � RowDefinitions �� CornerRadius ��Name �� Padding �� TextAlignment �� Orientation J� Effect �� 	IsDefault�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      )localclr-namespace:MagicMirror.Views  5      %  &	        &	 �    '  �    7  7   7   7   7   �� 5      "  ��6   .�5   
   ��  � ��
 �����67   �� 5   
    � ��$ 25��6#   60   �� 5   
    � ��$ 60��6"   6/   �� 5	   
    � ��$ 5q�6#   6/   �� 5
   
    � ��$ 微软雅黑)�6'   66   �� 5   
    � ��$ 14(�6%   62   �� 5   
    � �� 5      �� 5      " ��6"   .R�5      � $ btnGrid��6   .+�5      �� $ 	rectangle��6$   
��� ������	#AACCCCCC6C   �� 5      #��z��6+   ��. # z 6�   #��z��6�   5       5      P� 5       �@J�IsMouseOver	 . . �5      �� $
 btnGrid��67    �@�Cursor$
 Hand��6L   �� 5      $
 	rectangle��65    � ��
 � ���6L   5      5      5      5      �� 5      "  ��6&   .�5   
   ��  � ��$ 18(�6%   �� 5    
    � ��$ Webdings)�6'   �� 5!   
    � ��$ 5,0,0,0q�6#   �� 5"   
    � ��$ Right=�60   �� 5#   
    � ��$	 Top=�6.   �� 5$   
    � �� �#FDFDFD6'   �� 5%   
    � |� .  6&   �� 5&   
    � �� 5'      �� 5(      " ��6"   .R�5)      � $ btnGrid��6   .+�5*      �� #��z��6+   ��. # z 6�   #��z��6�   5+       5,      P� 5-       �@J�IsMouseOver	 . . �5.      ��  � �� �	#FFF9EE906;   �� 5/       �@J�Effect 50   "      51   &   $ White��67   $ 0Q�6E   $ 0Q�6S   $ 20Q�6c   53      54      56      58      59      �� 5;      "   6   .�5=   
   ��  � �� 5>      �� 5?      "  6"   .R�5@      �  5A      �� 5B      $��40 �6,   �� 5C      $��* �6,   .+�5F      �� 
��� ���$��0��63   $��40��6A   $ 5,5,0,0��6M   ���#e0e0e0$��1,1,1,0q�6z   ._�5G      � .+�5H   "   �� $ 
PART_Title��6,   ���#eef4fb$ 10q�6l   $��Stretch=�5I   ,   $	��Top=�6J   $
 Left=�6c   $��15(�6x   ��5H   @   �� *Title+5I   x   �� 5J   "   $ 
Horizontal=�6-   $��0,5,5,0q�6F   $��Right=�6W   $	��Top=�6s   .+�5K   &   �� $��CloseButton��6-   8��  $��r��6k   ��6w   �� *CloseCommand+5L   #   5M      5N      �� 5P      $ 0,0,5,5��6!   $��1��68   ���#e0e0e0$��2,0,2,2q�6[   
�������# z 6�   ._�5Q      � $��1��6R   $��0q�6_   ��6#   �� *ContentFlowDirection+ 5R   "   �� 5S   &   $��* �64   �� 5T   &   $��40 �64   .+�5W   "   �� $ 
Horizontal=�6-   
�������$��Center=�6Y   $��10,20q�6t   .+�5X   &   �� $
��Left=�6R   $��Center=�6m   $
��None=�6�   ��6,   �� *MessageImageSource+6�   �� 5Y   &   $
��Wrap=�6I   $
 Left=�6]   $	��Top=�5Z   0   $
��10,0q�6H   $	��280��6V   ��5Y   0   �� *	Message+��6r   �� *ContentTextAlignment+5Z   V   5[   #   �� 5]   "   $��1��6)   ���	#FFE6E6E6$��0 1 0 0q�6M   ���	#FFDFDFDF._�5^   &   �� $ 
Horizontal=�61   $��Center=�6J   $��Right=�6e   $��0 0 5 0q�6�   .+�5_   *   �� $	��是��61   8�� y�6=   �� *YesNoVisibility+��6d   �� *
YesCommand+ 6�   �� *IsYesDefault+6�   �� 5`   *   $	��否��61   8�� y�6=   �� *YesNoVisibility+��6d   �� *	NoCommand+ 6�   �� *IsNoDefault+6�   �� 5a   *   $��确定��61   8�� y�6>   �� *OkVisibility+��6b   �� *	OkCommand+ 6�   �� *IsOkDefault+6�   �� 5b   *   $��取消��61   8�� y�6>   �� *CancelVisibility+��6f   �� *CancelCommand+ 6�   �� *IsCancelDefault+6�   5c   '   5d   #   5e      5f      5g      5h      5j      5k      5l      