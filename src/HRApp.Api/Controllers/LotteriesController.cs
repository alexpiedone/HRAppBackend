using HRApp.Application;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using static HRApp.Api.MockData;

namespace HRApp.Api;


[ApiController]
[Route("api/[controller]")]
public class LotteriesController : GenericController<Lottery>
{
    private readonly IBaseRepository<Lottery> _lotteryRepository;
    private readonly IMemoryCache _memoryCache;
    public LotteriesController(IBaseRepository<Lottery> lotteryRepository,
        IMemoryCache memoryCache) : base(lotteryRepository)
    {
        _lotteryRepository = lotteryRepository;
        _memoryCache = memoryCache;
    }

    [HttpGet("CarouselData")]
    public async Task<ActionResult<IEnumerable<LotteryCarouselDTO>>> GetLotteryCarouselData(
    [FromQuery] LotteryCarouselRequest request)
    {
        string cacheKey = $"lotteryData_{request.LotteryName}_{request.Page}_{request.PageSize}";

        if (_memoryCache.TryGetValue(cacheKey, out var cachedData))
        {
            return Ok(cachedData);
        }
        var activeLotteries = MockLotteryData.MockLotteryCarousels.AsQueryable();

        if (!string.IsNullOrEmpty(request.LotteryName))
        {
            activeLotteries = activeLotteries.Where(l => l.Name.Contains(request.LotteryName));
        }

        var totalCount = activeLotteries.Count();
        var pagedLotteries = activeLotteries
            .Skip((request.Page - 1) * request.PageSize)
            .Take(request.PageSize)
            .ToList();
        var result = new { TotalCount = totalCount, Items = pagedLotteries };
        var cacheExpiration = TimeSpan.FromMinutes(5);
        _memoryCache.Set(cacheKey, result, cacheExpiration);

        return Ok(result);
    }

    [HttpGet("Result/{id}")]
    public async Task<ActionResult<LotteryResultDto>> GetLotteryResult(int id)
    {
        var result = MockLotteryData.GetResultByLotteryId(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
    public class LotteryCarouselRequest
    {
        public string LotteryName { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string SortBy { get; set; } = "name_asc"; // Default sorting to Name Ascending
    }


}
