using HRApp.Domain;

namespace HRApp.Application;

public interface ILeaveRequestRepository : IBaseRepository<LeaveRequest>
{
    Task<List<LeaveRequest>> GetPendingRequestsByUserIdAsync(Guid userId);
}