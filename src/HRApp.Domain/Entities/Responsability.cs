namespace HRApp.Domain;

[DbTable("Responsabilities")]
public class Responsability : BaseEntity
{
    public string Description { get; set; } = string.Empty; 
}
