using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Bugify.Domain.AggregatesModel.UserAggregate;

namespace Bugify.Domain.SeedWork;

public interface IUnitOfWork<TKey>
{
    public ITaskRepository<TKey> TaskRepository { get; set; }
    public IUserRepository<TKey> UserRepository { get; set; }
    public IProjectRepository<TKey> ProjectRepository { get; set; }
    public IUserProjectRepository<TKey> UserProjectRepository { get; set; }

    public Task Save();
}
