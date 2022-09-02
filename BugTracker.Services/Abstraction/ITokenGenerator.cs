using System.Collections.Generic;

namespace BugTracker.Services.Abstraction
{
    public interface ITokenGenerator
    {
        public string GenerateJWTToken(
            (string userId, string username, IList<string> roles) userDetails);
    }
}
