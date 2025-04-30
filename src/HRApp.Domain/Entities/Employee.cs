using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

[Table("Employees")]
public class Employee : BaseEntity
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}