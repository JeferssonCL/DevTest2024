using Backend.Domain.Bases;

namespace Backend.Domain.Concretes;

public class Option : BaseEntity
{
    public Guid PoolId { get; set; }
    public string Name { get; set; }
    public Pool Pool { get; set; }
}