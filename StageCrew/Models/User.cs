using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StageCrew.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Location { get; set; }
        public string AboutMe { get; set; }
        public User() { }
        public User (string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public User (string Username, string Password, string Location, string AboutMe)
        {
            this.Username = Username;
            this.Password = Password;
            this.Location = Location;
            this.AboutMe = AboutMe;
        }
        public bool CheckInformation()
        {
            if (this.Username == null || this.Password == null)
            {
                return false;
            }
            if (!this.Username.Equals("") && !this.Password.Equals(""))
                return true;
            else
                return false;
        }
    }
}
