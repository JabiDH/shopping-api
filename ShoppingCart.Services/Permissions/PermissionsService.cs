using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Services.Permissions
{
    public class PermissionsService : IPermissionsService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public PermissionsService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<bool> HasPermission(string email, string role)
        {
            if (string.IsNullOrEmpty(email)) {  throw new ArgumentNullException("email"); }
            if (string.IsNullOrEmpty(role)) { throw new ArgumentNullException("role"); }

            var userIdentity = await userManager.FindByEmailAsync(email);
            if (userIdentity == null)
            {
                throw new ApplicationException("Email not found.");
            }

            var isValidRole = await roleManager.RoleExistsAsync(role);
            if (!isValidRole)
            {
                throw new ApplicationException("Not a valid role.");
            }

            return await userManager.IsInRoleAsync(userIdentity, role);
        }
    }
}
