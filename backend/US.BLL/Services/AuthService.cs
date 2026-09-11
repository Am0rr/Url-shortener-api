using AutoMapper;
using US.BLL.DTOs.Identity;
using US.BLL.Interfaces;
using US.DAL.Interfaces;

namespace US.BLL.Services;

public class AuthService(
    IUnitOfWork unitOfWork,
    IJwtProvider jwtProvider,
    IMapper mapper) : IAuthService
{
    public async Task<AuthResponse> LoginAsync(LoginRequest request, CancellationToken cancellationToken = default)
    {
        var user = await unitOfWork.Users.GetByEmailAsync(request.Email, cancellationToken)
                   ?? throw new UnauthorizedAccessException("Invalid email or password.");
        
        if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid email or password.");

        var accessToken = jwtProvider.GenerateAccessToken(user.Id, user.Email, user.Role.ToString());

        return mapper.Map<AuthResponse>(user) with {AccessToken = accessToken};
    }
}