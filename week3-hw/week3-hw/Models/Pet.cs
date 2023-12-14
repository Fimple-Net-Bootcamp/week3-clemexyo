namespace week3_hw.Models;

public class Pet : Entity<int>
{
    public string Name { get; set; }
    public HealthType HealthType { get; set; }
    public List<Action> Actions { get; set; }
    public List<Food> Foods { get; set; }
}
