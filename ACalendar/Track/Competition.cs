using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACalendar.Track
{
    public class Competition
    {
        private Event _event;
        private TimeSpan startOfCompetition;

        public Event Event { get { return _event; } private set { _event = value; } }
        public TimeSpan StartOfCompetition { get { return startOfCompetition; } private set { startOfCompetition = value; } }

        public Competition(Event _event, TimeSpan start)
        {
            Event = _event;
            StartOfCompetition = start;
        }


    }
}
