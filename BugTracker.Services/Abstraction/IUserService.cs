using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction;

public interface IUserService<TKey>
{
    public System.Threading.Tasks.Task<User<TKey>> GetUserById(TKey id);
    public System.Threading.Tasks.Task<IEnumerable<User<TKey>>> GetAllUsers();

    public System.Threading.Tasks.Task<User<TKey>>
        CreateUser(User<TKey> user);

    public System.Threading.Tasks.Task<User<TKey>>
        UpdateUser(User<TKey> user);

    public System.Threading.Tasks.Task<User<TKey>>
        DeleteUser(User<TKey> user);
}
