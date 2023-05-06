using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;
using System.Threading;

namespace BugTracker.WebAPI.Features.UserFeatures.Commands;

public class DeleteUserCommand : IRequest<User<int>>
{
    public User<int> User { get; set; }

    public class
        DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,
            User<int>>
    {
        private readonly IUserService<int> _service;

        public DeleteUserCommandHandler(IUserService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<User<int>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteUser(request.User);
            return result;
        }
    }
}
