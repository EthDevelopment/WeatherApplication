using Newtonsoft.Json;
using System;

namespace WeatherApplication
{
    public class WeatherForecast
    {
        [JsonIgnore]
        public DateTime Date { get; set; }
        [JsonProperty("date")]
        public string FormattedDate => Date.ToString("dd-MM-yy");
        public int TemperatureC { get; set; }
        public int TemperatureF { get; set; }
        public string? Summary { get; set; }
        public string AnalogClockTime { get; private set; }
        public string CityName { get; set; } 


        public WeatherForecast()
        {
            AnalogClockTime = DateTime.Now.ToString("HH:mm:ss");
        }


    }
}
