using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;

[Table("Events")]
public class Event : BaseEntity
{
    [Required]
    public string Title { get; set; } 

    [Required]
    public string Description { get; set; }

    [Required]
    public DateTime Date { get; set; }

    public string Location { get; set; } 
    public string Duration { get; set; } 
    public int? ImageId { get; set; }
}
