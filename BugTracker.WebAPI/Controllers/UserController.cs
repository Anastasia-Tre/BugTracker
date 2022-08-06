using BugTracker.Services.Abstraction;
using BugTracker.WebAPI.Model.Command.User;
using BugTracker.WebAPI.Model.Response.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService<int> _userService;

        public UserController(IUserService<int> userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public IActionResult GetById([FromQuery] GetUserCommand command)
        {
            var result = _userService.GetUserById(command.UserId);
            return Ok(new UserResponse { User = result });
        }

        [HttpGet]
        [Route("all")]
        [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
        public IActionResult GetAll([FromQuery] GetAllUsersCommand command)
        {
            var result = _userService.GetAllUsers();
            return Ok(new UsersResponse { Users = result });
        }
    }
}
