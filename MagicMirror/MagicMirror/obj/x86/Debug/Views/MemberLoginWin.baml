   M S B A M L   `   `   `  ����F  BMagicMirror, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MagicMirror.ConvertersMagicMirror.Converters  5   
   &     MagicMirror.Views.MemberLoginWin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   :	converter$clr-namespace:MagicMirror.Converters     5   
   c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5   	     � Title$  TryingProductAlertWin��5   	   
������  � WindowStyle$
 None=�5   	    � AllowsTransparency .  � WindowState$ 	Maximized=�66    � 	Resources 5
         LoadStoryboard g� Duration W� From	 W� To �� 
TargetName	 �� TargetProperty  UnLoadStoryboard  mainClientAreaStoryboard8  2System.Windows.Media.Animation.EasingColorKeyFrame
 �� KeyTime �� Value t� From	 t� To g� AutoReverse2  ,MagicMirror.Converters.IndentParentConverter  indentParentConverter��%�  &	        &	 P    &	 �    &	 p    �� 5   
   .��5      W� $ 0:0:0.5D�6   $ 0X�61   $ 1X�6:   $ mainGrid��6A   $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�5      5      W� 5      $ 0:0:0.5D�6   $ 0X�61   $ 1X�6:   $ mainGrid��6A   $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�5      5      5      �� 5   
   .��5      W� $ 0:0:0.5D�6   $ 1X�61   $ 0X�6:   $ mainGrid��6A   $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleX)�5      5      W� 5      $ 0:0:0.5D�6   $ 1X�61   $ 0X�6:   $ mainGrid��6A   $9	 3(UIElement.RenderTransform).(ScaleTransform.ScaleY)�5      5      5      �� 5   
   .��5       �� $)	 #BorderBrush.(SolidColorBrush.Color)�6+   $ mainClientArea��6k   .g�5!        $
 0:0:0.0��6&   $ 	#44FFFFFF��68   6L     5"      $
 0:0:0.1��6&   $	 Red��68     5#      $
 0:0:0.2��6&   $ 	#44FFFFFF��68     5$      $
 0:0:0.3��6&   $	 Red��68     5%      $
 0:0:0.4��6&   $ 	#44FFFFFF��68     5&      $
 0:0:0.5��6&   $	 Red��68     5'      $
 0:0:0.6��6&   $ 	#44FFFFFF��68     5(      $
 0:0:0.7��6&   $	 Red��68     5)      $
 0:0:0.8��6&   $ 	#44FFFFFF��68   5*      t� 5+      $ 0:0:0.8D�6!   $ 1X�64   $ 2X�6=   $ mainClientArea��6D    . $	 BorderThickness�5,      6L   5-        5/   
   6J   50      .��52      � .+�54   
   � -   5        ���#FFFFFF J� Opacity$
 0.01Q�54   $   6d   � 56   
   -   5         �Name$ mainGrid��56      z�57      �� 58      -   5        mainGridScaleTransform�� �� ScaleX$ 1Q�58   A    �� ScaleY$ 1Q�6L   6Y   .  (System.Windows.Interactivity.Interaction   	Behaviors 5;      H  BMicrosoft.Expression.Interactivity.Layout.MouseDragElementBehavior  5<      .+�5?      �� -   5         ��Name$ mainClientArea��5?      $��Center=�6-   $��Center=�6H   $	��280��6e   $	��350��6r    �� CornerRadius$ 5��5@      ���#DEDEDE$��1q�68   ���#F3F6FA._�5A      � .+�5B      �� -   5        $	��Top=�5B      $��Right=�65   $��35��6Q   $��30��6\   ��5C      �� 5D      .R�5E   "   �� $ 	btnBorder��6)   $ 0,5,0,0��6<   ���#F3F6FA._�5F   &   ��  ��Name$ btnText��60   $��Center=�6B   $��Center=�6]    � ToolTip$ 关闭��6z   $��Webdings)�5G   (   $��r��6>   ���#9E9EAB$��15(�6\   6l   5H   #    �� Triggers 5I   "   :� 5J   &    :� RoutedEvent$ Mouse.MouseEnter��63   .[�5K   *   �� .��5L   .   �� .��5M   2   �� $(	 "Background.(SolidColorBrush.Color)�6O   $ 	btnBorder��6�   .g�5N   6   �� $
 00:00:00��6J    #F3F6FA6]   6o   �� 5O   6   $
 
00:00:0.25��6J    #D440276_   6q   5P   3   �� 5Q   2   $(	 "Foreground.(SolidColorBrush.Color)�6O   $ btnText��6�   .g�5R   6   �� $
 00:00:00��6J    #9E9EAB6]   6o   �� 5S   6   $
 
00:00:0.25��6J   	 White6_   6o   5T   3   5U   /   5V   +   5W   '   :� 5Y   &   $ Mouse.MouseLeave��63   .[�5Z   *   �� .��5[   .   �� .��5\   2   �� $(	 "Background.(SolidColorBrush.Color)�6O   $ 	btnBorder��6�   .g�5]   6   �� $
 00:00:00��6J    #D440276]   6o   �� 5^   6   $
 
00:00:0.25��6J    #F3F6FA6_   6q   5_   3   �� 5`   2   $(	 "Foreground.(SolidColorBrush.Color)�6O   $ btnText��6�   .g�5a   6   �� $
 00:00:00��6J   	 White6]   6m   �� 5b   6   $
 
00:00:0.25��6J    #9E9EAB6_   6q   5c   3   5d   /   5e   +   5f   '   5h      5j      �� 5l      $��Center=�6!   $��Center=�6<   .+�5m      �� $��	新宋体)�6%   $��28(�66   $
��Wrap=�6D   $��Center=�6X   $��Center=�6s   
��� �����5n      �� *Width+ �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ BorderL� �� 	Converter# [ ;9请出示会员卡或输入会员号以收藏此衣服？5p      �� 5r      -   5         ��Name$ 
tbUserName��5r   "   $	��250��66   $��40��6B   $��20q�6N   ���#CCC$��1q�6m   .��6�   6�   5s      �� 5u      $��Bottom=�6!   $��Right=�6<   $��10,20q�6X    �� Orientation$ 
Horizontal=�6g   .+�5v      �� -   5        $��60��5v   !   $��35��6,   ��5w      �� 5x   "   .R�5y   &   �� $ 	btnBorder��6-   $ 2��6@   
��� ���._�5z   *   �� $ btnText��64   $��Center=�6F   $��Center=�6a   $��确定��6~   ���#9E9EAB$��15(�6�   5{   +   5|   '    5}   &   :� 5~   *   $ Mouse.MouseEnter��67   .[�5   .   �� .��5�   2   �� .��5�   6   �� $(	 "Background.(SolidColorBrush.Color)�6S   $ 	btnBorder��6�   .g�5�   :   �� $
 00:00:00��6N    Gold6a   6p   �� 5�   :   $
 
00:00:0.25��6N    	Goldenrod6c   6w   5�   7   5�   3   5�   /   5�   +   :� 5�   *   $ Mouse.MouseLeave��67   .[�5�   .   �� .��5�   2   �� .��5�   6   �� $(	 "Background.(SolidColorBrush.Color)�6S   $ 	btnBorder��6�   .g�5�   :   �� $
 00:00:00��6N    	Goldenrod6a   6u   �� 5�   :   $
 
00:00:0.25��6N    Gold6c   6r   5�   7   5�   3   5�   /   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      