using BugTracker.DataModel.Base;

namespace BugTracker.DataModel
{
    public class Project<TKey> : BaseEntity<TKey>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
