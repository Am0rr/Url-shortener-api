using Microsoft.EntityFrameworkCore;
using US.DAL.Entities;
using US.DAL.Enums;
using US.DAL.Persistence;

namespace US.API.Infrastructure.Seeders;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        await context.Database.MigrateAsync();

        if (!await context.Users.AnyAsync())
        {
            var admin = new User("admin@urlshortener.com", BCrypt.Net.BCrypt.HashPassword("Admin123!"), UserRole.Admin);
            var user = new User("user@urlshortener.com", BCrypt.Net.BCrypt.HashPassword("User123!"), UserRole.User);

            context.Users.AddRange(admin, user);
            await context.SaveChangesAsync();

            context.AboutContents.Add(new AboutContent(
                "This Url Shortener uses a random Base62 code generation algorithm to create short, unique aliases for long URLs.",
                admin.Id));

            context.ShortUrls.AddRange(
                new ShortUrl("https://www.google.com", "goo123", admin.Id),
                new ShortUrl("https://www.github.com", "gh456", user.Id)
            );

            await context.SaveChangesAsync();
        }
    }
}

