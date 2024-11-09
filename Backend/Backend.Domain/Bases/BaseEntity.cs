using Backend.Domain.Interfaces;

namespace Backend.Domain.Bases;

public class BaseEntity : BaseRegister, IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } =  true;
}