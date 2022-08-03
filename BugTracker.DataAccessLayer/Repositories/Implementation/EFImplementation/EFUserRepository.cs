using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation
{
    public class EFUserRepository<TKey> : EFGenericRepository<UserEntity<TKey>, TKey>, IUserRepository<TKey>
    {
        public EFUserRepository(BugTrackerDbContext<TKey> dbContext) : base(dbContext, dbContext.Users)
        {
        }
    }
}
