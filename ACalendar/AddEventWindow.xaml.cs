﻿using ACalendar.Database;
using ACalendar.Track;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACalendar
{
    /// <summary>
    /// Window for adding either a training or a meeting event for an athlete.
    /// </summary>
    public partial class AddEventWindow : Window
    {
        private Athlete user;

        private List<Competition> competitionsToMeeting;
        private StackPanel competitionPanel;
        private TextBox description;

        private int competitionTableCounter = 1;
        private bool TrainingMode;

        /// <summary>
        /// Initializes a new instance of the AddEventWindow class.
        /// Sets up the window according to the variant (training or meeting).
        /// </summary>
        /// <param name="variant">Type of event to add ("training" or "meeting").</param>
        /// <param name="athlete">The athlete for whom the event is added.</param>
        public AddEventWindow(string variant, Athlete athlete)
        {
            InitializeComponent();
            ResizeMode = ResizeMode.NoResize;

            this.user = athlete;

            switch (variant)
            {
                case "training":
                    TrainingSetup();
                    TrainingMode = true;
                    break;
                case "meeting":
                    competitionsToMeeting = new List<Competition>();
                    MeetingSetup();
                    TrainingMode = false;
                    break;
            }

            Submit.Click += (s, e) =>
            {
                if (TrainingMode)
                {
                    string mainFocus = MainInput.Text;
                    int rating = GetSelectedRadioNumber();
                    string weather = WeatherInput.Text;
                    string descriptionToSave = description.Text;

                    if (mainFocus != string.Empty || rating != 0 || weather != string.Empty || descriptionToSave != string.Empty)
                    {
                        if (DateTime.TryParse(DateInput.Text, out DateTime date))
                        {
                            Training training = new Training(mainFocus, rating, descriptionToSave, weather, date);

                            TrainingDAO.Save(training, user);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please fill in the date.", "Empty date", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    } else
                    {
                        MessageBox.Show("Fill in all parameters", "Empty parameters", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }
                else
                {
                    string place = MainInput.Text;
                    int rating = GetSelectedRadioNumber();
                    string weather = WeatherInput.Text;

                    if (place != string.Empty || rating != 0 || weather != string.Empty)
                    {
                        if (DateTime.TryParse(DateInput.Text, out DateTime date))
                        {
                            Meeting meeting = new Meeting(place, rating, weather, date);

                            MeetingDAO.Save(meeting, user);

                            foreach (Competition competition in competitionsToMeeting)
                            {
                                CompetitionDAO.Save(competition, meeting, user);
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Please fill in the date.", "Empty date", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Fill in all parameters", "Empty parameters", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
            };
        }

        /// <summary>
        /// Sets up the UI components for entering training details.
        /// </summary>
        private void TrainingSetup()
        {
            Title.Text = "Training";

            MainInputTitle.Text = "Main Focus:";

            TextBlock title = new TextBlock();
            title.Text = "Description:";
            title.FontSize = 16;
            title.HorizontalAlignment = HorizontalAlignment.Left;
            title.VerticalAlignment = VerticalAlignment.Top;
            title.Margin = new Thickness(30, 0, 0, 0);

            BottomPart.Children.Add(title);

            description = new TextBox();
            description.VerticalAlignment = VerticalAlignment.Top;
            description.HorizontalAlignment = HorizontalAlignment.Left;
            description.Margin = new Thickness(30, 20, 0, 0);
            description.Width = 565;
            description.Height = 90;
            description.MaxLength = 300;
            description.TextWrapping = TextWrapping.Wrap;

            BottomPart.Children.Add(description);

        }

        /// <summary>
        /// Sets up the UI components for entering meeting details.
        /// </summary>
        private void MeetingSetup()
        {
            Title.Text = "Meeting";

            MainInputTitle.Text = "Place:";

            Rating.Text = "Difficulty:";

            WeatherTitle.Text = "Weather forecast:";


            Button addCompetition = new Button();
            addCompetition.Content = "Add Competition";
            addCompetition.HorizontalAlignment = HorizontalAlignment.Left;
            addCompetition.VerticalAlignment = VerticalAlignment.Top;
            addCompetition.Margin = new Thickness(0, 0, 0, 5);
            addCompetition.Width = 100;
            addCompetition.Height = 35;

            addCompetition.Click += (s, e) =>
            {
                AddCompetition addCompetition = new AddCompetition(this);
                addCompetition.Show();
            };

            competitionPanel = new StackPanel();
            competitionPanel.Width = 580;
            competitionPanel.Orientation = Orientation.Vertical;
            competitionPanel.VerticalAlignment = VerticalAlignment.Top;
            competitionPanel.HorizontalAlignment = HorizontalAlignment.Left;
            competitionPanel.Margin = new Thickness(30, 5, 0, 0);

            competitionPanel.Children.Add(addCompetition);
            
            BottomPart.Children.Add(competitionPanel);

        }

        /// <summary>
        /// Receives a new competition event and adds it to the meeting.
        /// </summary>
        /// <param name="_event">The event to add.</param>
        /// <param name="time">The start time of the competition.</param>
        /// <returns>Returns true when the competition is added successfully.</returns>
        public bool RecieveCompetition(Event _event, TimeSpan time)
        {
            Event trackEvent = _event;

            Competition competition = new Competition(trackEvent, time);

            AddCompetitionToMeeting(competition);

            return true;
        }

        /// <summary>
        /// Adds a competition UI entry to the meeting panel and internal list.
        /// </summary>
        /// <param name="competition">The competition to add.</param>
        private void AddCompetitionToMeeting(Competition competition)
        {
            Grid competitionGrid = new Grid();
            competitionGrid.Height = 20;
            competitionGrid.Margin = new Thickness(0, 0, 10, 0);
            
            competitionGrid.ColumnDefinitions.Add(new ColumnDefinition());
            competitionGrid.ColumnDefinitions.Add(new ColumnDefinition());
            competitionGrid.ColumnDefinitions.Add(new ColumnDefinition());
            
            if (competitionTableCounter % 2 == 0)
            {
                competitionGrid.Background = new SolidColorBrush(Colors.LightBlue);
            }
            else
            {
                competitionGrid.Background = new SolidColorBrush(Colors.LightGray);
            }
            competitionTableCounter++;



            TextBlock raceIcon = new TextBlock();
            raceIcon.Text = "🏁";
            raceIcon.HorizontalAlignment = HorizontalAlignment.Left;
            raceIcon.VerticalAlignment = VerticalAlignment.Center;
            raceIcon.FontSize = 14;


            TextBlock eventName = new TextBlock();
            eventName.Text = competition.Event.ToString();
            eventName.HorizontalAlignment = HorizontalAlignment.Left;
            eventName.VerticalAlignment = VerticalAlignment.Center;
            eventName.FontSize = 14;



            TextBlock time = new TextBlock();
            time.Text = competition.StartOfCompetition.ToString();
            time.HorizontalAlignment = HorizontalAlignment.Right;
            time.VerticalAlignment = VerticalAlignment.Center;
            time.FontSize = 14;


            Grid.SetColumn(raceIcon, 0);
            Grid.SetColumn(eventName, 1);
            Grid.SetColumn(time, 2);

            competitionGrid.Children.Add(raceIcon);
            competitionGrid.Children.Add(eventName);
            competitionGrid.Children.Add(time);

            competitionPanel.Children.Add(competitionGrid);

            competitionsToMeeting.Add(competition);

        }

        /// <summary>
        /// Gets the integer value associated with the selected rating radio button.
        /// </summary>
        /// <returns>The selected rating number; returns 0 if none selected.</returns>
        public int GetSelectedRadioNumber()
        {
            RadioButton[] buttons = new RadioButton[] {R1, R2, R3, R4, R5, R6, R7, R8, R9, R10 };

            foreach (RadioButton radio in buttons)
            {
                if (radio.IsChecked == true)
                {
                    return Convert.ToInt32(radio.Tag);
                }
            }
            return 0;
        }

    }
}
