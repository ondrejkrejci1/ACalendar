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

        private int monthMoveCounter;

        private bool meetingBorderVisible = true;
        private bool trainingBorderVisible = true;

        private bool failed = false;

        private UI.Calendar calendar;

        public MainWindow()
        {
            InitializeComponent();

            Thread loginThread = new Thread(() =>
            {
                LoginWindow loginWindow = new LoginWindow(this);
                
                loginWindow.Closed += (s, e) =>
                {
                    System.Windows.Threading.Dispatcher.CurrentDispatcher.InvokeShutdown();
                    failed = true;
                };

                loginWindow.Show();
                System.Windows.Threading.Dispatcher.Run();
            });

            loginThread.SetApartmentState(ApartmentState.STA);
            loginThread.Start();

            do
            {
                if (failed)
                {
                    break;
                }
                Thread.Sleep(100);
            } while(Athlete == null);

            if (failed && athlete == null)
            {
                Environment.Exit(0);
            }

            this.Show();
            this.Activate();
            this.WindowState = WindowState.Normal;
            this.Topmost = true;
            this.Topmost = false;
            this.Focus();


            SetActivityAdd();
            
            this.calendar = new UI.Calendar(CalendarGrid, Athlete, trainingBorderVisible, meetingBorderVisible);
            
            InitializeMoveMonthButtons(calendar);

            InitializeReloadButton(calendar);

            InitializeFilter(calendar);

            InitializeWarning();

        }

        private void InitializeWarning()
        {
            Warning warning = new Warning();

            warning.WarningButton.Click += (s, e) => {
                MessageBox.Show("Do not forget to add todays training.", "Add training", MessageBoxButton.OK);
                warning.HideButton(true);
            };
            
            BottomSection.Children.Add(warning.WarningButton);
        }


        private void InitializeMoveMonthButtons(UI.Calendar calendar)
        {
            MoveMonthButton monthDown = new MoveMonthButton(false, "◀");
            MoveMonthButton monthUp = new MoveMonthButton(true, "▶");

            monthDown.MoveMonthB.Click += (s, e) => { monthMoveCounter--; DateTime change = MoveMonthButton.Move(monthMoveCounter, calendar, trainingBorderVisible, meetingBorderVisible); MonthAndYear.Text = $"{change.Year}-{GetMonthByInt(change.Month)}"; };
            monthUp.MoveMonthB.Click += (s, e) => { monthMoveCounter++; DateTime change = MoveMonthButton.Move(monthMoveCounter, calendar, trainingBorderVisible, meetingBorderVisible); MonthAndYear.Text = $"{change.Year}-{GetMonthByInt(change.Month)}"; };

            MonthDown.Children.Add(monthDown.MoveMonthB);
            MonthUp.Children.Add(monthUp.MoveMonthB);

        }

        private void SetActivityAdd()
        {
            AddActivityButton activityButton = new AddActivityButton();

            Grid.SetRow(activityButton.AddActivity, 3);
            Grid.SetRow(activityButton.AddPanel, 3);

            activityButton.InitializeAddEventAction(athlete);

            MAIN.Children.Add(activityButton.AddActivity);
            MAIN.Children.Add(activityButton.AddPanel);
            
        }

        private void InitializeReloadButton(UI.Calendar calendar)
        {
            ReloadButton realoaButton = new ReloadButton();

            realoaButton.Button.Click += (s, e) =>
            {
                DateTime current = DateTime.Now.AddMonths(monthMoveCounter);
                calendar.UpdateCalendar(current.Year, current.Month, trainingBorderVisible, meetingBorderVisible);
            };

            BottomSection.Children.Add(realoaButton.Button);
        }

        private void InitializeFilter(UI.Calendar calendar)
        {
            Filter meeting = new Filter("Meeting", new Thickness(100, 0, 0, 25));
            Filter training = new Filter("Training", new Thickness(100, 0, 0, 5));

            training.ButtonOperator.Click += (s, e) => 
            {
                if (trainingBorderVisible)
                {
                    calendar.VisibilityTrainings(Visibility.Hidden);
                    trainingBorderVisible = false;
                }
                else
                {
                    calendar.VisibilityTrainings(Visibility.Visible);
                    trainingBorderVisible = true;
                }
            };


            meeting.ButtonOperator.Click += (s, e) =>
            {
                if (meetingBorderVisible)
                {
                    calendar.VisibilityMeetings(Visibility.Hidden);
                    meetingBorderVisible = false;
                }else
                {
                    calendar.VisibilityMeetings(Visibility.Visible);
                    meetingBorderVisible = true;
                }
            };

            BottomSection.Children.Add(meeting.Container);
            BottomSection.Children.Add(training.Container);
        }

        private string GetMonthByInt(int month)
        {
            string monthString = "";

            switch(month){
                case 1:
                    monthString = "January";
                    break;
                case 2:
                    monthString = "February";
                    break;
                case 3:
                    monthString = "March";
                    break;
                case 4:
                    monthString = "April";
                    break;
                case 5:
                    monthString = "May";
                    break;
                case 6:
                    monthString = "June";
                    break;
                case 7:
                    monthString = "July";
                    break;
                case 8:
                    monthString = "Aughust";
                    break;
                case 9:
                    monthString = "September";
                    break;
                case 10:
                    monthString = "October";
                    break;
                case 11:
                    monthString = "November";
                    break;
                case 12:
                    monthString = "December";
                    break;
            }

            return monthString;
        }
    }
}