using HRApp.Application;
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
    public UsersController(IUserRepository userRepository) : base(userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("GetColleagues")]
    public async Task<IEnumerable<User>> GetColleagues()
    {
        var currentUser = (await _userRepository.Query(u => u.Active).FirstOrDefaultAsync())!;
        return await _userRepository.Query(u => u.Id != currentUser.Id && u.CompanyId == currentUser.CompanyId)
                .ToListAsync(); ;
    }

    [HttpPost("upload-avatar/{userId}")]
    public async Task<IActionResult> UploadAvatar(int userId, IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var user = await _userRepository.GetByIdAsync(userId, true);
        
        var fileData = new File
        {
            FileName = file.FileName,
            ContentType = file.ContentType
        };

        using (var memoryStream = new MemoryStream())
        {
            await file.CopyToAsync(memoryStream);
            fileData.Data = memoryStream.ToArray();
        }

        //_context.Files.Add(fileData);
        //await _context.SaveChangesAsync();

        user.AvatarFileId = fileData.Id;
        await _userRepository.UpdateAsync(user);

        return Ok(new { fileData.FileName, fileData.ContentType });
    }

}
