using System.ComponentModel.DataAnnotations;

namespace week3_hw.Models;

public class Pet
{
    public Pet(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public HealthType? HealthType { get; set; }
    public List<Food>? Actions { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Food>? Foods { get; set; }
}
