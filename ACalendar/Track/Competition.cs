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
        private float wind;
        private TimeSpan startOfCompetition;

        public Event Event { get { return _event; } private set { _event = value; } }
        public float Wind { get { return wind; } private set { wind = value; } }
        public TimeSpan StartOfCompetition { get { return startOfCompetition; } private set { startOfCompetition = value; } }

        public Competition(Event _event, TimeSpan start)
        {
            Event = _event;
            StartOfCompetition = start;
        }

        public Competition(Event _event, float wind, TimeSpan start)
        {
            Event = _event;
            Wind = wind;
            StartOfCompetition = start;
        }

    }
}
