using HRApp.Application;
using HRApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Infrastructure;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(Guid id) => await _dbSet.FindAsync(id);
    public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();
    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(T entity)
    {
        var item = await _dbSet.FindAsync(entity.Id);

        if (item == null)
        {
            return;
        }

        item.Active = false;

        _dbSet.Update(item);
        await _context.SaveChangesAsync();
    }
}