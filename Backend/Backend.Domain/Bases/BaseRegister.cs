using Backend.Domain.Interfaces;

namespace Backend.Domain.Bases;

public class BaseRegister : IRegister
{
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}