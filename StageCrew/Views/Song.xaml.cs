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
    public partial class Song : ContentPage
    {
        public Song()
        {
            InitializeComponent();
        }

        private async void Add_Stanza_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Stanza());
        }
    }
}