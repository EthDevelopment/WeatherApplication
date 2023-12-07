// File: WeatherForecast.cs
using System;

namespace WeatherApplication
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
        public string AnalogClockTime { get; private set; }

        public WeatherForecast()
        {
            AnalogClockTime = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
