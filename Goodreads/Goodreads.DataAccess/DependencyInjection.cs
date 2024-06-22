using Goodreads.Business.Abstractions.Repositories;
using Goodreads.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Goodreads.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories();
        services.AddDbConnection(configuration);

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["MySQLConnectionString"];
        services.AddDbContext<AppDbContext>(
            options => options
                .UseMySql(
                    connectionString,
                    new MySqlServerVersion(new Version(8, 0, 25))
                )
        );
        return services;
    }
}