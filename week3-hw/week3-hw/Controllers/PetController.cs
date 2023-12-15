using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using week3_hw.Models;
using week3_hw.Requests;

namespace week3_hw.Controllers;

[ApiController]
[Route("/api/v1/pets")]
public class PetController : ControllerBase
{
    private readonly VirtualPetsDbContext _dbContext;
    public PetController(VirtualPetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string name)
    {
        var pet = new Pet(name);

        _dbContext.Pets.Add(pet);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var pet = _dbContext.Pets.Where(x => x.Id == id).FirstOrDefault();
        if (pet is null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var pets = _dbContext.Pets.ToList();
        if (!pets.Any())
        {
            return NotFound();
        }
        return Ok(pets);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdatePetRequest request)
    {
        var updated = new Pet(request.Name, request.HealthType, request.Activities, request.Foods);
        var current = _dbContext.Pets.Where(x => x.Id == id).FirstOrDefault();
        if (current is null)
        {
            return NotFound();
        }
        current = updated;

        await _dbContext.SaveChangesAsync();
        return Ok(current);
    }
}
