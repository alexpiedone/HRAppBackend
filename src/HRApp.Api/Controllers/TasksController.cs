using HRApp.Application;
using HRApp.Domain;
using HRApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Api;

[ApiController]
[Route("api/[controller]")]
public class TasksController : GenericController<TaskItem>
{
    private readonly IBaseRepository<TaskItem> _baseRepo;

    public TasksController(IBaseRepository<TaskItem> baseRepo)
        : base(baseRepo)
    {
        _baseRepo = baseRepo;
    }

}


[ApiController]
[Route("api/[controller]")]
public class TaskActionsController : GenericController<TaskAction>
{
    private readonly IBaseRepository<TaskAction> _baseRepo;

    public TaskActionsController(IBaseRepository<TaskAction> baseRepo)
        : base(baseRepo)
    {
        _baseRepo = baseRepo;
    }

}