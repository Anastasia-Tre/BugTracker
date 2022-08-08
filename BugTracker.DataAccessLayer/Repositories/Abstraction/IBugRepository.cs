using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface IBugRepository<TKey> : IRepository<BugEntity<TKey>, TKey>
    {
        public Task<IEnumerable<BugEntity<int>>> Search(string searchString);

        public Task<IEnumerable<BugEntity<int>>> GetBugsForProject(
            TKey projectId);

        public Task<IEnumerable<BugEntity<int>>> GetBugsForUser(TKey userId);
    }
}
