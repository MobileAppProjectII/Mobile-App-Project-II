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
        public HomeScreen()
        {
            InitializeComponent();
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

        private void MakeNewButton()
        {
            Button button = new Button
            {
                Text = "New Set"
            };

            SetsStuff.Children.Add(button);
        }
    }

   
}