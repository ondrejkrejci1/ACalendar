using ACalendar.Track;
using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    public class AddActivityButton
    {
        public Button AddActivity;
        public Button AddTraining;
        public Button AddMeeting;
        public StackPanel AddPanel;

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


            AddMeeting = new Button();
            AddMeeting.Height = 25;
            AddMeeting.Width = 90;
            AddMeeting.Content = "Add Meeting";
            AddMeeting.HorizontalContentAlignment = HorizontalAlignment.Center;
            AddMeeting.VerticalContentAlignment = VerticalAlignment.Center;
            AddMeeting.Visibility = Visibility.Hidden;

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

        public void InitializeAddEventAction(Athlete athlete)
        {
            AddTraining.Click += (s, e) => { AddEventWindow addEvent = new AddEventWindow("training", athlete); addEvent.Show(); };
            AddMeeting.Click += (s, e) => { AddEventWindow addEvent = new AddEventWindow("meeting", athlete); addEvent.Show(); };

        }



    }
}
