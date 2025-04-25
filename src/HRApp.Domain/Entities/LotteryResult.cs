namespace HRApp.Domain;

[DbTable("LotteryResult")]
public class LotteryResult : BaseEntity
{
    public int LotteryId { get; set; }

    public virtual Lottery Lottery { get; set; }

    public DateTime ResultDateTime { get; set; }

    public string WinningBalls { get; set; } 

    public string Link1 { get; set; }

    public string Link2 { get; set; }
}
