using week3_hw.Models;

namespace week3_hw.Requests;

public record UpdateUserRequest
(
    string Name,
    List<Pet>? Pets
);
