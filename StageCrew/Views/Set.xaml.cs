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
        public Set()
        {
            InitializeComponent();
        }

        private async void Set_Add_Song_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Song());
        }

        private async void Save_Set_Button_Clicked(object sender, EventArgs e)
        {
            // Should save the set into the database.
            // Page where the new set shows up
            // *** This line needs to be replaced because it shouldn't technically be opening a new account info page

           // await Navigation.PushAsync(new AccountInfo());
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