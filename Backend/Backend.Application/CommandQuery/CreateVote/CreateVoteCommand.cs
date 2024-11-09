using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.CommandQuery.CreateVote;

public class CreateVoteCommand(Guid pollId, CreateVoteDto createVoteDto) : IRequest<VoteDto>
{
    public Guid PollId { get; set; } = pollId;
    public CreateVoteDto Vote { get; set; } = createVoteDto;
}