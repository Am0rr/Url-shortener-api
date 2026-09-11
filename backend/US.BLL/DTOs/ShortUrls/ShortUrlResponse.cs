namespace US.BLL.DTOs.ShortUrls;

public record ShortUrlResponse
{
    public int Id { get; init; }
    public string OriginalUrl { get; init; } = null!;
    public string ShortCode { get; init; } = null!;
    public string CreatedByEmail { get; init; } = null!;
    public DateTimeOffset CreatedAt { get; init; }
}