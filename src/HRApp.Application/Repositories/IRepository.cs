using System.Linq.Expressions;

namespace HRApp.Application;

public interface IBaseRepository<T> where T : class
{
    Task<T?> GetByIdAsync(int id, bool throwError = false);
    Task<List<T>> GetAllAsync();
    IQueryable<T> Query(Expression<Func<T, bool>>? predicate = null);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}