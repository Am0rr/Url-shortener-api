namespace US.BLL.DTOs.ShortUrls;

public record ShortUrlResponse(
    int Id,
    string OriginalUrl,
    string ShortCode,
    string CreatedByEmail,
    DateTimeOffset CreatedAt
);