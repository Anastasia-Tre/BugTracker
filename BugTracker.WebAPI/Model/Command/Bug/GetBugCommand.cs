using System.ComponentModel.DataAnnotations;

namespace BugTracker.WebAPI.Model.Command.Bug
{
    public class GetBugCommand
    {
        [Required]
        public int BugId { get; set; }
    }
}
