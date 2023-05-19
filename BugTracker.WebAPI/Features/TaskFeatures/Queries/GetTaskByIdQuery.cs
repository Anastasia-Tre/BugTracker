using System.Threading;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using MediatR;

namespace Bugify.WebAPI.Features.TaskFeatures.Queries;

public class GetTaskByIdQuery : IRequest<Task<int>>
{
    public int TaskId { get; set; }

    public class
        GetTaskByIdQueryHandler : IRequestHandler<GetTaskByIdQuery, Task<int>>
    {
        private readonly ITaskService<int> _service;

        public GetTaskByIdQueryHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Task<int>> Handle(
            GetTaskByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _service.GetTaskById(request.TaskId);
            return result;
        }
    }
}
