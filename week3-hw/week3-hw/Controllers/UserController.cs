using Microsoft.AspNetCore.Mvc;
using week3_hw.Models;
using week3_hw.Services.UserService;


namespace week3_hw.Controllers;

[ApiController]
[Route("/api/v1/users")]
public class UserController : ControllerBase
{
    private readonly VirtualPetsDbContext _dbContext;
    public UserController(VirtualPetsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] string name)
    {
        User user = new User(name);

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        if(user is null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, string userName)
    {
        var current = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        if (current is null)
        {
            return NotFound();
        }
        current.UpdatedAt = DateTime.Now;
        current.Name = userName;

        await _dbContext.SaveChangesAsync();
        return Ok(current);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var current = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        if (current is null)
        {
            return NotFound();
        }
        
        _dbContext.Users.Remove(current);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}
