namespace US.BLL.DTOs.AboutContents;

public record AboutContentResponse(
    int Id,
    string Text,
    int LastModifiedByUserId
);