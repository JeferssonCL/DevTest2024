using Backend.Application.CommandQuery.CreatePoolCommands;
using Backend.Application.CommandQuery.CreateVote;
using Backend.Application.CommandQuery.GetAllPolls;
using Backend.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PollController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public ActionResult<PollDto> CreatePool([FromBody] CreatePollDto createPollDto)
    {
        var response = mediator.Send(new CreatePoolCommand(createPollDto));
        return Ok(response.Result);
    }
    
    [HttpGet]
    public ActionResult<List<PollDto>> GetAllPools()
    {
        var response = mediator.Send(new GetAllPollsCommand());
        return Ok(response.Result);
    }
    
    [HttpPost("{id}/votes")]
    public ActionResult<List<PollDto>> CreateVite(Guid id, [FromBody] CreateVoteDto createVoteDto)
    {
        var response = mediator.Send(new CreateVoteCommand(id, createVoteDto));
        return Ok(response.Result);
    }
    
}