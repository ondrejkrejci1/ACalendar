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


        public MainWindow()
        {
            InitializeComponent();

            Thread loginThread = new Thread(() =>
            {
                LoginWindow loginWindow = new LoginWindow(this);
                
                loginWindow.Closed += (s, e) =>
                {
                    System.Windows.Threading.Dispatcher.CurrentDispatcher.InvokeShutdown();
                };

                loginWindow.Show();
                System.Windows.Threading.Dispatcher.Run();
            });

            loginThread.SetApartmentState(ApartmentState.STA);
            loginThread.Start();

            do
            {
                Thread.Sleep(100);
            } while(Athlete == null);

            this.Show();
            this.Activate();
            this.WindowState = WindowState.Normal;
            this.Topmost = true;
            this.Topmost = false;
            this.Focus();


            SetActivityAdd();
            
            UI.Calendar calendar = new UI.Calendar(CalendarGrid,Athlete);
            
            InitializeMoveMonthButtons(calendar);

            InitializeReloadButton(calendar);

        }

        private void InitializeMoveMonthButtons(UI.Calendar calendar)
        {
            MoveMonthButton monthDown = new MoveMonthButton(false, "◀");
            MoveMonthButton monthUp = new MoveMonthButton(true, "▶");

            monthDown.MoveMonthB.Click += (s, e) => { monthMoveCounter--; DateTime change = MoveMonthButton.Move(monthMoveCounter, calendar); MonthAndYear.Text = $"{change.Year}-{change.Month}"; };
            monthUp.MoveMonthB.Click += (s, e) => { monthMoveCounter++; DateTime change = MoveMonthButton.Move(monthMoveCounter, calendar); MonthAndYear.Text = $"{change.Year}-{change.Month}"; };

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
                calendar.UpdateCalendar(current.Year, current.Month);
            };

            BottomSection.Children.Add(realoaButton.Button);
        }
    }
}