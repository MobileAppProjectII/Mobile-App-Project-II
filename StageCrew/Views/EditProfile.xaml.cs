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
    public partial class EditProfile : ContentPage
    {
        string _dbPath = @"/data/data/com.companyname.stagecrew/files/TestDB.db3";
        private string verified_username;
        private string verified_password;

        public EditProfile()
        {
            InitializeComponent();
            Init(this.profileImg);
        }

        public EditProfile(string verified_username, string verified_password)
        {
            InitializeComponent();
            this.verified_username = verified_username;
            this.verified_password = verified_password;
            Init(this.profileImg);
        }
        public EditProfile(string verified_username, string verified_password, Image new_avatar)
        {
           ;
            this.verified_username = verified_username;
            this.verified_password = verified_password;
            this.profileImg = new_avatar;
            InitializeComponent();
            Init(new_avatar);
        }



        private void Init(Image new_avatar)
        {
            AccountNameLabel.Text = this.verified_username;
            profileImg.Source = new_avatar.Source;


            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
                DisplayAlert("Item Clicked", "Congratulations on touching the label", "Okay");

                Navigation.PopAsync();
                Navigation.PushAsync(new SelectAvatar(this.verified_username, this.verified_password));
               
                //you can call gotopage and then just put a number to signify the page you want to go to. 1 is homescreen

            };
            profileImg.GestureRecognizers.Add(tapGestureRecognizer);


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
        private void SubmitAccountInfoClicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
            {
                User user = new User(this.verified_username, this.verified_password, location_info.Text, aboutMe_info.Text);

                conn.CreateTable<User>(); //creates table to read from it?
                var data = conn.Table<User>().ToList(); //everything is in contacts at this point
                foreach(User s in data)
                {
                    if (s.Username == this.verified_username && s.Password == this.verified_password)
                    {
                        //got current user
                        //adding should just update current
                        user.id = s.id;
                        App.UserDatabase.SaveUser(user);
                        break;
                    }
                }
                Navigation.PopAsync(); // pop editprof off stack.
                Navigation.PopAsync(); // pop old profile page off stack
                Navigation.PushAsync(new HomeScreen(this.verified_username, this.verified_password)); //push a new homescreen onto the stack



            }
        }


    }
}