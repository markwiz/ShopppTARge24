using System.Text.Json.Serialization;

namespace ShopTARge24.Core.Dto.OpenWeather;

public sealed class OpenWeatherCityWeatherDto
{
    [JsonPropertyName("name")] public string? Name { get; init; }
    [JsonPropertyName("weather")] public List<WeatherDto> Weather { get; init; } = [];
    [JsonPropertyName("main")] public MainDto? Main { get; init; }
    [JsonPropertyName("wind")] public WindDto? Wind { get; init; }

    public sealed class WeatherDto
    {
        [JsonPropertyName("main")] public string? Main { get; init; }
        [JsonPropertyName("description")] public string? Description { get; init; }
        [JsonPropertyName("icon")] public string? Icon { get; init; }
    }

    public sealed class MainDto
    {
        [JsonPropertyName("temp")] public double Temp { get; init; }          // °C (kasutame units=metric)
        [JsonPropertyName("feels_like")] public double FeelsLike { get; init; } // °C
        [JsonPropertyName("humidity")] public int Humidity { get; init; }       // %
        [JsonPropertyName("pressure")] public int Pressure { get; init; }       // hPa
    }

    public sealed class WindDto
    {
        [JsonPropertyName("speed")] public double Speed { get; init; } // m/s (teisendame km/h-ks)
    }
}
