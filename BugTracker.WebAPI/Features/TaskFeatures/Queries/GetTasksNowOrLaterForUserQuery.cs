using System.Collections.Generic;
using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Queries;

public class GetTasksNowOrLaterForUser : IRequest<IEnumerable<Task<int>>>
{
    public int UserId { get; set; }

    public class GetTasksNowOrLaterForUserHandler : IRequestHandler<
        GetTasksNowOrLaterForUser, IEnumerable<Task<int>>>
    {
        private readonly ITaskService<int> _service;

        public GetTasksNowOrLaterForUserHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task<int>>> Handle(
            GetTasksNowOrLaterForUser request,
            CancellationToken cancellationToken)
        {
            var result =
                await _service.GetTasksNowOrLaterForUser(request.UserId);
            return result;
        }
    }
}
