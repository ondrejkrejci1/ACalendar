using ACalendar.Track;
using System.Data.SqlClient;

namespace ACalendar.Database
{
    /// <summary>
    /// Handles saving and loading meetings from the database.
    /// </summary>
    public class MeetingDAO
    {
        /// <summary>
        /// Saves a meeting entry to the database for the specified athlete.
        /// If the athlete does not already exist in the database, they will be saved first.
        /// </summary>
        /// <param name="meeting">The meeting instance to save.</param>
        /// <param name="athlete">The athlete to whom the meeting belongs.</param>
        public static void Save(Meeting meeting, Athlete athlete)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand commandSelect = null;
            SqlCommand commandInsert = null;

            int athleteID = 0;
            bool savedAthlete = false;

            foreach (Athlete a in AthleteDAO.GetAll())
            {
                if (a.Username == athlete.Username)
                    savedAthlete = true;
            }

            if (!savedAthlete)
            {
                AthleteDAO.Save(athlete);
            }

            using (commandSelect = new SqlCommand("select id from athlete where username = @username and password = @password", conn))
            {
                commandSelect.Parameters.Add(new SqlParameter("@username", athlete.Username));
                commandSelect.Parameters.Add(new SqlParameter("@password", athlete.Password));

                using (SqlDataReader reader = commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        athleteID = int.Parse(reader[0].ToString());
                        break;
                    }
                }
            }

            using (commandInsert = new SqlCommand("insert into meeting(athlete_id,place,date,rating,weather) values(@athlete_id,@place,@date,@rating,@weather)", conn))
            {
                commandInsert.Parameters.Add(new SqlParameter("@athlete_id", athleteID));
                commandInsert.Parameters.Add(new SqlParameter("@place", meeting.Place)); 
                commandInsert.Parameters.Add(new SqlParameter("@date", meeting.Date));
                commandInsert.Parameters.Add(new SqlParameter("@rating", meeting.Rating));
                commandInsert.Parameters.Add(new SqlParameter("@weather", meeting.Weather));

                commandInsert.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retrieves all meetings for the specified athlete from the database.
        /// Each meeting will also include its associated competitions.
        /// </summary>
        /// <param name="athlete">The athlete whose meetings are to be retrieved.</param>
        /// <returns>A list of meeting entries including related competitions.</returns>
        public static List<Meeting> GetAllMeetings(Athlete athlete)
        {
            List<Meeting> meetings = new List<Meeting>();

            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand commandSelect = null;

            using (commandSelect = new SqlCommand("select m.place,m.rating,m.weather,m.date from meeting m inner join athlete a on m.athlete_id = a.id where a.username = @username", conn))
            {
                commandSelect.Parameters.Add(new SqlParameter("@username", athlete.Username));

                using (SqlDataReader reader = commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Meeting meeting = new Meeting(
                            reader[0].ToString(),
                            int.Parse(reader[1].ToString()),
                            reader[2].ToString(),
                            DateTime.Parse(reader[3].ToString())
                        );

                        meetings.Add(meeting);
                    }
                }
            }

            foreach(Meeting meeting in meetings)
            {
                foreach(Competition competition in CompetitionDAO.GetAll(meeting,athlete))
                {
                    meeting.AddCompetition(competition);
                }
            }
            

            return meetings;
        }
    }
}
