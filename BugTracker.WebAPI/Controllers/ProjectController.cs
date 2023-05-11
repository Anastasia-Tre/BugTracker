using System.Collections.Generic;
using BugTracker.DataModel;
using BugTracker.WebAPI.Features.ProjectFeatures.Commands;
using BugTracker.WebAPI.Features.ProjectFeatures.Queries;
using BugTracker.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers;

[Route("/[controller]")]
[ApiController]
[TypeFilter(typeof(ExceptionFilter))]
public class ProjectController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Project<int>), StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> GetById(int id)
    {
        return Ok(await _mediator.Send(new GetProjectByIdQuery
            { ProjectId = id }));
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Project<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> GetAll()
    {
        return Ok(await _mediator.Send(new GetAllProjectsQuery()));
    }

    [HttpGet]
    [Route("search")]
    [ProducesResponseType(typeof(IEnumerable<Project<int>>),
        StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> SearchProjects(
        [FromQuery] string searchString)
    {
        return Ok(await _mediator.Send(new GetProjectsBySearchString
            { SearchString = searchString }));
    }

    [HttpPost]
    [Route("create")]
    [ProducesResponseType(typeof(Project<int>), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> CreateProject(
        Project<int> project)
    {
        var actionName = nameof(CreateProject);
        return CreatedAtAction(actionName, await _mediator.Send(
            new CreateProjectCommand
                { Project = project }));
    }

    [HttpPost]
    [Route("{id}")]
    [ProducesResponseType(typeof(Project<int>), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> UpdateProject(
        Project<int> project)
    {
        var actionName = nameof(UpdateProject);
        return CreatedAtAction(actionName, await _mediator.Send(
            new UpdateProjectCommand
                { Project = project }));
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(typeof(Project<int>), StatusCodes.Status201Created)]
    [ProducesDefaultResponseType]
    public async System.Threading.Tasks.Task<IActionResult> DeleteProject(
        Project<int> project)
    {
        return Ok(await _mediator.Send(new DeleteProjectCommand
            { Project = project }));
    }
}
