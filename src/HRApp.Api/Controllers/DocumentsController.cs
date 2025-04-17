using HRApp.Application;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Api;

[ApiController]
[Route("api/[controller]")]
public class DocumentsController : GenericController<Document>
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentsController(IDocumentRepository documentRepository)
        : base(documentRepository)
    {
        _documentRepository = documentRepository;
    }
}
