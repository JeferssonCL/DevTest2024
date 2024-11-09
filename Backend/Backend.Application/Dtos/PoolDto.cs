namespace Backend.Application.Dtos;

public class PoolDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<OptionDto> Options { get; set; }
}