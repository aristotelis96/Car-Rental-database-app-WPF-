   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.HorsePower   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��400��5   	   $	��500��6    � Title$ Horse Power��5	   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $ ��Cars from faster to slower��6-   $��20(�6R   $
��0, 2q�6`   $��Center=�6n   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid��5       $��1��6      SelectionMode$ Single=�6J      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6a   $��15(�6s      
IsReadOnly . ��62   ��    	CellStyle 5      �� 5       �� 
TargetType*  $System.Windows.Controls.DataGridCell"  6   .�5      �� 	 �� Property	 � ��
 �� Value$
 0q�68   5      5      5      5      