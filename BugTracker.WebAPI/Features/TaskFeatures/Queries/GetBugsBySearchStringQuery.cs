using System.Collections.Generic;
using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Queries;

public class GetTasksBySearchStringQuery : IRequest<IEnumerable<Task<int>>>
{
    public string SearchString { get; set; }

    public class GetTasksBySearchStringQueryHandler : IRequestHandler<
        GetTasksBySearchStringQuery, IEnumerable<Task<int>>>
    {
        private readonly ITaskService<int> _service;

        public GetTasksBySearchStringQueryHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task<int>>> Handle(
            GetTasksBySearchStringQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _service.SearchTasks(request.SearchString);
            return result;
        }
    }
}
