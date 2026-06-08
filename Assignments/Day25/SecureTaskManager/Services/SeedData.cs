using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using SecureTaskManager.Models;

namespace SecureTaskManager.Services
{
    public static class SeedData
    {
        public static async Task Initialize(
            IServiceProvider serviceProvider)
        {
            var roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            var userManager =
                serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roles = { "Admin", "User" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(
                        new IdentityRole(role));
            }

            var admin =
                await userManager.FindByEmailAsync("admin@test.com");

            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };

                await userManager.CreateAsync(
                    admin,
                    "Admin@123");

                await userManager.AddToRoleAsync(
                    admin,
                    "Admin");
            }

            var user =
                await userManager.FindByEmailAsync("user@test.com");

            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "user@test.com",
                    Email = "user@test.com"
                };

                await userManager.CreateAsync(
                    user,
                    "User@123");

                await userManager.AddToRoleAsync(
                    user,
                    "User");

                await userManager.AddClaimAsync(
                    user,
                    new Claim("CanEditTask", "true"));
            }
        }
    }
}