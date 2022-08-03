namespace BugTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public List<Project> Projects { get; set; }

        //public List<int> BugIds { get; set; }
        //public List<Bug> Bugs { get; set; }
    }
}
