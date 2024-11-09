namespace Backend.Domain.Interfaces;

public interface IRegister
{
    public DateTime CreatedAt { get; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}