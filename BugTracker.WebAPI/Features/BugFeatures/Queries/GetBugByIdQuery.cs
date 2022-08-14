using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.BugFeatures.Queries
{
    public class GetBugByIdQuery : IRequest<Bug<int>>
    {
        public int BugId { get; set; }

        public class
            GetBugByIdQueryHandler : IRequestHandler<GetBugByIdQuery, Bug<int>>
        {
            private readonly IBugService<int> _service;

            public GetBugByIdQueryHandler(IBugService<int> service)
            {
                _service = service;
            }

            public async Task<Bug<int>> Handle(GetBugByIdQuery request,
                CancellationToken cancellationToken)
            {
                var result = await _service.GetBugById(request.BugId);
                return result;
            }
        }
    }
}
