using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<UserEntity<int>>> GetAllUsers()
        {
            return await _entities.ToListAsync();
        }
    }
}
