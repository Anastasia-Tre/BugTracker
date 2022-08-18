using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.
    EFImplementation
{
    public class EFUserProjectRepository : EFRepository<UserProjectEntity<int>>,
        IUserProjectRepository<int>
    {
        public EFUserProjectRepository(BugTrackerDbContext dbContext) : base(
            dbContext, dbContext.UserProjects)
        {
        }

        public async Task<IEnumerable<UserEntity<int>>> GetUsersForProject(
            int projectId)
        {
            return await _entities
                .Where(userproject => userproject.ProjectId.Equals(projectId))
                .Select(userproject => userproject.UserEntity)
                .ToListAsync();
        }

        public async Task<IEnumerable<ProjectEntity<int>>> GetProjectsForUser(
            int userId)
        {
            return await _entities
                .Where(userproject => userproject.UserId.Equals(userId))
                .Select(userproject => userproject.ProjectEntity)
                .ToListAsync();
        }
    }
}
