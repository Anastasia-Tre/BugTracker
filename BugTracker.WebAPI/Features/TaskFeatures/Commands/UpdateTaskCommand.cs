using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;
using System.Threading;

namespace BugTracker.WebAPI.Features.TaskFeatures.Commands;

public class UpdateTaskCommand : IRequest<Task<int>>
{
    public Task<int> Task { get; set; }

    public class
        UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand,
            Task<int>>
    {
        private readonly ITaskService<int> _service;

        public UpdateTaskCommandHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Task<int>> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateTask(request.Task);
            return result;
        }
    }
}
