using US.DAL.Entities;

namespace US.DAL.Interfaces;

public interface IShortUrlRepository
{
    void Add(ShortUrl url);
    void Delete(ShortUrl url);
    Task<ShortUrl?> GetByOriginalUrlAsync(string originalUrl, CancellationToken cancellationToken = default);
    Task<ShortUrl?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<ShortUrl>> GetAllAsync(CancellationToken cancellationToken = default);
}