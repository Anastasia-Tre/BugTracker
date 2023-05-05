using BugTracker.DataAccessLayer.Repositories.Abstraction;
using System.Threading.Tasks;

namespace BugTracker.DataAccessLayer.UnitOfWork.Abstraction;

public interface IUnitOfWork<TKey>
{
    public ITaskRepository<TKey> TaskRepository { get; set; }
    public IUserRepository<TKey> UserRepository { get; set; }
    public IProjectRepository<TKey> ProjectRepository { get; set; }
    public IUserProjectRepository<TKey> UserProjectRepository { get; set; }

    public Task Save();
}
