namespace Bugify.Domain.AggregatesModel.ProjectAggregate;

public interface IProjectService<TKey>
{
    public Task<Project<TKey>> GetProjectById(TKey id);

    public Task<IEnumerable<Project<TKey>>>
        SearchProjects(
            string searchString = "");

    public Task<Project<TKey>>
        CreateProject(Project<TKey> project);

    public Task<Project<TKey>>
        UpdateProject(Project<TKey> project);

    public Task<Project<TKey>>
        DeleteProject(Project<TKey> project);
}
