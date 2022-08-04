using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    public interface IProjectService<TKey>
    {
        public Project<TKey> GetProjectById(TKey id);
        public IEnumerable<Project<TKey>> SearchProjects(string searchString);

        // public Project<TKey> CreateProject();
        // public Project<TKey> DeleteProject(TKey id);
    }
}
