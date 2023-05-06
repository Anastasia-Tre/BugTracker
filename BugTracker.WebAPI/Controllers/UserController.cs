using System.Collections.Generic;
using BugTracker.DataModel;
using BugTracker.WebAPI.Features.UserFeatures.Commands;
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
    public async System.Threading.Tasks.Task<IActionResult> GetById(int id)
    {
        return Ok(
            await _mediator.Send(new GetUserByIdQuery { UserId = id }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<User<int>>),
        StatusCodes.Status200OK)]
    public async System.Threading.Tasks.Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllUsersQuery()));
    }


    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(User<int>), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> CreateUser(
        User<int> user)
    {
        var actionName = nameof(CreateUser);
        return CreatedAtAction(actionName, await _mediator.Send(new CreateUserCommand
            { User = user }));
    }

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(User<int>), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> UpdateUser(
        User<int> user)
    {
        var actionName = nameof(UpdateUser);
        return CreatedAtAction(actionName, await _mediator.Send(new UpdateUserCommand
            { User = user }));
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(User<int>), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> DeleteUser(
        User<int> user)
    {
        return Ok(await _mediator.Send(new DeleteUserCommand
            { User = user }));
    }
}
