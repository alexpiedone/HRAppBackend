using HRApp.Communication;

namespace HRApp.Application;

public interface IUserService
{
    Task<IEnumerable<ColleagueDto>> GetColleaguesAsync();
    //Task<object?> UploadAvatarAsync(int userId, IFormFile file);
    Task<RoleInfoDto?> GetRoleInfoAsync(int userId);
    Task<IEnumerable<UserProjectDto>> GetUserProjectsAsync(int userId);
    Task<IEnumerable<UserDocumentDto>> GetEmploymentDocumentsAsync(int userId);
    Task<CurrentSalaryDto?> GetCurrentSalaryAsync(int userId);
    Task<UserHierarchyDto?> GetUserHierarchyAsync(int userId);
}
