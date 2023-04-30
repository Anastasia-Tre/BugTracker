using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction;

public interface IBugRepository<TKey> : IRepository<BugEntity<TKey>, TKey>
{
    public Task<IEnumerable<BugEntity<TKey>>> Search(string searchString);

    public Task<IEnumerable<BugEntity<TKey>>> GetBugsForProject(
        TKey projectId);

    public Task<IEnumerable<BugEntity<TKey>>> GetBugsForUser(TKey userId);
}
