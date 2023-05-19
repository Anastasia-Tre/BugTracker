using System.Threading;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using MediatR;

namespace Bugify.WebAPI.Features.TaskFeatures.Commands;

public class AssignTaskToUserCommand : IRequest<Task<int>>
{
    public int TaskId { get; set; }
    public int UserId { get; set; }

    public class
        AssignTaskToUserCommandHandler : IRequestHandler<
            AssignTaskToUserCommand, Task<int>>
    {
        private readonly ITaskService<int> _service;

        public AssignTaskToUserCommandHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Task<int>> Handle(
            AssignTaskToUserCommand request,
            CancellationToken cancellationToken)
        {
            var result =
                await _service.AssignTaskToUser(request.TaskId,
                    request.UserId);
            return result;
        }
    }
}
