using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRApp.Domain;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    [DefaultValue("getdate()")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool Active { get; set; } = true;
}
