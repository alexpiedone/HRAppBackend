using HRApp.Application;
using HRApp.Communication;
using HRApp.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace HRApp.Api;


[ApiController]
[Route("api/[controller]")]
public class NewsController : GenericController<NewsItem>
{
    private readonly INewsRepository _newsRepo;

    public NewsController(IBaseRepository<NewsItem> baseRepo, INewsRepository newsRepo)
        : base(baseRepo)
    {
        _newsRepo = newsRepo;
    }

    [HttpGet("GetAllDTO")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<NewsItemDto>>> GetAllDTO()
    {
        var items = await _newsRepo
            .Query(a => a.Active)
            .Include(n => n.Author)
            .Include(n => n.Category)
            .Include(n => n.Author.AvatarFile) 
            .AsNoTracking()
            .ToListAsync();

        var result = items.Select(n => new NewsItemDto
        {
            Id = n.Id.ToString(),
            Title = n.Title,
            Description = n.Content,
            Category = n.Category.Name,
            Date = n.CreatedAt, 
            IsFeatured = n.isPrincipal, 
            Author = n.Author != null ? new AuthorDto
            {
                Name = n.Author.FullName,
                Initials = GetInitials(n.Author.FullName)
            } : null,
            Action = null 
        });

        return Ok(result);
    }

    private string GetInitials(string fullName)
    {
        if (string.IsNullOrEmpty(fullName)) return "US";

        var parts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0) return "US";

        return parts.Length >= 2
            ? $"{parts[0][0]}{parts[^1][0]}".ToUpper()
            : parts[0].Length >= 2
                ? parts[0].Substring(0, 2).ToUpper()
                : $"{parts[0][0]}X".ToUpper();
    }
}