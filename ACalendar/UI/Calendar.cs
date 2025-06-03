using ACalendar.Database;
using ACalendar.Track;
using System.Windows;
using System.Windows.Controls;

namespace ACalendar.UI
{
    /// <summary>
    /// Represents a calendar UI component that displays day tiles for a given month.
    /// It manages creating the day tiles, placing them on a grid, and linking trainings and meetings to the correct days.
    /// </summary>
    public class Calendar
    {
        private List<DayTile> days;
        private Grid calendar;

        /// <summary>
        /// Gets the list of day tiles currently displayed on the calendar.
        /// </summary>
        public List<DayTile> Days {  get { return days; } }

        private Grid calendarPanel;

        private Athlete athlete;

        /// <summary>
        /// Creates a new calendar instance.
        /// It initializes day tiles for the current month and loads activities for the given athlete.
        /// </summary>
        /// <param name="grid">The grid container to place the day tiles into.</param>
        /// <param name="athlete">The athlete whose activities are shown on the calendar.</param>
        /// <param name="trainingVisibility">Whether training borders should be visible initially.</param>
        /// <param name="meetingVisibiliti">Whether meeting borders should be visible initially.</param>
        public Calendar(Grid grid, Athlete athlete,bool trainingVisibility, bool meetingVisibiliti)
        {
            calendarPanel = grid;
            this.athlete = athlete;

            GenerateMonthTiles(DateTime.Now.Year, DateTime.Now.Month);
            PlaceDayTiles();
            ActivitiesToDays(athlete, trainingVisibility, meetingVisibiliti);
        }


        /// <summary>
        /// Generates DayTile instances for every day in the specified month and year.
        /// </summary>
        /// <param name="year">Year for the month to generate.</param>
        /// <param name="month">Month to generate days for.</param>
        public void GenerateMonthTiles(int year,int month)
        {
            int numberOfDays = DateTime.DaysInMonth(year, month);

            days = new List<DayTile>();

            for (int i = 1; i < numberOfDays+1; i++)
            {
                DayTile day = new DayTile(new DateTime(year,month,i),i.ToString(),athlete);
                days.Add(day);
            }

        }

        /// <summary>
        /// Places the day tiles in the grid according to their weekday positions.
        /// The week starts on Monday.
        /// </summary>
        public void PlaceDayTiles()
        {
            int year = GetTile(0).Date.Year;
            int month = GetTile(0).Date.Month;

            DateTime firstDayOfMonth = new DateTime(year, month, 1);
            int startDay = ((int)firstDayOfMonth.DayOfWeek + 6) % 7;

            int row = 0;
            int column = startDay;

            foreach(DayTile dayTile in days)
            {
                Grid.SetRow(dayTile.Container,row);
                Grid.SetColumn(dayTile.Container,column);

                calendarPanel.Children.Add(dayTile.Container);

                column++;

                if(column > 6)
                {
                    row++;
                    column = 0;
                }

            }


        }

        /// <summary>
        /// Returns the day tile at the specified index.
        /// </summary>
        public DayTile GetTile(int index)
        {
            return Days[index];
        }

        /// <summary>
        /// Updates the calendar to show the specified month and year.
        /// It clears old tiles and activities and generates new ones.
        /// </summary>
        public void UpdateCalendar(int year, int month, bool visibleTraining, bool visibleMeeting)
        {
            Days.Clear();
            calendarPanel.Children.Clear();

            GenerateMonthTiles(year, month);

            PlaceDayTiles();

            ActivitiesToDays(athlete, visibleTraining, visibleMeeting);

        }

        /// <summary>
        /// Loads activities from the database and assigns them to their corresponding day tiles.
        /// Also controls the visibility of training and meeting borders.
        /// </summary>
        private void ActivitiesToDays(Athlete athlete, bool visibleTraining, bool visibleMeeting)
        {
            List<Training> savedTrainings = TrainingDAO.GetAllTrainings(athlete);

            foreach(Training training in savedTrainings)
            {
                foreach(DayTile day in Days)
                {
                    if(day.Date.Date == training.Date.Date)
                    {
                        day.AddBorder(true,visibleTraining);
                        day.AddTraining(training);
                    }
                }
            }

            List<Meeting> savedMeetings = MeetingDAO.GetAllMeetings(athlete);

            foreach (Meeting meeting in savedMeetings)
            {
                
                foreach (DayTile day in Days)
                {
                    if (day.Date.Date == meeting.Date.Date)
                    {
                        day.AddBorder(false,visibleMeeting);
                        day.AddMeeting(meeting);
                    }
                }
            }

        }

        /// <summary>
        /// Sets the visibility of all meeting borders on the calendar.
        /// </summary>
        public void VisibilityMeetings(Visibility visibility)
        {
            foreach (DayTile day in Days)
            {
                day.HideBorder(false, visibility);
            }
        }

        /// <summary>
        /// Sets the visibility of all training borders on the calendar.
        /// </summary>
        public void VisibilityTrainings(Visibility visibility)
        {
            foreach (DayTile day in Days)
            {
                day.HideBorder(true, visibility);
            }
        }

    }
}
