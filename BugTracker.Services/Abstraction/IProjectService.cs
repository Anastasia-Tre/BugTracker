using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction
{
    internal interface IProjectService<TKey>
    {
        public Project<TKey> GetBugById(TKey id);
        public IEnumerable<Project<TKey>> SearchBugs(string searchString);

        // public Project<TKey> CreateProject();
        // public Project<TKey> DeleteProject(TKey id);
    }
}
