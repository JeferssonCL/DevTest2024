using Backend.Application.CommandQuery.CreatePoolCommands;
using Backend.Application.CommandQuery.CreateVote;
using Backend.Application.CommandQuery.GetAllPools;
using Backend.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PoolController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public ActionResult<PoolDto> CreatePool([FromBody] CreatePoolDto createPoolDto)
    {
        var response = mediator.Send(new CreatePoolCommand(createPoolDto));
        return Ok(response.Result);
    }
    
    [HttpGet]
    public ActionResult<List<PoolDto>> GetAllPools()
    {
        var response = mediator.Send(new GetAllPoolsCommand());
        return Ok(response.Result);
    }
    
    [HttpPost("{id}/votes")]
    public ActionResult<List<PoolDto>> CreateVite(Guid id, [FromBody] CreateVoteDto createVoteDto)
    {
        var response = mediator.Send(new CreateVoteCommand(id, createVoteDto));
        return Ok(response.Result);
    }
    
}