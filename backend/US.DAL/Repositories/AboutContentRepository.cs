using Microsoft.EntityFrameworkCore;
using US.DAL.Entities;
using US.DAL.Interfaces;
using US.DAL.Persistence;

namespace US.DAL.Repositories;

public class AboutContentRepository(AppDbContext context) : IAboutContentRepository
{
    public async Task<AboutContent?> GetContentAsync(CancellationToken cancellationToken = default)
    {
        return await context.AboutContents.FirstOrDefaultAsync(cancellationToken);
    }
}
