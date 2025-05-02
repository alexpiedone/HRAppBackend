using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HRApp.Domain;

[Table("Tasks")]
public class TaskItem : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
    public DateTime DueDate { get; set; }
    public int Priority { get; set; }

    public int UserAssignedId { get; set; }

    public TaskAction? Action { get; set; }
}

[Table("TaskActions")]
public class TaskAction
{
    [Key]
    [ForeignKey("TaskItem")]
    public int TaskId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Type { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Url { get; set; }
    
    [MaxLength(200)]
    public string? ApiEndpoint { get; set; }
    
    [MaxLength(50)]
    public string? ButtonText { get; set; }
    
    public TaskItem? TaskItem { get; set; }
}

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed,
    OnHold
}