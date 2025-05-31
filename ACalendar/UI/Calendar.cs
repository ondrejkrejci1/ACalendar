using ACalendar.Database;
using ACalendar.Track;
using System.Windows.Controls;
using System.Windows.Media;

namespace ACalendar.UI
{
    public class Calendar
    {
        private List<DayTile> days;
        private Grid calendar;
        public List<DayTile> Days {  get { return days; } }

        private Grid calendarPanel;

        private Athlete athlete;

        public Calendar(Grid grid, Athlete athlete)
        {
            calendarPanel = grid;
            this.athlete = athlete;

            GenerateMonthTiles(DateTime.Now.Year, DateTime.Now.Month);
            PlaceDayTiles();
            ActivitiesToDays(athlete);
        }


        public void GenerateMonthTiles(int year,int month)
        {
            int numberOfDays = DateTime.DaysInMonth(year, month);

            days = new List<DayTile>();

            for (int i = 1; i < numberOfDays+1; i++)
            {
                DayTile day = new DayTile(new DateTime(year,month,i),i.ToString());
                days.Add(day);
            }

        }

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

        public DayTile GetTile(int index)
        {
            return Days[index];
        }

        public void UpdateCalendar(int year, int month)
        {
            Days.Clear();
            calendarPanel.Children.Clear();

            GenerateMonthTiles(year, month);

            PlaceDayTiles();

            ActivitiesToDays(athlete);

        }

        private void ActivitiesToDays(Athlete athlete)
        {
            List<Training> savedTrainings = TrainingDAO.GetAllTrainings(athlete);

            foreach(Training training in savedTrainings)
            {
                foreach(DayTile day in Days)
                {
                    if(day.Date.Date == training.Date.Date)
                    {
                        day.AddBorder(true);
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
                        day.AddBorder(false);
                        day.AddMeeting(meeting);
                    }
                }
            }

        }



    }
}
