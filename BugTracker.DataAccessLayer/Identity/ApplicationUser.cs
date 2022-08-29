using Microsoft.AspNetCore.Identity;

namespace BugTracker.DataAccessLayer.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
