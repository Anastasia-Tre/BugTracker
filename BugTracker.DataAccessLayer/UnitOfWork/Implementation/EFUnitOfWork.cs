using BugTracker.DataAccessLayer.Repositories.Abstraction;
using BugTracker.DataAccessLayer.UnitOfWork.Abstraction;

namespace BugTracker.DataAccessLayer.UnitOfWork.Implementation
{
    public class EFUnitOfWork<TKey> : IUnitOfWork<TKey>
    {
        private BugTrackerDbContext<TKey> _dbContext;

        public IBugRepository<TKey> BugRepository { get; set; }
        public IUserRepository<TKey> UserRepository { get; set; }
        public IProjectRepository<TKey> ProjectRepository { get; set; }
        public IUserProjectRepository<TKey> UserProjectRepository { get; set; }

        public EFUnitOfWork(BugTrackerDbContext<TKey> dbContext,
            IBugRepository<TKey> bugRepository,
            IUserRepository<TKey> userRepository,
            IProjectRepository<TKey> projectRepository,
            IUserProjectRepository<TKey> userProjectRepository)
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
