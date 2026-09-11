using DotNetEnv;
using US.API.Infrastructure.Filters;
using US.DAL;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = $"Server={Env.GetString("DB_HOST", "localhost")},{Env.GetString("MSSQL_PORT", "1433")};" +
                       $"Database={Env.GetString("DB_NAME", "UrlShortenerDb")};" +
                       $"User Id={Env.GetString("DB_USER", "sa")};" +
                       $"Password={Env.GetString("MSSQL_SA_PASSWORD")};" +
                       $"Encrypt=False;" +
                       $"TrustServerCertificate=True;";

builder.Services.AddDataAccessLayer(connectionString);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
