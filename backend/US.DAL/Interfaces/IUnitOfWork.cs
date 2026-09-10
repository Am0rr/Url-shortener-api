namespace US.DAL.Interfaces;

public interface IUnitOfWork
{
    IUserRepository Users { get; }
    IShortUrlRepository ShortUrls { get; }
    IAboutContentRepository AboutContents { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}