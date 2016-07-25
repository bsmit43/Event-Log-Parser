using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Monitor.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //navigate to Dashboard view when initialized
            InitializeComponent();
            _mainFrame.Navigate(new Dashboard());
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            //navigate to dashboard view when clicked
            _mainFrame.Navigate(new Dashboard());
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //navigate to search view when clicked
            _mainFrame.Navigate(new Search());
        }

        private void _mainFrame_Navigated_2(object sender, RoutedEventArgs e)
        {
            //navigated to Monitor view when clicked
            _mainFrame.Navigate(new Monitor());
        }
    }
}
