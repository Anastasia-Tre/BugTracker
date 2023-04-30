using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.ProjectFeatures.Queries;

public class GetProjectByIdQuery : IRequest<Project<int>>
{
    public int ProjectId { get; set; }

    public class
        GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery,
            Project<int>>
    {
        private readonly IProjectService<int> _service;

        public GetProjectByIdQueryHandler(IProjectService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Project<int>> Handle(
            GetProjectByIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = await _service.GetProjectById(request.ProjectId);
            return result;
        }
    }
}
