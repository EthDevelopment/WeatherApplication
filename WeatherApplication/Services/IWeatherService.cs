using WeatherApplication;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecasts();
}
