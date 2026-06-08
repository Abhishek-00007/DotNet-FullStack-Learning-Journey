using Microsoft.AspNetCore.Identity;
using SecureShoppingApp.Models;

namespace SecureShoppingApp.Data;

public static class DbSeeder
{
    public static async Task SeedRoles(IServiceProvider serviceProvider)
    {
        var roleManager =
            serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        string[] roles = { "Admin", "Customer" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var userManager =
            serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        var admin =
            await userManager.FindByNameAsync("admin");

        if (admin == null)
        {
            admin = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@test.com"
            };

            await userManager.CreateAsync(
                admin,
                "Admin@123"
            );

            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}