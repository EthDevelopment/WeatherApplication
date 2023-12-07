using WeatherApplication;

public interface IWeatherService
{
    IEnumerable<WeatherForecast> GetWeatherForecasts();
}