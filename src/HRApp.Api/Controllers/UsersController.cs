using HRApp.Application;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HRApp.Api;


[ApiController]
[Route("api/[controller]")]
public class UsersController : GenericController<User>
{
    private readonly IUserRepository _userRepository;
    public UsersController(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> GetColleagues()
    {
        var currentUser = (await _userRepository.Query(u=>u.Active).FirstOrDefaultAsync())!;
        return await _userRepository.Query(u => u.Id != currentUser.Id && u.CompanyId == currentUser.CompanyId)
                .ToListAsync();;
    }
}
