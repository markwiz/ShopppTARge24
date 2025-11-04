namespace ShopTARge24.Core.Dto;

public class CocktailSummaryDto
{
    public string Id { get; init; } = "";
    public string Name { get; init; } = "";
    public string? ThumbUrl { get; init; }
    public string? Category { get; init; }
    public string? Alcoholic { get; init; }
}

public sealed class CocktailDetailDto : CocktailSummaryDto
{
    public string? Glass { get; init; }
    public string? Instructions { get; init; }
    public IReadOnlyList<(string Ingredient, string? Measure)> Ingredients { get; init; } = [];
}
