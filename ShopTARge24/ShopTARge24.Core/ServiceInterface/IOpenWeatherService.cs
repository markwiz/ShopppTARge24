using ShopTARge24.Core.Dto.OpenWeather;

namespace ShopTARge24.Core.ServiceInterface;

public interface IOpenWeatherService
{
    Task<OpenWeatherCityWeatherDto?> GetCurrentByCityAsync(string city, CancellationToken ct = default);
}
