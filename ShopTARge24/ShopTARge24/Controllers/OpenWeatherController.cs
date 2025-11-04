using Microsoft.AspNetCore.Mvc;
using ShopTARge24.Core.ServiceInterface;
using ShopTARge24.Models.OpenWeather;

namespace ShopTARge24.Controllers;

public sealed class OpenWeatherController : Controller
{
    private readonly IOpenWeatherService _svc;
    public OpenWeatherController(IOpenWeatherService svc) => _svc = svc;

    // GET: /OpenWeather (otsinguvorm)
    public IActionResult Index() => View(new OpenWeatherSearchViewModel());

    // POST: /OpenWeather/City
    [HttpPost]
    public async Task<IActionResult> City(OpenWeatherSearchViewModel vm, CancellationToken ct)
    {
        if (string.IsNullOrWhiteSpace(vm.City))
        {
            ModelState.AddModelError(nameof(vm.City), "City is required.");
            return View("Index", vm);
        }

        var dto = await _svc.GetCurrentByCityAsync(vm.City.Trim(), ct);
        if (dto is null)
        {
            ModelState.AddModelError("", "No data from OpenWeather.");
            return View("Index", vm);
        }

        var cond = dto.Weather.FirstOrDefault();
        var windKmh = (dto.Wind?.Speed ?? 0) * 3.6; // m/s -> km/h

        var result = new OpenWeatherCityViewModel
        {
            City = dto.Name ?? vm.City,
            TemperatureC = dto.Main?.Temp ?? 0,
            FeelsLikeC = dto.Main?.FeelsLike ?? 0,
            HumidityPct = dto.Main?.Humidity ?? 0,
            PressureHpa = dto.Main?.Pressure ?? 0,
            WindKmh = Math.Round(windKmh, 2),
            Condition = cond?.Main ?? cond?.Description ?? "N/A"
        };

        return View(result);
    }
}
