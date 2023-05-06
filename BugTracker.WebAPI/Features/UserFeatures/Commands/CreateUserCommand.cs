using BugTracker.DataModel;
using MediatR;
using System.Threading;
using BugTracker.Services.Abstraction;

namespace BugTracker.WebAPI.Features.UserFeatures.Commands;

public class CreateUserCommand : IRequest<User<int>>
{
    public User<int> User { get; set; }

    public class
        CreateUserCommandHandler : IRequestHandler<CreateUserCommand,
            User<int>>
    {
        private readonly IUserService<int> _service;

        public CreateUserCommandHandler(IUserService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<User<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateUser(request.User);
            return result;
        }
    }
}
