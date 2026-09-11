using AutoMapper;
using US.BLL.DTOs.ShortUrls;
using US.BLL.Exceptions;
using US.BLL.Helpers;
using US.BLL.Interfaces;
using US.DAL.Entities;
using US.DAL.Interfaces;

namespace US.BLL.Services;

public class ShortUrlService(
    IUnitOfWork unitOfWork,
    IMapper mapper) : IShortUrlService
{
    private const int MaxGenerationAttempts = 5;
    
    public async Task<ShortUrlResponse> CreateAsync(int userId, CreateShortUrlRequest request,
        CancellationToken cancellationToken = default)
    {
        var existing = await unitOfWork.ShortUrls.GetByOriginalUrlAsync(request.OriginalUrl, cancellationToken);

        if (existing is not null)
            throw new ConflictException("This URL has already been shortened.");

        var shortCode = await GenerateUniqueShortCodeAsync(cancellationToken);
        var entity = new ShortUrl(request.OriginalUrl, shortCode, userId);
        
        unitOfWork.ShortUrls.Add(entity);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return mapper.Map<ShortUrlResponse>(entity);
    }

    public async Task DeleteAsync(int urlId, int currentUserId, bool isAdmin, CancellationToken cancellationToken = default)
    {
        var url = await unitOfWork.ShortUrls.GetByIdAsync(urlId, cancellationToken)
                  ?? throw new NotFoundException($"Short url with id {urlId} was not found.");
        
        if(!isAdmin && url.CreatedByUserId != currentUserId)
            throw new ForbiddenException("You can only delete short URLs created by you.");

        unitOfWork.ShortUrls.Delete(url);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<ShortUrlResponse> GetByIdAsync(int urlId, CancellationToken cancellationToken = default)
    {
        var url = await unitOfWork.ShortUrls.GetByIdAsync(urlId, cancellationToken)
                  ?? throw new NotFoundException($"Short url with id {urlId} was not found.");

        return mapper.Map<ShortUrlResponse>(url);
    }

    public async Task<IEnumerable<ShortUrlResponse>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var urls = await unitOfWork.ShortUrls.GetAllAsync(cancellationToken);

        return mapper.Map<IEnumerable<ShortUrlResponse>>(urls);
    }

    private async Task<string> GenerateUniqueShortCodeAsync(CancellationToken cancellationToken)
    {
        for (var attempt = 0; attempt < MaxGenerationAttempts; attempt++)
        {
            var candidate = ShortCodeGenerator.Generate();

            var existing = await unitOfWork.ShortUrls.GetByShortCodeAsync(candidate, cancellationToken);

            if (existing is null)
                return candidate;
        }
        
        throw new InvalidOperationException(
            $"Failed to generate a unique short code after {MaxGenerationAttempts} attempts.");
    }
}