    using System.Security.Claims;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.IdentityModel.JsonWebTokens;
    using US.BLL.DTOs.ShortUrls;
    using US.BLL.Interfaces;

    namespace US.API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ShortUrlsController(IShortUrlService shortUrlService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ShortUrlResponse>> Create([FromBody] CreateShortUrlRequest request,
            CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);
            
            var url = await shortUrlService.CreateAsync(userId, request, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = url.Id }, url);  
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.FindFirst(JwtRegisteredClaimNames.Sub)!.Value);
            var isAdmin = User.IsInRole("Admin");
            await shortUrlService.DeleteAsync(id, userId, isAdmin, cancellationToken);
            return NoContent();
        }
        
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ShortUrlResponse>>> GetAll(CancellationToken cancellationToken)
        {
            var urls = await shortUrlService.GetAllAsync(cancellationToken);
            return Ok(urls);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ShortUrlResponse>> GetById(int id, CancellationToken cancellationToken)
        {
            var url = await shortUrlService.GetByIdAsync(id, cancellationToken);
            return Ok(url);
        }
    }