using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

[Table("Companies")]
public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
