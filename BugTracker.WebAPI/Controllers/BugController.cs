using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BugTracker.Services.Abstraction;
using BugTracker.WebAPI.Model.Command.Bug;
using BugTracker.WebAPI.Model.Response.Bug;

namespace BugTracker.WebAPI.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult GetById([FromQuery] GetBugCommand command)
        {
            var result = _bugService.GetBugById(command.BugId);
            return Ok(new BugResponse() { Bug = result });
        }

        [HttpGet]
        [Route("/all")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] SearchBugsCommand command)
        {
            var result = _bugService.SearchBugs(command.SearchString);
            return Ok(new BugsResponse() { Bugs = result });
        }

        [HttpGet]
        [Route("/search")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public IActionResult SearchBugs([FromQuery] SearchBugsCommand command)
        {
            var result = _bugService.SearchBugs(command.SearchString);
            return Ok(new BugsResponse() { Bugs = result });
        }

        [HttpGet]
        [Route("/forUser")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public IActionResult GetBugsForUser([FromQuery] GetBugsForUserCommand command)
        {
            var result = _bugService.GetBugsForUser(command.UserId);
            return Ok(new BugsResponse() { Bugs = result });
        }

        [HttpGet]
        [Route("/forProject")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public IActionResult GetBugsForProject([FromQuery] GetBugsForProjectCommand command)
        {
            var result = _bugService.GetBugsForProject(command.ProjectId);
            return Ok(new BugsResponse() { Bugs = result });
        }

        [HttpPut]
        [Route("/assign")]
        [ProducesResponseType(typeof(BugsResponse), StatusCodes.Status200OK)]
        public IActionResult AssignBugToUser([FromQuery] AssignBugToUserCommand command)
        {
            //var result = _bugService.AssignBugToUser(command.BugId, command.UserId);
            return Ok();
        }
    }
}
