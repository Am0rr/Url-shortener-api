namespace US.BLL.Interfaces;

public interface IJwtProvider
{
    string GenerateAccessToken(int userId, string email, string userRole);
}