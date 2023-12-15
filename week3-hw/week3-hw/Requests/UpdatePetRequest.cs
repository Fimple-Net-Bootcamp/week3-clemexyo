using week3_hw.Models;

namespace week3_hw.Requests;

public record UpdatePetRequest
(
     string Name,
     HealthType? HealthType,
     List<Activity>? Activities,
     DateTime CreatedAt,
     List<Food>? Foods
);
