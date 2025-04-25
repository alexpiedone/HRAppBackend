using HRApp.Application;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Api;


[ApiController]
[Route("api/[controller]")]
public class LotteriesController : GenericController<Lottery>
{
    private readonly IBaseRepository<Lottery> _lotteryRepository;

    public LotteriesController(IBaseRepository<Lottery> lotteryRepository) : base(lotteryRepository)
    {
        _lotteryRepository = lotteryRepository;
    }

    [HttpGet("CarouselData")]
    public async Task<ActionResult<IEnumerable<LotteryCarouselDTO>>> GetLotteryCarouselData(
        [FromQuery] LotteryCarouselRequest request)
    {
        //IQueryable<Lottery> activeLotteries = _lotteryRepository.Query(l => l.Active);
        var activeLotteries = MockData.MockLotteryCarousels;

        if (!string.IsNullOrEmpty(request.LotteryName))
            activeLotteries = activeLotteries.Where(l => l.Name.Contains(request.LotteryName));

        //switch (request.SortBy?.ToLower())
        //{
        //    case "drawtime":
        //        activeLotteries = activeLotteries.OrderBy(l => l.DrawTime);
        //        break;
        //    case "jackpot":
        //        activeLotteries = activeLotteries.OrderBy(l => l.Jackpot);
        //        break;
        //    case "name":
        //        activeLotteries = activeLotteries.OrderBy(l => l.Name);
        //        break;
        //    default:
        //        activeLotteries = activeLotteries.OrderBy(l => l.DrawTime); // Default sorting
        //        break;
        //}

        var totalCount = activeLotteries.Count();
        var pagedlotteries = activeLotteries
            .Skip((request.Page- 1) * request.PageSize)
            .Take(request.PageSize);

        var results = pagedlotteries.Select(l => new LotteryCarouselDTO
        {
            Id = l.Id,
            Name = l.Name,
            LogoUrl = l.LogoUrl,
            Jackpot = l.Jackpot,
            DrawTime = l.DrawTime,
            CardLink = l.CardLink
        });

        return Ok(new { TotalCount = totalCount, Items = results });
    }

    [HttpGet("Result/{id}")]
    public async Task<ActionResult<LotteryResultDto>> GetLotteryResult(int id)
    {
        var lottery = await _lotteryRepository.Query(l => l.Id == id)
            .Include(l => l.Results.OrderByDescending(r => r.ResultDateTime).FirstOrDefault())
            .FirstOrDefaultAsync();

        if (lottery == null || lottery.Results.FirstOrDefault() == null)
        {
            return NotFound();
        }

        var latestResult = lottery.Results.First();

        return Ok(new LotteryResultDto
        {
            ResultDateTime = latestResult.ResultDateTime,
            WinningBalls = latestResult.WinningBalls,
            Link1 = latestResult.Link1,
            Link2 = latestResult.Link2
        });
    }

    public class LotteryCarouselRequest
    {
        public string LotteryName { get; set; }
        public string SortBy { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
