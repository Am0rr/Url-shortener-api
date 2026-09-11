using DotNetEnv;
using US.API.Infrastructure.Filters;
using US.API.Infrastructure.Identity;
using US.API.Middleware;
using US.BLL;
using US.BLL.Interfaces;
using US.DAL;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

var connectionString = $"Server={Env.GetString("DB_HOST", "localhost")},{Env.GetString("MSSQL_PORT", "1433")};" +
                       $"Database={Env.GetString("DB_NAME", "UrlShortenerDb")};" +
                       $"User Id={Env.GetString("DB_USER", "sa")};" +
                       $"Password={Env.GetString("MSSQL_SA_PASSWORD")};" +
                       $"Encrypt=False;" +
                       $"TrustServerCertificate=True;";

builder.Services.AddDataAccessLayer(connectionString);

builder.Services.AddScoped<ValidationFilter>();
builder.Services.AddBusinessLogicLayer();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
