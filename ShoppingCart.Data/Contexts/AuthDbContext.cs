using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Data.Contexts
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);

            var adminRoleId = "4F2FED6E-34E0-44D3-8E97-E848DFC3DE7C";
            var userRoleId = "83983B7E-DAA2-4843-A246-927D2411D3E5";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole()
                { 
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

            var email = "admin@shoppingcart.com";
            var adminId = "8e9b2e07-5b77-43fa-aee0-91c607c94d79";
            var adminUser = new IdentityUser()
            {
                Id = adminId,
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                PasswordHash = "AQAAAAIAAYagAAAAEJlgiA0cfxn9eghnJ0Cn36MAVkuuqsLQifAhKPGJ5hDZAaxMs0A8895p2D757EEGzg==",
                SecurityStamp = "DAUFPCXDO7ETJ5KJEFU6UDWXLYMGYOJX",
                ConcurrencyStamp = "4719e4aa-f465-4f4a-bc66-085a7e00220f"
            };

            builder.Entity<IdentityUser>().HasData(adminUser);

            var adminUseRole = new IdentityUserRole<string>()
            {
                UserId = adminId,
                RoleId = adminRoleId
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminUseRole);
        }
    }
}
