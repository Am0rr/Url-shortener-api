namespace US.API.Infrastructure.Identity;

public class JwtOptions
{
    public string SecureKey { get; init; } = null!;
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public int AccessTokenLifetimeInMinutes { get; init; }
}