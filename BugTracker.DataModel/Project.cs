using System.ComponentModel.DataAnnotations;

namespace BugTracker.DataModel
{
    public class Project
    {
        [Key] public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        //public List<User> UsersId { get; set; }
    }
}
