   M S B A M L   `   `   `  ����F  BMagicMirror, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:MagicMirror.ConvertersMagicMirror.Converters  5      5clr-namespace:MagicMirror.ViewsMagicMirror.Views  5      *    $MagicMirror.Views.AllProductsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      :	converter$clr-namespace:MagicMirror.Converters     5      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      *viewclr-namespace:MagicMirror.Views  5        � 	Resources  5
      0   *MagicMirror.Converters.IndexToNumConverter   IndexToNumConverter2   ,MagicMirror.Converters.GridCellSizeConverter  gridCellSizeConverter7  1MagicMirror.Converters.HeightDependWidthConverter  heightDependWidthConverter  ItemsPanelTemplate A� Columns A� Rows  ItemDataTemplate ��Name �� ElementName �� ConverterParameter �� 	Converter � RowDefinitions �� Path	 �� Triggers
 P� Property P� Value �� Property �� Value �� 
TargetName  PageItemsPanelTemplate �� Orientation  PageItemDataTemplate��%Y  &	        &	      &	 &     &	 9     &	 �     7  7  &	 �    &	 �      5   
   6F     5   
   6J     5   
   6T   �� 5   
   .R�5      A� $��Center=�6O   $��10q�6l    6   �� *	PageCol+ 66   �� *	PageRow+6l   5      �� 5   
   .R�5      �� $ 
cellBorder��6   
������ $��1q�6C   $��2q�6W   ._�5      � ��6   �� *ActualWidth+$ gridAllProducts��$ 3��8   ��5      �� *ActualHeight+$ gridAllProducts��$ 4��8   5      �� 5      $��* �6(   65   �� 5      $
��auto �6(   68   .+�5      �� $��0��6   $��Uniform=�6K   ��6)   �� $ 	ImagePath�6K   �� 5      $��1��6    $��Center=�6H   $��0,5,0,0q�6e   $��CharacterEllipsis =�6v   ��6-   �� $
 Name�6v   5      5      	 5       P� 5!      
 �@J�IsMouseOver .  �5"      �� 5#       �@J�Opacity$	 0.8Q�64   �� 5$      $ 
cellBorder��6J    � ��
 � ���5&      5(      �� 5*   
   .R�5+      �� $ 
Horizontal=�6   64   5,      �� 5.   
   .R�5/      �� $ 
cellBorder��6   
������ $��1q�6C   $��2q�6W   ._�50      �� 51      	 53      P� 54      
 �@J�IsMouseOver .  �55      �� 56       �@J�Opacity$	 0.8Q�64   �� 57      $ 
cellBorder��6H    � �� �#389CFF59      5;      5=      .��5?      �  5@   
   �� 5A      $��* �6   6)   �� 5B      $
��auto �6   6,   �� 5C      $
��auto �6   6,   .+�5F   
   � -   5         �Name$ gridAllProducts��5F      $��0��6(   $��Stretch=�65   $��Stretch=�6Q   .+�5G      �� -   5         ��Name$ 
lbProducts��5G      $��10q�6*   #���  66   #���  5H      ��5I      �� *ProductBizList+5J      5K      � 5M   
   -   5        $ gridPageSwitch��5M      $��1��6'   $��right=�64   $��10q�6P   $��Center=�6\    � ColumnDefinitions 5N      �� 5O      $
��auto �6#   62   �� 5P      $��* �6#   6/   �� 5Q      $
��auto �6#   62     5T       �� 
TargetType��%Q  '��       �� 5U      " ��6   .�5V      ��  � ��$ 32��6/   6<   �� 5W       � ��$ 35��6.   6;   �� 5X       � ��$ 0q�68   6D   �� 5Y       � ��$ 0q�6/   6;   �� 5Z       � ��$ 16(�61   6>   �� 5[       �@�Cursor$
 Hand��6/   6>   �� 5\       � ��
 �2͚�6I   5^      5_      .+�5a      ��  � ToolTip$ 	上一页��6   $��0��6#   $��Center=�6V   ��63   �� *PrePageCommand+��5b      �� 5c      .R�5d      �� $��1q�6!    �� CornerRadius$ 5,0,0,5��65   ��5e      �� 5f   "    �� 
StartPoint$	 0,0&�66    �� EndPoint$	 1,0&�6G   .��5g   &   �  � Color$ #F9F9F9��63    � Offset$ 0Q�6C   6P   � 5h   &   $ #F2F2F2��63   $ 1Q�6C   6P   5i   #   ._�5k      ��  �� Padding$ 2q�6(   $��Webdings)�65   $��7��6K   #��z��5l   (   $��Center=�5m   (   $��Center=�6C   5n      5o      5p      5r      � 5t      $��1��6   $��Stretch=�6#   $��Center=�6A   ���#F2F2F2$��30��6q   .+�5u      �� -   5        $ lbPages��5u      #���  6+   
������ $��0q�5v      $��Disabled=�6/   .  (System.Windows.Interactivity.Interaction   Triggers 5w      /  )System.Windows.Interactivity.EventTrigger  5x         	EventName$ SelectionChanged��6)   .  (System.Windows.Interactivity.TriggerBase   Actions. 5y      6  0System.Windows.Interactivity.InvokeCommandAction     Command 64   �� *GotoPageCommand+   CommandParameter 6X   �� *SelectedValue+$ lbPages��5z        5}        �� 
TargetType! �� Triggers��%N  '��       �� 5~      " ��6=   .�5      ��  � ��
 �2͚�6Q   �� 5�       � ��$ 15(�69   6F   �� 5�       � �� �#CCC6K   �� 5�       � �� 5�   "   �� 5�   &   "  ��66   .R�5�   *   �� $ Border��61   $��4q�6A   $��1q�6L   #��z��6a   $��Center=�5�   1   $��Center=�6L   $��30��6i   ._�5�   .   �� $��Center=�6@   $��Center=�6[   5�   +   5�   '   5�      ! 5�      P� 5�   "   
 �@J�IsMouseOver .  �5�   &   �� 5�   *    � �� �#389CFF6G   �� 5�   *    � �� �#389CFF6H   5�   #   5�      5�      5�      5�      �� 5�      $ 	下一页��6   $��Center=�6H   $��2��5�      $��Webdings)�6%   ��5�   #   �� *NextPageCommand+��5�      �� 5�      .R�5�      �� $��1q�6!   $ 0,5,5,0��65   ��5�      �� 5�   "   $	 0,0&�66   $	 1,0&�6G   .��5�   &   � $ #F2F2F2��63   $ 0Q�6C   6P   � 5�   &   $ #F9F9F9��63   $ 1Q�6C   6P   5�   #   ._�5�      �� $ 2q�6(   $��Webdings)�65   $��8��6K   #��z��5�   (   $��Center=�5�   (   $��Center=�6C   5�      5�      5�      5�      5�      5�      5�      