using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using US.BLL.DTOs.AboutContents;
using US.BLL.DTOs.Identity;
using US.BLL.Interfaces;
using US.DAL.Enums;

namespace US.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class AboutContentsController(IAboutContentService aboutContentService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet]
    public async Task<ActionResult<AboutContentResponse>> GetContent(CancellationToken cancellationToken)
    {
        var content = await aboutContentService.GetContentAsync(cancellationToken);

        return Ok(content);
    }

    [Authorize(Roles = nameof(UserRole.Admin))]
    [HttpPut]
    public async Task<ActionResult<AboutContentResponse>> Update([FromBody] UpdateAboutContentRequest request,
        CancellationToken cancellationToken)
    {
        var userId = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);

        var content = await aboutContentService.UpdateAsync(userId, request, cancellationToken);

        return Ok(content);
    }
}