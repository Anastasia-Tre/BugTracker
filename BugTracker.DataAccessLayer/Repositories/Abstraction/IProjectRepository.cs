using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface
        IProjectRepository<TKey> : IRepository<ProjectEntity<TKey>, TKey>
    {
        public Task<IEnumerable<ProjectEntity<int>>>
            Search(string searchString);
    }
}
