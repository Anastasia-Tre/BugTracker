using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<User<int>>
    {
        public int UserId { get; set; }

        public class
            GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery,
                User<int>>
        {
            private readonly IUserService<int> _service;

            public GetUserByIdQueryHandler(IUserService<int> service)
            {
                _service = service;
            }

            public async Task<User<int>> Handle(GetUserByIdQuery request,
                CancellationToken cancellationToken)
            {
                var result = await _service.GetUserById(request.UserId);
                return result;
            }
        }
    }
}
