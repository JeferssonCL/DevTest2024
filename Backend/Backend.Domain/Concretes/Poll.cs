using Backend.Domain.Bases;

namespace Backend.Domain.Concretes;

public class Poll : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Option> Options { get; set; }
}