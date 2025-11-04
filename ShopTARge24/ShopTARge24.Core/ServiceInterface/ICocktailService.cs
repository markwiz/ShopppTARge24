using ShopTARge24.Core.Dto;

namespace ShopTARge24.Core.ServiceInterface;

public interface ICocktailService
{
    Task<IReadOnlyList<CocktailSummaryDto>> SearchAsync(string query, CancellationToken ct = default);
    Task<CocktailDetailDto?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<CocktailDetailDto?> GetRandomAsync(CancellationToken ct = default);
}
