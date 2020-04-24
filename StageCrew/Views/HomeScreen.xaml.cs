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
                        break;
                    }
                }
                //read info here and fill fields
            }
        }

        private void CreateSetButtonClicked(object sender, EventArgs e)
        {
           // gotoPage(2);
            MakeNewButton();
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

        private async void ExampleGigClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Set());
        }

        private void MakeNewButton()
        {
            Button button = new Button
            {
                Text = "New Set"
            };

            SetsStuff.Children.Add(button);
        }

        private async void EditProfileButtonClicked(object sender, EventArgs e)

        {
            string homescreen_username = this.verified_username;
            string homescreen_password = this.verified_password;
            await Navigation.PushAsync(new EditProfile(homescreen_username, homescreen_password));

        }
    }

   
}