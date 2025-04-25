namespace HRApp.Api;

public class LotteryCarouselDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LogoUrl { get; set; }
    public string Jackpot { get; set; }
    public DateTime DrawTime { get; set; }
    public string CardLink { get; set; }
}
