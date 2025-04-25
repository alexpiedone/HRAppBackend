

namespace HRApp.Domain;

public static class MockData
{
    public static IEnumerable<Lottery> MockLotteryCarousels =
    [
        new Lottery
        {
            Name = "Mega Millions",
            LogoUrl = "/images/mega_millions_logo.png",
            Jackpot = "$350 Million",
            DrawTime = DateTime.Now.AddDays(2).AddHours(20),
            CardLink = "/mega-millions",
            Results = new List<LotteryResult>
            {
                new LotteryResult { ResultDateTime = DateTime.Now.AddDays(-1), WinningBalls = "10, 25, 38, 54, 67" }
            }
        },
        new Lottery
        {
            Name = "Powerball",
            LogoUrl = "/images/powerball_logo.png",
            Jackpot = "$180 Million",
            DrawTime = DateTime.Now.AddDays(3).AddHours(21),
            CardLink = "/powerball",
            Results = new List<LotteryResult>
            {
                new LotteryResult { ResultDateTime = DateTime.Now.AddDays(-2), WinningBalls = "5, 12, 28, 39, 62" }
            }
        },
        new Lottery
        {
            Name = "EuroMillions",
            LogoUrl = "/images/euromillions_logo.png",
            Jackpot = "€120 Million",
            DrawTime = DateTime.Now.AddDays(1).AddHours(22),
            CardLink = "/euromillions",
            Results = new List<LotteryResult>
            {
                new LotteryResult { ResultDateTime = DateTime.Now.AddDays(-3), WinningBalls = "7, 18, 23, 41, 49" }
            }
        },
        new Lottery
        {
            Name = "Lotto 6/49",
            LogoUrl = "/images/lotto649_logo.png",
            Jackpot = "$5 Million",
            DrawTime = DateTime.Now.AddHours(12),
            CardLink = "/lotto649",
            Results = new List<LotteryResult>
            {
                new LotteryResult { ResultDateTime = DateTime.Now.AddDays(-4), WinningBalls = "3, 11, 27, 34, 42, 48" }
            }
        },
    ];
}
