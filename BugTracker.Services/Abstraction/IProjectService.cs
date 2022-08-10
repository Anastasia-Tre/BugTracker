using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    public interface IProjectService<in TKey>
    {
        public Task<Project<int>> GetProjectById(TKey id);

        public Task<IEnumerable<Project<int>>> SearchProjects(
            string searchString);

        // public Project<TKey> CreateProject();
        // public Project<TKey> DeleteProject(TKey id);
    }
}
