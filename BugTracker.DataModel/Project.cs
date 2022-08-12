namespace BugTracker.DataModel
{
    public class Project<TKey>
    {
        public TKey Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        //public List<TKey> UsersId { get; set; }
    }
}
