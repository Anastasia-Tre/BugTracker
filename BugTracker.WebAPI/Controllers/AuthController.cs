using System.Threading.Tasks;
using BugTracker.WebAPI.Features.AuthFeatures.Commands;
using BugTracker.WebAPI.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BugTracker.WebAPI.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionFilter))]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesDefaultResponseType]
        public async Task<IActionResult> Login([FromBody] AuthCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
