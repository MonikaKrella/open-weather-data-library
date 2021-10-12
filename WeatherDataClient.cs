using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherDataLibrary
{
    public class WeatherDataClient
    {
        private const string API_WEATHER_END_POINT =
            "https://api.openweathermap.org/data/2.5/weather?q={0}&units={1}&appid={2}";

        private readonly WebClient mainWebClient = new WebClient();

        public string ApiKey { get; }

        public WeatherDataClient(string argApiKey)
        {
            ApiKey = argApiKey;
        }

        public WeatherData DownLoadWeatherData(string city, TemperatureUnits temperatureUnits = TemperatureUnits.Standard)
        {
            WeatherData downloadWeatherData = DownloadWeatherData_Internal(city, temperatureUnits, mainWebClient);
            return downloadWeatherData;
        }

        public void DownLoadWeatherDataAsync(string city, Action<WeatherData> onWatherDataDownloaded, TemperatureUnits temperatureUnits = TemperatureUnits.Standard)
        {
            Task.Run(() =>
            {
                WebClient webClient = new WebClient();
                WeatherData downloadWeatherData = DownloadWeatherData_Internal(city, temperatureUnits, webClient);
                onWatherDataDownloaded.Invoke(downloadWeatherData);
            });
        }

        public async Task<WeatherData> DownloadWeatherDataAsync(string city, TemperatureUnits temperatureUnits = TemperatureUnits.Standard)
        {
            WeatherData weatherData = await Task.Run<WeatherData>(() =>
            {
                WebClient webClient = new WebClient();
                WeatherData downloadWeatherData = DownloadWeatherData_Internal(city, temperatureUnits, webClient);
                return downloadWeatherData;
            });
            return weatherData;
        }

        private WeatherData DownloadWeatherData_Internal(string city, TemperatureUnits temperatureUnits, WebClient webClient)
        {
            string unitsAsString = temperatureUnits.ToString().ToLower();
            string adress = string.Format(API_WEATHER_END_POINT, city, unitsAsString , ApiKey);
            string websiteContent = webClient.DownloadString(adress);

            WeatherData weatherDataFromJSON = JsonConvert.DeserializeObject<WeatherData>(websiteContent);
            return weatherDataFromJSON;
        }
    }
}