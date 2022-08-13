using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface IUserRepository<TKey> : IRepository<UserEntity<TKey>, TKey>
    {
        public Task<IEnumerable<UserEntity<TKey>>> GetAllUsers();
    }
}
