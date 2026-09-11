using Microsoft.EntityFrameworkCore;
using US.DAL.Entities;
using US.DAL.Interfaces;
using US.DAL.Persistence;

namespace US.DAL.Repositories;

public class ShortUrlRepository(AppDbContext context) 
    : IShortUrlRepository
{
    private readonly DbSet<ShortUrl> _dbSet = context.Set<ShortUrl>();

    public void Add(ShortUrl url)
    {
        _dbSet.Add(url);
    }

    public void Delete(ShortUrl url)
    {
        _dbSet.Remove(url);
    }
    
    public async Task<ShortUrl?> GetByOriginalUrlAsync(string originalUrl, CancellationToken cancellationToken = default)
    {
        return await _dbSet.FirstOrDefaultAsync(s => s.OriginalUrl == originalUrl, cancellationToken);
    }

    public async Task<ShortUrl?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(s => s.CreatedBy)
            .FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    public async Task<IEnumerable<ShortUrl>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .AsNoTracking()
            .Include(s => s.CreatedBy)
            .ToListAsync(cancellationToken);
    }
}