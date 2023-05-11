using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.ProjectFeatures.Commands;

public class UpdateProjectCommand : IRequest<Project<int>>
{
    public Project<int> Project { get; set; }

    public class
        UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand,
            Project<int>>
    {
        private readonly IProjectService<int> _service;

        public UpdateProjectCommandHandler(IProjectService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Project<int>> Handle(
            UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.UpdateProject(request.Project);
            return result;
        }
    }
}
