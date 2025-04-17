namespace HRApp.Domain;

[DbTable("Trainings")]
public class Training : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Location { get; set; } = string.Empty;

    public bool IsMandatory { get; set; } = false;
    public bool TestBoolean { get; set; } = false;

    public bool AnotherBoolean { get; set; } = false;

    public ICollection<User> Participants { get; set; } = new List<User>();
}
