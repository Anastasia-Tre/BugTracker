using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataAccessLayer.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.DataAccessLayer.Repositories.Implementation.
    EFImplementation
{
    public class EFProjectRepository : EFRepository<ProjectEntity<int>>,
        IProjectRepository<int>
    {
        public EFProjectRepository(BugTrackerDbContext dbContext) : base(
            dbContext, dbContext.Projects)
        {
        }

        public async Task<IEnumerable<ProjectEntity<int>>> Search(
            string searchString)
        {
            var result = _entities.AsQueryable();
            var isSearchStringEmpty = string.IsNullOrEmpty(searchString);

            if (!isSearchStringEmpty)
            {
                searchString = searchString.ToLower();
                result = await Task.Run(() => result.Where(project =>
                    project.Name.ToLower().Contains(searchString)
                    || project.Description.Contains(searchString)));
            }

            return await result.ToListAsync();
        }
    }
}
