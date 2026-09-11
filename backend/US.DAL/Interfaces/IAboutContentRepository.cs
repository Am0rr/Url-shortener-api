using US.DAL.Entities;

namespace US.DAL.Interfaces;

public interface IAboutContentRepository
{
    Task<AboutContent?> GetContentAsync(CancellationToken cancellationToken = default);
}