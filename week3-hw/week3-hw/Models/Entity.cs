using System.ComponentModel.DataAnnotations;

namespace week3_hw.Models;

public abstract class Entity<T>
{
    [Key]
    public T Id { get; set;  }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
}
