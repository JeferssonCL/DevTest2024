using Backend.Application.Dtos;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.CommandQuery.CreateVote;

public class CreateVoteCommandHandler(IRepository<Pool> poolRepository,
    IRepository<Vote> voteRepository,
    IRepository<Option> optionRepository) : IRequestHandler<CreateVoteCommand, VoteDto>
{
    public async Task<VoteDto> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
    {
        var voteDto = request.Vote;

        var option = optionRepository.GetByIdAsync(voteDto.OptionId);
        if (option == null) throw new KeyNotFoundException();
        
        var pool = poolRepository.GetByIdAsync(request.PollId);
        if (pool == null) throw new KeyNotFoundException();
        
        var vote = await voteRepository.AddAsync(new Vote
        {
            OptionId = voteDto.OptionId,
            VoterEmail = voteDto.Email
        });
        return new VoteDto
        {
            Id = vote.Id,
            PoolId = pool.Result.Id,
            OptionId = option.Result.Id,
            Email = voteDto.Email,
        };
    }
}