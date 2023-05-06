using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction;

public interface IProjectService<TKey>
{
    public System.Threading.Tasks.Task<Project<TKey>> GetProjectById(TKey id);

    public System.Threading.Tasks.Task<IEnumerable<Project<TKey>>>
        SearchProjects(
            string searchString = "");

    public System.Threading.Tasks.Task<Project<int>>
        CreateProject(Project<int> project);

    public System.Threading.Tasks.Task<Project<int>> 
        UpdateProject(Project<int> project);

    public System.Threading.Tasks.Task<Project<int>>
        DeleteProject(Project<int> project);
}
