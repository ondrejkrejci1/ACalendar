namespace ACalendar.Track
{
    /// <summary>
    /// Class Athlete represents user who use this app.
    /// </summary>
    public class Athlete
    {
        private string username;
        private string password;

        /// <summary>
        /// Gets username of athlete. This is read-only from outside.
        /// </summary>
        public string Username { get { return username; } private set { username = value; } }

        /// <summary>
        /// Gets password of athlete. Also read-only from outside.
        /// </summary>
        public string Password { get { return password; } private set{ password = value; } }

        /// <summary>
        /// Constructor to create new athlete with username and password.
        /// </summary>
        /// <param name="username">User's login name</param>
        /// <param name="password">User's password</param>
        public Athlete(string username, string password) 
        {
            Username = username;
            Password = password;
        }
    }
}
