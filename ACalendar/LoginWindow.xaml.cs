using ACalendar.Database;
using ACalendar.Track;
using ACalendar.vendor;
using System.Windows;

namespace ACalendar
{
    /// <summary>
    /// Interakční logika pro LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private bool logginMode = true;

        public LoginWindow(MainWindow main)
        {
            InitializeComponent();

            RegisterRadio.Click += (s, e) =>
            {
                logginMode = false;
            };

            LogginRadio.Click += (s, e) =>
            {
                logginMode = true;
            };

            Submit.Click += (s, e) =>
            {

                if (logginMode)
                {
                    string username = UsernameInput.Text;
                    string password = Hasher.ComputeSha256Hash(PasswordInput.Text);

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
                    string username = Username.Text;
                    string password = Hasher.ComputeSha256Hash(PasswordInput.Text);
                    string confirmPassword = Hasher.ComputeSha256Hash(ConfirmInput.Text);

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
