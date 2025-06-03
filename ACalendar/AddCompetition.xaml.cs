using ACalendar.Track;
using System.Windows;

namespace ACalendar
{
    /// <summary>
    /// Window for adding a competition event to an existing meeting.
    /// </summary>
    public partial class AddCompetition : Window
    {

        /// <summary>
        /// Initializes a new instance of the AddCompetition class.
        /// </summary>
        /// <param name="eventWindow">Reference to the parent AddEventWindow to which this competition will be added.</param>
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
