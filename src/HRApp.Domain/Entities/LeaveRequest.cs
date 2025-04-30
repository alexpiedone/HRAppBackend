using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;


[Table("LeaveRequests")]
public class LeaveRequest : Request
{
    public LeaveType LeaveType { get; set; } = LeaveType.Paid;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public string? Reason { get; set; }
    public bool RequiresApproval { get; set; } = true;
}


public enum LeaveType
{
    Paid,
    Unpaid,
    Sick,
    Maternity,
    Paternity,
    Study,
    Other
}