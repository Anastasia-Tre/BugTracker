using System;
using System.Threading.Tasks;
using BugTracker.Services.Abstraction;
using BugTracker.WebAPI.Model.Command.Bug;
using BugTracker.WebAPI.Model.Response.Bug;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private readonly IBugService<int> _bugService;

        public BugController(IBugService<int> bugService)
        {
            _bugService = bugService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(BugResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetById([FromQuery] GetBugCommand command)
        {
            try
            {
                var result = await _bugService.GetBugById(command.BugId);
                return Ok(new BugResponse { Bug = result });
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll([FromQuery] SearchBugsCommand command)
        {
            try
            {
                var result = await _bugService.SearchBugs(command.SearchString);
                return Ok(new BugsResponse { Bugs = result });
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("search")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchBugs([FromQuery] SearchBugsCommand command)
        {
            try
            {
                var result = await _bugService.SearchBugs(command.SearchString);
                return Ok(new BugsResponse { Bugs = result });
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("forUser")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBugsForUser(
            [FromQuery] GetBugsForUserCommand command)
        {
            try
            {
                var result = await _bugService.GetBugsForUser(command.UserId);
                return Ok(new BugsResponse { Bugs = result });
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpGet]
        [Route("forProject")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetBugsForProject(
            [FromQuery] GetBugsForProjectCommand command)
        {
            try
            {
                var result = await _bugService.GetBugsForProject(command.ProjectId);
                return Ok(new BugsResponse { Bugs = result });
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }

        [HttpPut]
        [Route("assign")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AssignBugToUser(
            [FromQuery] AssignBugToUserCommand command)
        {
            try
            {
                var result = await _bugService.AssignBugToUser(command.BugId, command.UserId);
                return Ok(new BugResponse { Bug = result });
            } 
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
        }
    }
}
