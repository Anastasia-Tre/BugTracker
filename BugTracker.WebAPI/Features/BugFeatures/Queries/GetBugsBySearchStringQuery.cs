using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.BugFeatures.Queries
{
    public class GetBugsBySearchStringQuery : IRequest<IEnumerable<Bug<int>>>
    {
        public string SearchString { get; set; }

        public class GetBugsBySearchStringQueryHandler : IRequestHandler<GetBugsBySearchStringQuery, IEnumerable<Bug<int>>>
        {
            private readonly IBugService<int> _service;

            public GetBugsBySearchStringQueryHandler(IBugService<int> service)
            {
                _service = service;
            }

            public async Task<IEnumerable<Bug<int>>> Handle(GetBugsBySearchStringQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.SearchBugs(request.SearchString);
                return result;
            }
        }
    }
}
