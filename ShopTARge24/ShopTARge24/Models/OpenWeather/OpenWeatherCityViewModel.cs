namespace ShopTARge24.Models.OpenWeather;

public sealed class OpenWeatherCityViewModel
{
    public string City { get; set; } = "";
    public double TemperatureC { get; set; }
    public double FeelsLikeC { get; set; }
    public int HumidityPct { get; set; }
    public int PressureHpa { get; set; }
    public double WindKmh { get; set; }
    public string Condition { get; set; } = "";
}
