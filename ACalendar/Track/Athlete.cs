using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACalendar.Track
{
    public class Athlete
    {
        private string username;
        private string password;

        public string Username { get { return username; } private set { username = value; } }
        public string Password { get { return password; } private set{ password = value; } }

        public Athlete(string username, string password) 
        {
            Username = username;
            Password = password;
        }
    }
}
