using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.
    EFImplementation
{
    public class EFRepository<T> : IRepository<T, int> where T : BaseEntity<int>
    {
        protected readonly BugTrackerDbContext _dbContext;
        protected readonly DbSet<T> _entities;

        public EFRepository(BugTrackerDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _entities = dbSet;
        }

        public async Task Create(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
    }
}
