   M S B A M L   `   `   `  ����J  FWpfApplication1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:WpfApplication1WpfApplication1  5   	   ^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35tOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration System.Windows.Forms.Integration 5   	   [ WSystem.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089Y@clr-namespace:System.Windows.Forms;assembly=System.Windows.FormsSystem.Windows.Forms 5   	   m iSystem.Windows.Forms.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35�mclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization/System.Windows.Forms.DataVisualization.Charting 5	   	       WpfApplication1.Dashboard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:WpfApplication1     5   	   _wfiOclr-namespace:System.Windows.Forms.Integration;assembly=WindowsFormsIntegration     5   	   Owf@clr-namespace:System.Windows.Forms;assembly=System.Windows.Forms     5   	   �winformchartmclr-namespace:System.Windows.Forms.DataVisualization.Charting;assembly=System.Windows.Forms.DataVisualization     5	   	     N� Title$  	Dashboard��5       N� ShowsNavigationUI .  $��940.943��5   "   $��1542.233��63   .��5      � $��
10,0,10,-6q�6    � ColumnDefinitions 5   
   �� 5      $
��280* �6   �� 5      $	��61* �6   �� 5      $��1191* �6    � RowDefinitions 5   
   �� 5      $
��386* �6   �� 5      $
��551* �6   .+�5   
   �� $��0,-22,-2,149q�6   $��3��6+   7  1System.Windows.Forms.Integration.WindowsFormsHost  5   
   -   5          Name$ sidebarchart��5      $��672,107,62,503q�61   $��2��6I   $��2��6Z      Child. 5      ;  5System.Windows.Forms.DataVisualization.Charting.Chart  -   5        
Chart1��"  System.Windows.Forms.Control   Dock$
 Fill=�5   1      Series 5      <  6System.Windows.Forms.DataVisualization.Charting.Series  5         Name$ series��6*   	   	ChartType$
	 Line=�68   
   
ChartAreas
 5      ?  9System.Windows.Forms.DataVisualization.Charting.ChartArea  5      5       5!        5#   
   -   5        $	 Pie��5#      $��202,107,554,503q�6(   $��2��6A   $��2��6R   . 5$        -   5        
Chart2��$
 Fill=�5$   1    5%        5&      $ series��6*   $		 Pie=�68   
 5(        5)      5+      5,        5.   
   -   5        $ linechartgf��5.      $��10,107,1021,503q�60   $��2��6I   $��3��6Z   . 5/        -   5        
Chart3��$
 Fill=�5/   1    50        51      $ series��6*   $
	 Line=�68   
 53        54      56      57        59   
   -   5        $ 
barchartgf��59      $��10,95,377,80q�6/   $��1��6E   $��3��6R   . 5:        -   5        
Chart4��$
 Fill=�5:   1    5;        5<      $ series��6*   $
	 Line=�68   
 5>        5?      5A      5B      �� 5C   
   -	   5         ��Name$ 
successbox��5C       d� 	IsChecked$
 TrueY�6(   $��Success��69   $
��Left=�6K   $��887.073,131,0,0q�6f   $	��Top=�6   $��1��6�   $��2��6�   �� 5D   
   -
   5        $ failbox��5D      $
 TrueY�6$   $��Failure��65   $
��Left=�6G   $��887.073,151,0,0q�6b   $	��Top=�6{   $��1��6�   $��2��6�   �� 5E   
   -   5         ��Name$ fileTextbox��5E      $
��Left=�6'   $��23��6B   $��C:\temp\newevents.txt��6N    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��145��6�   $��672.073,-5,0,0q�6�   $��2��6�   �� 5F   
   -   5        $ 	searchbox��5F      $
��Left=�6%   $��23��6@   $��121.073,56,0,0q�6L   $
 Wrap=�6d   $	��Top=�6x   $	��152��6�   $��2��6�   �� 5G   
   -   5         ��Name$ browsebutton��5G      $��	Browse...��6'   $
��Left=�6;   $��824.073,-5,0,0q�6V   $	��Top=�6n   $��75��6�   
������� J� RenderTransformOrigin$ 0.897,0.768&�6�   $��22��6�   $��2��6�   �� 5H   
   -   5        $ updatebutton��5H      $��	Update...��6'   $
��Left=�6;   $��278.073,57,0,0q�6V   $	��Top=�6n   $��75��6�   
�������$��22��6�    �� 	IsDefault . $��2��6�   (  "System.Windows.Controls.DatePicker  5I   
   -   5          Name$ datepicker1��5I         Text$ D��6*   $
��Left=�63   $��	85,54,0,0q�6N   $	��Top=�6a   $��25��6y   $	��102��6�     5J   
   -   5        $ datepicker2��5J      $
��Left=�6*   $��
208,54,0,0q�6E   $	��Top=�6Y   $��25��6q   $	��102��6}   $��2��6�   �� 5K   
   -   5         ��Name$ statusLabel��5K      $��Ready for Action��6&   $
��Left=�6A   $��19.073,-22,0,0q�6\   $	��Top=�6t   $��24(�6�   $��2��6�   ��5L      �� 5M       �� Color# � ��6"   5O      �� 5P   
   -   5        $ 	timelabel��5P      $�� ��6#   $
��Left=�6.   $��202.073,344,0,0q�6I   $	��Top=�6b   $��16(�6z   $
��Bold"�6�   $��1��6�   $��2��6�   �� 5Q   
   -   5         ��Name$ eventDropdown��5Q      $
��Left=�6*   $��19.073,54,0,0q�6E   $	��Top=�6\   $��97��6t   
�������$��24��6�   $��2��6�   �� 5R   
   -   5        $ resultcountDrpdwn��5R      $
��Left=�6.   $��887,198,0,0q�6I   $	��Top=�6^   $��74��6v   $��23��6�   
�������$��1��6�   $��2��6�   �� 5S   
   -   5        $ Date_Frequency��5S      $
��Left=�6+   $��887,303,0,0q�6F   $	��Top=�6[   $��74��6s   $��23��6~   
�������$��1��6�   $��2��6�   �� 5T   
   -   5        $ Number_Frequency��5T      $
��Left=�6-   $��887,249,0,0q�6H   $	��Top=�6]   $��74��6u   $��23��6�   
�������$��1��6�   $��2��6�   �� 5U   
   -   5        $ Number_Interval��5U      $��Number Frequency��6)   $
��Left=�6D   $��967,249,0,0q�6_   $	��Top=�6t   $��16(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   �� 5V   
   -   5        $ Date_Interval��5V      $��Date Frequency��6'   $
��Left=�6@   $��967,295,0,0q�6[   $	��Top=�6p   $��16(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   �� 5W   
   $
��Left=�6   $	��100��6,   $��411.073,254,0,0q�69   $	��Top=�6R   $	��100��6j   $��2��6v   �� 5X   
   -   5         ��Name$ image��5X      $
��Left=�6   $	��100��6:   $	��Top=�6G   $	��100��6_   �� 5Y   
   -   5        $ Amount_of_Results��5Y      $��Number of Results��6+   $
��Left=�6G   $��961,190,0,0q�6b   $	��Top=�6w   $��16(�6�   $
��Bold"�6�   $��1��6�   $��2��6�   5\      5]      