using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;
using System.Threading;

namespace BugTracker.WebAPI.Features.TaskFeatures.Commands;

public class DeleteTaskCommand : IRequest<Task<int>>
{
    public Task<int> Task { get; set; }

    public class
        DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand,
            Task<int>>
    {
        private readonly ITaskService<int> _service;

        public DeleteTaskCommandHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Task<int>> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteTask(request.Task);
            return result;
        }
    }
}
