namespace Backend.Application.Dtos;

public class CreatePollDto
{
    public string Name { get; set; }
    public List<CreateOptionDto> Options{ get; set; }
}