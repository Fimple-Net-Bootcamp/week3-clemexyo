using Microsoft.AspNetCore.Mvc;
using week3_hw.Models;

namespace week3_hw.Controllers;

[ApiController]
[Route("/api/v1/actions")]
public class ActionController : ControllerBase
{
    private readonly VirtualPetsDbContext _dbContext;
    public ActionController(VirtualPetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string name)
    {
        var action = new Models.Food(name);

        _dbContext.Actions.Add(action);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = action.Id }, action);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var action = _dbContext.Actions.Where(x => x.Id == id).FirstOrDefault();
        if (action is null)
        {
            return NotFound();
        }
        return Ok(action);
    }
}
