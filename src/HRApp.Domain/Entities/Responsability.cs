using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

[Table("Responsabilities")]
public class Responsability : BaseEntity
{
    public string Description { get; set; } = string.Empty;
}
