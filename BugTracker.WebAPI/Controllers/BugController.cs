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
    }
}
