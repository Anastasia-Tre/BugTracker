using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    public interface IProjectService<TKey>
    {
        public Task<Project<TKey>> GetProjectById(TKey id);

        public Task<IEnumerable<Project<TKey>>> SearchProjects(
            string searchString = "");
    }
}
