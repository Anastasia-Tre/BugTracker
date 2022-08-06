using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.
    EFImplementation
{
    public class EFUserRepository : EFRepository<UserEntity<int>>,
        IUserRepository<int>
    {
        public EFUserRepository(BugTrackerDbContext dbContext) : base(dbContext,
            dbContext.Users)
        {
        }
    }
}
