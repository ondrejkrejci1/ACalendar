using ACalendar.Track;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACalendar.UI
{
    /// <summary>
    /// This class represent one day tile on calendar.
    /// It contain button to show day details and borders for trainings or meetings.
    /// </summary>
    public class DayTile
    {
        private DateTime _date;
        private List<Meeting> meetings;
        private List<Training> trainings;

        /// <summary>
        /// Container grid for all UI elements of this tile.
        /// </summary>
        public Grid Container { get; private set; }

        /// <summary>
        /// List of borders which can show trainings or meetings visually.
        /// </summary>
        public List<Border> Borders { get; private set; }

        /// <summary>
        /// Button that user can click to open day window with details.
        /// </summary>
        public Button DayButton { get; private set; }

        public DateTime Date { get { return _date; } private set { _date = value; } }


        /// <summary>
        /// Constructor initialize tile with date, button content and athlete for context.
        /// It also attach click event for button.
        /// </summary>
        /// <param name="date">Date for this tile</param>
        /// <param name="content">Text on the button (usually day number)</param>
        /// <param name="athlete">Athlete to show activities for</param>
        public DayTile(DateTime date, string content,Athlete athlete) 
        {
            Date = date;

            Initialize(content);

            DayButton.Click += (s, e) =>
            {
                DayWindow dayWindow = new DayWindow(new AddActivityButton(),athlete);


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

        // Initialize UI components
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

        /// <summary>
        /// Add training activity to this day tile.
        /// </summary>
        /// <param name="training">Training to add</param>
        public void AddTraining(Training training)
        {
            trainings.Add( training );
        }

        /// <summary>
        /// Add meeting activity to this day tile.
        /// </summary>
        /// <param name="meeting">Meeting to add</param>
        public void AddMeeting(Meeting meeting)
        {
            meetings.Add(meeting);
        }

        /// <summary>
        /// Add border to tile to show if there is training or meeting.
        /// If border already exist it will not add more.
        /// </summary>
        /// <param name="training">True for training border, false for meeting border</param>
        /// <param name="visible">If false border will be hidden</param>
        public void AddBorder(bool training, bool visible)
        {
            if (training)
            {
                if(trainings.Count < 1)
                {
                    Border border = new Border();
                    border.Tag = "Training";
                    border.BorderBrush = new SolidColorBrush(Colors.IndianRed);
                    border.BorderThickness = new Thickness(3);
                    border.Margin = new Thickness(5);

                    if (!visible)
                    {
                        border.Visibility = Visibility.Hidden;
                    }

                    Container.Children.Add(border);

                    Borders.Add(border);
                }
                
            } else
            {
                if(meetings.Count < 1)
                {
                    Border border = new Border();
                    border.Tag = "Meeting";
                    border.BorderBrush = new SolidColorBrush(Colors.OliveDrab);
                    border.BorderThickness = new Thickness(3);
                    border.Margin = new Thickness(2);

                    if (!visible)
                    {
                        border.Visibility = Visibility.Hidden;
                    }

                    Container.Children.Add(border);

                    Borders.Add(border);
                }                
            }
        }

        /// <summary>
        /// Hide or show borders for training or meeting.
        /// </summary>
        /// <param name="training">True for training borders, false for meeting borders</param>
        /// <param name="visibility">Visibility value to set</param>
        public void HideBorder(bool training, Visibility visibility)
        {
            if (training)
            {
                foreach(Border border in Borders)
                {
                    if(border.Tag == "Training")
                    {
                        border.Visibility = visibility;
                    }
                }

            } else
            {
                foreach (Border border in Borders)
                {
                    if (border.Tag == "Meeting")
                    {
                        border.Visibility = visibility;
                    }
                }
            }
        }


    }
}
