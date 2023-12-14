﻿using System.ComponentModel.DataAnnotations;

namespace week3_hw.Models;

public class Pet
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public HealthType HealthType { get; set; }
    public List<Action> Actions { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<Food> Foods { get; set; }
}
