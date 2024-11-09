namespace Backend.Application.Dtos;

public class VoteDto
{
    public Guid Id { get; set; }
    public Guid PoolId { get; set; }
    public Guid OptionId { get; set; }
    public string Email { get; set; }
}