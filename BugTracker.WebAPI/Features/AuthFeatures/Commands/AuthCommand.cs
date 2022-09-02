using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using MediatR;

namespace BugTracker.WebAPI.Features.AuthFeatures.Commands
{
    public class AuthCommand : IRequest<User<int>>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public class
            AuthCommandHandler : IRequestHandler<AuthCommand, User<int>>
        {
            public Task<User<int>> Handle(AuthCommand request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
