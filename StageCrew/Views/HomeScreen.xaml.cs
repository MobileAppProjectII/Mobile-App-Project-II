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
    public partial class HomeScreen : ContentPage
    {
        string _dbPath = @"/data/data/com.companyname.stagecrew/files/TestDB.db3";

        private string verified_username;
        private string verified_password;
        private string current_set;

        public HomeScreen()
        {
            InitializeComponent();
        }

  
        public HomeScreen(string verified_username, string verified_password)
        {
            InitializeComponent();
            this.verified_username = verified_username;
            this.verified_password = verified_password;
            Init();
        }

        private void Init()
        {
            AccountNameLabel.Text = this.verified_username;

            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<User>(); //creates table to read from it?
                var data = conn.Table<User>().ToList();

                foreach (User s in data)
                {
                    if (this.verified_username == s.Username && this.verified_password == s.Password)
                    {
                        //current user 
                        //get rest of data for prof page
                        aboutMe_info.Text = s.AboutMe;
                        location_info.Text = s.Location;

                        string str = s.Image;

                        // passing string "str" in  
                        // switch statement 
                        switch (str)
                        {

                            case "File: download.jpg":
                                profileImg.Source = "download.jpg";
                                break;

                            case "File: avatar2.png":
                                profileImg.Source = "avatar2.png";
                                break;

                            case "File: avatar3.png":
                                profileImg.Source = "avatar3.png";
                                break;

                            case "File: avatar4.png":
                                profileImg.Source = "avatar4.png";
                                break;

                            case "File: avatar5.png":
                                profileImg.Source = "avatar5.png";
                                break;

                            case "File: avatar6.jpg":
                                profileImg.Source = "avatar6.jpg";
                                break;

                            case "File: avatar7.jpg":
                                profileImg.Source = "avatar7.jpg";
                                break;

                            default:
                                DisplayAlert("Error", "Error in database loading picture", "Okay");
                                break;
                        }
                        break;
                    }
                }
                //read info here and fill fields
            }

            //open set database
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SetInfo>(); //creates table to read from it?
                var data = conn.Table<SetInfo>().ToList(); //everything is in contacts at this point

                foreach (SetInfo x in data)
                {
                    if (x.username == this.verified_username && x.password == this.verified_password)
                    {
                        //get all sets with this account's info
                        MakeNewButton(x.SetName);
                    }
                }

            }
        }

        private void CreateSetButtonClicked(object sender, EventArgs e)
        {


            SetInfo newSet = new SetInfo(this.verified_username, this.verified_password);
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                conn.CreateTable<SetInfo>(); //creates table to read from it?
                var data = conn.Table<SetInfo>().ToList(); //everything is in contacts at this point
                App.UserDatabase.SaveSet(newSet);
                Navigation.PopAsync();
                Navigation.PushAsync(new HomeScreen(this.verified_username, this.verified_password)); // open another one to load in data from db

            }


           
        }
        private async void gotoPage(int num)
        {
            if (num == 1)
            {
                await Navigation.PushAsync(new HomeScreen());
            }
            else if (num == 2)
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }

        //private async void ExampleGigClicked(object sender, EventArgs e)
        //{
        //    await Navigation.PushAsync(new Set());
        //}

        private void MakeNewButton(string buttonName)
        {
            Button button = new Button
            {
                Text = buttonName
            };

            button.Clicked += new EventHandler(this.button_Click);

            SetsStuff.Children.Add(button);
            

        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Navigation.PushAsync(new Set(button.Text, this.verified_username, this.verified_password));
            // identify which button was clicked and perform necessary actions
        }

        private async void EditProfileButtonClicked(object sender, EventArgs e)

        {
            string homescreen_username = this.verified_username;
            string homescreen_password = this.verified_password;
            await Navigation.PushAsync(new EditProfile(homescreen_username, homescreen_password, profileImg));

        }
    }

   
}