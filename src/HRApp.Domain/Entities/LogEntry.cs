namespace HRApp.Domain;

[DbTable("LogEntries")]
public class LogEntry : BaseEntity
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    public string Actor { get; set; } 
    
    public string Action { get; set; } 
    
    public string Context { get; set; } 
    
    public TimeSpan Duration { get; set; } 
    
    public string StatusCode { get; set; } 
    
    public bool Success { get; set; }
    
    public string ErrorMessage { get; set; } 
    
    public string AdditionalData { get; set; } 
}

