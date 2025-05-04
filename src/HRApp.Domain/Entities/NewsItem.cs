using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;


[Table("NewsItems")]
public class NewsItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    public int CategoryId { get; set; }

    [ForeignKey("CategoryId")]
    public NewsCategoryItem? Category { get; set; } = new NewsCategoryItem();

    public int AuthorId { get; set; }
    
    [ForeignKey("AuthorId")]
    public virtual User? Author { get; set; } 

    public bool isPrincipal { get; set; } = false;
}

[Table("NewsCategories")]
public class NewsCategoryItem : BaseEntity
{
    public string Name { get; set; }
}

public enum NewsCategory
{
    Announcement,
    Update,
    Event,
    General
}


public class NewsCategoryItemConfiguration : IEntityTypeConfiguration<NewsCategoryItem>
{
    public void Configure(EntityTypeBuilder<NewsCategoryItem> builder)
    {
        builder.HasData
        (
            new NewsCategoryItem
            {
                Id = 1,
                Name = NewsCategory.Announcement.ToString()
            },
            new NewsCategoryItem
            {
                Id = 2,
                Name = NewsCategory.Update.ToString()
            },
            new NewsCategoryItem
            {
                Id = 3,
                Name = NewsCategory.Event.ToString()
            },
            new NewsCategoryItem
            {
                Id = 4,
                Name = NewsCategory.General.ToString()
            }
        );
    }
}
