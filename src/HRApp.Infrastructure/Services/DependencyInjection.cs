using HRApp.Application;
using Microsoft.Extensions.DependencyInjection;

namespace HRApp.Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IDocumentRepository,DocumentRepository>();
        services.AddScoped<INewsRepository, NewsRepository>();
        return services;
    }
}