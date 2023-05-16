using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Infrastructure.Repositories.EFImplementation;

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

        return await result.OrderByDescending(project => project.Created).ToListAsync();
    }
}
