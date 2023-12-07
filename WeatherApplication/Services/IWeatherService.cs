// Update the IWeatherService interface
using WeatherApplication;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecasts();
}
