using US.DAL.Entities;

namespace US.DAL.Interfaces;

public interface IAboutContentRepository : IBaseRepository<AboutContent>
{
    Task<AboutContent> GetContentAsync(CancellationToken cancellationToken = default);
}