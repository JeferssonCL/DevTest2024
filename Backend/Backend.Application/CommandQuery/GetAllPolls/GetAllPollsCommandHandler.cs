using Backend.Application.Dtos;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.CommandQuery.GetAllPolls;

public class GetAllPollsCommandHandler(IRepository<Poll> poolRepository,
    IRepository<Vote> voteRepository,
    IRepository<Option> optionRepository) : IRequestHandler<GetAllPollsCommand, List<PollDto>>
{
    public Task<List<PollDto>> Handle(GetAllPollsCommand request, CancellationToken cancellationToken)
    {
        var poolDtos = new List<PollDto>();
        var pools = poolRepository.GetAll().Result.ToList();

        foreach (var pool in pools)
        {
            var optionsDtos = new List<OptionDto>();
            var options = optionRepository.GetAll().Result.Where(x => x.PoolId == pool.Id).ToList();
            foreach (var option in options)
            {
                var count =  voteRepository.GetAll().Result.Count(v => v.OptionId == option.Id);
                optionsDtos.Add(new OptionDto
                {
                    Id = option.Id,
                    Name = option.Name,
                    votes = count
                });
            }
            poolDtos.Add(new PollDto
            {
                Id = pool.Id,
                Name = pool.Name,
                Options = optionsDtos
            });
        } return Task.FromResult(poolDtos);
    }
}