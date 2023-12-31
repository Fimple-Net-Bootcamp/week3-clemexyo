﻿using System.ComponentModel.DataAnnotations;

namespace week3_hw.Models;

public class Pet
{
    public Pet(string name)
    {
        Name = name;
        CreatedAt = DateTime.UtcNow;
    }

    public Pet(string name, HealthType? healthType, List<Activity>? activities, List<Food>? foods) : this(name)
    {
        HealthType = healthType;
        Activities = activities;
        Foods = foods;
        CreatedAt = DateTime.UtcNow;
    }

    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public HealthType? HealthType { get; set; }
    public List<Activity>? Activities { get; set; } = new List<Activity>();
    public DateTime CreatedAt { get; set; }
    public List<Food>? Foods { get; set; } = new List<Food>();
}
