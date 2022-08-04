using System.ComponentModel.DataAnnotations;

namespace BugTracker.WebAPI.Model.Command.Bug
{
    public class AssignBugToUserCommand
    {
        [Required]
        public int BugId { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
