using BugTracker.Services.Abstraction;
using BugTracker.WebAPI.Model.Command.Project;
using BugTracker.WebAPI.Model.Response.Project;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService<int> _projectService;

        public ProjectController(IProjectService<int> projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status200OK)]
        public IActionResult GetById([FromQuery] GetProjectCommand command)
        {
            var result = _projectService.GetProjectById(command.ProjectId);
            return Ok(new ProjectResponse { Project = result });
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(ProjectResponse), StatusCodes.Status200OK)]
        public IActionResult SearchProjects([FromQuery] SearchProjectsCommand command)
        {
            var result = _projectService.SearchProjects(command.SearchString);
            return Ok(new ProjectsResponse { Projects = result });
        }
    }
}
