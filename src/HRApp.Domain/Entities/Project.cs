using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

[Table("Projects")]
public class Project : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }  
    public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
}
