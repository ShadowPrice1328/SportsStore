using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public static class IdentitySeedData
    {
        public const string adminUser = "Admin";
        public const string adminPassword = "Secret123$";
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser? user = await userManager.FindByNameAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser(adminUser)
                {
                    Email = "admin@example.com",
                    PhoneNumber = "+380000000000"
                };
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}