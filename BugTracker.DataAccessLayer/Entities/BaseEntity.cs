using System.ComponentModel.DataAnnotations;

namespace BugTracker.DataAccessLayer.Entities
{
    internal class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
