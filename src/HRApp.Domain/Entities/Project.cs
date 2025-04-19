using System.ComponentModel.DataAnnotations;

namespace HRApp.Domain;

[DbTable("Projects")]
public class Project : BaseEntity
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }  
    public ICollection<UserProject> UserProjects { get; set; } = new List<UserProject>();
}
