using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ACalendar.UI
{
    public class Calendar
    {
        private List<DayTile> days;
        private Grid calendar;
        public List<DayTile> Days {  get { return days; } }

        private Grid calendarPanel;

        public Calendar(Grid grid)
        {
            calendarPanel = grid;

            GenerateMonthTiles(DateTime.Now.Year,DateTime.Now.Month);
            PlaceDayTiles();
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

            GenerateMonthTiles(year, month);

            PlaceDayTiles();

        }



    }
}
