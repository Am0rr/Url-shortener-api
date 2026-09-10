using Microsoft.EntityFrameworkCore;
using US.DAL.Entities;
using US.DAL.Interfaces;
using US.DAL.Persistence;
using System.Linq.Expressions;

namespace US.DAL.Repositories;

public class BaseRepository<T>(AppDbContext context) 
    : IBaseRepository<T> where T : BaseEntity
{
    protected readonly DbSet<T> DbSet = context.Set<T>();
    
    public void Add(T item)
    {
        DbSet.Add(item);
    }

    public void Update(T item)
    {
        DbSet.Update(item);
    }

    public void Delete(T item)
    {
        DbSet.Remove(item);
    }

    public virtual async Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([id], cancellationToken);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.AsNoTracking().ToListAsync(cancellationToken);
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await DbSet.AnyAsync(predicate, cancellationToken);
    }
}