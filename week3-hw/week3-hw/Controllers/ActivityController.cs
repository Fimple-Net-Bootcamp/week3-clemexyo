using Microsoft.AspNetCore.Mvc;
using week3_hw.Models;

namespace week3_hw.Controllers;

[ApiController]
[Route("/api/v1/activities")]
public class ActivityController : ControllerBase
{
    private readonly VirtualPetsDbContext _dbContext;
    public ActivityController(VirtualPetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string name)
    {
        var action = new Activity(name);

        _dbContext.Activities.Add(action);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = action.Id }, action);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var action = _dbContext.Activities.Where(x => x.Id == id).FirstOrDefault();
        if (action is null)
        {
            return NotFound();
        }
        return Ok(action);
    }
}
