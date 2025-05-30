using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACalendar.Track
{
    public class Training
    {
        private string mainFocus;
        private int rating;
        private string description;
        private string weather;
        private DateTime date;

        public string MainFocus {  get { return mainFocus; } private set { mainFocus = value; } }
        public int Rating { get { return rating; } private set { rating = value; } }
        public string Description { get { return description; } private set { description = value; } }
        public string Weather { get { return weather; } private set { weather = value; } }
        public DateTime Date { get { return date; } private set { date = value; } }

        public Training(string mainFocus,int rating,string description,string weather,DateTime date)
        {
            MainFocus = mainFocus;
            Rating = rating;
            Description = description;
            Weather = weather;
            Date = date;
        }





    }
}
