using BugTracker.DataAccessLayer.Entities.Base;

namespace BugTracker.DataAccessLayer.Entities
{
    public class UserEntity<TKey> : BaseEntity<TKey>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
