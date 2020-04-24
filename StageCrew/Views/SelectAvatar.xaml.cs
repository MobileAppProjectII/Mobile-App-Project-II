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
    public partial class SelectAvatar : ContentPage
    {
        string verified_username;
        string verified_password;
        public SelectAvatar(string verified_username, string verified_password)
        {
           
            InitializeComponent();
            this.verified_username = verified_username;
            this.verified_password = verified_password;
            Init();
        }

        private void Init()
        {
            add_gesture(profileImg1);
            add_gesture(profileImg2);
            add_gesture(profileImg3);
            add_gesture(profileImg4);
            add_gesture(profileImg5);
            add_gesture(profileImg6);
            add_gesture(profileImg7);


        }

        private void add_gesture(Image element)
        {
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                // handle the tap
                DisplayAlert("Item Clicked", "Congratulations on touching the label", "Okay");

                Navigation.PushAsync(new EditProfile(this.verified_username, this.verified_password, element));
                //you can call gotopage and then just put a number to signify the page you want to go to. 1 is homescreen

            };
            element.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}