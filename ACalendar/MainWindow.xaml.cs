using ACalendar.Track;
using ACalendar.UI;
using System.Windows;
using System.Windows.Controls;

namespace ACalendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Athlete athlete;
        public Athlete Athlete { get { return athlete; } set { athlete = value; } }
        public MainWindow()
        {
            InitializeComponent();

            SetActivityAdd();

        }

        private void SetActivityAdd()
        {
            AddActivityButton activityButton = new AddActivityButton();

            Grid.SetRow(activityButton.AddActivity, 3);
            Grid.SetRow(activityButton.AddPanel, 3);

            MAIN.Children.Add(activityButton.AddActivity);
            MAIN.Children.Add(activityButton.AddPanel);

        }
    }
}