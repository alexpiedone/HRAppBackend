namespace HRApp.Api;

public static class MockData
{
    public static class MockLotteryData
    {
        public static List<LotteryCarouselDTO> MockLotteryCarousels => new List<LotteryCarouselDTO>
        {
           new LotteryCarouselDTO
            {
                Id = 1,
                Name = "Powerball",
                LogoUrl = "powerball.png",
                Jackpot = "$50 Million",
                DrawTime = "Every Wednesday, Saturday at 10:00 PM",
                CardLink = "/powerball"
            },
            new LotteryCarouselDTO
            {
                Id = 2,
                Name = "Mega Millions",
                LogoUrl = "megamillions.png",
                Jackpot = "$40 Million",
                DrawTime = "Every Tuesday, Friday at 11:00 PM",
                CardLink = "/megamillions"
            },
            new LotteryCarouselDTO
            {
                Id = 3,
                Name = "EuroMillions",
                LogoUrl = "euromillions.png",
                Jackpot = "€70 Million",
                DrawTime = "Every Tuesday, Friday at 8:45 PM",
                CardLink = "/euromillions"
            },
            new LotteryCarouselDTO
            {
                Id = 4,
                Name = "Lotto 6/49",
                LogoUrl = "lotto649.png",
                Jackpot = "$5 Million",
                DrawTime = "Every Wednesday, Saturday at 10:00 PM",
                CardLink = "/lotto649"
            },
            new LotteryCarouselDTO
            {
                Id = 5,
                Name = "EuroJackpot",
                LogoUrl = "eurojackpot.png",
                Jackpot = "€50 Million",
                DrawTime = "Every Friday at 9:00 PM",
                CardLink = "/eurojackpot"
            },
            new LotteryCarouselDTO
            {
                Id = 6,
                Name = "UK National Lottery",
                LogoUrl = "uklottery.png",
                Jackpot = "£10 Million",
                DrawTime = "Every Wednesday, Saturday at 8:00 PM",
                CardLink = "/uknational"
            },
            new LotteryCarouselDTO
            {
                Id = 7,
                Name = "Australia Powerball",
                LogoUrl = "auspowerball.png",
                Jackpot = "$80 Million",
                DrawTime = "Every Thursday at 8:30 PM",
                CardLink = "/auspowerball"
            },
            new LotteryCarouselDTO
            {
                Id = 8,
                Name = "SuperEnalotto",
                LogoUrl = "superenalotto.png",
                Jackpot = "€130 Million",
                DrawTime = "Every Tuesday, Thursday, Saturday at 8:00 PM",
                CardLink = "/superenalotto"
            },
            new LotteryCarouselDTO
            {
                Id = 9,
                Name = "Cash 4 Life",
                LogoUrl = "cash4life.png",
                Jackpot = "$1,000 a day for life",
                DrawTime = "Every Monday, Wednesday, Saturday at 9:00 PM",
                CardLink = "/cash4life"
            },
            new LotteryCarouselDTO
            {
                Id = 10,
                Name = "Lucky for Life",
                LogoUrl = "luckyforlife.png",
                Jackpot = "$1,000 a day for life",
                DrawTime = "Every Monday, Thursday at 10:38 PM",
                CardLink = "/luckyforlife"
            },
            new LotteryCarouselDTO
            {
                Id = 11,
                Name = "Hot Lotto",
                LogoUrl = "hotlotto.png",
                Jackpot = "$10 Million",
                DrawTime = "Every Wednesday, Saturday at 9:00 PM",
                CardLink = "/hotlotto"
            },
            new LotteryCarouselDTO
            {
                Id = 12,
                Name = "Mega-Sena",
                LogoUrl = "megasena.png",
                Jackpot = "R$70 Million",
                DrawTime = "Every Wednesday, Saturday at 8:00 PM",
                CardLink = "/megasena"
            },
            new LotteryCarouselDTO
            {
                Id = 13,
                Name = "Powerball Australia",
                LogoUrl = "powerballaus.png",
                Jackpot = "$10 Million",
                DrawTime = "Every Thursday at 8:30 PM",
                CardLink = "/powerballaus"
            },
            new LotteryCarouselDTO
            {
                Id = 14,
                Name = "Oz Lotto",
                LogoUrl = "ozlotto.png",
                Jackpot = "$20 Million",
                DrawTime = "Every Tuesday at 8:30 PM",
                CardLink = "/ozlotto"
            },
            new LotteryCarouselDTO
            {
                Id = 15,
                Name = "SuperLotto Plus",
                LogoUrl = "superlottoplus.png",
                Jackpot = "$20 Million",
                DrawTime = "Every Wednesday, Saturday at 7:45 PM",
                CardLink = "/superlottoplus"
            },
            new LotteryCarouselDTO
            {
                Id = 16,
                Name = "Pick 3",
                LogoUrl = "pick3.png",
                Jackpot = "$500",
                DrawTime = "Every day at 10:00 PM",
                CardLink = "/pick3"
            }

        };

        public static List<LotteryResultDto> MockLotteryResults => new List<LotteryResultDto>
        {
            new LotteryResultDto
            {
                ResultDateTime = new DateTime(2025, 10, 16, 22, 0, 0),
                WinningBalls = "12, 25, 37, 48, 59, 10",
                Link1 = "/powerball/results",
                Link2 = "/how-to-play/powerball"
            },
            new LotteryResultDto
            {
                ResultDateTime = new DateTime(2025, 10, 14, 23, 0, 0),
                WinningBalls = "05, 18, 22, 36, 51, 12",
                Link1 = "/megamillions/results",
                Link2 = "/how-to-play/megamillions"
            }
        };

        // Helper method to get result by lottery ID
        public static LotteryResultDto GetResultByLotteryId(int id)
        {
            return MockLotteryResults.FirstOrDefault();
        }
    }
}
