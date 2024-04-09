using Application.Base;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Base;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMainDatabase(configuration);
        return services;
    }
    
    private static IServiceCollection AddMainDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var ServerName = Environment.GetEnvironmentVariable("DATABASE_SERVER") ?? configuration["MainDataBase:ServerName"];
        var Port = Environment.GetEnvironmentVariable("DATABASE_PORT") ?? configuration["MainDataBase:Port"];
        var DatabaseName = Environment.GetEnvironmentVariable("DATABASE_NAME") ?? configuration["MainDataBase:DbName"];
        var Username = Environment.GetEnvironmentVariable("DATABASE_USER") ?? configuration["MainDataBase:Username"];
        var Password = Environment.GetEnvironmentVariable("DATABASE_PASSWORD") ?? configuration["MainDataBase:MyStrngPassw0rd"];
        string connectionString = $"Server={ServerName},{Port};Database={DatabaseName};User Id={Username};Password={Password};TrustServerCertificate=Yes;MultipleActiveResultSets=true";
        Console.WriteLine("the connection is : " + connectionString);

        services.AddDbContext<DatabaseContext>(
            (sp, options) =>
            {
                options.UseLazyLoadingProxies();
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName));

            });
        services.AddScoped<IDatabaseContext>(provider => provider.GetRequiredService<DatabaseContext>());
        return services;
    }
}