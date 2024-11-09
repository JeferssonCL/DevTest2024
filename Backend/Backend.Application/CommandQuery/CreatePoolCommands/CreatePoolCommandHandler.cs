using Backend.Application.Dtos;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using MediatR;

namespace Backend.Application.CommandQuery.CreatePoolCommands;

public class CreatePoolCommandHandler(
    IValidator<CreatePollDto> validator,
    IRepository<Poll> poolRepository,
    IRepository<Vote> voteRepository,
    IRepository<Option> optionRepository) : IRequestHandler<CreatePoolCommand, PollDto>
{
    public async Task<PollDto> Handle(CreatePoolCommand request, CancellationToken cancellationToken)
    {
        var createPoolDto = request.PollDto;
        var response = await validator.ValidateAsync(createPoolDto, cancellationToken);
        if (!response.IsValid) 
            throw new ValidationException(response.Errors);
        
        var options = new List<OptionDto>();

        var pool = new Poll
        {
            Name = createPoolDto.Name
        };
        
        await poolRepository.AddAsync(pool);

        foreach (var option in createPoolDto.Options)
        {
            var optionToAdd = await optionRepository.AddAsync(new Option
            {
                PoolId = pool.Id,
                Name = option.Name
            });
            var count =  voteRepository.GetAll().Result.Count(v => v.OptionId == optionToAdd.Id);
            options.Add(new OptionDto
            {
                Id = optionToAdd.Id,
                Name = optionToAdd.Name,
                votes = count
            });
        }
        return new PollDto
        {
            Id = pool.Id,
            Name = pool.Name,
            Options = options
        };
    }
}