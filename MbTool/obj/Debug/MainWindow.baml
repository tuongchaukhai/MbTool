   M S B A M L   `   `   `  ����A  =MbTool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:MbToolMbTool  5   	       MbTool.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:MbTool     5   	     � Title$  MbTool��5   	    � 
ResizeMode$ NoResize=�6   .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��
myDataGrid��5
      $��10q�6%   $	��610��61   $	��Top=�6A   $��Center=�6Y   ��. $
��Auto=�5      $
��Auto=�5         AutoGenerateColumns .     SelectionUnit$
 Cell=�5         CanUserAddRows .  ��5      ��  �� Path$ 	phoneList� �� NotifyOnSourceUpdated .  �� UpdateSourceTrigger$ PropertyChanged=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 PHONE��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 64   �� *Process.MainWindowTitle+$ PropertyChanged=�  5      $	 ADB ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6t   
 65   �� *AdbId+$ PropertyChanged=�6t   4  .System.Windows.Controls.DataGridComboBoxColumn  5      $
	 TYPE��6)   $
 Auto 67      SelectedItemBinding 6D   �� *Type+   ItemsSource 6i   ��    MbTool.PhoneData   Types �� Source# Z    ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$ Center=�6D   �� 5       � ��$ Center=�6B   5      5      4  .System.Windows.Controls.DataGridTemplateColumn  5      $	 ACTION��6)      CellTemplate 5       �� 5!      .R�5"      �� $��	btnAction��6$   -   5        
 � Tag 5"   i   �� ��5#   "   �� 5$   &   " ��6,   .�5%   *   ��  � ��$ Center=�6W   �� 5&   *    � ��$ START��6D   �� 5'   *    � ��
 �����6G    �� Triggers 5(   *   �� 5)   .    �� Binding 6:   �� *Action+ �� Value True6U   .a�5*   2   ��  � ��$
 STOP��6L   �� 5+   2    � ��
 ��  �6O   5,   /   5.   '   50      51      53        55      $	 SOUND��6)    56      �� 57      .R�58      �� $��btnSound��6$   -   5         58   g   �� ��59   "   �� 5:   &   " ��6,   .�5;   *   ��  � ��$ Center=�6W   �� 5<   *    � ��$	 OFF��6D   �� 5=   *    � ��
 �����6G    5>   *   �� 5?   .    6:   �� *Sound+ True6T   .a�5@   2   ��  � ��$ ON��6L   �� 5A   2    � ��
 �**��6O   5B   /   5D   '   5F      5G      5I      5K      5L      5M      