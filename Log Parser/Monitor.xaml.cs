using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Monitor.xaml
    /// </summary>
    public partial class Monitor : Page
    {
        universal regUniversal = new universal();
        Txtreader readText = new Txtreader();
        public Monitor()
        {
            InitializeComponent();

            //set initial selected value
            this.eventDropdown.Items.Insert(0, "All Events");
            this.eventDropdown.SelectedIndex = 0;
            this.eventDropdown.Items.Add("Security");
            this.eventDropdown.Items.Add("Information");
            this.eventDropdown.Items.Add("System");

            this.resultcountDrpdwn.Items.Insert(0, "100");
            this.resultcountDrpdwn.SelectedIndex = 0;
            this.resultcountDrpdwn.Items.Add("500");
            this.resultcountDrpdwn.Items.Add("1000");
            this.resultcountDrpdwn.Items.Add("5000");
            this.resultcountDrpdwn.Items.Add("10000");

            //Set Dates when search initialized
            DateTime today = DateTime.Now;
            datepicker1.Text = today.AddDays(-40).ToString();
            datepicker2.Text = today.ToString();

            //click monitor button
            ButtonAutomationPeer peer = new ButtonAutomationPeer(Monitor_Button);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
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
            if (string.IsNullOrWhiteSpace(fileTextbox.Text) || !File.Exists(fileTextbox.Text))
            {
                //if filebox is null or only white space dispay error message
                MessageBox.Show("File location cannot be found.");
            }
            else
            {
                //set status label text
                statusLabel.Content = "Monitoring log for changes...";
                statusLabel.Refresh();

                //file location variable
                string fileName = fileTextbox.Text;

                //escape any special characters with searchbox so they are interpreted literally
                string searchString = Regex.Escape(searchbox.Text);

                //Start timer (mostly for testing to see which method of text reading faster)
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                int counter = 0;

                //Clear the datagrid so new values can be clearly seen populating
                this.DataGrid1.ItemsSource = null;

                //initialize collection for use in datagrid
                ObservableCollection<Log> users = new ObservableCollection<Log>();

                //Put date picker selected values in variable
                DateTime startDate = datepicker1.SelectedDate.Value;
                DateTime endDate = datepicker2.SelectedDate.Value;
                TimeSpan diffDate = endDate.Subtract(startDate);

                //Parse combobox to get integer from text value
                bool parsed = Int32.TryParse(resultcountDrpdwn.Text, out counter);

                //int i = 0;
                int count = 0;
                progressbar.Minimum = 0;
                progressbar.Maximum = counter;
                if (eventDropdown.SelectedIndex == 0)
                {
                    //Match the output of the TxtReader function to the output of the Regex function
                    foreach (Match match in Regex.Matches(readText.Readtxtfile(fileName), regUniversal.section(), RegexOptions.Singleline))
                    {
                        count++;
                        if (!parsed)
                        {
                            MessageBox.Show("Must enter a number in box");
                        }

                        if (count == counter)
                        {
                            //stop script when loop max results reached.
                            break;
                        }
                        //get logs
                        string log = match.Value;
                        bool found = regUniversal.search(searchString, log);

                        DateTime dt;
                        DateTime.TryParse(regUniversal.finddate(log), out dt);

                        if ((dt > startDate) && (dt < endDate))
                        {
                            if (string.IsNullOrWhiteSpace(searchbox.Text) || found == true)
                            {
                                //add found values to users observable collection
                                users.Add(new Log
                                {
                                    //numbering = count,
                                    Date = regUniversal.finddate(log),
                                    Event_Number = regUniversal.IDnum(log),
                                    Success_Fail = regUniversal.Audit(log),
                                    Source = regUniversal.source(log),
                                    Description = regUniversal.description(log),
                                    Event_ID = regUniversal.secid(log),
                                    Account_Name = regUniversal.accname(log),
                                    Object_Type = regUniversal.objtype(log)
                                });

                                //update progress bar
                                progressbar.Value = count;
                                progressbar.Refresh();
                            }
                        }
                    }

                    //put users observable collection in the datagrid               
                    DataGrid1.ItemsSource = users;
                    progressbar.Value = 0;

                    //stop the timer
                    stopWatch.Stop();

                    //find out how much time elapsed
                    TimeSpan ts = stopWatch.Elapsed;
                    TimeSpan interval = TimeSpan.FromMilliseconds(ts.Milliseconds);
                    string timeInterval = interval.TotalSeconds.ToString();
                    timelabel.Content = timeInterval;
                    timelabel.Refresh();

                    //count the number of rows
                    int noOfRows = DataGrid1.Items.Count;

                    /*
                    //label text changed when done searching
                    if (noOfRows == 0)
                    {
                        statusLabel.Content = "No Items Found.";
                    }

                    if (noOfRows != 0)
                    {
                        statusLabel.Content = noOfRows + " Items Found.";
                    }
                    */
                    //label text changed to done
                    
                        progressbar.Value = 100;
                        FileSystemWatcher watcher = new FileSystemWatcher();
                        watcher.Path = System.IO.Path.GetDirectoryName(fileName);
                        watcher.NotifyFilter = NotifyFilters.Size;
                        watcher.Filter = System.IO.Path.GetFileName(fileName);
                        watcher.Changed += new FileSystemEventHandler(OnChanged);
                        watcher.EnableRaisingEvents = true;                   
                    //this.DataGrid.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(new Action(() =>
            {
                ButtonAutomationPeer peer = new ButtonAutomationPeer(Monitor_Button);
                IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
                invokeProv.Invoke();
                statusLabel.Content = "Log has been updated";          
            }));
        }

    }
}

