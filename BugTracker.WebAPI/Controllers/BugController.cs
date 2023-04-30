using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.WebAPI.Features.BugFeatures.Commands;
using BugTracker.WebAPI.Features.BugFeatures.Queries;
using BugTracker.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
[TypeFilter(typeof(ExceptionFilter))]
public class BugController : ControllerBase
{
    private readonly IMediator _mediator;

    public BugController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Bug<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(
            await _mediator.Send(new GetBugByIdQuery { BugId = id }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Bug<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllBugsQuery()));
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType(typeof(IEnumerable<Bug<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> SearchBugs(
        [FromQuery] string searchString)
    {
        return Ok(await _mediator.Send(
            new GetBugsBySearchStringQuery { SearchString = searchString }));
    }

    [HttpGet]
    [Route("forUser")]
    [ProducesResponseType(typeof(IEnumerable<Bug<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetBugsForUser([FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetBugsByUserQuery { UserId = userId }));
    }

    [HttpGet]
    [Route("forProject")]
    [ProducesResponseType(typeof(IEnumerable<Bug<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetBugsForProject(
        [FromQuery] int projectId)
    {
        return Ok(await _mediator.Send(
            new GetBugsByProjectQuery { ProjectId = projectId }));
    }

    [HttpPut]
    [Route("assign")]
    [ProducesResponseType(typeof(Bug<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> AssignBugToUser([FromQuery] int bugId,
        int userId)
    {
        return Ok(await _mediator.Send(
            new AssignBugToUserCommand { BugId = bugId, UserId = userId }));
    }
}
