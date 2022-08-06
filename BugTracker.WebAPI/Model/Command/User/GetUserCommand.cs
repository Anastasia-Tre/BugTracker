using System.ComponentModel.DataAnnotations;

namespace BugTracker.WebAPI.Model.Command.User
{
    public class GetUserCommand
    {
        [Required] public int UserId { get; set; }
    }
}
