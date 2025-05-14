using HRApp.Application;
using HRApp.Communication;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using File = HRApp.Domain.File;

namespace HRApp.Api;


[ApiController]
[Route("api/[controller]")]
public class UsersController : GenericController<User>
{
    private readonly IUserRepository _userRepository;
    private readonly IFileRepository _fileRepository;

    public UsersController(IUserRepository userRepository, IFileRepository fileRepository) : base(userRepository)
    {
        _userRepository = userRepository;
        _fileRepository = fileRepository;
    }

    [HttpGet("GetColleagues")]
    public async Task<IEnumerable<ColleagueDto>> GetColleagues()
    {

        var users = await _userRepository.Query(u => u.Active)
            .Include(u => u.AvatarFile)
            .Include(u => u.UserResponsibilities)
                .ThenInclude(ur => ur.Responsibility)
            .Include(u => u.UserProjects)
                .ThenInclude(up => up.Project)
            .ToListAsync();
        var result = users.Select(u => new  ColleagueDto
        {
            Id = u.Id,
            Name = u.FullName, 
            Email = u.Email,
            Phone = u.Phone,
            Responsibilities = string.Join(", ", u.UserResponsibilities.Select(r => r.Responsibility.Description)),
            Avatar = u.AvatarFile?.Data != null 
                ? $"data:{u.AvatarFile.ContentType};base64,{Convert.ToBase64String(u.AvatarFile.Data)}" 
                : null,
            Projects = u.UserProjects.Select(up => up.Project.Name).ToList()
        });

        return result;
    }

  
}
