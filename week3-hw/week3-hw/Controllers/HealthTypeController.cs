using Microsoft.AspNetCore.Mvc;
using week3_hw.Models;

namespace week3_hw.Controllers;

[ApiController]
[Route("/api/v1/healthtype")]
public class HealthTypeController : ControllerBase
{
    private readonly VirtualPetsDbContext _dbContext;
    public HealthTypeController(VirtualPetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string name)
    {
        var healthType = new HealthType(name);

        _dbContext.HealthTypes.Add(healthType);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = healthType.Id }, healthType);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var types = _dbContext.Foods.ToList();
        if (!types.Any())
        {
            return NotFound();
        }
        return Ok(types);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var healthType = _dbContext.HealthTypes.Where(x => x.Id == id).FirstOrDefault();
        if (healthType is null)
        {
            return NotFound();
        }
        return Ok(healthType);
    }
}
