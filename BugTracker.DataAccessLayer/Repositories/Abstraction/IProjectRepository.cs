using System.Collections.Generic;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface
        IProjectRepository<TKey> : IRepository<ProjectEntity<TKey>, TKey>
    {
        public IEnumerable<ProjectEntity<TKey>> Search(string searchString);
    }
}
