using System.Collections.Generic;
using System.Threading.Tasks;

namespace BugTracker.Services.Abstraction
{
    public interface IIdentityService
    {
        Task<bool> SigninUserAsync(string username, string password);
        Task<bool> SignoutUserAsync(string username, string password);

        Task<bool> CreateRoleAsync(string roleName);
        Task<bool> DeleteRoleAsync(string roleId);
        Task<List<(string id, string roleName)>> GetRolesAsync();
        Task<(string id, string roleName)> GetRoleByIdAsync(string id);
        Task<bool> UpdateRole(string id, string roleName);

        Task<bool> IsInRoleAsync(string userId, string role);
        Task<List<string>> GetUserRolesAsync(string userId);
        Task<bool> AssignUserToRole(string username, IList<string> roles);
        Task<bool> UpdateUsersRole(string username, IList<string> usersRole);

    }
}
