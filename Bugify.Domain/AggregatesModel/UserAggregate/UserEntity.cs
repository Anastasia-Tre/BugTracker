using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.SeedWork;

namespace Bugify.Domain.AggregatesModel.UserAggregate;

public class UserEntity<TKey> : BaseEntity<TKey>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Title { get; set; }
    public string Bio { get; set; }

    public ICollection<ProjectEntity<TKey>> Projects { get; } =
        new List<ProjectEntity<TKey>>();
    //public TaskEntity<TKey> Tasks { get; set; }
}
