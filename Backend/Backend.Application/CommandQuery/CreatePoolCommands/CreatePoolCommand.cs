using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.CommandQuery.CreatePoolCommands;

public class CreatePoolCommand(CreatePollDto createPollDto) : IRequest<PollDto>
{
    public CreatePollDto PollDto { get; set; } = createPollDto;
}