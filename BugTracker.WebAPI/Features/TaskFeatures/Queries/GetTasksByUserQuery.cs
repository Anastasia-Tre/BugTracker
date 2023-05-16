using System.Collections.Generic;
using System.Threading;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Queries;

public class GetTasksByUserQuery : IRequest<IEnumerable<Task<int>>>
{
    public int UserId { get; set; }

    public class GetTasksByUserQueryHandler : IRequestHandler<
        GetTasksByUserQuery, IEnumerable<Task<int>>>
    {
        private readonly ITaskService<int> _service;

        public GetTasksByUserQueryHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<IEnumerable<Task<int>>> Handle(
            GetTasksByUserQuery request, CancellationToken cancellationToken)
        {
            var result =
                await _service.GetTasksForUser(request.UserId);
            return result;
        }
    }
}
