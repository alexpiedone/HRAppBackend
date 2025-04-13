using HRApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HRApp.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var entityTypes = Assembly.GetExecutingAssembly()
                                  .GetTypes()
                                  .Where(t => t.IsClass &&
                                    !t.IsAbstract &&
                                    t.GetCustomAttribute<DbTableAttribute>() != null)
                                  .ToList();

        foreach (var entityType in entityTypes)
        {
            var method = typeof(ModelBuilder).GetMethod("Entity", new Type[] { });
            var entityMethod = method.MakeGenericMethod(entityType);
            entityMethod.Invoke(modelBuilder, null);
        }
    }
}
