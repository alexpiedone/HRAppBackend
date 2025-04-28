using HRApp.Application;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HRApp.Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        RegisterRepositories(services, Assembly.GetExecutingAssembly());

        return services;
    }

    public static void RegisterRepositories(this IServiceCollection services, Assembly assembly)
    {
        var repositoryTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract &&
                        t.GetInterfaces().Any(i => i.Name.StartsWith("I") && i.Name.EndsWith("Repository")))
            .ToList();

        foreach (var repositoryType in repositoryTypes)
        {
            var interfaceType = repositoryType.GetInterfaces()
                .FirstOrDefault(i => i.Name.StartsWith("I") && i.Name.EndsWith("Repository"));

            if (interfaceType != null)
            {
                services.AddScoped(interfaceType, repositoryType);
            }
        }
    }

}