using BugTracker.DataAccessLayer.Repositories.Abstraction;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;

namespace BugTracker.DataAccessLayer.UnitOfWork.Implementation
{
    public class EFUnitOfWork : IUnitOfWork<int>
    {
        private BugTrackerDbContext _dbContext;

        public IBugRepository<int> BugRepository { get; set; }
        public IUserRepository<int> UserRepository { get; set; }
        public IProjectRepository<int> ProjectRepository { get; set; }
        public IUserProjectRepository<int> UserProjectRepository { get; set; }

        public EFUnitOfWork(BugTrackerDbContext dbContext,
            IBugRepository<int> bugRepository,
            IUserRepository<int> userRepository,
            IProjectRepository<int> projectRepository,
            IUserProjectRepository<int> userProjectRepository)
        {
            _dbContext = dbContext;
            BugRepository = bugRepository;
            UserRepository = userRepository;
            ProjectRepository = projectRepository;
            UserProjectRepository = userProjectRepository;
        }

        ~EFUnitOfWork()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
