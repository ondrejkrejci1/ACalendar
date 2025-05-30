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

        public Calendar(Grid grid)
        {

        }


        public void GenerateMonthTiles(int year,int month)
        {

        }

        public void PlaceDayTiles(int year,int month)
        {

        }

        public DayTile GetTile(int index)
        {
            return Days[index];
        }

        public void UpdateCalendar(int year, int month)
        {



        }



    }
}
