using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.WebAPI.Features.ProjectFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetProjectByIdQuery
                { ProjectId = id }));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Project<int>>),
            StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllProjectsQuery()));
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(IEnumerable<Project<int>>),
            StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SearchProjects(
            [FromQuery] string searchString)
        {
            return Ok(await _mediator.Send(new GetProjectsBySearchString
                { SearchString = searchString }));
        }
    }
}
