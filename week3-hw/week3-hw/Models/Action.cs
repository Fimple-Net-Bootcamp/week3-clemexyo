using System.ComponentModel.DataAnnotations;

namespace week3_hw.Models;

public class Action
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
}
