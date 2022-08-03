using BugTracker.DataAccessLayer.Entities.Enums;

namespace BugTracker.DataAccessLayer.Entities
{
    public class BugEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public BugStatus Status { get; set; }
        public BugType Type { get; set; }
        public BugPriority Priority { get; set; }

        public int AuthorId { get; set; }

        //public List<User> AssignToIds { get; set; }
        public int ProjectId { get; set; }

        public string Date { get; set; }
        public float Estimate { get; set; }
    }

    public class BugUser
    {
    }
}
