using HRApp.Application;
using HRApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Infrastructure;

public class LeaveRequestRepository : Repository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(AppDbContext context) : base(context) {}

    public async Task<List<LeaveRequest>> GetPendingRequestsByUserIdAsync(Guid userId)
    {
        return await _dbSet
            .Where(r => r.UserId == userId && r.Status == RequestStatus.Pending)
            .ToListAsync();
    }
}