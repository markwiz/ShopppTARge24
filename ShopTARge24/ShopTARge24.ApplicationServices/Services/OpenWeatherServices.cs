using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using ShopTARge24.Core.Dto.OpenWeather;
using ShopTARge24.Core.ServiceInterface;

namespace ShopTARge24.ApplicationServices.Services;

public sealed class OpenWeatherServices : IOpenWeatherService
{
    private readonly HttpClient _http;
    private readonly string _apiKey;

    public OpenWeatherServices(HttpClient http, IConfiguration cfg)
    {
        _http = http;
        if (_http.BaseAddress is null)
        {
            var baseUrl = cfg["OpenWeather:BaseUrl"] ?? "https://api.openweathermap.org/";
            _http.BaseAddress = new Uri(baseUrl);
        }
        _apiKey = cfg["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("OpenWeather ApiKey missing.");
    }

    public async Task<OpenWeatherCityWeatherDto?> GetCurrentByCityAsync(string city, CancellationToken ct = default)
    {
        // units=metric → Celsius; speed m/s (teisendame ViewModelis)
        var path = $"data/2.5/weather?q={Uri.EscapeDataString(city)}&appid={_apiKey}&units=metric";
        return await _http.GetFromJsonAsync<OpenWeatherCityWeatherDto>(path, ct);
    }
}
