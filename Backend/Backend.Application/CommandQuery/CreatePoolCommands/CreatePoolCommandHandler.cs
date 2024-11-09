using Backend.Application.Dtos;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using FluentValidation;
using MediatR;

namespace Backend.Application.CommandQuery.CreatePoolCommands;

public class CreatePoolCommandHandler(
    IValidator<CreatePoolDto> validator,
    IRepository<Pool> poolRepository,
    IRepository<Vote> voteRepository,
    IRepository<Option> optionRepository) : IRequestHandler<CreatePoolCommand, PoolDto>
{
    public async Task<PoolDto> Handle(CreatePoolCommand request, CancellationToken cancellationToken)
    {
        var createPoolDto = request.PoolDto;
        var response = await validator.ValidateAsync(createPoolDto, cancellationToken);
        if (!response.IsValid) 
            throw new ValidationException(response.Errors);
        
        var options = new List<OptionDto>();

        var pool = new Pool
        {
            Name = createPoolDto.Name
        };

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
        
        await poolRepository.AddAsync(pool);
        return new PoolDto
        {
            Id = pool.Id,
            Name = pool.Name,
            Options = options
        };
    }
}