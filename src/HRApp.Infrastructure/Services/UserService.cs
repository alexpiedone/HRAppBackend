using HRApp.Application;
using HRApp.Communication;

namespace HRApp.Infrastructure;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IFileRepository _fileRepository;

    public UserService(IUserRepository userRepository, IFileRepository fileRepository)
    {
        _userRepository = userRepository;
        _fileRepository = fileRepository;
    }

    public Task<IEnumerable<ColleagueDto>> GetColleaguesAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CurrentSalaryDto?> GetCurrentSalaryAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserDocumentDto>> GetEmploymentDocumentsAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<RoleInfoDto?> GetRoleInfoAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<UserHierarchyDto?> GetUserHierarchyAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<UserProjectDto>> GetUserProjectsAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
