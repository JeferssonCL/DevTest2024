using System.Data;
using Backend.Application.Dtos;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using MediatR;

namespace Backend.Application.CommandQuery.CreateVote;

public class CreateVoteCommandHandler(IValidator<CreateVoteDto> validator,
    IRepository<Poll> poolRepository,
    IRepository<Vote> voteRepository,
    IRepository<Option> optionRepository) : IRequestHandler<CreateVoteCommand, VoteDto>
{
    public async Task<VoteDto> Handle(CreateVoteCommand request, CancellationToken cancellationToken)
    {
        var voteDto = request.Vote;
        var response = await validator.ValidateAsync(voteDto, cancellationToken);
        if (!response.IsValid) 
            throw new ValidationException(response.Errors);
        
        var option = await optionRepository.GetByIdAsync(voteDto.OptionId);
        if (option == null) throw new KeyNotFoundException();
        
        var pool = await poolRepository.GetByIdAsync(request.PollId);
        if (pool == null) throw new KeyNotFoundException();
        
        var votes = voteRepository.GetAll().Result.Where(e => e.VoterEmail == voteDto.Email);
        if (votes.Any()) throw new DuplicateNameException();
        
        var vote = await voteRepository.AddAsync(new Vote
        {
            OptionId = voteDto.OptionId,
            VoterEmail = voteDto.Email
        });
        
        return new VoteDto
        {
            Id = vote.Id,
            PoolId = pool.Id,
            OptionId = option.Id,
            Email = voteDto.Email,
        };
    }
}