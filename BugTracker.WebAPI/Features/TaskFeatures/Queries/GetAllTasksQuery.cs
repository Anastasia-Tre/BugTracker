using System.Collections.Generic;
using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Queries;

public class GetAllTasksQuery : IRequest<IEnumerable<Task<int>>>
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery,
        IEnumerable<Task<int>>>
    {
        private readonly ITaskService<int> _service;

        public GetAllTasksQueryHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task<int>>> Handle(
            GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.SearchTasks();
            return result;
        }
    }
}
