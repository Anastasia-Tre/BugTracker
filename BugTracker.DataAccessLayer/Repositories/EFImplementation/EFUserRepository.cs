using System.Collections.Generic;
using System.Threading.Tasks;
using Bugify.Domain.AggregatesModel.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace Bugify.Infrastructure.Repositories.EFImplementation;

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
