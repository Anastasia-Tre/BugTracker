using System.Collections.Generic;
using System.Linq;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation
{
    public class EFUserProjectRepository<TKey> : EFRepository<UserProjectEntity<TKey>, TKey>, IUserProjectRepository<TKey>
    {
        public EFUserProjectRepository(BugTrackerDbContext<TKey> dbContext) : base(dbContext, dbContext.UserProjects)
        {
        }

        public IEnumerable<UserEntity<TKey>> GetUsersForProject(TKey projectId)
        {
            return GetAll()
                .Where(userproject => userproject.ProjectId.Equals(projectId))
                .Select(userproject => userproject.UserEntity);
        }

        public IEnumerable<ProjectEntity<TKey>> GetProjectsForUser(TKey userId)
        {
            return GetAll()
                .Where(userproject => userproject.UserId.Equals(userId))
                .Select(userproject => userproject.ProjectEntity);
        }
    }
}
