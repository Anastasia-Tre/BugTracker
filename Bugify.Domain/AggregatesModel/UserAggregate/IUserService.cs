namespace Bugify.Domain.AggregatesModel.UserAggregate;

public interface IUserService<TKey>
{
    public Task<User<TKey>> GetUserById(TKey id);
    public Task<IEnumerable<User<TKey>>> GetAllUsers();

    public Task<User<TKey>>
        CreateUser(User<TKey> user);

    public Task<User<TKey>>
        UpdateUser(User<TKey> user);

    public Task<User<TKey>>
        DeleteUser(User<TKey> user);
}
