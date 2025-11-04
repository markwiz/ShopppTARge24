using System.Net.Http.Json;
using System.Linq;
using CoreDtos = ShopTARge24.Core.Dto;
using ShopTARge24.Core.ServiceInterface;

namespace ShopTARge24.ApplicationServices.Services;

public sealed class CocktailService : ICocktailService
{
    private readonly HttpClient _http;

    public CocktailService(HttpClient http)
    {
        _http = http;
        _http.BaseAddress ??= new Uri("https://www.thecocktaildb.com/api/json/v1/1/");
    }

    public async Task<IReadOnlyList<CoreDtos.CocktailSummaryDto>> SearchAsync(string query, CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(query))
            return Array.Empty<CoreDtos.CocktailSummaryDto>();

        var env = await _http.GetFromJsonAsync<CocktailApiEnvelope<DrinkApi>>(
            $"search.php?s={Uri.EscapeDataString(query)}", ct);

        var drinks = env?.Drinks ?? new List<DrinkApi>();

        return drinks.Select(d => new CoreDtos.CocktailSummaryDto
        {
            Id = d.idDrink ?? "",
            Name = d.strDrink ?? "",
            ThumbUrl = d.strDrinkThumb,
            Category = d.strCategory,
            Alcoholic = d.strAlcoholic
        }).ToList();
    }

    public async Task<CoreDtos.CocktailDetailDto?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var env = await _http.GetFromJsonAsync<CocktailApiEnvelope<DrinkApi>>(
            $"lookup.php?i={Uri.EscapeDataString(id)}", ct);

        var d = env?.Drinks?.FirstOrDefault();
        return d is null ? null : MapDetail(d);
    }

    public async Task<CoreDtos.CocktailDetailDto?> GetRandomAsync(CancellationToken ct = default)
    {
        var env = await _http.GetFromJsonAsync<CocktailApiEnvelope<DrinkApi>>("random.php", ct);
        var d = env?.Drinks?.FirstOrDefault();
        return d is null ? null : MapDetail(d);
    }

    private static CoreDtos.CocktailDetailDto MapDetail(DrinkApi d)
    {
        var ingredients = new List<(string, string?)>();

        void Add(string? ing, string? meas)
        {
            var name = (ing ?? "").Trim();
            if (!string.IsNullOrWhiteSpace(name))
                ingredients.Add((name, string.IsNullOrWhiteSpace(meas) ? null : meas!.Trim()));
        }

        Add(d.strIngredient1, d.strMeasure1); Add(d.strIngredient2, d.strMeasure2);
        Add(d.strIngredient3, d.strMeasure3); Add(d.strIngredient4, d.strMeasure4);
        Add(d.strIngredient5, d.strMeasure5); Add(d.strIngredient6, d.strMeasure6);
        Add(d.strIngredient7, d.strMeasure7); Add(d.strIngredient8, d.strMeasure8);
        Add(d.strIngredient9, d.strMeasure9); Add(d.strIngredient10, d.strMeasure10);
        Add(d.strIngredient11, d.strMeasure11); Add(d.strIngredient12, d.strMeasure12);
        Add(d.strIngredient13, d.strMeasure13); Add(d.strIngredient14, d.strMeasure14);
        Add(d.strIngredient15, d.strMeasure15);

        return new CoreDtos.CocktailDetailDto
        {
            Id = d.idDrink ?? "",
            Name = d.strDrink ?? "",
            ThumbUrl = d.strDrinkThumb,
            Category = d.strCategory,
            Alcoholic = d.strAlcoholic,
            Glass = d.strGlass,
            Instructions = d.strInstructions,
            Ingredients = ingredients
        };
    }

    // --- Toormudelid hoiame siin privaatsena ---
    private sealed class CocktailApiEnvelope<T>
    {
        public List<T>? Drinks { get; set; }
    }

    private sealed class DrinkApi
    {
        public string? idDrink { get; set; }
        public string? strDrink { get; set; }
        public string? strDrinkThumb { get; set; }
        public string? strCategory { get; set; }
        public string? strAlcoholic { get; set; }
        public string? strGlass { get; set; }
        public string? strInstructions { get; set; }

        public string? strIngredient1 { get; set; }
        public string? strMeasure1 { get; set; }
        public string? strIngredient2 { get; set; }
        public string? strMeasure2 { get; set; }
        public string? strIngredient3 { get; set; }
        public string? strMeasure3 { get; set; }
        public string? strIngredient4 { get; set; }
        public string? strMeasure4 { get; set; }
        public string? strIngredient5 { get; set; }
        public string? strMeasure5 { get; set; }
        public string? strIngredient6 { get; set; }
        public string? strMeasure6 { get; set; }
        public string? strIngredient7 { get; set; }
        public string? strMeasure7 { get; set; }
        public string? strIngredient8 { get; set; }
        public string? strMeasure8 { get; set; }
        public string? strIngredient9 { get; set; }
        public string? strMeasure9 { get; set; }
        public string? strIngredient10 { get; set; }
        public string? strMeasure10 { get; set; }
        public string? strIngredient11 { get; set; }
        public string? strMeasure11 { get; set; }
        public string? strIngredient12 { get; set; }
        public string? strMeasure12 { get; set; }
        public string? strIngredient13 { get; set; }
        public string? strMeasure13 { get; set; }
        public string? strIngredient14 { get; set; }
        public string? strMeasure14 { get; set; }
        public string? strIngredient15 { get; set; }
        public string? strMeasure15 { get; set; }
    }
}
