using Bugify.Domain.AggregatesModel.UserAggregate;
using Bugify.Domain.SeedWork;

namespace Bugify.Domain.AggregatesModel.ProjectAggregate;

public class ProjectEntity<TKey> : BaseEntity<TKey>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Deadline { get; set; }
    public ProjectStatus Status { get; set; }

    public TKey AuthorId { get; set; }
    public UserEntity<TKey> Author { get; set; }

    //public TaskEntity<TKey>[] Tasks { get; set; }
    //public UserEntity<TKey>[] Team { get; set; }
}
