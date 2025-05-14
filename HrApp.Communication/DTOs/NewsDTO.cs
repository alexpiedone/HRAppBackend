namespace HRApp.Communication;

public class NewsItemDto
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }
    public AuthorDto Author { get; set; }
    public bool IsFeatured { get; set; }
    public string ImageUrl { get; set; }
    public ActionDto Action { get; set; }
}

public class AuthorDto
{
    public string Name { get; set; }
    public string Initials { get; set; }
    public string Color { get; set; }
}

public class ActionDto
{
    public string Type { get; set; }
    public string Url { get; set; }
}