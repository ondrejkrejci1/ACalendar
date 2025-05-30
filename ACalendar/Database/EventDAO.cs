using ACalendar.Track;
using ACalendar.vendor;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACalendar.Database
{
    public class EventDAO
    {
        public static void Save(Event _event)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("insert into athletick_event(name) values(@event)", conn))
            {
                command.Parameters.Add(new SqlParameter("@event", _event.ToString()));

                command.ExecuteNonQuery();
            }

        }


        public static List<Event> GetAll()
        {
            List<Event> events = new List<Event>();

            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("select name from athletick_event", conn))
            {

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Enum.TryParse<Event>(reader[1].ToString(), ignoreCase: true, out Event eevent))
                        {
                            events.Add(eevent);
                        }
                    }
                }

                command.ExecuteNonQuery();
            }


            return events;
        }
    }
}
