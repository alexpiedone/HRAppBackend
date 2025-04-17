using HRApp.Domain;

namespace HRApp.Application;

public interface ILeaveRequestRepository : IRepository<LeaveRequest>
{
    Task<List<LeaveRequest>> GetPendingRequestsByUserIdAsync(Guid userId);
}