using System.Collections.Generic;
using System.Threading.Tasks;

namespace WeatherApplication.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetWeatherForecasts(double latitude, double longitude);
    }
}