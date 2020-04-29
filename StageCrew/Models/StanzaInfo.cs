using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StageCrew.Models
{
     public class StanzaInfo
    {
        private string verified_username;
        private string verified_password;

        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string StanzaName { get; set; }
        public string SongName { get; set; }
        public string SetName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string SetDescription { get; set; }

        public string song_notes { get; set; }

        public string stanza_notes { get; set; }

        public string line_1 { get; set; }
        public string line_2 { get; set; }
        public string line_3 { get; set; }
        public string line_4 { get; set; }
        public string chord_1a { get; set; }
        public string chord_1b { get; set; }
        public string chord_1c { get; set; }
        public string chord_2a { get; set; }
        public string chord_2b { get; set; }
        public string chord_2c { get; set; }
        public string chord_3a { get; set; }
        public string chord_3b { get; set; }
        public string chord_3c { get; set; }
        public string chord_4a { get; set; }
        public string chord_4b { get; set; }
        public string chord_4c { get; set; }


        public StanzaInfo() { }

        public StanzaInfo(string SongName)
        {
            this.SongName = SongName;
        }

        public StanzaInfo(string StanzaName, string songName, string setName, string SetDescription, string song_notes, string verified_username, string verified_password, string stanza_notes, string line_1, string line_2, string line_3, string line_4, string chord_1a, string chord_1b, string chord_1c, string chord_2a, string chord_2b, string chord_2c, string chord_3a, string chord_3b, string chord_3c, string chord_4a, string chord_4b, string chord_4c )
        {
            this.StanzaName = StanzaName;
            this.SongName = songName;
            this.SetName = setName;
            this.username = verified_username;
            this.password = verified_password;
            this.SetDescription = SetDescription;
            this.song_notes = song_notes;
            this.stanza_notes = stanza_notes;
            this.line_1 = line_1;
            this.line_2 = line_2;
            this.line_3 = line_3;
            this.line_4 = line_4;
            this.chord_1a = chord_1a;
            this.chord_1b = chord_1b;
            this.chord_1c = chord_1c;
            this.chord_2a = chord_2a;
            this.chord_2b = chord_2b;
            this.chord_2c = chord_2c;
            this.chord_3a = chord_3a;
            this.chord_3b = chord_3b;
            this.chord_3c = chord_3c;
            this.chord_4a = chord_4a;
            this.chord_4b = chord_4b;
            this.chord_4c = chord_4c;
           
        }
    }
}
