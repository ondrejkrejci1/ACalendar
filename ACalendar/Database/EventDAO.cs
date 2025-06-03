using ACalendar.Track;
using System.Data.SqlClient;

namespace ACalendar.Database
{
    /// <summary>
    /// Handles saving and loading events from the database.
    /// </summary>
    public class EventDAO
    {
        /// <summary>
        /// Saves a single event to the database.
        /// </summary>
        /// <param name="_event">The event to save.</param>
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

        /// <summary>
        /// Retrieves all events from the database.
        /// </summary>
        /// <returns>A list of all events stored in the database.</returns>
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
                        if (Enum.TryParse<Event>(reader[0].ToString(), ignoreCase: true, out Event eevent))
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
