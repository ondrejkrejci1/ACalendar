namespace ACalendar.Track
{
    /// <summary>
    /// Meeting represents one whole event where some competitions happened.
    /// </summary>
    public class Meeting
    {
        private List<Competition> competitions;

        private string place;
        private int rating;
        private string weather;
        private DateTime date;

        /// <summary>
        /// Where the meeting took place.
        /// </summary>
        public string Place {  get { return place; } private set { place = value; } }

        /// <summary>
        /// How successful or good the meeting felt, it's just a number.
        /// </summary>
        public int Rating { get { return rating; } private set { rating = value; } }

        /// <summary>
        /// Weather during the meeting day (could be sunny, rainy etc.).
        /// </summary>
        public string Weather { get { return weather; } private set { weather = value; } }

        /// <summary>
        /// The date when the meeting was done.
        /// </summary>
        public DateTime Date { get { return date; } private set { date = value; } }

        /// <summary>
        /// List of competitions that happened in this meeting.
        /// </summary>
        public List<Competition> Competitions { get { return competitions; } }

        /// <summary>
        /// Creates a new meeting. All basic info must be passed.
        /// </summary>
        /// <param name="place">Place of the meeting</param>
        /// <param name="rating">How good the meeting was</param>
        /// <param name="weather">Weather on that day</param>
        /// <param name="date">Date when it happened</param>
        public Meeting(string place, int rating, string weather, DateTime date)
        {
            Place = place;
            Rating = rating;
            Weather = weather;
            Date = date;

            competitions = new List<Competition>();
        }

        /// <summary>
        /// Adds one competition into this meeting.
        /// </summary>
        /// <param name="competition">Competition to add</param>
        public void AddCompetition(Competition competition)
        {
            competitions.Add(competition);
        }

    }
}
