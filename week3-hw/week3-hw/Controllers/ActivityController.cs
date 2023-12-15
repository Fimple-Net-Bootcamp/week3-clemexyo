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

    [HttpGet("/activity/{petId}")]
    public IActionResult GetPetActivities(int petId)
    {
        var pet = _dbContext.Pets.Where(x => x.Id == petId).FirstOrDefault();
        if (pet is null)
        {
            return NotFound();
        }
        return Ok(pet.Activities);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var activity = _dbContext.Activities.Where(x => x.Id == id).FirstOrDefault();
        if (activity is null)
        {
            return NotFound();
        }
        return Ok(activity);
    }
}
