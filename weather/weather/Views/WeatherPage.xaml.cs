using System;
using System.Collections.Generic;
using weather.ViewModels;
using Xamarin.Forms;

namespace weather.Views
{
    public partial class WeatherPage : ContentPage
    {
        WeatherPageViewModel viewModel;
        public WeatherPage()
        {
            InitializeComponent();
            viewModel = new WeatherPageViewModel();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.LoadWeatherData();
        }
    }
}
