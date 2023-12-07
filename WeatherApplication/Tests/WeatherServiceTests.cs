using WeatherApplication.Services;
using Xunit;

public class WeatherServiceTests
{
    [Fact]
    public void GetWeatherForecasts_ReturnsCorrectNumberOfForecasts()
    {
        var weatherService = new WeatherService();

        var forecasts = weatherService.GetWeatherForecasts();

        Assert.Equal(5, forecasts.Count());
    }

}