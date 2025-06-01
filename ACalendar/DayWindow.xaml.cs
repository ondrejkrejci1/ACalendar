using ACalendar.Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ACalendar
{
    /// <summary>
    /// Interakční logika pro DayWindow.xaml
    /// </summary>
    public partial class DayWindow : Window
    {

        private List<Training> trainings;
        private List<Meeting> meetings;
        public DayWindow()
        {
            InitializeComponent();

            trainings = new List<Training>();
            meetings = new List<Meeting>();

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

            TextBlock mainFocus = new TextBlock();
            mainFocus.Text = training.MainFocus;
            mainFocus.FontSize = 16;
            mainFocus.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(mainFocus, 0);
            
            TextBlock rating = new TextBlock();
            rating.Text = $"{training.Rating}/10";
            rating.FontSize = 14;
            rating.VerticalAlignment = VerticalAlignment.Center;
            Grid.SetColumn(rating, 1);
            
            TextBlock description = new TextBlock();
            description.Text = training.Description;
            description.FontSize = 12;
            description.HorizontalAlignment = HorizontalAlignment.Left;
            description.VerticalAlignment = VerticalAlignment.Center;
            description.TextWrapping = TextWrapping.Wrap;
            Grid.SetColumn(description, 2);

            trainingVisual.Children.Add(mainFocus);
            trainingVisual.Children.Add(rating);
            trainingVisual.Children.Add(description);

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

            TextBlock place = new TextBlock();
            place.Text = meeting.Place;
            place.FontSize = 16;
            place.VerticalAlignment = VerticalAlignment.Center;
            place.Margin = new Thickness(5, 0, 0, 0);
            Grid.SetColumn(place, 0);

            TextBlock rating = new TextBlock();
            rating.Text = $"{meeting.Rating}/10";
            rating.FontSize = 16;
            rating.VerticalAlignment = VerticalAlignment.Center;
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

            Grid.SetRow(meetingVisual, meetings.Count - 1);

            Meetings.Children.Add(meetingVisual);

        }
    }
}
