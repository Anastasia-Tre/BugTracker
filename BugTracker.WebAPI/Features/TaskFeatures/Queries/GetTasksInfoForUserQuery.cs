using System.Threading;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Queries;

public class GetTotalTasksForUser : IRequest<int>
{
    public int UserId { get; set; }

    public class GetTotalTasksForUserHandler : IRequestHandler<
        GetTotalTasksForUser, int>
    {
        private readonly ITaskService<int> _service;

        public GetTotalTasksForUserHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<int> Handle(
            GetTotalTasksForUser request, CancellationToken cancellationToken)
        {
            var result =
                await _service.GetTotalTasksForUser(request.UserId);
            return result;
        }
    }
}

public class GetCompleteTasksForUser : IRequest<int>
{
    public int UserId { get; set; }

    public class GetCompleteTasksForUserHandler : IRequestHandler<
        GetCompleteTasksForUser, int>
    {
        private readonly ITaskService<int> _service;

        public GetCompleteTasksForUserHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<int> Handle(
            GetCompleteTasksForUser request, CancellationToken cancellationToken)
        {
            var result =
                await _service.GetCompleteTasksForUser(request.UserId);
            return result;
        }
    }
}

public class GetUncompleteTasksForUser : IRequest<int>
{
    public int UserId { get; set; }

    public class GetUncompleteTasksForUserHandler : IRequestHandler<
        GetUncompleteTasksForUser, int>
    {
        private readonly ITaskService<int> _service;

        public GetUncompleteTasksForUserHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<int> Handle(
            GetUncompleteTasksForUser request, CancellationToken cancellationToken)
        {
            var result =
                await _service.GetUncompleteTasksForUser(request.UserId);
            return result;
        }
    }
}

public class GetOverdueTasksForUser : IRequest<int>
{
    public int UserId { get; set; }

    public class GetOverdueTasksForUserHandler : IRequestHandler<
        GetOverdueTasksForUser, int>
    {
        private readonly ITaskService<int> _service;

        public GetOverdueTasksForUserHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<int> Handle(
            GetOverdueTasksForUser request, CancellationToken cancellationToken)
        {
            var result =
                await _service.GetOverdueTasksForUser(request.UserId);
            return result;
        }
    }
}