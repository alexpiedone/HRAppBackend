using HRApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace HRApp.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        base.OnModelCreating(modelBuilder);

        var assemblies = new[]
        {
            Assembly.GetExecutingAssembly(),
            Assembly.Load("HRApp.Domain")
        };

        var entityTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<TableAttribute>() != null)
            .ToList();

        foreach (var type in entityTypes)
        {
            var method = typeof(ModelBuilder).GetMethods()
                .FirstOrDefault(m => m.Name == "Entity" && m.IsGenericMethod && m.GetParameters().Length == 0);

            if (method != null)
            {
                var generic = method.MakeGenericMethod(type);
                generic.Invoke(modelBuilder, null);
            }
        }

        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
    }
}
