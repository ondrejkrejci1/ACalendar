using ACalendar.Track;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACalendar.Database
{
    public class MeetingDAO
    {
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
            return meetings;
        }
    }
}
