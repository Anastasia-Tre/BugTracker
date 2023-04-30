using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.WebAPI.Features.UserFeatures.Queries;
using BugTracker.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
[TypeFilter(typeof(ExceptionFilter))]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(User<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(
            await _mediator.Send(new GetUserByIdQuery { UserId = id }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<User<int>>),
        StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllUsersQuery()));
    }
}
