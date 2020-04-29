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
    public partial class Set : ContentPage
    {
        string _dbPath = @"/data/data/com.companyname.stagecrew/files/TestDB.db3";

        private string verified_username;
        private string verified_password;
        private string SetName;
        private string SetDescription;

        public Set() { }
        public Set (string SetName, string verified_username, string verified_password)
        {
            InitializeComponent();
            this.verified_username = verified_username;
            this.verified_password = verified_password;
            this.SetName = SetName;
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SetInfo>(); //creates table to read from it?
                var data = conn.Table<SetInfo>().ToList(); //everything is in contacts at this point
                foreach (SetInfo s in data)
                {
                    if (s.username == this.verified_username && s.password == this.verified_password)
                    {
                        this.SetDescription = s.description;
                    }
                }
            }
            Init();
        }
        public Set(string SetName, string verified_username, string verified_password, string setDescription)
        {
            InitializeComponent();
            this.verified_username = verified_username;
            this.verified_password = verified_password;
            this.SetName = SetName;
            this.SetDescription = setDescription;
                Init();
        }

        public void Init()
        {

            SetNameLabel.Text = this.SetName;
            setDescriptionEditor.Text = this.SetDescription;

            //put songs in the set

            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SongInfo>();
                var data = conn.Table<SongInfo>().ToList();
                foreach (SongInfo x in data)
                {
                    if (this.verified_username == x.username && this.verified_password == x.password && this.SetName == x.SetName)
                    {
                        MakeNewButton(x.SongName);

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

            SongStack.Children.Add(button);


        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
             Navigation.PushAsync(new Song(button.Text, this.SetName, this.SetDescription, this.verified_username, this.verified_password));
            // identify which button was clicked and perform necessary actions
        }

        private void Set_Add_Song_Button_Clicked(object sender, EventArgs e)
        {
            SongInfo newSong = new SongInfo("New Song", this.SetName, this.SetDescription, this.verified_username, this.verified_password);
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SongInfo>(); //creates table to read from it?
                var data = conn.Table<SongInfo>().ToList(); //everything is in contacts at this point

                foreach (SongInfo y in data)
                {
                    if (y.SongName == "New Song")
                    {
                        App.UserDatabase.DeleteSong(y.id);
                    }
                }
                App.UserDatabase.SaveSong(newSong);


                Navigation.PopAsync();
                Navigation.PushAsync(new Set(this.SetName,  this.verified_username, this.verified_password, this.SetDescription)); // open another one to load in data from db

            }
        }


        private void Save_Set_Button_Clicked(object sender, EventArgs e)
        {
            // Should save the set into the database.
            // Page where the new set shows up
            // *** This line needs to be replaced because it shouldn't technically be opening a new account info page
            string old_set_name = this.SetName;
            SetDescription = setDescriptionEditor.Text;
            this.SetName = SetNameLabel.Text;
            SetInfo newSet = new SetInfo(this.SetName, SetDescription, this.verified_username, this.verified_password) ;
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SetInfo>(); //creates table to read from it?
                var data = conn.Table<SetInfo>().ToList(); //everything is in contacts at this point

                foreach (SetInfo s in data)
                {
                    if (s.SetName == "New Set" || s.SetName == newSet.SetName || s.SetName == old_set_name)
                        App.UserDatabase.DeleteSet(s.id);
                        
                }

                App.UserDatabase.SaveSet(newSet);


                Navigation.PopAsync();
                Navigation.PushAsync(new HomeScreen(this.verified_username, this.verified_password)); // open another one to load in data from db

            }

        }

        private void ShareProcedure(object sender, EventArgs e)
        {
            // Technically we're going to make nothing happen here since we're not actually making it share


            //User user = new User(Entry_Username.Text, Entry_Password.Text);
            //if (user.CheckInformation())
            //{
            //    DisplayAlert("Login", "Login Success.", "Ok.");
            //    await Navigation.PushAsync(new AccountInfo());
            //}
            //else
            //{
            //    DisplayAlert("Login", "Login not correct, empty username or password.", "Ok.");
            //}

        }
    }
}