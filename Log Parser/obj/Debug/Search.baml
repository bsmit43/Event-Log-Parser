   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   m iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting 5	   	       WpfApplication1.Search   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   �winformchartmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5	   	     N� Title$  Search��5       N� ShowsNavigationUI .  .��5      � $
��1777��6    � ColumnDefinitions 5   
   �� 5      $��1368* �6   �� 5      .+�5   
   �� $��0,0,-1.2,678.6q�6   $��2��6-   .+�5      � $	��819��6   $��0,0,-167.4,0q�6    5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	DataGrid1��5      $��
70,122,0,0q�6&   $	��Top=�6:   $	��569��6R   $
��1559��6_    � DataContext$ ObservableCollection��6�   $��1q�6�   $��Arial)�6�   $
��Left=�6�      	RowHeight$ 30Q�6     HeadersVisibility$ Column=�6%     CanUserAddRows .  ��.   � UseLayoutRounding . $��0,0,1,0q�6�  	   MaxColumnWidth$		 500Q�6�  
   AreRowDetailsFrozen
 .    MinColumnWidth$ 50Q�6�  ��6�   �� ��5      �� 5       �� Color# � ��6"      AlternatingRowBackground 5      �� 5      # � ��6"      VerticalGridLinesBrush 5      �� 5      # � ��6"      HorizontalGridLinesBrush 5!      �� 5"      # � ��6"      Columns 5$      5&      � 5'   
   -   5         �Name$ progressbar��5'      $
��Left=�6+   $��33��6F   $��1432,730,0,0q�6R   $	��Top=�6h   $	��197��6�   6�   �� 5(   
   -   5         ��Name$ fileTextbox��5(      $
��Left=�6'   $��23��6B   $��C:\temp\newevents.txt��6N    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��145��6�   $��
1013,9,0,0q�6�   �� 5)   
   -   5        $ 	searchbox��5)      $
��Left=�6%   $��23��6@   $��
462,56,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��152��6�   �� 5*   
   -   5        $��	Browse...��5*      $
��Left=�6&   $��
1165,9,0,0q�6A   $	��Top=�6U   $��75��6m   
������� J� RenderTransformOrigin$ 0.897,0.768&�6�   $��22��6�   �� 5+   
   -   5         ��Name$ searchbutton��5+      $��Search��6'   $
��Left=�68   $��
619,57,0,0q�6S   $	��Top=�6g   $��75��6   
�������$��22��6�    �� 	IsDefault . 6�   (  "System.Windows.Controls.DatePicker  5,   
   -   5          Name$ datepicker1��5,         Text$ D��6*   $
��Left=�63   $��	85,54,0,0q�6N   $	��Top=�6a   $��25��6y   $	��102��6�     5-   
   -   5        $ datepicker2��5-      $
��Left=�6*   $��
208,54,0,0q�6E   $	��Top=�6Y   $��25��6q   $	��102��6}   �� 5.   
   -	   5         ��Name$ statusLabel��5.      $��Ready for Action��6&   $
��Left=�6A   $��	350,2,0,0q�6\   $	��Top=�6o   $��24(�6�   ��5/      �� 50      # � ��6"   52      �� 53   
   -
   5        $ 	timelabel��53      $�� ��6#   $
��Left=�6.   $��543,730,0,0q�6I   $	��Top=�6^   $��16(�6v   $
��Bold"�6�   �� 54   
   -   5         ��Name$ eventDropdown��54      $
��Left=�6*   $��
360,54,0,0q�6E   $	��Top=�6Y   $��97��6q   
�������$��24��6�   o� 55   
   $
��Left=�6   $��30��6*   $��
-3,84,-1,0q�66   $	��Top=�6J   $
��1781��6b   $��2��6o   ��56      �� 57      # � ��6"   59      �� 5:   
   -   5        $ resultcountDrpdwn��5:      $
��Left=�6.   $��1245,91,0,0q�6I   $	��Top=�6^   $��74��6v   $��23��6�   
�������6�   5<      5=      