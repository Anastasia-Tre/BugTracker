using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.BugFeatures.Queries
{
    public class GetAllBugsQuery : IRequest<IEnumerable<Bug<int>>>
    {
        public class GetAllBugsQueryHandler : IRequestHandler<GetAllBugsQuery,
            IEnumerable<Bug<int>>>
        {
            private readonly IBugService<int> _service;

            public GetAllBugsQueryHandler(IBugService<int> service)
            {
                _service = service;
            }

            public async Task<IEnumerable<Bug<int>>> Handle(
                GetAllBugsQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.SearchBugs();
                return result;
            }
        }
    }
}
