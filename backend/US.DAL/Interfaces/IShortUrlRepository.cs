using US.DAL.Entities;

namespace US.DAL.Interfaces;

public interface IShortUrlRepository : IBaseRepository<ShortUrl>
{
    Task<ShortUrl> GetByOriginalUrlAsync(string originalUrl, CancellationToken cancellationToken = default);
    Task<ShortUrl> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default);
}