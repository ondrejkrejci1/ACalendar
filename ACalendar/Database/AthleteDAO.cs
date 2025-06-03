using ACalendar.Track;
using System.Data.SqlClient;

namespace ACalendar.Database
{
    /// <summary>
    /// Handles saving and loading athletes from the database.
    /// </summary>
    public class AthleteDAO
    {
        /// <summary>
        /// Saves a new athlete to the database.
        /// It inserts the username and password into the athlete table.
        /// </summary>
        /// <param name="athlete">The athlete object that should be saved</param>
        public static void Save(Athlete athlete)
        {
            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using(command = new SqlCommand("insert into athlete(username,password) values(@username,@password)",conn))
            {
                command.Parameters.Add(new SqlParameter("@username",athlete.Username));
                command.Parameters.Add(new SqlParameter("@password",athlete.Password));

                command.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// Loads all athletes from the database.
        /// It creates a list of Athlete objects using the data from table.
        /// </summary>
        /// <returns>List of all athletes found in the database</returns>
        public static List<Athlete> GetAll()
        {
            List<Athlete> athletes = new List<Athlete>();

            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand command = null;

            using (command = new SqlCommand("select username,password from athlete", conn))
            {

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Athlete athlete = new Athlete(
                            reader[0].ToString(),
                            reader[1].ToString()
                        );

                        athletes.Add( athlete );
                    }
                }

                command.ExecuteNonQuery();
            }


            return athletes;
        }
    }
}
