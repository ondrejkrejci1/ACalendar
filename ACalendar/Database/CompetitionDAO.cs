using ACalendar.Track;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACalendar.Database
{
    public class CompetitionDAO
    {
        public static void Save(Competition competition, Meeting meeting,Athlete athlete)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand commandSelect = null;
            SqlCommand commandInsert = null;

            int meetingID = 0;
            bool savedMeeting = false;

            int eventID = 0;
            bool savedEvent = false;

            foreach (Meeting m in MeetingDAO.GetAllMeetings(athlete))
            {
                if(m.Date == meeting.Date && m.Place == meeting.Place)
                    savedMeeting = true;
                     
            }

            if (!savedMeeting)
            {
                MeetingDAO.Save(meeting,athlete);
            }

            using (commandSelect = new SqlCommand("select id from meeting where place = @place and date = @date", conn))
            {
                commandSelect.Parameters.Add(new SqlParameter("@place", meeting.Place));
                commandSelect.Parameters.Add(new SqlParameter("@date", meeting.Date));

                using (SqlDataReader reader = commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        meetingID = int.Parse(reader[0].ToString());
                        break;
                    }
                }
            }



            foreach (Event e in EventDAO.GetAll())
            {
                if(e == competition.Event) 
                    savedEvent = true;
            }

            if (!savedEvent)
            {
                EventDAO.Save(competition.Event);
            }

            using (commandSelect = new SqlCommand("select id from athletick_event where name = @name", conn))
            {
                commandSelect.Parameters.Add(new SqlParameter("@name", competition.Event.ToString()));

                using (SqlDataReader reader = commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eventID = int.Parse(reader[0].ToString());
                        break;
                    }
                }
            }



            using (commandInsert = new SqlCommand("insert into competition(meeting_id,athletic_event_id,wind,start_of_competition) values(@meeting_id,@athletic_event_id,@wind,@start_of_competiton)", conn))
            {
                commandInsert.Parameters.Add(new SqlParameter("@meeting_id", meetingID));
                commandInsert.Parameters.Add(new SqlParameter("@athletic_event_id", eventID));
                commandInsert.Parameters.Add(new SqlParameter("@wind", competition.Wind));
                commandInsert.Parameters.Add(new SqlParameter("@start_of_competiton", competition.StartOfCompetition));

                commandInsert.ExecuteNonQuery();
            }
        }

        public static List<Competition> GetAll(Meeting meeting, Athlete athlete)
        {
            List<Competition> competitions = new List<Competition>();

            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand commandSelect = null;

            using (commandSelect = new SqlCommand(
                "select a.name,c.wind,c.start_of_competition from competition c inner join meeting m on m.id = c.meeting_id inner join athletick_event a on a.id = c.athletic_event_id inner join athlete on athlete.id = m.athlete_id" +
                " where m.place = @place and m.date = @date and athlete.username = @username", conn))
            {
                commandSelect.Parameters.Add(new SqlParameter("@place", meeting.Place));
                commandSelect.Parameters.Add(new SqlParameter("@date", meeting.Date));
                commandSelect.Parameters.Add(new SqlParameter("@username", athlete.Username));

                using (SqlDataReader reader = commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Event _event = new Event();
                        if (Enum.TryParse<Event>(reader[0].ToString(), ignoreCase: true, out Event eevent))
                        {
                            _event = eevent;
                        }
                        Competition competition = new Competition( _event,float.Parse( reader[1].ToString()), TimeSpan.Parse(reader[2].ToString()));

                        competitions.Add(competition);
                    }
                }
            }
            return competitions;
        }
    }
}
