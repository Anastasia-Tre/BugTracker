using System.Collections.Generic;
using System.Linq;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.EFImplementation
{
    public class EFUserProjectRepository : EFRepository<UserProjectEntity<int>>, IUserProjectRepository<int>
    {
        public EFUserProjectRepository(BugTrackerDbContext dbContext) : base(dbContext, dbContext.UserProjects)
        {
        }

        public IEnumerable<UserEntity<int>> GetUsersForProject(int projectId)
        {
            return GetAll()
                .Where(userproject => userproject.ProjectId.Equals(projectId))
                .Select(userproject => userproject.UserEntity);
        }

        public IEnumerable<ProjectEntity<int>> GetProjectsForUser(int userId)
        {
            return GetAll()
                .Where(userproject => userproject.UserId.Equals(userId))
                .Select(userproject => userproject.ProjectEntity);
        }
    }
}
