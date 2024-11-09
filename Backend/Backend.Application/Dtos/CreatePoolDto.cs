namespace Backend.Application.Dtos;

public class CreatePoolDto
{
    public string Name { get; set; }
    public List<CreateOptionDto> Options{ get; set; }
}