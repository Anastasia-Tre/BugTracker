using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.UserFeatures.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User<int>>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery,
            IEnumerable<User<int>>>
        {
            private readonly IUserService<int> _service;

            public GetAllUsersQueryHandler(IUserService<int> service)
            {
                _service = service;
            }

            public async Task<IEnumerable<User<int>>> Handle(
                GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var result = await _service.GetAllUsers();
                return result;
            }
        }
    }
}
