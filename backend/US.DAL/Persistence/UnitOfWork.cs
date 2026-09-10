using US.DAL.Interfaces;

namespace US.DAL.Persistence;

public class UnitOfWork(
    AppDbContext context,
    IUserRepository users,
    IShortUrlRepository shortUrls,
    IAboutContentRepository aboutContents) : IUnitOfWork
{
    public IUserRepository Users { get; } = users;
    public IShortUrlRepository ShortUrls { get; } = shortUrls;
    public IAboutContentRepository AboutContents { get; } = aboutContents;

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await context.SaveChangesAsync(cancellationToken);
    }
}