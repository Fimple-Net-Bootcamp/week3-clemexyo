using Microsoft.AspNetCore.Mvc;
using week3_hw.Models;

namespace week3_hw.Controllers;

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
