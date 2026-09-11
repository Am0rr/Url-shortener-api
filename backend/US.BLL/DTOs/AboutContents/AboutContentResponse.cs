namespace US.BLL.DTOs.AboutContents;

public record AboutContentResponse
{
    public int Id { get; init; }
    public string Text { get; init; } = null!;
    public string LastModifiedByEmail { get; init; } = null!;
    public DateTimeOffset? UpdatedAt { get; init; }
}