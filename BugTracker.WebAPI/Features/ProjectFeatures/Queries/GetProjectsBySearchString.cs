using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.ProjectFeatures.Queries
{
    public class GetProjectsBySearchString : IRequest<IEnumerable<Project<int>>>
    {
        public string SearchString;

        public class
            GetProjectsBySearchStringHandler : IRequestHandler<
                GetProjectsBySearchString,
                IEnumerable<Project<int>>>
        {
            private readonly IProjectService<int> _service;

            public GetProjectsBySearchStringHandler(
                IProjectService<int> service)
            {
                _service = service;
            }

            public async Task<IEnumerable<Project<int>>> Handle(
                GetProjectsBySearchString request,
                CancellationToken cancellationToken)
            {
                var result =
                    await _service.SearchProjects(request.SearchString);
                return result;
            }
        }
    }
}
