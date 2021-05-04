using Microsoft.AspNetCore.Identity;
using ServerSite.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSite.Data
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedEssentialsAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles

            if (!roleManager.RoleExistsAsync("admin").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (!roleManager.RoleExistsAsync("user").Result)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            //Seed Default User
            var admin = new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0123456789",
                FullName = "Admin",
                PhoneNumberConfirmed = true
            };
            var user = new User
            {
                UserName = "user@gmail.com",
                Email = "user@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "0123456789",
                FullName = "User",
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.Count(u => u.Email == admin.Email) == 0)
            {
                IdentityResult result = await userManager.CreateAsync(admin, "Admin123!");
                if (result.Succeeded)
                {

                    await userManager.AddToRoleAsync(admin, "admin");

                }
                IdentityResult result1 = await userManager.CreateAsync(user, "User123!");
                if (result1.Succeeded)
                {

                    await userManager.AddToRoleAsync(user, "user");

                }
            }
        }
    }
}
