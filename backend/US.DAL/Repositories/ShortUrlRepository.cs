using Microsoft.EntityFrameworkCore;
using US.DAL.Entities;
using US.DAL.Interfaces;
using US.DAL.Persistence;

namespace US.DAL.Repositories;

public class ShortUrlRepository(AppDbContext context) 
    : BaseRepository<ShortUrl>(context), IShortUrlRepository
{
    public async Task<ShortUrl?> GetByOriginalUrlAsync(string originalUrl, CancellationToken cancellationToken = default)
    {
        return await DbSet.FirstOrDefaultAsync(s => s.OriginalUrl == originalUrl, cancellationToken);
    }

    public async Task<IEnumerable<ShortUrl>> GetByUserIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .Where(s => s.CreatedByUserId == userId)
            .ToListAsync(cancellationToken);
    }

    public override async Task<ShortUrl?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet
            .Include(s => s.CreatedBy)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public override async Task<IEnumerable<ShortUrl>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet
            .AsNoTracking()
            .Include(s => s.CreatedBy)
            .ToListAsync(cancellationToken);
    }
}