using ACalendar.Track;
using System.Windows;

namespace ACalendar
{
    /// <summary>
    /// Interakční logika pro TrainingPreview.xaml
    /// </summary>
    public partial class TrainingPreview : Window
    {
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
