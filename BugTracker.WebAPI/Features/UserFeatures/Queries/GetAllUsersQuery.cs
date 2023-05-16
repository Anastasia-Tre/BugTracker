using System.Collections.Generic;
using System.Threading;
using Bugify.Domain.AggregatesModel.UserAggregate;
using MediatR;

namespace BugTracker.WebAPI.Features.UserFeatures.Queries;

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

        public async System.Threading.Tasks.Task<IEnumerable<User<int>>> Handle(
            GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetAllUsers();
            return result;
        }
    }
}
