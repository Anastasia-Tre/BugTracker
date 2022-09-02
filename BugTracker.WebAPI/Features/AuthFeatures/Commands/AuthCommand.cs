using System;
using System.Threading;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.DataModel.Exceptions;
using BugTracker.Services.Abstraction;
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
            private readonly ITokenGenerator _tokenGenerator;
            private readonly IIdentityService _identityService;

            public AuthCommandHandler(IIdentityService identityService, ITokenGenerator tokenGenerator)
            {
                _identityService = identityService;
                _tokenGenerator = tokenGenerator;
            }

            public async Task<User<int>> Handle(AuthCommand request, CancellationToken cancellationToken)
            {
                var result = await _identityService.SigninUserAsync(
                    request.Username, request.Password);

                if (!result)
                {
                    throw new BadRequestException(
                        "Invalid username or password");
                }

                throw new NotImplementedException();
            }
        }
    }
}
