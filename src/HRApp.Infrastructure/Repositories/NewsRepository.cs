using HRApp.Application;
using HRApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Infrastructure;

public class NewsRepository : BaseRepository<NewsItem>, INewsRepository
{
    public NewsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<NewsItem>> GetNewsForUserAsync(int userId)
    {
        return await _context.Set<NewsItem>()
            .Where(n => n.Active)
            .ToListAsync();
    }
}