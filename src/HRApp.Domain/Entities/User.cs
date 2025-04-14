namespace HRApp.Domain;


[DbTable("Users")]
public class User : BaseEntity
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;

    public UserRole Role { get; set; } = UserRole.Employee;
    public bool IsActive { get; set; } = true;
    
    public ICollection<Request> Requests { get; set; } = new List<Request>();
    public ICollection<Notification> Notifications { get; set; } = new List<Notification>();
}

public enum UserRole
{
    Admin,
    Manager,
    Employee
}