using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using US.DAL.Persistence;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

var connectionString = $"Server={Env.GetString("DB_HOST", "localhost")},{Env.GetString("MSSQL_PORT", "1433")};" +
                       $"Database={Env.GetString("DB_NAME", "UrlShortenerDb")};" +
                       $"User Id={Env.GetString("DB_USER", "sa")};" +
                       $"Password={Env.GetString("MSSQL_SA_PASSWORD")};" +
                       $"Encrypt=False;" +
                       $"TrustServerCertificate=True;";

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
