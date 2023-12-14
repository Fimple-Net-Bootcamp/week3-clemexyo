using System.ComponentModel.DataAnnotations;

namespace week3_hw.Models;

public class Food 
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}
