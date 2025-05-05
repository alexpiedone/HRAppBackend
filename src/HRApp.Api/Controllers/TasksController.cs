using HRApp.Application;
using HRApp.Domain;
using HRApp.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

    [HttpGet("GetAllDTO")]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<TaskItem>>> GetAllDTO()
    {
        var items = await _baseRepo
            .Query(a => a.Active).Include(n => n.Action)
            .ToListAsync();

        var result = items.Select(n => new TaskDTO
        {
            Name = n.Name,
            Description = n.Description,
            Status = n.Status.ToString(),
            Priority = n.Priority,
            Action = new TaskActionDTO
            {
                Type = n.Action.Type.ToString(),
                Url = n.Action.Url
            }
        });

        return Ok(result);
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