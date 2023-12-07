// File: WeatherService.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApplication.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string apiKey = "f6d912239d5cda7c2fb11db5a69a819a\r\n";
        private readonly HttpClient httpClient;

        public WeatherService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecasts()
        {
            string apiUrl = "https://api.openweathermap.org/data/2.5/forecast";
            string city = "Manchester"; // Replace with the desired city name
            string url = $"{apiUrl}?q={city}&appid={apiKey}";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<OpenWeatherMapResponse>(json);

                    return MapToWeatherForecasts(weatherData);
                }
                else
                {
                    // Handle error response
                    // Log or return an empty list
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                // Log or return an empty list
            }

            return new List<WeatherForecast>();
        }

        private IEnumerable<WeatherForecast> MapToWeatherForecasts(OpenWeatherMapResponse weatherData)
        {
            return weatherData?.List?.Select(item => new WeatherForecast
            {
                Date = DateTimeOffset.FromUnixTimeSeconds(item.Dt).DateTime,
                TemperatureC = (int)(item.Main.Temp - 273.15),
                TemperatureF = (int)((item.Main.Temp - 273.15) * 9 / 5 + 32),
                Summary = item.Weather.FirstOrDefault()?.Description
            }) ?? Enumerable.Empty<WeatherForecast>();
        }
    }
}
