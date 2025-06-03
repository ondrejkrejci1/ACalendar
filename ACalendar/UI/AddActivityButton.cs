using ACalendar.Track;
using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    /// <summary>
    /// This class creates and manages buttons for adding activities in UI.
    /// It provides main add button and buttons to add training or meeting.
    /// Also contains panel to hold the training and meeting buttons.
    /// </summary>
    public class AddActivityButton
    {
        /// <summary>
        /// Main button to show add options.
        /// </summary>
        public Button AddActivity;

        /// <summary>
        /// Button to add new training.
        /// </summary>
        public Button AddTraining;

        /// <summary>
        /// Button to add new meeting.
        /// </summary>
        public Button AddMeeting;

        /// <summary>
        /// Panel which contains AddTraining and AddMeeting buttons.
        /// </summary>
        public StackPanel AddPanel;

        /// <summary>
        /// Constructor initialize all buttons and panel with default settings.
        /// Also sets up events to show and hide buttons properly.
        /// </summary>
        public AddActivityButton()
        {
            AddActivity = new Button();
            AddActivity.Height = 50;
            AddActivity.Width = 70;
            AddActivity.HorizontalAlignment = HorizontalAlignment.Right;
            AddActivity.VerticalAlignment = VerticalAlignment.Bottom;
            AddActivity.Margin = new Thickness(0, 0, 5, 5);
            AddActivity.Content = "✚";
            AddActivity.FontSize = 40;
            AddActivity.BorderThickness = new Thickness(0);

            AddActivity.Click += (s, e) =>
            {
                AddActivity.Visibility = Visibility.Hidden;

                AddPanel.Visibility = Visibility.Visible;
                AddTraining.Visibility = Visibility.Visible;
                AddMeeting.Visibility = Visibility.Visible;
            };
            

            AddTraining = new Button();
            AddTraining.Height = 25;
            AddTraining.Width = 90;
            AddTraining.Content = "Add Training";
            AddTraining.HorizontalContentAlignment = HorizontalAlignment.Center;
            AddTraining.VerticalContentAlignment = VerticalAlignment.Center;
            AddTraining.Visibility = Visibility.Hidden;
            AddTraining.BorderThickness = new Thickness(0);


            AddMeeting = new Button();
            AddMeeting.Height = 25;
            AddMeeting.Width = 90;
            AddMeeting.Content = "Add Meeting";
            AddMeeting.HorizontalContentAlignment = HorizontalAlignment.Center;
            AddMeeting.VerticalContentAlignment = VerticalAlignment.Center;
            AddMeeting.Visibility = Visibility.Hidden;
            AddMeeting.BorderThickness = new Thickness(0);

            AddPanel = new StackPanel();
            AddPanel.Height = 50;
            AddPanel.Width = 90;
            AddPanel.HorizontalAlignment = HorizontalAlignment.Right;
            AddPanel.VerticalAlignment = VerticalAlignment.Bottom;
            AddPanel.Margin = new Thickness(0,0,5,5);
            AddPanel.Visibility = Visibility.Hidden;

            AddPanel.MouseLeave += (s, e) =>
            {
                AddPanel.Visibility = Visibility.Hidden;
                AddTraining.Visibility = Visibility.Hidden;
                AddMeeting.Visibility = Visibility.Hidden;

                AddActivity.Visibility = Visibility.Visible;
            };

            AddPanel.Children.Add(AddMeeting);
            AddPanel.Children.Add(AddTraining);


        }

        /// <summary>
        /// Change layout of buttons
        /// </summary>
        public void SpecialSettings()
        {
            AddActivity.HorizontalAlignment = HorizontalAlignment.Center;
            AddActivity.Margin = new Thickness(0,5,0,0);

            AddPanel.HorizontalAlignment= HorizontalAlignment.Center;
            AddPanel.Margin = new Thickness(0, -47, 0, 0);
        }

        /// <summary>
        /// Initialize click actions for add training and meeting buttons.
        /// When clicked, it opens new window to add the event.
        /// </summary>
        /// <param name="athlete">Athlete for whom new events are added</param>
        public void InitializeAddEventAction(Athlete athlete)
        {
            AddTraining.Click += (s, e) => {
                AddEventWindow addEvent = new AddEventWindow("training", athlete);
                addEvent.Show();
            };

            AddMeeting.Click += (s, e) => {
                AddEventWindow addEvent = new AddEventWindow("meeting", athlete);
                addEvent.Show();
            };

        }



    }
}
