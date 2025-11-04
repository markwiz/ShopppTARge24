using System.Text.Json.Serialization;

namespace ShopTARge24.Core.Dto;

public sealed class ChuckNorrisJokeDto
{
    [JsonPropertyName("categories")] public List<string> Categories { get; init; } = [];
    [JsonPropertyName("created_at")] public string? CreatedAt { get; init; }
    [JsonPropertyName("icon_url")] public string? IconUrl { get; init; }
    [JsonPropertyName("id")] public string? Id { get; init; }
    [JsonPropertyName("updated_at")] public string? UpdatedAt { get; init; }
    [JsonPropertyName("url")] public string? Url { get; init; }
    [JsonPropertyName("value")] public string? Value { get; init; }
}
