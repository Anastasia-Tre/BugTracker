using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BugTracker.Services.Abstraction;
using Microsoft.AspNetCore.Identity;
using BugTracker.DataAccessLayer.Identity;
using Microsoft.EntityFrameworkCore;

namespace BugTracker.Services.Implementation
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _roleManager = roleManager;
        }

        public Task<bool> SigninUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SignoutUserAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateRoleAsync(string roleName)
        {
            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.ToString());
            }
            return result.Succeeded;
        }

        public Task<bool> DeleteRoleAsync(string roleId)
        {
            throw new NotImplementedException();
        }

        public Task<List<(string id, string roleName)>> GetRolesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(string id, string roleName)> GetRoleByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateRole(string id, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(string userId, string role)
        {
            throw new NotImplementedException();
        }

        public Task<List<string>> GetUserRolesAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AssignUserToRole(string username, IList<string> roles)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == username);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var result = await _userManager.AddToRolesAsync(user, roles);
            return result.Succeeded;
        }

        public Task<bool> UpdateUsersRole(string username, IList<string> usersRole)
        {
            throw new NotImplementedException();
        }
    }
}
