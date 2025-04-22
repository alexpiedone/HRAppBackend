namespace HRApp.Domain;

[DbTable("LogEntries")]
public class LogEntry : BaseEntity
{
    public DateTime Timestamp { get; set; }
    public string Level { get; set; } = "info"; // info / error
    public string Message { get; set; } = string.Empty;
    public string CorrelationId { get; set; } = string.Empty;
    public string App { get; set; } = "HR-Frontend";
}

