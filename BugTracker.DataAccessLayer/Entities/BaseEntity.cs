using System.ComponentModel.DataAnnotations;

namespace BugTracker.DataAccessLayer.Entities;

public abstract class BaseEntity<TKey>
{
    [Key] public TKey Id { get; set; }
}
