using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using US.DAL.Interfaces;
using US.DAL.Persistence;
using US.DAL.Repositories;

namespace US.DAL;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IShortUrlRepository, ShortUrlRepository>();
        services.AddScoped<IAboutContentRepository, AboutContentRepository>();

        return services;
    }
}