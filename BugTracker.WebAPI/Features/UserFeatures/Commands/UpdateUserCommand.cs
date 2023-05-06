using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;
using System.Threading;

namespace BugTracker.WebAPI.Features.UserFeatures.Commands;

public class UpdateUserCommand : IRequest<User<int>>
{
    public User<int> User { get; set; }

    public class
        UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,
            User<int>>
    {
        private readonly IUserService<int> _service;

        public UpdateUserCommandHandler(IUserService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<User<int>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateUser(request.User);
            return result;
        }
    }
}
