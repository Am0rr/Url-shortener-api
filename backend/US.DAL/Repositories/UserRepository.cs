using US.DAL.Entities;
using US.DAL.Interfaces;
using US.DAL.Persistence;

namespace US.DAL.Repositories;

public class UserRepository(AppDbContext context) 
    : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        return await DbSet.FindAsync([email], cancellationToken);
    }
}