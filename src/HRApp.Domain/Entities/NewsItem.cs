using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;


[Table("NewsItems")]
public class NewsItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

}