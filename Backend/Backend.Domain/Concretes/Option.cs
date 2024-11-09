using Backend.Domain.Bases;

namespace Backend.Domain.Concretes;

public class Option : BaseEntity
{
    public Guid PoolId { get; set; }
    public string Name { get; set; }
    public Poll Poll { get; set; }
    public ICollection<Vote> Votes { get; set; }

}