using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

[Table("UserResponsabilities")]
public class UserResponsibility : BaseEntity
{
    public int UserId { get; set; }

    public User? User { get; set; }

    public int ResponsibilityId { get; set; }

    public Responsability? Responsibility { get; set; }
}
