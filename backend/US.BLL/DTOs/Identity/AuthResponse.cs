namespace US.BLL.DTOs.Identity;

public record AuthResponse
{
    public int Id { get; init; }
    public string AccessToken { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string Role { get; init; } = null!;
}