namespace US.BLL.DTOs.Identity;

public record AuthResponse(
    string AccessToken,
    int UserId,
    string Email,
    string Role
);