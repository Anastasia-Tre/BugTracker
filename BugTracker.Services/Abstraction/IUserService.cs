using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction;

public interface IUserService<TKey>
{
    public System.Threading.Tasks.Task<User<TKey>> GetUserById(TKey id);
    public System.Threading.Tasks.Task<IEnumerable<User<TKey>>> GetAllUsers();

    // public User<TKey> CreateUser();
    // public User<TKey> UpdateUser(TKey id, User<TKey> user);
    // public User<TKey> DeleteUser(TKey id);
}
