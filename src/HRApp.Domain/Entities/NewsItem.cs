using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;


[Table("NewsItems")]
public class NewsItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public NewsCategory Category { get; set; }

    public int AuthorId { get; set; }

    public bool isPrincipal { get; set; } = false;


}

public enum NewsCategory
{
    Announcement,
    Update,
    Event,
    General
}