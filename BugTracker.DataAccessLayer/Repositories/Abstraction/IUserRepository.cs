using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface IUserRepository<TKey> : IRepository<UserEntity<TKey>, TKey>
    {

    }
}
