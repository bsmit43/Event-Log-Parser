using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections.Generic;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        universal regUniversal = new universal();
        Txtreader readText = new Txtreader();

        public Dashboard()
        {
            InitializeComponent();

            //event type combobox
            this.eventDropdown.Items.Insert(0, "Security");
            this.eventDropdown.SelectedIndex = 0;
            this.eventDropdown.Items.Add("All Events");
            this.eventDropdown.Items.Add("Information");
            this.eventDropdown.Items.Add("System");

            //Search result combobox
            this.resultcountDrpdwn.Items.Insert(0, "500");
            this.resultcountDrpdwn.SelectedIndex = 0;
            this.resultcountDrpdwn.Items.Add("100");
            this.resultcountDrpdwn.Items.Add("1000");
            this.resultcountDrpdwn.Items.Add("5000");
            this.resultcountDrpdwn.Items.Add("10000");

            //chart date frequency
            this.Date_Frequency.Items.Insert(0, "10");
            this.Date_Frequency.SelectedIndex = 0;
            this.Date_Frequency.Items.Add("1");
            this.Date_Frequency.Items.Add("3");
            this.Date_Frequency.Items.Add("5");
            this.Date_Frequency.Items.Add("8");

            //number per day chart frequency
            this.Number_Frequency.Items.Insert(0, "10");
            this.Number_Frequency.SelectedIndex = 0;
            this.Number_Frequency.Items.Add("5");
            this.Number_Frequency.Items.Add("15");
            this.Number_Frequency.Items.Add("20");
            this.Number_Frequency.Items.Add("25");

            //Automatically set date picker
            DateTime today = DateTime.Now;
            datepicker1.Text = today.AddDays(-40).ToString();
            datepicker2.Text = today.ToString();

            //Programatically click update button when dashboard is loaded 
            ButtonAutomationPeer peer = new ButtonAutomationPeer(updatebutton);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fileTextbox.Text))
            {
                //Show error message if file box empty
                MessageBox.Show("File location cannot be empty.");
            }
            else
            {
                //Set variable for file text box so I can identify easier
                string fileName = fileTextbox.Text;

                //Set searchbox to escape any special characters
                string searchString = Regex.Escape(searchbox.Text);

                //Start timer
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                //Set the status label text
                statusLabel.Content = "Dasboard";
 
                //DataGridView gridView = sender as DataGridView;
                ObservableCollection<Log> users = new ObservableCollection<Log>();

                //Initialize side bar chart
                Chart sidebar = new Chart();
                Series sideseries = new Series();
                sideseries.ChartType = SeriesChartType.Bar;
                sidebar.Series.Clear();
                sidebar.ChartAreas.Add("Default");
                sidebar.Series.Add(sideseries);

                //Initialize pie chart
                Chart piechart = new Chart();
                Series pieseries = new Series();
                pieseries.ChartType = SeriesChartType.Pie;
                piechart.Series.Clear();
                piechart.ChartAreas.Add("Default");
                piechart.Series.Add(pieseries);

                //Initialize line chart
                Chart linechart = new Chart();
                Series lineseries = new Series();
                Series lineseries2 = new Series();
                lineseries.ChartType = SeriesChartType.Line;
                lineseries2.ChartType = SeriesChartType.Line;
                linechart.Series.Clear();
                linechart.ChartAreas.Add("Default");
                linechart.Series.Add(lineseries);
                linechart.Series.Add(lineseries2);

                //Initialize bar chart
                Chart barchart = new Chart();
                Series barseries = new Series();
                Series barseries2 = new Series();
                barseries.ChartType = SeriesChartType.Column;
                barseries2.ChartType = SeriesChartType.Column;
                barchart.Series.Clear();
                barchart.ChartAreas.Add("Default");
                barchart.Series.Add(barseries);
                barchart.Series.Add(barseries2);

                int count = 0;

                if (eventDropdown.SelectedIndex == 0)
                {                    
                    DateTime startDate = datepicker1.SelectedDate.Value;
                    DateTime endDate = datepicker2.SelectedDate.Value;
                    TimeSpan diffDate = endDate.Subtract(startDate);
                    List<string> uniquesec = new List<string>();

                    foreach (Match match in Regex.Matches(readText.Readtxtfile(fileName), regUniversal.section(), RegexOptions.Singleline))
                    {
                        //count number of loops for max results.
                        count++;
                     
                        string log = match.Value;
                        bool found = regUniversal.search(searchString, log);

                        int numvalue;
                        bool parsed = Int32.TryParse(resultcountDrpdwn.Text, out numvalue);
                        if (count > numvalue)
                        {
                            //stop script when loop max results reached.
                            break;
                        }
                        
                        DateTime dt;
                        DateTime.TryParse(regUniversal.finddate(log), out dt);
                        if ((dt > startDate) && (dt < endDate))
                        {
                            if (string.IsNullOrWhiteSpace(searchbox.Text) || found == true)
                            {
                                //add items to datagrid
                                users.Add(new Log
                                {
                                    Date = regUniversal.finddate(log),
                                    Event_Number = regUniversal.IDnum(log),
                                    Success_Fail = regUniversal.Audit(log),
                                    Source = regUniversal.source(log),
                                    Description = regUniversal.description(log),
                                    Event_ID = regUniversal.secid(log),
                                    Account_Name = regUniversal.accname(log),
                                    Object_Type = regUniversal.objtype(log)
                                });

                            }
                        }
                        //DataGrid1.ItemsSource = users;
                    }
                    //progressbar.Value = 100;

                    //side bar chart
                    sideseries.Points.AddY(10);
                    sideseries.Points.AddY(7);
                    sideseries.Points.AddY(24);
                    sideseries.Points.AddY(11);
                    sidebarchart.Child = sidebar;

                    //if the success box is checked.
                    if (successbox.IsChecked == true)
                    {
                        //Group by date
                        var suc = users.Where(x => x.Success_Fail == "Audit Success")
                        .GroupBy(x => x.Date)
                        .Select(x => new
                        {
                            Value = x.Count(),
                            Day = x.Key
                        }).ToList();

                        foreach (var user in suc)
                        {
                            //barchart
                            barseries.Points.AddXY(DateTime.Parse(user.Day).ToString("MM/dd/yyyy HH:mm:ss tt"), user.Value);
                            //linechart
                            lineseries.Points.AddXY(DateTime.Parse(user.Day).ToString("MM/dd/yyyy HH:mm:ss tt"), user.Value);
                        }
                    }

                    //if the failure box is checked.
                    if (failbox.IsChecked == true)
                    {
                        //Group by date
                        var fail = users.Where(x => x.Success_Fail == "Audit Failure")
                    .GroupBy(x => x.Date)
                    .Select(x => new
                    {
                        Value = x.Count(),
                        Day = x.Key
                    }).ToList();

                        foreach (var user in fail)
                        {
                            //barchart
                            barseries2.Points.AddXY(DateTime.Parse(user.Day).ToString("MM/dd/yyyy HH:mm:ss tt"), user.Value);
                            //barchart.Series[0].Color = Color.Red;
                            //linechart
                            lineseries2.Points.AddXY(DateTime.Parse(user.Day).ToString("MM/dd/yyyy HH:mm:ss tt"), user.Value);
                        }
                    }
                    //Group by date
                    var failpie = users.Where(x => x.Source == "Microsoft-Windows-Security-Auditing")
                    .GroupBy(x => x.Success_Fail)
                    .Select(x => new
                    {
                        Value = x.Count(),
                        SuccFail = x.Key
                    }).ToList();

                    foreach (var user in failpie)
                    {
                        //piechart
                        pieseries.Points.AddXY(user.SuccFail + " " + user.Value, user.Value);
                    }

                    //piechart
                    Pie.Child = piechart;
                    piechart.ChartAreas[0].AxisX.Title = "Date(s)";
                    piechart.ChartAreas[0].AxisY.Title = "Events Per Day";
                    piechart.Series[0].XValueType = ChartValueType.Date;
                    piechart.ChartAreas[0].AxisX.Interval = Convert.ToDouble(Date_Frequency.SelectedValue);
                    piechart.ChartAreas[0].AxisY.Interval = Convert.ToDouble(Number_Frequency.SelectedValue);
                    //piechart.ChartAreas[0].Area3DStyle.Enable3D = true;
                    //piechart.ChartAreas[0].Area3DStyle.LightStyle = LightStyle.None;
                    //Change bar color if desire
                    piechart.Series[0].BorderColor = Color.Gray;
                    piechart.Series[0]["PieLabelStyle"] = "Outside";
                    //piechart.Series[0].Color = Color.LightBlue;

                    //barchart
                    barchartgf.Child = barchart;
                    barchart.ChartAreas[0].AxisX.Title = "Date(s)";
                    barchart.ChartAreas[0].AxisY.Title = "Events Per Day";
                    barchart.Series[0].XValueType = ChartValueType.Date;
                    barchart.ChartAreas[0].AxisX.Interval = Convert.ToDouble(Date_Frequency.SelectedValue);
                    barchart.ChartAreas[0].AxisY.Interval = Convert.ToDouble(Number_Frequency.SelectedValue);
                    // Create a new legend called "SuccessLegend1".
                    barchart.Legends.Add(new Legend("successLegend"));

                    // Assign the legend to Series1.
                    barchart.Series[0].LegendText = "Success";

                    barchart.Series[0].Legend = "successLegend";
                    barchart.Series[0].IsVisibleInLegend = true;

                    barchart.Legends.Add(new Legend("failureLegend"));

                    // Assign the legend to Series1.
                    barchart.Series[1].LegendText = "Failure";
                    barchart.Series[1].Legend = "failureLegend";
                    barchart.Series[1].IsVisibleInLegend = true;

                    //Change bar color if desired
                    //barchart.Series[0].Color = Color.Blue;

                    //linechart
                    linechartgf.Child = linechart;
                    linechart.ChartAreas[0].AxisX.Title = "Date(s)";
                    linechart.ChartAreas[0].AxisY.Title = "Events Per Day";
                    linechart.Series[0].XValueType = ChartValueType.Date;
                    linechart.ChartAreas[0].AxisX.Interval = Convert.ToDouble(Date_Frequency.SelectedValue);
                    linechart.ChartAreas[0].AxisY.Interval = Convert.ToDouble(Number_Frequency.SelectedValue);

                    //label text changed to done
                    //progressbar.Value = 100;
                    FileSystemWatcher watcher = new FileSystemWatcher();
                    watcher.Path = System.IO.Path.GetDirectoryName(fileName);
                    watcher.NotifyFilter = NotifyFilters.Size;
                    watcher.Filter = System.IO.Path.GetFileName(fileName);
                    watcher.Changed += new FileSystemEventHandler(OnChanged);
                    watcher.EnableRaisingEvents = true;

                    //progressbar.Value = 0;
                    //progressbar.Refresh();
                    //this.DataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".txt";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                fileTextbox.Text = filename;
            }
        }

        private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() => {
                ButtonAutomationPeer peer = new ButtonAutomationPeer(updatebutton);
                IInvokeProvider invokeProv =
                  peer.GetPattern(PatternInterface.Invoke)
                  as IInvokeProvider;
                invokeProv.Invoke();
            }));
        }
    }
}

