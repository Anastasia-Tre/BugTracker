using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction;

public interface IRepository<T, in TKey> where T : BaseEntity<TKey>
{
    Task<T> GetById(TKey id);

    Task Create(T item);
    void Update(T item);
    void Delete(T item);
}
