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
    public partial class SongPage : ContentPage
    {
        string _dbPath = @"/data/data/com.companyname.stagecrew/files/TestDB.db3";


        string SongName;
        string SetName;
        string SetDescription;
        string verified_username;
        string verified_password;
        string song_notes;
        public SongPage()
        {
            InitializeComponent();
        }

        
       
        public SongPage(string SongName, string SetName, string SetDescription, string username, string password)
        {
            this.SongName = SongName;
            this.SetName = SetName;
            this.SetDescription = SetDescription;
            this.verified_username = username;
            this.verified_password = password;
            this.song_notes = "empty";
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SongInfo>(); //creates table to read from it?
                var data = conn.Table<SongInfo>().ToList(); //everything is in contacts at this point
                foreach (SongInfo s in data)
                {
                    if (s.username == this.verified_username && s.password == this.verified_password && s.SetName == this.SetName)
                    {
                        this.song_notes = s.description;
                    }
                }
            }
            InitializeComponent();
            Init();
        }

        public SongPage(string SongName, string SetName, string SetDescription, string username, string password, string song_notes)
        {
            this.SongName = SongName;
            this.SetName = SetName;
            this.SetDescription = SetDescription;
            this.verified_username = username;
            this.verified_password = password;
            this.song_notes = song_notes;
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            SongNameEntry.Text = SongName;
            NotesEditor.Text = song_notes;
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<StanzaInfo>();
                var data = conn.Table<StanzaInfo>().ToList();
                foreach (StanzaInfo x in data)
                {
                    if (this.verified_username == x.username && this.verified_password == x.password && this.SetName == x.SetName && this.SongName == x.SongName)
                    {
                        MakeNewButton(x.StanzaName);

                    }
                }
            }

        }

        private void MakeNewButton(string buttonName)
        {
            Button button = new Button
            {
                Text = buttonName,
                WidthRequest = 50,
                HeightRequest = 50,
            };

            button.Clicked += new EventHandler(this.button_Click);

            StanzaStack.Children.Add(button);


        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Navigation.PushAsync(new Stanza(button.Text, this.SongName, this.SetName, this.SetDescription, this.song_notes, this.verified_username, this.verified_password));
            // identify which button was clicked and perform necessary actions
        }
        private void Add_Stanza_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Stanza("Verse 1", this.SongName, this.SetName, this.SetDescription, this.song_notes, this.verified_username, this.verified_password));
        }

        private void SaveSongButton_Clicked(object sender, EventArgs e)
        {
            //add song to database 
            //open up new stanza stuff

            string old_song_name = this.SongName;
            this.SongName = SongNameEntry.Text;
            this.song_notes = NotesEditor.Text;
            SongInfo song = new SongInfo(this.SongName, this.SetName, this.SetDescription, this.verified_username, this.verified_password, song_notes);
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SongInfo>(); //creates table to read from it?
                var data = conn.Table<SongInfo>().ToList(); //everything is in contacts at this point

                foreach (SongInfo s in data)
                {
                    if (s.SongName == "New Song" || s.SongName == old_song_name || song.SongName == s.SongName)
                    {
                        App.UserDatabase.DeleteSong(s.id);
                    }
                }

                App.UserDatabase.SaveSong(song);


                Navigation.PopAsync();
                Navigation.PushAsync(new Set(this.SetName, this.verified_username, this.verified_password, SetDescription));
            }
        }
    }
}