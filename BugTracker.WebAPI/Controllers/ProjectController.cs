using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetById(
            [FromQuery] GetProjectCommand command)
        {
            try
            {
                var result =
                    await _projectService.GetProjectById(command.ProjectId);
                return Ok(new ProjectResponse { Project = result });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(ProjectsResponse),
            StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery] SearchProjectsCommand command)
        {
            try
            {
                var result =
                    await _projectService.SearchProjects(command.SearchString);
                return Ok(new ProjectsResponse { Projects = result });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(ProjectsResponse),
            StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchProjects(
            [FromQuery] SearchProjectsCommand command)
        {
            try
            {
                var result =
                    await _projectService.SearchProjects(command.SearchString);
                return Ok(new ProjectsResponse { Projects = result });
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }
    }
}
