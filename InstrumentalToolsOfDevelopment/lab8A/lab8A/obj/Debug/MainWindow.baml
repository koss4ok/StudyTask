   M S B A M L   `   `   `  ����@  <lab8A, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab8Alab8A  5   	       lab8A.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:lab8A     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   r� -   5         r�Name$ me��5      $y�Hidden=�6#    r� LoadedBehavior$ Manual=�67   �� 5   
   $��0��6   $��10q�6"   .+�5      �� $��Volume��6   �� 5      -   5         ��Name$ slVolume��5       � Minimum$ 0Q�6'    � Maximum$ 1Q�63    � Value 6?   ��  �� ElementName$ me��	 �� Path$	 Volume�
 �� Mode$
 TwoWay=�5      �� 5   
   $��1��6   $��10q�6"   .+�5      �� $��Balnce��6   �� 5      -   5        $ 	slBalance��5      $ -1Q�6(   $ 1Q�65    6A   �� $ me��$	 Balance�$
 TwoWay=�5      �� 5   
   $��2��6   $��10q�6"   .+�5      �� $��Speed��6   �� 5      -   5        $ slSpeed��5      $ 0Q�6&   $ 3Q�62    6>   �� $ me��$	 
SpeedRatio�5      � 5   
   $��3��6   $��10q�6    � ColumnDefinitions 5      �� 5      $��* �6#   �� 5       $��* �6#   �� 5!      $��* �6#   �� 5"      $��* �6#   �� 5#      $��3* �6#   .+�5%      �� -   5         ��Name$ btnPause��5%      $��0��6'   $��Pause��67   $��Center=�6G   $��5q�6d   6q   �� 5&      -   5        $ btnPlay��5&      $��1��6&   $
��Play��66   $��Center=�6G   $��5q�6d   6q   �� 5'      -   5        $ btnStop��5'      $��2��6&   $
��Stop��66   $��Center=�6G   $��5q�6d   6q   �� 5(      -   5        $ btnOpen��5(      $��3��6&   $
��Open��66   $��Center=�6G   $��5q�6d   6q   5*      5,      5-      