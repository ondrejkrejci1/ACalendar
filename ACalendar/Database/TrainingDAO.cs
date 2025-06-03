using ACalendar.Track;
using System.Data.SqlClient;

namespace ACalendar.Database
{
    /// <summary>
    /// Handles saving and loading trainings from the database.
    /// </summary>
    public class TrainingDAO
    {
        /// <summary>
        /// Saves a training to the database for the specified athlete.
        /// If the athlete does not already exist in the database, they will be saved first.
        /// </summary>
        /// <param name="training">Training instance to save.</param>
        /// <param name="athlete">Athlete to whom the training belongs.</param>
        public static void Save(Training training, Athlete athlete)
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

            using (commandInsert = new SqlCommand("insert into training(athlete_id,date,main_focus,weather,rating,description) values(@athlete_id,@date,@main_focus,@weather,@rating,@description)", conn))
            {
                commandInsert.Parameters.Add(new SqlParameter("@athlete_id", athleteID));
                commandInsert.Parameters.Add(new SqlParameter("@date", training.Date));
                commandInsert.Parameters.Add(new SqlParameter("@main_focus", training.MainFocus));
                commandInsert.Parameters.Add(new SqlParameter("@weather", training.Weather));
                commandInsert.Parameters.Add(new SqlParameter("@rating", training.Rating));
                commandInsert.Parameters.Add(new SqlParameter("@description", training.Description));

                commandInsert.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retrieves all trainings for the specified athlete from the database.
        /// </summary>
        /// <param name="athlete">Athlete whose trainings are to be retrieved.</param>
        /// <returns>List of training entries belonging to the specified athlete.</returns>
        public static List<Training> GetAllTrainings(Athlete athlete)
        {
            List<Training> trainings = new List<Training>();

            SqlConnection conn = DatabaseSingleton.GetInstance();

            SqlCommand commandSelect = null;

            using (commandSelect = new SqlCommand("select t.main_focus,t.rating,t.description,t.weather,t.date from training t inner join athlete a on t.athlete_id = a.id where a.username = @username",conn))
            {
                commandSelect.Parameters.Add(new SqlParameter("@username", athlete.Username));

                using(SqlDataReader reader=  commandSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Training training = new Training(
                            reader[0].ToString(),
                            int.Parse(reader[1].ToString()),
                            reader[2].ToString(),
                            reader[3].ToString(),
                            DateTime.Parse(reader[4].ToString())                            
                        );

                        trainings.Add(training);
                    }
                }
            }
            return trainings;
        }
    }
}
