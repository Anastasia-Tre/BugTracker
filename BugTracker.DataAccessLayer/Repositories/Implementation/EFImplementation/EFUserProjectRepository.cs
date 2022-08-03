using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public IEnumerable<ProjectEntity<TKey>> GetProjectsForUser(TKey userId)
        {
            throw new NotImplementedException();
        }
    }
}
