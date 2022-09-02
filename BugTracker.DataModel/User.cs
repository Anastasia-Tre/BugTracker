using BugTracker.DataModel.Base;

namespace BugTracker.DataModel
{
    public class User<TKey> : BaseEntity<TKey>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
