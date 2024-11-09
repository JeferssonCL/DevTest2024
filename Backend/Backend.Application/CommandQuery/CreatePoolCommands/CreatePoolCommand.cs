using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.CommandQuery.CreatePoolCommands;

public class CreatePoolCommand(CreatePoolDto createPoolDto) : IRequest<PoolDto>
{
    public CreatePoolDto PoolDto { get; set; } = createPoolDto;
}