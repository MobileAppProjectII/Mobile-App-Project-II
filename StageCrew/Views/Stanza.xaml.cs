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
    public partial class Stanza : ContentPage
    {
        public Stanza()
        {
            InitializeComponent();
        }

        // The following functions should be changed to save off lyrics, open tabs to add chords, or save off recordings
        // instead of opening the song page again
        private async void Add_Lyrics_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Song());
        }
        private async void Add_Chord_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Song());
        }
        private async void Add_Recording_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Song());
        }
    }
}