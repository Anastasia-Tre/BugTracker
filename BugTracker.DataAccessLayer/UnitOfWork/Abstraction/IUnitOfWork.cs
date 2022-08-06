using BugTracker.DataAccessLayer.Repositories.Abstraction;

namespace BugTracker.DataAccessLayer.UnitOfWork.Abstraction
{
    public interface IUnitOfWork<TKey>
    {
        public IBugRepository<TKey> BugRepository { get; set; }
        public IUserRepository<TKey> UserRepository { get; set; }
        public IProjectRepository<TKey> ProjectRepository { get; set; }
        public IUserProjectRepository<TKey> UserProjectRepository { get; set; }

        public void Save();
    }
}
