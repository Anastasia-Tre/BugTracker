using System.Threading;
using Bugify.Domain.AggregatesModel.ProjectAggregate;
using MediatR;

namespace Bugify.WebAPI.Features.ProjectFeatures.Commands;

public class CreateProjectCommand : IRequest<Project<int>>
{
    public Project<int> Project { get; set; }

    public class
        CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand,
            Project<int>>
    {
        private readonly IProjectService<int> _service;

        public CreateProjectCommandHandler(IProjectService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Project<int>> Handle(
            CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateProject(request.Project);
            return result;
        }
    }
}
