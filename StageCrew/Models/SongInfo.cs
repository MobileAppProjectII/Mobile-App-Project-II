using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StageCrew.Models
{
    public class SongInfo
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string SongName { get; set; }
        public string SetName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string description { get; set; }

        public string song_notes { get; set; }
        public SongInfo() { }

        public SongInfo(string SongName)
        {
            this.SongName = SongName;
        }


        public SongInfo(string SongName, string SetName, string setdescription, string username, string password)
        {
            this.SongName = SongName;
            this.SetName = SetName;
            this.username = username;
            this.password = password;
            this.description = setdescription;
            this.song_notes = null;
        }
        public SongInfo(string SongName, string SetName, string setdescription, string username, string password, string song_notes)
        {
            this.SongName = SongName;
            this.SetName = SetName;
            this.username = username;
            this.password = password;
            this.description = setdescription;
            this.song_notes = song_notes;
        }

    }
}
