using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.BugFeatures.Queries;

public class GetBugsByProjectQuery : IRequest<IEnumerable<Bug<int>>>
{
    public int ProjectId { get; set; }

    public class GetBugsByProjectQueryHandler : IRequestHandler<
        GetBugsByProjectQuery, IEnumerable<Bug<int>>>
    {
        private readonly IBugService<int> _service;

        public GetBugsByProjectQueryHandler(IBugService<int> service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Bug<int>>> Handle(
            GetBugsByProjectQuery request,
            CancellationToken cancellationToken)
        {
            var result =
                await _service.GetBugsForProject(request.ProjectId);
            return result;
        }
    }
}
