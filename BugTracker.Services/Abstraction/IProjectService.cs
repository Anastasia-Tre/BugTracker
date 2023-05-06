using System.Collections.Generic;
using BugTracker.DataModel;

namespace BugTracker.Services.Abstraction;

public interface IProjectService<TKey>
{
    public System.Threading.Tasks.Task<Project<TKey>> GetProjectById(TKey id);

    public System.Threading.Tasks.Task<IEnumerable<Project<TKey>>>
        SearchProjects(
            string searchString = "");

    public System.Threading.Tasks.Task<Project<TKey>>
        CreateProject(Project<TKey> project);

    public System.Threading.Tasks.Task<Project<TKey>> 
        UpdateProject(Project<TKey> project);

    public System.Threading.Tasks.Task<Project<TKey>>
        DeleteProject(Project<TKey> project);
}
