using WeatherApplication.Services;
using Xunit;

public class WeatherServiceTests
{
    [Fact]
    public async Task GetWeatherForecasts_ReturnsCorrectNumberOfForecasts()
    {
        var weatherService = new WeatherService();

        var forecasts = await weatherService.GetWeatherForecasts();

        Assert.Equal(5, forecasts.Count());
    }
}
