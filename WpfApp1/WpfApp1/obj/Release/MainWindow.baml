   M S B A M L   `   `   `  ����   WpfApp1    WpfApp1.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � WindowStartupLocation$  CenterOwner=�$
��Auto��$
��Auto�� � Title$ 
Car Rental��.���  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $��* �.+��� $��0��$	��150��$	��900��$��0q�$
��Fill=�$��cars.png��$	��Top=�$y�Visible=��� $��1�� �� Orientation$ 
Horizontal=�$��40��.+��� -    ��Name$ TablesComboBox��$	��150��$��20(�$��Center=�$��Center=�$��0q��� $��1��
���   ��� -   $	��Add��$��0q�$��20(�
�������$	��100���� $��1��
���   ��� -   $
��Edit��$��0q�$��20(�
�������$	��100���� $��1��
���   ��� -   $��Delete��$��0q�$��20(�
���  ��$	��100���� $��1��
���   ��� $��1��$ 
Horizontal=�$��40��$��Right=�.+��� -    ��Name$ 
ViewPhones��$��0��$��View Phones��$��0q�$��15(�
�������$	��100��$y�	Collapsed=�$��Center=�$��Right=��� $��1��
���   ��� -   $ 
ViewEmails��$��0��$��View E-mails��$��0q�$��15(�
�������$	��100��$y�	Collapsed=�$��Center=�$��Right=��� $��1��
���   ��� -   $ ViewEmployees��$��0��$��View Employees��$��0q�$��15(�
�������$	��120��$y�	Collapsed=�$��Center=�$��Right=��� $��1��
���   ��� -   $ Numberofcars��$��0��$��Number of Vehicles��$��0q�$��15(�
�������$	��140��$y�	Collapsed=�$��Center=�$��Right=��� $��1��
���   ��� -	   $ 
Horsepower��$��0��$��Order by Horse Power��$��0q�$��15(�
�������$	��150��$y�	Collapsed=�$��Center=�$��Right=��� $��1��
���   ��� -
   $ FindVehicle��$��0��$��Find vehicle by km��$��0q�$��15(�
�������$	��150��$y�	Collapsed=�$��Center=�$��Right=��� $��1��
���   ��� -   $
 City��$��0��$��Citizens per city��$��0q�$��15(�
�������$	��150��$y�	Collapsed=�$��Center=�$��Right=��� $��1��
���   �&   System.Windows.Controls.DataGrid  -     Name$ DataGrid��$��2��   SelectionMode$ Single=�   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$	 100 $��15(�	   
IsReadOnly	 . ���� 
   	CellStyle
 ��  �� 
TargetType*  $System.Windows.Controls.DataGridCell"  .���  �� Property � �� �� Value$ 0q�