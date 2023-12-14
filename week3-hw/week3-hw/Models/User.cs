namespace week3_hw.Models;

public class User : Entity<int>
{
    public User(string name) 
    {
        Name = name;
        CreatedAt = DateTime.Now;
    }
    public string Name { get; set; }
    public List<Pet>? Pets { get; set; }
}
