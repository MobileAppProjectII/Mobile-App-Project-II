using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using StageCrew.Views;
using StageCrew.Data;

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
                if (userDatabase == null)
                {
                    userDatabase = new UserDatabaseController();
                }
                return userDatabase;
            }
        }
        //public App()
        //{
        //    InitializeComponent();

        //    MainPage = new NavigationPage(new LoginPage());
        //}

        //protected override void OnStart()
        //{
        //}

        //protected override void OnSleep()
        //{
        //}

        //protected override void OnResume()
        //{
        //}
    }
}
