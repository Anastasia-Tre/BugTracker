using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction;

public interface
    IUserProjectRepository<TKey> : IRepository<UserProjectEntity<TKey>,
        TKey>
{
    public Task<IEnumerable<UserEntity<TKey>>> GetUsersForProject(
        TKey projectId);

    public Task<IEnumerable<ProjectEntity<TKey>>> GetProjectsForUser(
        TKey userId);
}
