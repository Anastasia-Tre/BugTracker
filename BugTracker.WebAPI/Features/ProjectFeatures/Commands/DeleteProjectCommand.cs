using System.Threading;
using Bugify.Domain.AggregatesModel.ProjectAggregate;
using MediatR;

namespace BugTracker.WebAPI.Features.ProjectFeatures.Commands;

public class DeleteProjectCommand : IRequest<Project<int>>
{
    public Project<int> Project { get; set; }

    public class
        DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand,
            Project<int>>
    {
        private readonly IProjectService<int> _service;

        public DeleteProjectCommandHandler(IProjectService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Project<int>> Handle(
            DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.DeleteProject(request.Project);
            return result;
        }
    }
}
