using HRApp.Application;
using HRApp.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

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

    public async Task<T?> GetByIdAsync(int id, bool throwError = false)
    {
        var result = await _dbSet.FindAsync(id);
        if (result == null && throwError)
            throw new Exception("Niciun element gasit");
        return result;
    }

    public async Task<List<T>> GetAllAsync() => await _dbSet.ToListAsync();


    public IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null)
    {
        return predicate == null ? _dbSet : _dbSet.Where(predicate);
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

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
