namespace ACalendar.Track
{
    /// <summary>
    /// Class that represents one competition during meeting.
    /// </summary>
    public class Competition
    {
        private Event _event;
        private TimeSpan startOfCompetition;

        /// <summary>
        /// Gets event type for this competition.
        /// </summary>
        public Event Event { get { return _event; } private set { _event = value; } }

        /// <summary>
        /// Gets time when competition should start, only time of day is used.
        /// </summary>
        public TimeSpan StartOfCompetition { get { return startOfCompetition; } private set { startOfCompetition = value; } }

        /// <summary>
        /// Constructor for new competition instance. Needs event type and time of start.
        /// </summary>
        /// <param name="_event">The event type that this competition is about.</param>
        /// <param name="start">The time when it starts (like 13:45).</param>
        public Competition(Event _event, TimeSpan start)
        {
            Event = _event;
            StartOfCompetition = start;
        }


    }
}
