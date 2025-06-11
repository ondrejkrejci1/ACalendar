using System.Configuration;
using System.Data.SqlClient;
using System.Windows;

namespace ACalendar.Database
{
    /// <summary>
    /// Provides a singleton-style access to a database.
    /// </summary>
    public class DatabaseSingleton
    {
        private static SqlConnection? conn = null;
        private DatabaseSingleton()
        {

        }

        /// <summary>
        /// This method returns connection object to SQL.
        /// It open connection if it's not already opened.
        /// Settings are read from App.config file.
        /// </summary>
        /// <returns>Returns SqlConnection instance</returns>
        public static SqlConnection GetInstance()
        {
            if (conn == null)
            {
                try
                {
                    SqlConnectionStringBuilder consStringBuilder = new SqlConnectionStringBuilder();
                    consStringBuilder.UserID = ReadSetting("Name");
                    consStringBuilder.Password = ReadSetting("Password");
                    consStringBuilder.InitialCatalog = ReadSetting("Database");
                    consStringBuilder.DataSource = ReadSetting("DataSource");
                    consStringBuilder.ConnectTimeout = 5;
                    conn = new SqlConnection(consStringBuilder.ConnectionString);
                    conn.Open();
                } catch (Exception ex)
                {
                    MessageBox.Show("Something is wrong with configuration file.", "Wrong configuration file", MessageBoxButton.OK, MessageBoxImage.Error);
                    Environment.Exit(0);
                }
            }
            return conn;
        }

        /// <summary>
        /// Closes and disposes the database connection if it exists.
        /// </summary>
        public static void CloseConnection()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        /// <summary>
        /// Helper method for reading values from App.config file.
        /// If the key is missing, "Not Found" is returned (for now).
        /// </summary>
        /// <param name="key">The name of the setting key</param>
        /// <returns>The setting value, or "Not Found"</returns>
        private static string ReadSetting(string key)
        {
            try
            {
                var appSettings = ConfigurationManager.AppSettings;
                string result = appSettings[key] ?? "Not Found";
                return result;
            } catch(Exception ex)
            {
                MessageBox.Show("Could not read configuration file.", "Wrong configuration file", MessageBoxButton.OK, MessageBoxImage.Error);
                Environment.Exit(0);
            }
            return null;
        }
    }
}
