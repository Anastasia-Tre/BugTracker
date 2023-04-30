using System.Collections.Generic;
using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Queries;

public class GetTasksByProjectQuery : IRequest<IEnumerable<Task<int>>>
{
    public int ProjectId { get; set; }

    public class GetTasksByProjectQueryHandler : IRequestHandler<
        GetTasksByProjectQuery, IEnumerable<Task<int>>>
    {
        private readonly ITaskService<int> _service;

        public GetTasksByProjectQueryHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task<int>>> Handle(
            GetTasksByProjectQuery request,
            CancellationToken cancellationToken)
        {
            var result =
                await _service.GetTasksForProject(request.ProjectId);
            return result;
        }
    }
}
