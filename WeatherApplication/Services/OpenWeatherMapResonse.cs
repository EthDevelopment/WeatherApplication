public class OpenWeatherMapResponse
{
    public List<WeatherData> List { get; set; }
}

public class WeatherData
{
    public long Dt { get; set; }
    public MainInfo Main { get; set; }
    public List<WeatherInfo> Weather { get; set; }
}

public class MainInfo
{
    public double Temp { get; set; }
}

public class WeatherInfo
{
    public string Description { get; set; }
}
