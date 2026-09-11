namespace US.BLL.DTOs.AboutContents;

public record AboutContentResponse(
    int Id,
    string Text,
    string LastModifiedByEmail,
    DateTimeOffset? UpdatedAt
);