using ACalendar.Track;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACalendar.UI
{
    public class DayTile
    {
        private DateTime _date;
        private List<Meeting> meetings;
        private List<Training> trainings;

        public Grid Container { get; private set; }
        public List<Border> Borders { get; private set; }
        public Button DayButton { get; private set; }

        public DateTime Date { get { return _date; } private set { _date = value; } }



        public DayTile(DateTime date, string content) 
        {
            Date = date;

            Initialize(content);

            DayButton.Click += (s, e) =>
            {
                DayWindow dayWindow = new DayWindow();

                foreach (Training training in trainings)
                {
                    dayWindow.AddTraining(training);
                }
                foreach(Meeting meeting in meetings)
                {
                    dayWindow.AddMeeting(meeting);
                }

                dayWindow.Show();
            };

            

        }

        private void Initialize(string content)
        {
            meetings = new List<Meeting>();
            trainings = new List<Training>();
        
            Container = new Grid();
            Container.Margin = new Thickness(1);

            Borders = new List<Border>();

            DayButton = new Button();
            DayButton.Content = content;
            DayButton.Margin = new Thickness(7,7,7,7);
            DayButton.HorizontalContentAlignment = HorizontalAlignment.Center;
            DayButton.VerticalContentAlignment = VerticalAlignment.Center;
            DayButton.BorderThickness  = new Thickness(0);

            Container.Children.Add( DayButton );

        }

        public void AddTraining(Training training)
        {
            trainings.Add( training );
        }

        public void AddMeeting(Meeting meeting)
        {
            meetings.Add(meeting);
        }

        public void AddBorder(bool training)
        {
            if (training)
            {
                if(trainings.Count < 1)
                {
                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.IndianRed);
                    border.BorderThickness = new Thickness(3);
                    border.Margin = new Thickness(5);

                    Container.Children.Add(border);

                    Borders.Add(border);
                }
                
            } else
            {
                if(meetings.Count < 1)
                {
                    Border border = new Border();
                    border.BorderBrush = new SolidColorBrush(Colors.OliveDrab);
                    border.BorderThickness = new Thickness(3);
                    border.Margin = new Thickness(2);

                    Container.Children.Add(border);

                    Borders.Add(border);
                }                
            }
        }


    }
}
