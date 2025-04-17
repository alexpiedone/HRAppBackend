using HRApp.Application;
using HRApp.Domain;

namespace HRApp.Infrastructure;

public class DocumentRepository : BaseRepository<Document>, IDocumentRepository
{
    public DocumentRepository(AppDbContext context) : base(context)
    {
    }
}
