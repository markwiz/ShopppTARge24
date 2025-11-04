using System.Net.Http.Json;
using ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;

namespace ShopTARge24.ApplicationServices.Services;

public sealed class ChuckNorrisService : IChuckNorrisService
{
    private readonly HttpClient _http;

    public ChuckNorrisService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress ??= new Uri("https://api.chucknorris.io/");
    }

    public async Task<ChuckNorrisJokeDto> GetRandomAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<ChuckNorrisJokeDto>("jokes/random", ct)
           ?? new ChuckNorrisJokeDto { Value = "No joke found." };

    public async Task<IReadOnlyList<string>> GetCategoriesAsync(CancellationToken ct = default)
        => await _http.GetFromJsonAsync<List<string>>("jokes/categories", ct) ?? [];

    public async Task<ChuckNorrisJokeDto> GetRandomByCategoryAsync(string category, CancellationToken ct = default)
        => await _http.GetFromJsonAsync<ChuckNorrisJokeDto>($"jokes/random?category={Uri.EscapeDataString(category)}", ct)
           ?? new ChuckNorrisJokeDto { Value = $"No joke found for '{category}'." };
}
