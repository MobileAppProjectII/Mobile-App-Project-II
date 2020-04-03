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
    public partial class LoginPage : ContentPage
    {
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
            
        }
        private void SignInProcedure(object sender, EventArgs e)
        {
            User user = new User(Entry_Username.Text, Entry_Password.Text);
            if (user.CheckInformation())
            {
                DisplayAlert("Login", "Login Success", "Okay");
                int num = 1; //1 is the mainpage
                gotoPage(num);
                

            }
            else
            {
                DisplayAlert("Login", "Login Not Correct, empty username or password", "Okay");
            }


        }

        private async void gotoPage(int num)
        {
            if (num == 1)
            {
                await Navigation.PushAsync(new HomeScreen());
            }
        }
    }
}