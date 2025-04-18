namespace HRApp.Domain;

[DbTable("UserResponsabilities")]
public class UserResponsibility : BaseEntity
{
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid ResponsibilityId { get; set; }
    public Responsability? Responsibility { get; set; }
}
