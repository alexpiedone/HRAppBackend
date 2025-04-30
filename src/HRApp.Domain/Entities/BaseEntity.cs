using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HRApp.Domain;

public class BaseEntity
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public bool Active { get; set; } = true;
}
