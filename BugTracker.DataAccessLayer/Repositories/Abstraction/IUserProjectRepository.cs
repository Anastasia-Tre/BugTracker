using System.Collections.Generic;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface IUserProjectRepository<TKey> : IRepository<UserProjectEntity<TKey>, TKey>
    {
        public IEnumerable<UserEntity<TKey>> GetUsersForProject(TKey projectId);
        public IEnumerable<ProjectEntity<TKey>> GetProjectsForUser(TKey userId);
    }
}
