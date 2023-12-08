// WeatherServiceTests.cs

using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using WeatherApplication.Services;
using WeatherApplication;

public class WeatherServiceTests
{
    [Fact]
    public async Task GetWeatherForecasts_ValidCity_ReturnsData()
    {
        // Arrange
        var weatherService = new WeatherService();

        // Replace 'YourCityName' with the desired city name
        string city = "YourCityName";

        // Act
        var weatherForecasts = await weatherService.GetWeatherForecasts(city);

        // Assert
        Assert.NotNull(weatherForecasts);
        Assert.IsAssignableFrom<IEnumerable<WeatherForecast>>(weatherForecasts);
    }
}
