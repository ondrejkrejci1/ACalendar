using ACalendar.Track;
using System.Windows;
using System.Windows.Controls;

namespace ACalendar
{
    /// <summary>
    /// Interakční logika pro MeetingPreview.xaml
    /// </summary>
    public partial class MeetingPreview : Window
    {
        public MeetingPreview(Meeting meeting)
        {
            InitializeComponent();

            Place.Text = meeting.Place;
            Difficulty.Text = meeting.Rating.ToString()+ "/10";
            Date.Text = $"{meeting.Date.Day}.{meeting.Date.Month}.{meeting.Date.Year}";
            Weather.Text = meeting.Weather;

            foreach(Competition comp in meeting.Competitions)
            {
                Grid grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
                grid.ColumnDefinitions.Add(new ColumnDefinition {  });
                grid.Height = 40;
                grid.Margin = new Thickness(0,0,0,5);

                TextBlock flag = new TextBlock();
                flag.Text = "🏁";
                flag.HorizontalAlignment = HorizontalAlignment.Left;
                flag.VerticalAlignment = VerticalAlignment.Center;
                flag.FontSize = 20;

                TextBlock _event = new TextBlock();
                _event.Text = comp.Event.ToString();
                _event.HorizontalAlignment = HorizontalAlignment.Left;
                _event.VerticalAlignment = VerticalAlignment.Center;
                _event.FontSize = 16;

                TextBlock time = new TextBlock();
                time.Text = $"{comp.StartOfCompetition.Hours}:{comp.StartOfCompetition.Minutes}";
                time.HorizontalAlignment = HorizontalAlignment.Center;
                time.VerticalAlignment = VerticalAlignment.Center;
                time.FontSize = 16;

                Grid.SetColumn(_event, 1);
                Grid.SetColumn(time, 2);

                grid.Children.Add(flag);
                grid.Children.Add(_event);
                grid.Children.Add(time);

                Competitions.Children.Add(grid);
            }



        }
    }
}
