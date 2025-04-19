namespace HRApp.Domain;


[DbTable("Users")]
public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    
    public string Phone { get; set; } = string.Empty;

     public int? AvatarFileId { get; set; }
    public File? AvatarFile { get; set; }

    public int CompanyId { get; set; }
    public Company? Company { get; set; }
    
    public ICollection<UserProject> UserProjects { get; set; } = [];
    public ICollection<Project> Projects { get; set; } = [];
    
    public ICollection<Responsability> Responsabilities { get; set; } = [];

    public ICollection<Request> Requests { get; set; } = [];

    public ICollection<Notification> Notifications { get; set; } = [];
}

public enum UserRole
{
    Admin,
    Manager,
    Employee
}