using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using weather.Interface;
using weather.Model;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace weather.Service
{
    public class HttpService
    {
        private readonly HttpClient _httpClient;
        private static string  API_KEY = "67e9f288096046fa823112427202204";

        public HttpService()
        {
            _httpClient = CreateHttpClient();
        }

        private HttpClient CreateHttpClient()
        {
            var handler = new HttpClientHandler
            {
                Proxy = DependencyService.Get<IProxyInfoProvider>().GetProxySettings()
            };

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("http://api.weatherapi.com")
            };

            return httpClient;
        }

        public async Task<Weather> GetWeatherAsync(Xamarin.Essentials.Location location)
        {
            var url = String.Format("http://api.weatherapi.com/v1/forecast.json?key={0}&q=-37.8867,145.0868&days=1", API_KEY);
            if (location != null)
            {
                url = String.Format("http://api.weatherapi.com/v1/forecast.json?key={0}&q={1},{2}&days=1", API_KEY, location.Latitude, location.Longitude); 
            }
            var response = await _httpClient.GetAsync(url);
            var json = await response.Content.ReadAsStringAsync();
            var weather = Weather.FromJson(json);

            return weather;
        }
   
    }
}
