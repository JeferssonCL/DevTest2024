using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.CommandQuery.GetAllPools;

public class GetAllPoolsCommand : IRequest<List<PoolDto>>;