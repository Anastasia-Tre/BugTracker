using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.ProjectFeatures.Queries
{
    public class GetAllProjectsQuery : IRequest<IEnumerable<Project<int>>>
    {
        public class
            GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery,
                IEnumerable<Project<int>>>
        {
            private readonly IProjectService<int> _service;

            public GetAllProjectsQueryHandler(IProjectService<int> service)
            {
                _service = service;
            }

            public async Task<IEnumerable<Project<int>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.SearchProjects();
                return result;
            }
        }
    }
}
