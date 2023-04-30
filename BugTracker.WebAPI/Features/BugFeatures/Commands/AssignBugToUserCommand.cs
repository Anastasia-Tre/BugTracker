using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.BugFeatures.Commands;

public class AssignBugToUserCommand : IRequest<Bug<int>>
{
    public int BugId { get; set; }
    public int UserId { get; set; }

    public class
        AssignBugToUserCommandHandler : IRequestHandler<
            AssignBugToUserCommand, Bug<int>>
    {
        private readonly IBugService<int> _service;

        public AssignBugToUserCommandHandler(IBugService<int> service)
        {
            _service = service;
        }

        public async Task<Bug<int>> Handle(AssignBugToUserCommand request,
            CancellationToken cancellationToken)
        {
            var result =
                await _service.AssignBugToUser(request.BugId,
                    request.UserId);
            return result;
        }
    }
}
