   M S B A M L   `   `   `  ����F  BMagicMirror, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:MagicMirror.ViewsMagicMirror.Views  5   	       MagicMirror.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   0viewclr-namespace:MagicMirror.Views     5   	   -   5          � Title$  
MainWindow��5   	    � Icon$ MagicMirror.ico��6      MainWinStyle#��[  5   	    � 	Resources 5        buttonMenuInStoryboard g� Duration W� From	 W� To �� 
TargetName �� TargetProperty W� EasingFunction2  ,System.Windows.Media.Animation.QuadraticEase7  1System.Windows.Media.Animation.EasingFunctionBase	   
EasingMode9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O� KeyTime O� Value  buttonMenuOutStoryboard��%.  &	       &	 �    �� 5	   
   .��5
      W� $ 0:0:0.5D�6   $	 100X�61   $ 0X�6<   $ menuButtons��6C   $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�5       5        5      $	 EaseOut=�6$   5      U� 5      $ (UIElement.Opacity)�6,   $ menuButtons��6\   .\�5        $
 0��6'   $ 0Q�63     5      $
 0:0:0.5��6'   $ 1Q�69   5      5      �� 5   
   .��5      W� $ 0:0:0.5D�6   $ 0X�61   $	 100X�6:   $ menuButtons��6C   $8 2(UIElement.RenderTransform).(TranslateTransform.Y)�5       5        5      $	 EaseOut=�6$   5      U� 5      $ (UIElement.Opacity)�6,   $ menuButtons��6\   .\�5        $
 0��6'   $ 1Q�63     5      $
 0:0:0.5��6'   $ 0Q�69   5       5!      5"      .��5%      �  � RowDefinitions 5&   
   �� 5'      $��* �6   6)   �� 5(      $
��auto �6   6,   .+�5,   
    � -   5          �Name$ NavigationFrame��5,      $��0��6   $��0q�66     � NavigationUIVisibility$ Hidden=�6J   6l   )   #MagicMirror.Views.MainButtonMenuBar  5/   
   -   5          Name$ menuButtons��5/   !   $��1��66   $y�Hidden=�6C   $	��110��6W   $��Bottom=�50   !   $��Center=�6<   z�51      T� 52      6'   54      55      56      