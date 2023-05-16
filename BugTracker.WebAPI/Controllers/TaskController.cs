using System.Collections.Generic;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using BugTracker.WebAPI.Features.TaskFeatures.Commands;
using BugTracker.WebAPI.Features.TaskFeatures.Queries;
using BugTracker.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ThreadTasks = System.Threading.Tasks;

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
    [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> GetById(int id)
    {
        return Ok(
            await _mediator.Send(new GetTaskByIdQuery { TaskId = id }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllTasksQuery()));
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType(typeof(IEnumerable<Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> SearchTasks(
        [FromQuery] string searchString)
    {
        return Ok(await _mediator.Send(
            new GetTasksBySearchStringQuery { SearchString = searchString }));
    }

    [HttpGet]
    [Route("forUser")]
    [ProducesResponseType(typeof(IEnumerable<Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> GetTasksForUser([FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetTasksByUserQuery { UserId = userId }));
    }

    [HttpGet]
    [Route("forProject")]
    [ProducesResponseType(typeof(IEnumerable<Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> GetTasksForProject(
        [FromQuery] int projectId)
    {
        return Ok(await _mediator.Send(
            new GetTasksByProjectQuery { ProjectId = projectId }));
    }

    [HttpPut]
    [Route("assign")]
    [ProducesResponseType(typeof(Task<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> AssignTaskToUser([FromQuery] int bugId,
        int userId)
    {
        return Ok(await _mediator.Send(
            new AssignTaskToUserCommand { TaskId = bugId, UserId = userId }));
    }


    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(Task<int>),
        StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> CreateTask(Task<int> task)
    {
        var actionName = nameof(CreateTask);
        return CreatedAtAction(actionName, await _mediator.Send(
            new CreateTaskCommand
                { Task = task }));
    }

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(Task<int>),
        StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> UpdateTask(Task<int> task)
    {
        var actionName = nameof(UpdateTask);
        return CreatedAtAction(actionName, await _mediator.Send(
            new UpdateTaskCommand
                { Task = task }));
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(Task<int>),
        StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> DeleteTask(Task<int> task)
    {
        return Ok(await _mediator.Send(new DeleteTaskCommand
            { Task = task }));
    }

    [HttpGet]
    [Route("inFocus")]
    [ProducesResponseType(typeof(Task<int>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> GetTaskInFocusForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetTaskInFocusForUser { UserId = userId }));
    }

    [HttpGet]
    [Route("nowOrLater")]
    [ProducesResponseType(typeof(IEnumerable<Task<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async ThreadTasks.Task<IActionResult> GetTasksNowOrLaterForUser(
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
    public async ThreadTasks.Task<IActionResult> GetTotalTasksForUser(
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
    public async ThreadTasks.Task<IActionResult> GetCompleteTasksForUser(
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
    public async ThreadTasks.Task<IActionResult> GetUncompleteTasksForUser(
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
    public async ThreadTasks.Task<IActionResult> GetOverdueTasksForUser(
        [FromQuery] int userId)
    {
        return Ok(await _mediator.Send(
            new GetOverdueTasksForUser { UserId = userId }));
    }
}
