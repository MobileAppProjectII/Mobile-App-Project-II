using StageCrew.Data;
using StageCrew.Views;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace StageCrew
{
    public partial class App : Application
    {

        static UserDatabaseController userDatabase;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public static UserDatabaseController UserDatabase
        {
            get
            {
                if (userDatabase == null )
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }
    }
}
