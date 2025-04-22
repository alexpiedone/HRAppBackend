using HRApp.Application;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Api;

[ApiController]
[Route("api/[controller]")]
public class CompaniesController : GenericController<Company>
{
    private readonly IBaseRepository<Company> _baseRepository;

    public CompaniesController(IBaseRepository<Company> baserepo)
        : base(baserepo)
    {
        _baseRepository = baserepo;
    }
}

[ApiController]
[Route("api/[controller]")]
public class ResponsabilitiesController : GenericController<Responsability>
{
    private readonly IBaseRepository<Responsability> _baseRepository;

    public ResponsabilitiesController(IBaseRepository<Responsability> baserepo)
        : base(baserepo)
    {
        _baseRepository = baserepo;
    }
}

[ApiController]
[Route("api/[controller]")]
public class UserResponsabilitiesController : GenericController<UserResponsibility>
{
    private readonly IBaseRepository<UserResponsibility> _baseRepository;

    public UserResponsabilitiesController(IBaseRepository<UserResponsibility> baserepo)
        : base(baserepo)
    {
        _baseRepository = baserepo;
    }
}

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : GenericController<Project>
{
    public ProjectsController(IBaseRepository<Project> baserepo) : base(baserepo) { }
}

[ApiController]
[Route("api/[controller]")]
public class UserProjectsController : GenericController<UserProject>
{
    public UserProjectsController(IBaseRepository<UserProject> baserepo) : base(baserepo) { }
}

[ApiController]
[Route("api/[controller]")]
public class FilesController : GenericController<Project>
{
    public FilesController(IBaseRepository<Project> baserepo) : base(baserepo) { }
}

[ApiController]
[Route("api/[controller]")]
public class LogsController : GenericController<LogEntry>
{
    public LogsController(IBaseRepository<LogEntry> baserepo) : base(baserepo) { }
}

