using Microsoft.AspNetCore.Mvc;
using week3_hw.Models;
using week3_hw.Requests;

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
    public IActionResult GetById(int petId)
    {
        var pet = _dbContext.Pets.Where(x => x.Id == petId).FirstOrDefault();
        if (pet is null)
        {
            return NotFound();
        }
        return Ok(pet.HealthType);
    }

    [HttpPatch("{petId}")]
    public async Task<IActionResult> UpdatePetHealthType(int petId, UpdatePetHealthTypeRequest request)
    {
        var pet = _dbContext.Pets.Where(x => x.Id == petId).FirstOrDefault();
        if (pet is null)
        {
            return NotFound();
        }

        pet.HealthType = request.HealthType;   
        await _dbContext.SaveChangesAsync();
        return Ok(pet.HealthType);
    }
}
