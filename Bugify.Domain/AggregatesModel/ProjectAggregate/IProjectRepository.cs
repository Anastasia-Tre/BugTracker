using Bugify.Domain.SeedWork;

namespace Bugify.Domain.AggregatesModel.ProjectAggregate;

public interface
    IProjectRepository<TKey> : IRepository<ProjectEntity<TKey>, TKey>
{
    public Task<IEnumerable<ProjectEntity<TKey>>>
        Search(string searchString);
}
