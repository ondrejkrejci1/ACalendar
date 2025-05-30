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
    public class AthleteDAO
    {
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
