using System.Collections.Generic;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface IBugRepository<TKey> : IRepository<BugEntity<TKey>, TKey>
    {
        public IEnumerable<BugEntity<TKey>> Search(string searchString);
        public IEnumerable<BugEntity<TKey>> GetBugsForProject(TKey projectId);
        public IEnumerable<BugEntity<TKey>> GetBugsForUser(TKey userId);
    }
}
