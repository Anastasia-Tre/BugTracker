using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    public interface IUserService<TKey>
    {
        public Task<User<TKey>> GetUserById(TKey id);
        public Task<IEnumerable<User<int>>> GetAllUsers();

        // public User<TKey> CreateUser();
        // public User<TKey> UpdateUser(TKey id, User<TKey> user);
        // public User<TKey> DeleteUser(TKey id);
    }
}
