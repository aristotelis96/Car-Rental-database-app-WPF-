   M S B A M L   `   `   `  ����  WpfApp1    WpfApp1.PhonesWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � WindowStartupLocation$  CenterScreen=�5   	   $	��300��5   	   $	��200��6    � Title$ Phones��5	   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��40��6;   .+�5      �� -   5        $	��Add��5      $��0q�6$   $��20(�68   
�������$	��100��6Y   6e   �� 5      $��1��6   
���   �6   �� 5      -   5        $��Delete��5      $��0q�6&   $��20(�6:   
�������$	��100��6[   6g   �� 5      $��1��6   
���   �6   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DataGrid��5       $��1��6      SelectionMode$ Single=�6J      ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 6a   $��15(�6s      
IsReadOnly . ��62   ��    	CellStyle 5      �� 5      	 �� 
TargetType*  $System.Windows.Controls.DataGridCell"	  6   .�5      �� 
 �� Property
 � �� �� Value$ 0q�68   5      5      5       5!      