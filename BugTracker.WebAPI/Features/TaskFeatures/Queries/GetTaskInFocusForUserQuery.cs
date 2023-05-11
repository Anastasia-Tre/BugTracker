using System.Collections.Generic;
using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Queries;

public class GetTaskInFocusForUser : IRequest<Task<int>>
{
    public int UserId { get; set; }

    public class GetTaskInFocusForUserHandler : IRequestHandler<
        GetTaskInFocusForUser, Task<int>>
    {
        private readonly ITaskService<int> _service;

        public GetTaskInFocusForUserHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Task<int>> Handle(
            GetTaskInFocusForUser request, CancellationToken cancellationToken)
        {
            var result =
                await _service.GetTaskInFocusForUser(request.UserId);
            return result;
        }
    }
}
