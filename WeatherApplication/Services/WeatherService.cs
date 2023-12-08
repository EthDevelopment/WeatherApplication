﻿// File: WeatherService.cs
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

                    // Pass the city name to MapToWeatherForecasts
                    return MapToWeatherForecasts(weatherData, city);
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

        private IEnumerable<WeatherForecast> MapToWeatherForecasts(OpenWeatherMapResponse weatherData, string city)
        {
            // Common properties for all items
            var baseDate = DateTimeOffset.Now.Date;
            var analogClockTime = DateTime.Now.ToString("HH:mm:ss");

            return weatherData?.List?.Select(item => new WeatherForecast
            {
                Date = baseDate.AddSeconds(item.Dt),
                TemperatureC = (int)(item.Main.Temp - 273.15),
                TemperatureF = (int)((item.Main.Temp - 273.15) * 9 / 5 + 32),
                Summary = item.Weather.FirstOrDefault()?.Description,
                CityName = city
            }) ?? Enumerable.Empty<WeatherForecast>();
        }

    }
}
