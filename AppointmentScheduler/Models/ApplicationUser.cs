using Microsoft.AspNetCore.Identity;

namespace AppointmentScheduler.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
