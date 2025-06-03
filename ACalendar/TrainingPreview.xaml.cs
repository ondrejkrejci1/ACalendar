using ACalendar.Track;
using System.Windows;

namespace ACalendar
{
    /// <summary>
    /// Window for displaying a preview of a training session.
    /// </summary>
    public partial class TrainingPreview : Window
    {

        /// <summary>
        /// Initializes a new instance of the TrainingPreview class 
        /// and displays the details of the specified training.
        /// </summary>
        /// <param name="training">The training instance whose details will be shown.</param>
        public TrainingPreview(Training training)
        {
            InitializeComponent();

            MainFocus.Text = training.MainFocus;
            Rating.Text = training.Rating.ToString() + "/10";
            Date.Text = $"{training.Date.Day}.{training.Date.Month}.{training.Date.Year}";
            Weather.Text = training.Weather;
            Description.Text = training.Description;

        }
    }
}
