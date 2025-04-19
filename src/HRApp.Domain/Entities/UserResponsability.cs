namespace HRApp.Domain;

[DbTable("UserResponsabilities")]
public class UserResponsibility : BaseEntity
{
    public int UserId { get; set; }

    public User? User { get; set; }

    public int ResponsibilityId { get; set; }

    public Responsability? Responsibility { get; set; }
}
