namespace ACalendar.Track
{
    /// <summary>
    /// Represents one training session done by the athlete.
    /// It stores basic info like how it went, what was done, and when.
    /// </summary>
    public class Training
    {
        private string mainFocus;
        private int rating;
        private string description;
        private string weather;
        private DateTime date;

        /// <summary>
        /// What was the main focus of this training (e.g. endurance, speed, technique).
        /// </summary>
        public string MainFocus {  get { return mainFocus; } private set { mainFocus = value; } }

        /// <summary>
        /// Rating of the session, how good or bad it was (usually 1–10).
        /// </summary>
        public int Rating { get { return rating; } private set { rating = value; } }

        /// <summary>
        /// Some extra notes or summary what exactly happened.
        /// </summary>
        public string Description { get { return description; } private set { description = value; } }

        /// <summary>
        /// What was the weather like during this training.
        /// </summary>
        public string Weather { get { return weather; } private set { weather = value; } }

        /// <summary>
        /// Date when the training happened.
        /// </summary>
        public DateTime Date { get { return date; } private set { date = value; } }

        /// <summary>
        /// Constructor for creating a new Training.
        /// All fields must be provided to keep consistency.
        /// </summary>
        /// <param name="mainFocus">The focus of the session</param>
        /// <param name="rating">How the training felt (rating number)</param>
        /// <param name="description">Free text about the training</param>
        /// <param name="weather">Weather condition during the training</param>
        /// <param name="date">When it was done</param>
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
