using Microsoft.AspNetCore.Mvc;
using week3_hw.Models;

namespace week3_hw.Controllers;

[ApiController]
[Route("/api/v1/foods")]
public class FoodController : ControllerBase
{
    private readonly VirtualPetsDbContext _dbContext;
    public FoodController(VirtualPetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string name)
    {
        var food = new Food(name);

        _dbContext.Foods.Add(food);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = food.Id }, food);
    }

    [HttpPost("{petId}")]
    public async Task<IActionResult> Feed(int petId, [FromBody] int foodId)
    {
        var pet = _dbContext.Pets.Where(x => x.Id == petId).FirstOrDefault();
        if (pet is null)
        {
            return NotFound();
        }

        var food = _dbContext.Foods.Where(x => x.Id == foodId).FirstOrDefault();
        if (food is null)
        {
            return NotFound();
        }
        pet.Foods.Add(food);
        await _dbContext.SaveChangesAsync();

        return Ok(pet);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var foods = _dbContext.Foods.ToList();
        if (!foods.Any())
        {
            return NotFound();
        }
        return Ok(foods);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var food = _dbContext.Foods.Where(x => x.Id == id).FirstOrDefault();
        if (food is null)
        {
            return NotFound();
        }
        return Ok(food);
    }
}
