using Microsoft.EntityFrameworkCore;
using US.DAL.Entities;

namespace US.DAL.Persistence;

public class AppDbContext(
    DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<ShortUrl> ShortUrls { get; set; }
    public DbSet<AboutContent> AboutContents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}