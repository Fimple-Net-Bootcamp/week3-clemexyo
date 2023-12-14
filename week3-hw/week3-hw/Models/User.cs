namespace week3_hw.Models;

public class User : Entity<int>
{
    public string Name { get; set; }
    public List<Pet>? Pets { get; set; }
}
