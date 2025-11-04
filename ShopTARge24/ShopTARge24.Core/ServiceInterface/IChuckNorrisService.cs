using ShopTARge24.Core.Dto;

namespace ShopTARge24.Core.ServiceInterface;

public interface IChuckNorrisService
{
    Task<ChuckNorrisJokeDto> GetRandomAsync(CancellationToken ct = default);
    Task<IReadOnlyList<string>> GetCategoriesAsync(CancellationToken ct = default);
    Task<ChuckNorrisJokeDto> GetRandomByCategoryAsync(string category, CancellationToken ct = default);
}
