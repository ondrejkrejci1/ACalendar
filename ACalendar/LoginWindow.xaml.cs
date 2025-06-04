using ACalendar.Database;
using ACalendar.Track;
using ACalendar.vendor;
using System.Windows;

namespace ACalendar
{
    /// <summary>
    /// Provides login and registration functionality for users.
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool logginMode = true;

        /// <summary>
        /// Initializes a new instance of the LoginWindow class.
        /// Sets up event handlers for switching modes and submitting credentials.
        /// </summary>
        /// <param name="main">Reference to the main window to update the logged-in athlete.</param>
        public LoginWindow(MainWindow main)
        {
            InitializeComponent();

            RegisterRadio.Click += (s, e) =>
            {
                if (logginMode)
                {
                    this.Height += 70;
                }

                logginMode = false;
                ConfirmPassword.Visibility = Visibility.Visible;
                ConfirmInput.Visibility = Visibility.Visible;                
            };

            LogginRadio.Click += (s, e) =>
            {
                if (!logginMode)
                {
                    this.Height -= 70;
                }

                logginMode = true;
                ConfirmPassword.Visibility = Visibility.Collapsed;
                ConfirmInput.Visibility = Visibility.Collapsed;
            };

            Submit.Click += (s, e) =>
            {

                if (logginMode)
                {
                    string username = UsernameInput.Text;
                    string password = Hasher.ComputeSha256Hash(PasswordInput.Password);

                    Athlete log = null;

                    foreach(Athlete athlete in AthleteDAO.GetAll())
                    {
                        if(athlete.Username == username && athlete.Password == password)
                            log = athlete;
                    }

                    if (log != null)
                    {
                        main.Athlete = log;
                        this.Close();
                    }


                }
                else
                {
                    string username = UsernameInput.Text;
                    string password = Hasher.ComputeSha256Hash(PasswordInput.Password);
                    string confirmPassword = Hasher.ComputeSha256Hash(ConfirmInput.Password);

                    foreach(Athlete athlete in AthleteDAO.GetAll())
                    {
                        if(athlete.Username == username)
                        {
                            MessageBox.Show("This username is already used. Please use different one.", "Used username", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                    }

                    if (username != string.Empty && password != string.Empty && confirmPassword != string.Empty)
                    {
                        if (password == confirmPassword)
                        {
                            Athlete athlete = new Athlete(username, password);

                            AthleteDAO.Save(athlete);

                            main.Athlete = athlete;

                            this.Close();
                        }
                    }

                }

            };
        
        }
    }
}
