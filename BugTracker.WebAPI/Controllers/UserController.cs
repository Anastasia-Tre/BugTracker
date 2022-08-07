using System;
using System.Threading.Tasks;
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
        public async Task<ActionResult<UserResponse>> GetById([FromQuery] GetUserCommand command)
        {
            try
            {
                var result = await _userService.GetUserById(command.UserId);
                //return Ok(new UserResponse { User = result });
                return Ok(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return NotFound(e.Message);
            }
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
