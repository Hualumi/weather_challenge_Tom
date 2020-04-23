using System;
using weather.Service;
using Xamarin.Forms;
using Xamarin.Essentials;
using weather.Interface;

namespace weather.ViewModels
{
    public class WeatherPageViewModel : BaseViewModel
    {
        string _address = "Area";
        public string Address
        {
            protected set
            {
                if (_address != value)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
            get { return _address; }
        }

        string _currentDay = "Current Day";

        public string CurrentDay
        {
            protected set
            {
                if (_currentDay != value)
                {
                    _currentDay = value;
                    OnPropertyChanged("CurrentDay");
                }
            }
            get { return _currentDay; }
        }

        string _lowTemp = "";

        public string LowTemp
        {
            protected set
            {
                if (_lowTemp != value)
                {
                    _lowTemp = value;
                    OnPropertyChanged("LowTemp");
                }
            }
            get { return _lowTemp; }
        }

        string _HighTemp = "";

        public string HighTemp
        {
            protected set
            {
                if (_HighTemp != value)
                {
                    _HighTemp = value;
                    OnPropertyChanged("HighTemp");
                }
            }
            get { return _HighTemp; }
        }

        string _imageUrl = "loading";

        public string ImageUrl
        {
            protected set
            {
                if (_imageUrl != value)
                {
                    _imageUrl = value;
                    OnPropertyChanged("ImageUrl");
                }
            }

            get
            {
                return _imageUrl;
            }
        }


        public WeatherPageViewModel()
        {
            DateTime now = DateTime.Now;
            CurrentDay = now.DayOfWeek.ToString();
            Device.BeginInvokeOnMainThread(() => {
            });
        }

        public async void LoadWeatherData()
        {
            DependencyService.Get<IMessage>().ShortAlert("Loading weather...");
            Location location = null;
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(3));
                location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
            }
            catch (Exception ex)
            {
                DependencyService.Get<IMessage>().LongAlert("Unable retrieve device location...");
                Console.WriteLine(ex.Message);
            }
            var httpService = new HttpService();
            var weather = await httpService.GetWeatherAsync(location);
            if (weather == null)
            {
                DependencyService.Get<IMessage>().LongAlert("Failed to retrieve weather info...");
                return;
            }
            Address = weather.Location.TzId;
            HighTemp = weather.Forecast.Forecastday[0].Day.MaxtempC.ToString() + "°";
            LowTemp = weather.Forecast.Forecastday[0].Day.MintempC.ToString() + "°";
            ImageUrl = "http:" + weather.Current.Condition.Icon;
        }
    }
}
