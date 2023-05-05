using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;

namespace BugTracker.DataAccessLayer.UnitOfWork.Implementation;

public class EFUnitOfWork : IUnitOfWork<int>
{
    private readonly BugTrackerDbContext _dbContext;

    public EFUnitOfWork(BugTrackerDbContext dbContext,
        ITaskRepository<int> taskRepository,
        IUserRepository<int> userRepository,
        IProjectRepository<int> projectRepository,
        IUserProjectRepository<int> userProjectRepository)
    {
        _dbContext = dbContext;
        TaskRepository = taskRepository;
        UserRepository = userRepository;
        ProjectRepository = projectRepository;
        UserProjectRepository = userProjectRepository;
    }

    public ITaskRepository<int> TaskRepository { get; set; }
    public IUserRepository<int> UserRepository { get; set; }
    public IProjectRepository<int> ProjectRepository { get; set; }
    public IUserProjectRepository<int> UserProjectRepository { get; set; }

    public async Task Save()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async void Dispose()
    {
        await _dbContext.DisposeAsync();
    }

    ~EFUnitOfWork()
    {
        _dbContext.DisposeAsync();
    }
}
