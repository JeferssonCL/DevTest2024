using Backend.Domain.Bases;

namespace Backend.Domain.Concretes;

public class Vote : BaseEntity
{
   public Guid OptionId { get; set; }
   public string VoterEmail { get; set; }
   public Option Option { get; set; }
}