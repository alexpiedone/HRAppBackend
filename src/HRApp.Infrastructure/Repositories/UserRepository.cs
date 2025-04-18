using HRApp.Application;
using HRApp.Domain;

namespace HRApp.Infrastructure;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
