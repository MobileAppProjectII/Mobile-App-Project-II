using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StageCrew.Models
{
    public class SetInfo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string SetName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string description { get; set; }


        public SetInfo() { }
        public SetInfo(string SetName)
        {
            this.SetName = SetName;
        }

        public SetInfo(string username, string password)
        {
            this.SetName = "New Set";
            this.username = username;
            this.password = password;
        }

        public SetInfo(string SetName, string description, string username, string password)
        {
            this.SetName = SetName;
            this.username = username;
            this.password = password;
            this.description = description;
        }


    }
}
