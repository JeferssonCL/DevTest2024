namespace Backend.Application.Dtos;

public class PollDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<OptionDto> Options { get; set; }
}