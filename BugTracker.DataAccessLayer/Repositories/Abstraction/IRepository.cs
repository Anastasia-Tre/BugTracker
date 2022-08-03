using System.Collections.Generic;
using BugTracker.DataAccessLayer.Entities;

namespace BugTracker.DataAccessLayer.Repositories.Abstraction
{
    public interface IRepository<T, in TKey> where T : BaseEntity<TKey>
    {
        T GetById(TKey id);
        IEnumerable<T> GetAll();

        void Create(T item);
        void Update(T item);
        void Delete(T item);
    }
}
