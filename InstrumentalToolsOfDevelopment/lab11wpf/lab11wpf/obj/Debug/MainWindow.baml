   M S B A M L   `   `   `  ����C  ?lab11wpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:lab11wpflab11wpf  5   	       lab11wpf.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:lab11wpf     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      $��5* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��Поставщик��6   $��0��6$   $��0��64   �� 5   
   -   5         ��Name$ lblOrderNum��5      $��Заказ № 111��6%   $��2��6;   $��0��6K   $��Right=�6X   �� 5   
   -   5        $ lblDate��5      $��
01.01.2019��6!   $��2��66   $��1��6F   $��Right=�6S   �� 5   
   -   5         ��Name$ 	tbxVendor��5      $��1��6%   $��0��65   $��Center=�6B   �� 5   
   $��Покупатель��6   $��0��6%   $��1��65   �� 5   
   -   5        $ tbxBuyer��5      $��1��6$   $��1��64   $��Center=�6A   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgOrders��5      $��0��6%   $��2��65   $��2��6B      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6%   	   Header$		 №��6F   
   
IsReadOnly
 . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6/   �� *ID+6Q     5      $ * 6%   $	 
Товар��6K    6/   �� *	Product+6K     5       $ * 6%   $	 Количество��6L    6/   �� *
Quantity+6L     5!      $ * 6%   $	 Цена��6I    6/   �� *Price+6I     5"      $ * 6%   $	 
Сумма��6G   
 .  6/   �� *Sum+6V   5$      �� 5%   
   -   5        $ lblSumOfAll��5%      $��Итого: ��6%   $��3��67   $��0��6D   $��2��6T   �� 5&   
   -   5         ��Name$ 	btnToWord��5&      $��В документ Word��6$   $��0��6>   $��4��6N   $��Center=�6[   $��Center=�6x   $��10q�6�   6�   �� 5'   
   -   5        $ 
btnToExcel��5'      $��В документ Excel��6%   $��1��6@   $��4��6P   $��Center=�6]   $��Center=�6z   $��10q�6�   6�   �� 5(   
   -	   5        $ btnFromExcel��5(      $#��Из документа Excel��6'   $��3��6D   $��4��6T   $��Center=�6a   $��Center=�6~   $��10q�6�   6�   5)      5*      