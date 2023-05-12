using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.WebAPI.Features.TaskFeatures.Commands;
using BugTracker.WebAPI.Features.TaskFeatures.Queries;
using BugTracker.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
[TypeFilter(typeof(ExceptionFilter))]
public class TaskController : ControllerBase
{
    private readonly IMediator _mediator;

    public TaskController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(DataModel.Task<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(
            await _mediator.Send(new GetTaskByIdQuery { TaskId = id }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DataModel.Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllTasksQuery()));
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType(typeof(IEnumerable<DataModel.Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> SearchTasks(
        [FromQuery] string searchString)
    {
        return Ok(await _mediator.Send(
            new GetTasksBySearchStringQuery { SearchString = searchString }));
    }

    [HttpGet]
    [Route("forUser")]
    [ProducesResponseType(typeof(IEnumerable<DataModel.Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetTasksForUser([FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetTasksByUserQuery { UserId = userId }));
    }

    [HttpGet]
    [Route("forProject")]
    [ProducesResponseType(typeof(IEnumerable<DataModel.Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetTasksForProject(
        [FromQuery] int projectId)
    {
        return Ok(await _mediator.Send(
            new GetTasksByProjectQuery { ProjectId = projectId }));
    }

    [HttpPut]
    [Route("assign")]
    [ProducesResponseType(typeof(DataModel.Task<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> AssignTaskToUser([FromQuery] int bugId,
        int userId)
    {
        return Ok(await _mediator.Send(
            new AssignTaskToUserCommand { TaskId = bugId, UserId = userId }));
    }


    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(DataModel.Task<int>),
        StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> CreateTask(DataModel.Task<int> task)
    {
        var actionName = nameof(CreateTask);
        return CreatedAtAction(actionName, await _mediator.Send(
            new CreateTaskCommand
                { Task = task }));
    }

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(DataModel.Task<int>),
        StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateTask(DataModel.Task<int> task)
    {
        var actionName = nameof(UpdateTask);
        return CreatedAtAction(actionName, await _mediator.Send(
            new UpdateTaskCommand
                { Task = task }));
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(DataModel.Task<int>),
        StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteTask(DataModel.Task<int> task)
    {
        return Ok(await _mediator.Send(new DeleteTaskCommand
            { Task = task }));
    }

    [HttpGet]
    [Route("inFocus")]
    [ProducesResponseType(typeof(DataModel.Task<int>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetTaskInFocusForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetTaskInFocusForUser { UserId = userId }));
    }

    [HttpGet]
    [Route("nowOrLater")]
    [ProducesResponseType(typeof(IEnumerable<DataModel.Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetTasksNowOrLaterForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetTasksNowOrLaterForUser { UserId = userId }));
    }

    [HttpGet]
    [Route("total")]
    [ProducesResponseType(typeof(int),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetTotalTasksForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetTotalTasksForUser { UserId = userId }));
    }

    [HttpGet]
    [Route("complete")]
    [ProducesResponseType(typeof(int),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetCompleteTasksForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetCompleteTasksForUser { UserId = userId }));
    }

    [HttpGet]
    [Route("uncomplete")]
    [ProducesResponseType(typeof(int),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetUncompleteTasksForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetUncompleteTasksForUser { UserId = userId }));
    }

    [HttpGet]
    [Route("overdue")]
    [ProducesResponseType(typeof(int),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> GetOverdueTasksForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetOverdueTasksForUser { UserId = userId }));
    }
}
