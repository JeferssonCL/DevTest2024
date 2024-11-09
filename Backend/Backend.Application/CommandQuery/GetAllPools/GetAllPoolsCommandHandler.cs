using Backend.Application.Dtos;
using Backend.Domain.Concretes;
using Backend.Infrastructure.Repositories.Interfaces;
using MediatR;

namespace Backend.Application.CommandQuery.GetAllPools;

public class GetAllPoolsCommandHandler(IRepository<Pool> poolRepository,
    IRepository<Vote> voteRepository,
    IRepository<Option> optionRepository) : IRequestHandler<GetAllPoolsCommand, List<PoolDto>>
{
    public Task<List<PoolDto>> Handle(GetAllPoolsCommand request, CancellationToken cancellationToken)
    {
        var poolDtos = new List<PoolDto>();
        var pools = poolRepository.GetAll().Result.ToList();
        Console.WriteLine(pools.Count);

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
            poolDtos.Add(new PoolDto
            {
                Id = pool.Id,
                Name = pool.Name,
                Options = optionsDtos
            });
        } return Task.FromResult(poolDtos);
    }
}