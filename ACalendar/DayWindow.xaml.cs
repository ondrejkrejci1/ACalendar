using ACalendar.Track;
using ACalendar.UI;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACalendar
{
    /// <summary>
    /// Interakční logika pro DayWindow.xaml
    /// </summary>
    public partial class DayWindow : Window
    {

        private List<Training> trainings;
        private List<Meeting> meetings;
        public AddActivityButton AddActiviti {  get; private set; }

        public DayWindow(AddActivityButton button, Athlete athlete)
        {
            InitializeComponent();

            trainings = new List<Training>();
            meetings = new List<Meeting>();

            AddActiviti = button;
            AddActiviti.InitializeAddEventAction(athlete);

            AddActiviti.SpecialSettings();

            Main.Children.Add(AddActiviti.AddActivity);
            Main.Children.Add(AddActiviti.AddPanel);
        }

        public void AddTraining(Training training)
        {
            trainings.Add(training);

            this.Height += 50;
            Trainings.Height += 50;

            Trainings.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });

            Day.Text = $"{training.Date.Day}.{training.Date.Month}.{training.Date.Year}";

            NothingHere.Visibility = Visibility.Hidden;

            Grid trainingVisual = new Grid();
            trainingVisual.Height = 40;
            trainingVisual.Margin = new Thickness(5);
            trainingVisual.Background = new SolidColorBrush(Colors.LightSalmon);

            trainingVisual.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            trainingVisual.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            trainingVisual.ColumnDefinitions.Add(new ColumnDefinition());
            trainingVisual.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });

            Button viewFull = new Button();
            viewFull.Height = 30;
            viewFull.Height = 30;
            viewFull.Margin = new Thickness(5);
            viewFull.Content = "View";
            viewFull.BorderThickness = new Thickness(0);

            viewFull.Click += (s, e) =>
            {
                TrainingPreview preview = new TrainingPreview(training);
                preview.Show();
            };
            Grid.SetColumn(viewFull, 3);

            TextBlock mainFocus = new TextBlock();

            string focus = training.MainFocus;
            focus = focus.Trim();
            string[] split = focus.Split(' ');
            mainFocus.Text = split[0];

            mainFocus.FontSize = 16;
            mainFocus.VerticalAlignment = VerticalAlignment.Center;
            mainFocus.TextWrapping = TextWrapping.Wrap;
            Grid.SetColumn(mainFocus, 0);
            
            TextBlock rating = new TextBlock();
            rating.Text = $"{training.Rating}/10";
            rating.FontSize = 14;
            rating.VerticalAlignment = VerticalAlignment.Center;
            rating.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(rating, 1);
            
            TextBlock description = new TextBlock();

            description.Text = training.Description;

            if (description.Text.Length > 80)
            {
                description.Text = string.Empty;

                for (int i = 0; i < 80; i++)
                {
                    description.Text += training.Description[i];
                }
                description.Text += "...";
            }

            description.FontSize = 12;
            description.HorizontalAlignment = HorizontalAlignment.Left;
            description.VerticalAlignment = VerticalAlignment.Center;
            description.TextWrapping = TextWrapping.Wrap;
            Grid.SetColumn(description, 2);

            trainingVisual.Children.Add(mainFocus);
            trainingVisual.Children.Add(rating);
            trainingVisual.Children.Add(description);
            trainingVisual.Children.Add(viewFull);

            Grid.SetRow(trainingVisual, trainings.Count - 1);

            Trainings.Children.Add(trainingVisual);

        }

        public void AddMeeting(Meeting meeting)
        {
            meetings.Add(meeting);

            this.Height += 50;
            Meetings.Height += 50;

            Meetings.RowDefinitions.Add(new RowDefinition {Height = new GridLength(50) });

            Day.Text = $"{meeting.Date.Day}.{meeting.Date.Month}.{meeting.Date.Year}";

            NothingHere.Visibility = Visibility.Hidden;

            Grid meetingVisual = new Grid();
            meetingVisual.Height = 40;
            meetingVisual.Margin = new Thickness(5,0,5,5);
            meetingVisual.Background = new SolidColorBrush(Colors.LightGreen);
            

            meetingVisual.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            meetingVisual.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(60) });
            meetingVisual.ColumnDefinitions.Add(new ColumnDefinition());
            meetingVisual.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });

            Button viewFull = new Button();
            viewFull.Height = 30;
            viewFull.Height = 30;
            viewFull.Margin = new Thickness(5);
            viewFull.Content = "View";
            viewFull.BorderThickness = new Thickness(0);

            viewFull.Click += (s, e) =>
            {
                MeetingPreview preview = new MeetingPreview(meeting);
                preview.Show();
            };
            Grid.SetColumn(viewFull, 3);

            TextBlock place = new TextBlock();

            string placeText = meeting.Place;
            placeText.Trim();
            string[] split = placeText.Split(' ');
            place.Text = split[0];


            place.FontSize = 16;
            place.VerticalAlignment = VerticalAlignment.Center;
            place.Margin = new Thickness(5, 0, 0, 0);
            Grid.SetColumn(place, 0);

            TextBlock rating = new TextBlock();
            rating.Text = $"{meeting.Rating}/10";
            rating.FontSize = 16;
            rating.VerticalAlignment = VerticalAlignment.Center;
            rating.HorizontalAlignment = HorizontalAlignment.Center;
            Grid.SetColumn(rating, 1);

            TextBlock competitions = new TextBlock();
            string competitionsContent = "Competitions: ";
            foreach(Competition competition in meeting.Competitions)
            {
                competitionsContent += $" {competition.Event.ToString()};";
            }

            competitions.Text = competitionsContent;
            competitions.FontSize = 12;
            competitions.VerticalAlignment = VerticalAlignment.Center;
            competitions.TextWrapping = TextWrapping.Wrap;
            Grid.SetColumn(competitions, 2);

            meetingVisual.Children.Add(place);
            meetingVisual.Children.Add(rating);
            meetingVisual.Children.Add(competitions);
            meetingVisual.Children.Add(viewFull);

            Grid.SetRow(meetingVisual, meetings.Count - 1);

            Meetings.Children.Add(meetingVisual);

        }
    }
}
