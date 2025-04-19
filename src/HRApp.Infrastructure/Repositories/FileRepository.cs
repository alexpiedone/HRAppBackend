using HRApp.Application;

namespace HRApp.Infrastructure;

public class FileRepository : BaseRepository<Domain.File>, IFileRepository
{
    public FileRepository(AppDbContext context) : base(context)
    {
    }
}
