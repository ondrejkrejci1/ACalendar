using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACalendar.Track
{
    public class Meeting
    {
        private List<Competition> competitions;

        private string place;
        private int rating;
        private string weather;
        private DateTime date;

        public string Place {  get { return place; } private set { place = value; } }
        public int Rating { get { return rating; } private set { rating = value; } }
        public string Weather { get { return weather; } private set { weather = value; } }
        public DateTime Date { get { return date; } private set { date = value; } }

        public List<Competition> Competitions { get; }

        public Meeting(string place, int rating, string weather, DateTime date)
        {
            Place = place;
            Rating = rating;
            Weather = weather;
            Date = date;

            competitions = new List<Competition>();
        }

        public void AddCompetition(Competition competition)
        {
            competitions.Add(competition);
        }

    }
}
