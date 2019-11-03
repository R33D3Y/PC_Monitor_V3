using CircularProgressBarApp;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PC_Monitor_V3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double high = 75;
        private double medium = 50;

        public MainWindow()
        {
            ViewModel vm = new ViewModel();

            DataContext = vm;
            InitializeComponent();

            #region Initialise Components

            vm.ProgressBar = new System.Collections.Generic.Dictionary<string, (CircularProgressBar cpb, TextBlock tb)>();
            vm.ProgressBar.Add("CPU_LOAD", (CPU_LOAD_CPB, CPU_LOAD_TEXT));

            #endregion

            #region Update Values

            UpdateProgressBar(vm.ProgressBar["CPU_LOAD"], "Load", 75, "%");

            #endregion
        }

        #region Progress Bar Helpers

        private void UpdateProgressBar((CircularProgressBar cpb, TextBlock tb) tmp, string pre, double value, string unit)
        {
            tmp.cpb.Value = value;
            tmp.tb.Text = pre + "\n" + value.ToString() + unit;
            tmp.cpb.Background = GetColour(value);
        }

        private Brush GetColour(double value)
        {
            if (value >= high)
            {
                return Brushes.Red;
            }

            else if (value < medium)
            {
                return Brushes.Green;
            }

            else
            {
                return Brushes.Orange;
            }
        }

        #endregion
    }
}
