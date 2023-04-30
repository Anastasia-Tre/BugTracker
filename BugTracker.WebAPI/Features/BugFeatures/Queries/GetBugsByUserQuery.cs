using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.BugFeatures.Queries;

public class GetBugsByUserQuery : IRequest<IEnumerable<Bug<int>>>
{
    public int UserId { get; set; }

    public class GetBugsByUserQueryHandler : IRequestHandler<
        GetBugsByUserQuery, IEnumerable<Bug<int>>>
    {
        private readonly IBugService<int> _service;

        public GetBugsByUserQueryHandler(IBugService<int> service)
        {
            _service = service;
        }

        public async Task<IEnumerable<Bug<int>>> Handle(
            GetBugsByUserQuery request, CancellationToken cancellationToken)
        {
            var result =
                await _service.GetBugsForUser(request.UserId);
            return result;
        }
    }
}
