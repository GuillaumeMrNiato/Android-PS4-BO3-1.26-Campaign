using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        { 
            Current.MainPage.DisplayAlert("Information", "-Black ops 3 Campaign tool By MrNiato for 1.26 update\n\n-Version of the APK : 1.0\n\n-Release Date : 28th September 2019\n\nTwitter : @ImMrNiato", "Ok");
        }
        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
