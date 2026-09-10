using System.Linq.Expressions;
using US.DAL.Entities;

namespace US.DAL.Interfaces;

public interface IBaseRepository<T> where T : BaseEntity
{
    void Add(T item);
    void Update(T item);
    void Delete(int id);
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default);
}