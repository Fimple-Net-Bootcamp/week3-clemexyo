using System.ComponentModel.DataAnnotations;

namespace week3_hw.Models;

public class User
{
    public User(string name) 
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public User(string name, List<Pet> pets)
    {
        Name = name;
        Pets = pets;
        CreatedAt = DateTime.UtcNow;
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Pet>? Pets { get; set; }
}
