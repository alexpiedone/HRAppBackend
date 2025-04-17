using HRApp.Application;
using HRApp.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HRApp.Api;

/// <summary>
/// Controller generic care implementeaza CRUD pentru entitati.
/// </summary>
/// <typeparam name="T">Trebuie sa mosteneasca BaseEntity</typeparam>
public abstract class GenericController<T> : ControllerBase
    where T : BaseEntity
{
    private readonly IBaseRepository<T> _repository;
    protected GenericController(IBaseRepository<T> repository)
    {
        _repository = repository;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult<IEnumerable<T>>> GetAll()
    {
        var items = await _repository.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("GetById/{id}")]
    public async Task<ActionResult<T>> GetById(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpPost("Create")]
    public async Task<ActionResult<T>> Create([FromBody] T item)
    {
        await _repository.AddAsync(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }

    [HttpPut("Update/{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] T item)
    {
        if (id != item.Id)
            return BadRequest();

        await _repository.UpdateAsync(item);
        return NoContent();
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
            return NotFound();
        item.Active = false;
        await _repository.UpdateAsync(item);
        return NoContent();
    }
}
