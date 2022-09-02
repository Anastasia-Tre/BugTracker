namespace BugTracker.DataModel.Base
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
