using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;
using AppointmentScheduler.Models;

namespace AppointmentScheduler.Data
{
    public static class DbSeeder
    {
        public static async Task Seed(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                // Apply pending migrations
                await context.Database.MigrateAsync();

                // Ensure an admin user exists
                string email = "admin@Application.com";
                string password = "Admin@123";

                if (!context.Users.Any(u => u.Email == email))
                {
                    var user = new ApplicationUser
                    {
                        UserName = email,
                        Email = email,
                        FullName = "Admin User"
                    };
                    await userManager.CreateAsync(user, password);
                }

                // Seed appointments if empty
                if (!context.Appointments.Any())
                {
                    var adminUser = await userManager.FindByEmailAsync(email);

                    context.Appointments.AddRange(
                        new Appointment { Title = "Team Meeting", Date = DateTime.Now.AddDays(1), Description = "Discuss project updates", UserId = adminUser.Id },
                        new Appointment { Title = "Doctor Appointment", Date = DateTime.Now.AddDays(3), Description = "Routine check-up", UserId = adminUser.Id },
                        new Appointment { Title = "Client Meeting", Date = DateTime.Now.AddDays(5), Description = "Project proposal", UserId = adminUser.Id }
                    );

                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
