using Bugify.Domain.AggregatesModel.UserAggregate;
using Bugify.Domain.SeedWork;

namespace Bugify.Domain.AggregatesModel.ProjectAggregate;

public interface
    IUserProjectRepository<TKey> : IRepository<UserProjectEntity<TKey>,
        TKey>
{
    public Task<IEnumerable<UserEntity<TKey>>> GetUsersForProject(
        TKey projectId);

    public Task<IEnumerable<ProjectEntity<TKey>>> GetProjectsForUser(
        TKey userId);
}
