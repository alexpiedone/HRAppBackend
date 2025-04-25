using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRApp.Domain;


[DbTable("Lottery")]
public class Lottery : BaseEntity
{

    [Required]
    public string Name { get; set; }

    public string LogoUrl { get; set; } 
    public string Jackpot { get; set; }
    public DateTime DrawTime { get; set; }

    public string CardLink { get; set; }

    public virtual ICollection<LotteryResult> Results { get; set; }
}