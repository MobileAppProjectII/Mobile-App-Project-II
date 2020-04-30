using SQLite;
using StageCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StageCrew.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Stanza : ContentPage
    {

        string _dbPath = @"/data/data/com.companyname.stagecrew/files/TestDB.db3";

        public string StanzaName;
        public string SongName;
        public string SetName;
        public string verified_username;
        public string verified_password;
        public string SetDescription;
        public string song_notes;
        public string stanza_notes;
        public string line_1;
        public string line_2;
        public string line_3;
        public string line_4;
        public string chord_1a;
        public string chord_1b;
        public string chord_1c;
        public string chord_2a;
        public string chord_2b;
        public string chord_2c;
        public string chord_3a;
        public string chord_3b;
        public string chord_3c;
        public string chord_4a;
        public string chord_4b;
        public string chord_4c;
        public Stanza()
        {
            InitializeComponent();
        }

        public Stanza(string StanzaName, string SongName, string SetName, string SetDescription, string song_notes, string username, string password)
        {
            this.StanzaName = StanzaName;
            this.SongName = SongName;
            this.SetName = SetName;
            this.SetDescription = SetDescription;
            this.song_notes = song_notes;
            this.verified_username = username;
            this.verified_password = password;
            this.stanza_notes = "empty";
            
            InitializeComponent();
            Init();

        }

        private void Init()
        {
            StanzaNameEntry.Text = this.StanzaName;
            NotesEditor.Text = this.stanza_notes;

            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<StanzaInfo>();
                var data = conn.Table<StanzaInfo>().ToList();
                foreach (StanzaInfo x in data)
                {
                    if (x.username == this.verified_username && this.verified_password == x.password && this.SongName == x.SongName && this.SetName == x.SetName
                        && this.StanzaName == x.StanzaName)
                    {
                        NotesEditor.Text = x.stanza_notes;
                        line1_entry.Text = x.line_1;
                        line2_entry.Text = x.line_2;
                        line3_entry.Text = x.line_3;
                        line4_entry.Text = x.line_4;

                        chord1a_entry.Text = x.chord_1a;
                        chord1b_entry.Text = x.chord_1b;
                        chord1c_entry.Text = x.chord_1c;
                        chord2a_entry.Text = x.chord_2a;
                        chord2b_entry.Text = x.chord_2b;
                        chord2c_entry.Text = x.chord_2c;
                        chord3a_entry.Text = x.chord_3a;
                        chord3b_entry.Text = x.chord_3b;
                        chord3c_entry.Text = x.chord_3c;
                        chord4a_entry.Text = x.chord_4a;
                        chord4b_entry.Text = x.chord_4b;
                        chord4c_entry.Text = x.chord_4c;

                    }
                }
            }
        }

        private void Add_Recording_Button_Clicked(object sender, EventArgs e)
        {

        }

        private void SaveStanzaButton_Clicked(object sender, EventArgs e)
        {
            //set variables to current values
            this.StanzaName = StanzaNameEntry.Text;
            this.stanza_notes = NotesEditor.Text;
            this.line_1 = line1_entry.Text;
            this.line_2 = line2_entry.Text;
            this.line_3 = line3_entry.Text;
            this.line_4 = line4_entry.Text;

            this.chord_1a = chord1a_entry.Text;
            this.chord_1b = chord1b_entry.Text;
            this.chord_1c = chord1c_entry.Text;
            this.chord_2a = chord2a_entry.Text;
            this.chord_2b = chord2b_entry.Text;
            this.chord_2c = chord2c_entry.Text;
            this.chord_3a = chord3a_entry.Text;
            this.chord_3b = chord3b_entry.Text;
            this.chord_3c = chord3c_entry.Text;
            this.chord_4a = chord4a_entry.Text;
            this.chord_4b = chord4b_entry.Text;
            this.chord_4c = chord4c_entry.Text;



            StanzaInfo stanza = new StanzaInfo(this.StanzaName, this.SongName, this.SetName, this.SetDescription, this.song_notes, this.verified_username, this.verified_password, this.stanza_notes, this.line_1, this.line_2,
                this.line_3, this.line_4, this.chord_1a, this.chord_1b, this.chord_1c, this.chord_2a, this.chord_2b, this.chord_2c,
                this.chord_3a, this.chord_3b, this.chord_3c, this.chord_4a, this.chord_4b, this.chord_4c);

            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<StanzaInfo>(); //creates table to read from it?
                var data = conn.Table<StanzaInfo>().ToList(); //everything is in contacts at this point
                foreach(StanzaInfo s in data)
                {
                    if (s.username == stanza.username && s.password == stanza.password &&  s.SetName == stanza.SetName && s.SongName == stanza.SongName && s.StanzaName == stanza.StanzaName)
                    {
                        App.UserDatabase.DeleteStanza(s.id);
                    }
                }
                App.UserDatabase.SaveStanza(stanza);
                Navigation.PopAsync();
                Navigation.PushAsync(new SongPage(this.SongName, this.SetName, this.SetDescription, this.verified_username, this.verified_password, this.song_notes));

            }
        }

        // The following functions should be changed to save off lyrics, open tabs to add chords, or save off recordings
        // instead of opening the song page again

    }
}