using Bugify.Domain.SeedWork;

namespace Bugify.Domain.AggregatesModel.UserAggregate;

public interface IUserRepository<TKey> : IRepository<UserEntity<TKey>, TKey>
{
    public Task<IEnumerable<UserEntity<TKey>>> GetAllUsers();
}
