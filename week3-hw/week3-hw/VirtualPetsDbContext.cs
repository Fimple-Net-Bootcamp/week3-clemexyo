namespace week3_hw;
using Microsoft.EntityFrameworkCore;
using week3_hw.Models;

public class VirtualPetsDbContext : DbContext
{
    public VirtualPetsDbContext(DbContextOptions<VirtualPetsDbContext> options) : base(options)
    {

    }
    public DbSet<Action> Actions { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<HealthType> HealthTypes { get; set; }
    public DbSet<Pet> Pets { get; set; }
    public DbSet<User> Users { get; set; }
    
}
