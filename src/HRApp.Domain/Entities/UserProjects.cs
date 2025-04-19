namespace HRApp.Domain;

[DbTable("UserProjects")]
public class UserProject : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; }

    public int ProjectId { get; set; }
    public Project Project { get; set; }
}
