using ShopTARge24.Core.Dto;

namespace ShopTARge24.Models.Cocktails;

public sealed class CocktailSearchViewModel
{
    public string? Query { get; set; }
    public IReadOnlyList<CocktailSummaryDto> Results { get; set; } = [];
    public CocktailDetailDto? Random { get; set; }
}

public sealed class CocktailDetailViewModel
{
    public CocktailDetailDto Cocktail { get; set; } = new();
}
