using System;
using weather.Interface;
using weather.Service;
using weather.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace weather
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new WeatherPage());

        }

        protected override async void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
