namespace BugTracker.DataAccessLayer.Entities
{
    public class UserProjectEntity<TKey> : BaseEntity<TKey>
    {
        public TKey UserId { get; set; }
        public UserEntity<TKey> UserEntity { get; set; }

        public TKey ProjectId { get; set; }
        public ProjectEntity<TKey> ProjectEntity { get; set; }
    }
}
