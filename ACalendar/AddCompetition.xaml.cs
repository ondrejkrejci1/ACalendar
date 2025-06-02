using ACalendar.Track;
using System.Windows;

namespace ACalendar
{
    /// <summary>
    /// Interakční logika pro AddCompetition.xaml
    /// </summary>
    public partial class AddCompetition : Window
    {
        public AddCompetition(AddEventWindow eventWindow)
        {
            InitializeComponent();

            Submit.Click += (s, e) => 
            {
                Event _event = new Event();

                if (Discipline.SelectedValue is ACalendar.Track.Event selectedEvent)
                {
                    _event = selectedEvent;

                    TimeSpan? timeSpan = Time.Value?.TimeOfDay;

                    if (timeSpan.HasValue)
                    {
                        TimeSpan time = timeSpan.Value;

                        eventWindow.RecieveCompetition(_event, time);

                        this.Close();
                    } else
                    {
                        MessageBox.Show("Please fill in the time.", "Empty time", MessageBoxButton.OK, MessageBoxImage.Error);
                    }


                }
                else
                {
                    MessageBox.Show("Fill in the event.", "Empty event", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            };
        }
    }
}
