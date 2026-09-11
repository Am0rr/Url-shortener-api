using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using US.BLL.Interfaces;

namespace US.API.Controllers;

[ApiController]
public class RedirectController(IShortUrlService shortUrlService) : ControllerBase
{
    [AllowAnonymous]
    [HttpGet("/{shortCode}")]
    public async Task<IActionResult> RedirectToOriginal(string shortCode, CancellationToken cancellationToken)
    {
        var url = await shortUrlService.GetByShortCodeAsync(shortCode, cancellationToken);
        
        return Redirect(url.OriginalUrl);
    }
}