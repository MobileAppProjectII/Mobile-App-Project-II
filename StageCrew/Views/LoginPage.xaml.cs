using StageCrew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StageCrew.Data;
using SQLite;
using System.IO;

namespace StageCrew.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        string _dbPath = @"/data/data/com.companyname.stagecrew/files/TestDB.db3";

        public LoginPage()
        {
            InitializeComponent();
            Init();
            
        }

        void Init()
        {
            BackgroundColor = Constants.BackgroundColor;
            Lbl_Username.TextColor = Constants.MainTextColor;
            Lbl_Password.TextColor = Constants.MainTextColor;
            LoginStuff.Margin = 20;


            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) => {
                // handle the tap
                DisplayAlert("Item Clicked", "Congratulations on touching the label", "Okay");

                gotoPage(2);
                //you can call gotopage and then just put a number to signify the page you want to go to. 1 is homescreen

            };
            Create_Text.GestureRecognizers.Add(tapGestureRecognizer);
           

        }
        private async void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                if (!File.Exists(_dbPath))
                {
                    await DisplayAlert("Error", "Database file does not exists at " + _dbPath, "Okay");
                    return;
                }
                using (SQLiteConnection conn = new SQLiteConnection(_dbPath))
                {
                    conn.CreateTable<User>(); //creates table to read from it?
                    var data = conn.Table<User>().ToList(); //everything is in contacts at this point
                    string verified_username = null;
                    string verified_password = null;
                    foreach(User s in data)
                    { 
                        if (s.Username == Entry_Username.Text && s.Password == Entry_Password.Text)
                        {
                            await DisplayAlert("success", "Found user in database!", "Okay");
                            verified_username = s.Username;
                            verified_password = s.Password;
                            break; //stop at the first find
                        }
                    }
                    if (verified_username == null)
                    {
                        await DisplayAlert("Account not found", "No account in with that information exists", "Okay");
                        Entry_Username.Text = "";
                        Entry_Password.Text = "";
                    }
                    else
                    {
                        await Navigation.PushAsync(new HomeScreen(verified_username, verified_password));

                    }

                }


            }
            else
            {
                await DisplayAlert("Login", "Login Not Correct, empty username or password", "Okay");
            }


        }
        public async void gotoPage(int num)
        {
            if (num == 1)
            {
                await Navigation.PushAsync(new HomeScreen());
            }
            else if (num ==2)
            {
                await Navigation.PushAsync(new CreateAccountPage());
            }
        }

    }
}