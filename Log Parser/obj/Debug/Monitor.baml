   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   m iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting 5	   	       WpfApplication1.Monitor   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   �winformchartmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5	   	     N� Title$  Monitor��5       N� ShowsNavigationUI .  .��5      � .+�5   
   �� $��0,0,-2.4,678.2q�6   $��2��6-   .+�5      � $	��819��6   $��	0,0,-22,0q�6    5      7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   -   5          Name$ sidebarchart��5      $��985,763,79,507q�61      Child. 5      ;  5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        
Chart1��"  System.Windows.Forms.Control   Dock$
 Fill=�5   1      Series 5      <  6System.Windows.Forms.DataVisualization.Charting.Series  5         Name$ series��6*      	ChartType$
 Line=�68      
ChartAreas 5      ?  9System.Windows.Forms.DataVisualization.Charting.ChartArea  5      5      5        5   
   -   5        $	 Pie��5      $��534,730,551,511q�6(   . 5        -   5        
Chart2��$
 Fill=�5   1    5         5!      $ series��6*   $	 Pie=�68    5#        5$      5&      5'        5)   
   -   5        $ linechartgf��5)      $��59,730,1007,508q�60   . 5*        -   5        
Chart3��$
 Fill=�5*   1    5+        5,      $ series��6*   $
 Line=�68    5.        5/      51      52      &   System.Windows.Controls.DataGrid  54   
   -   5        	  Name$	 	DataGrid1��54      $��
80,214,0,0q�6&   $	��Top=�6:   $	��499��6R   $
��1257��6_   
 � DataContext$
 ObservableCollection��55   +   $��1q�6N   $��Arial)�6b   $
��Left=�6u      	RowHeight$ 30Q�6�      HeadersVisibility$ Column=�56         CanUserAddRows .  ��.   � UseLayoutRounding . $��0,0,1,0q�6�      MaxColumnWidth$	 300Q�57      ��55      ��  � 	Resources 58         st �� 
TargetType �� Property �� Value��%V   &	        �� 59      " ��6#   .�5:      ��  � ��$ Center=�6:   5;      5<      ��5=      �� 5>       �� Color# � ��6"      AlternatingRowBackground 5@      �� 5A      # � ��6"      VerticalGridLinesBrush 5C      �� 5D      # � ��6"      HorizontalGridLinesBrush 5F      �� 5G      # � ��6"      Columns 5I      0  *System.Windows.Controls.DataGridTextColumn  5J      1  +System.Windows.Controls.DataGridBoundColumn   ElementStyle 5K      �� 5L      .�5M      ��  � ��$ Center=�6S   5N      5P      5R      � 5T   
   -   5         �Name$ progressbar��5T      $
��Left=�6+   $��33��6F   $��1139,725,0,0q�6R   $	��Top=�6h   $	��197��6�   6�   �� 5U   
   -	   5         ��Name$ fileTextbox��5U      $
��Left=�6'   $��23��6B   $��C:\temp\newevents.txt��6N    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��145��6�   $��
1013,9,0,0q�6�   �� 5V   
   -
   5        $ 	searchbox��5V      $
��Left=�6%   $��23��6@   $��
462,56,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $	��152��6�   �� 5W   
   -   5        $��	Browse...��5W      $
��Left=�6%   $��
1165,9,0,0q�6@   $	��Top=�6T   $��75��6l   
������� J� RenderTransformOrigin$ 0.897,0.768&�6�   $��22��6�   �� 5X   
   -   5         ��Name$ Monitor_Button��5X      $��Monitor��6)   $
��Left=�6;   $��
619,57,0,0q�6V   $	��Top=�6j   $��75��6�   
�������$��22��6�    �� 	IsDefault . 6�   (	  "System.Windows.Controls.DatePicker	  5Y   
   -   5          	 Name$  datepicker1��5Y      ! 	  Text$! D��6*   $
��Left=�63   $��	85,54,0,0q�6N   $	��Top=�6a   $��25��6y   $	��102��6�   	  5Z   
   -   5        $  datepicker2��5Z      $
��Left=�6*   $��
208,54,0,0q�6E   $	��Top=�6Y   $��25��6q   $	��102��6}   �� 5[   
   -   5        " ��Name$" statusLabel��5[      $��Ready for Action��6&   $
��Left=�6A   $��	350,2,0,0q�6\   $	��Top=�6o   $��24(�6�   ��5\      �� 5]      # � ��6"   5_      �� 5`   
   -   5        $" 	timelabel��5`      $�� ��6#   $
��Left=�6.   $��543,730,0,0q�6I   $	��Top=�6^   $��16(�6v   $
��Bold"�6�   �� 5a   
   -   5        # ��Name$# eventDropdown��5a      $
��Left=�6*   $��
360,54,0,0q�6E   $	��Top=�6Y   $��97��6q   
�������$��24��6�   o� 5b   
   $
��Left=�6   $��31��6*   $��-73,90,-133,0q�66   $	��Top=�6M   $
��1576��6e   ��5c      �� 5d      # � ��6"   5f      �� 5g   
   -   5        $# resultcountDrpdwn��5g      $
��Left=�6.   $��1217,98,0,0q�6I   $	��Top=�6^   $��74��6v   $��23��6�   
�������6�   5h      5i      