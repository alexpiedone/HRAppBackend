namespace HRApp.Domain;


[DbTable("Notifications")]
public class Notification : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;

    public NotificationType Type { get; set; } = NotificationType.Info;
    public bool IsRead { get; set; } = false;

}

public enum NotificationType
{
    Info,
    Warning,
    Success,
    Error
}