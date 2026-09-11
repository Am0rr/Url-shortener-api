using Microsoft.AspNetCore.Mvc;
using US.BLL.DTOs.Identity;
using US.BLL.Interfaces;

namespace US.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async Task<ActionResult<AuthResponse>> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await authService.LoginAsync(request, cancellationToken);

        return Ok(user);
    }
}
