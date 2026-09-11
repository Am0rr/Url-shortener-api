using US.BLL.DTOs.ShortUrls;

namespace US.BLL.Interfaces;

public interface IShortUrlService
{
    Task<ShortUrlResponse> CreateAsync(int userId, CreateShortUrlRequest request, CancellationToken cancellationToken = default);
    Task DeleteAsync(int urlId, int currentUserId, bool isAdmin, CancellationToken cancellationToken = default);
    Task<ShortUrlResponse> GetByIdAsync(int urlId, CancellationToken cancellationToken = default);
    Task<IEnumerable<ShortUrlResponse>> GetAllAsync(CancellationToken cancellationToken = default);
}