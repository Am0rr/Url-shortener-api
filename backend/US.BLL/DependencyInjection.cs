using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using US.BLL.Interfaces;
using US.BLL.Services;
using System.Reflection;
using US.BLL.Validators;

namespace US.BLL;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IShortUrlService, ShortUrlService>();
        services.AddScoped<IAboutContentService, AboutContentService>();

        services.AddValidatorsFromAssemblyContaining<CreateShortUrlRequestValidator>();
        
        services.AddAutoMapper(cfg => cfg.AddMaps(Assembly.GetExecutingAssembly()));

        return services;
    }
}