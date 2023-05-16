using System.ComponentModel.DataAnnotations;

namespace Bugify.Domain.SeedWork;

public abstract class BaseEntity<TKey>
{
    [Key] public TKey Id { get; set; }

    public DateTime Created { get; set; } = DateTime.Now;
}
