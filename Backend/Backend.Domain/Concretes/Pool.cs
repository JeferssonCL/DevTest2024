using Backend.Domain.Bases;

namespace Backend.Domain.Concretes;

public class Pool : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Option> Options { get; set; }
}