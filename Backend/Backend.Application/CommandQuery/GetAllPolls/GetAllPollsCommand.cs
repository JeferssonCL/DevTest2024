using Backend.Application.Dtos;
using MediatR;

namespace Backend.Application.CommandQuery.GetAllPolls;

public class GetAllPollsCommand : IRequest<List<PollDto>>;