using Goodreads.Business.Service;
using Goodreads.Business.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Goodreads.Business;

public static class DependencyInjection
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}