using HRApp.Application;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;

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

}