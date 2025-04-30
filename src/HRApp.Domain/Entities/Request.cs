using System.ComponentModel.DataAnnotations.Schema;

namespace HRApp.Domain;


[Table("Requests")]
public abstract class Request : BaseEntity
{
    public RequestStatus Status { get; set; } = RequestStatus.Draft;
    public string? Comment { get; set; }

    public int UserId { get; set; }

}

public enum RequestStatus
{
    Draft,
    Submitted,
    Approved,
    Rejected,
    Cancelled,
    Pending
}