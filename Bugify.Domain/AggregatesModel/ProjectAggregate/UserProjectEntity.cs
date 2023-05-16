using Bugify.Domain.AggregatesModel.UserAggregate;
using Bugify.Domain.SeedWork;

namespace Bugify.Domain.AggregatesModel.ProjectAggregate;

public class UserProjectEntity<TKey> : BaseEntity<TKey>
{
    public TKey UserId { get; set; }
    public UserEntity<TKey> UserEntity { get; set; }

    public TKey ProjectId { get; set; }
    public ProjectEntity<TKey> ProjectEntity { get; set; }
}
