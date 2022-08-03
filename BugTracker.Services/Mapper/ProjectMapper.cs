using BugTracker.DataAccessLayer.Entities;
using BugTracker.DataModel;

namespace BugTracker.Services.Mapper
{
    public static class ProjectMapper
    {
        public static Project<TKey> ToModelEntity<TKey>(
            this ProjectEntity<TKey> project)
        {
            return new Project<TKey>()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }

        public static ProjectEntity<TKey> ToDbEntity<TKey>(
            this Project<TKey> project)
        {
            return new ProjectEntity<TKey>()
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description
            };
        }
    }
}
