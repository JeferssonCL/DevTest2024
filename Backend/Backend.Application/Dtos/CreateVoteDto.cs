namespace Backend.Application.Dtos;

public class CreateVoteDto
{
    public Guid OptionId { get; set; }
    public string Email { get; set; }
}