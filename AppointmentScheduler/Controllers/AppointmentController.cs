using AppointmentScheduler.Data;
using AppointmentScheduler.Filters;
using AppointmentScheduler.Models;
using AppointmentScheduler.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Controllers
{
    [Authorize] 
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AppointmentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var appointments = await _context.Appointments
                .Where(a => a.UserId == user.Id)
                .ToListAsync();
            return View(appointments);
        }

        public IActionResult Create()
        {
            return View();
        }

        //  POST: Appointment/Create
        [HttpPost]
        [ValidateModelFilter]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Unauthorized();
                }

                var appointment = new Appointment
                {
                    Title = model.Title,
                    Date = model.Date,
                    Description = model.Description,
                    UserId = user.Id
                };

                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        // GET: Appointment/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null || !UserOwnsAppointment(appointment))
            {
                return NotFound();
            }

            var model = new AppointmentViewModel
            {
                Id = appointment.Id,
                Title = appointment.Title,
                Date = appointment.Date,
                Description = appointment.Description
            };

            return View(model);
        }

        // POST: Appointment/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var appointment = await _context.Appointments.FindAsync(model.Id);
                if (appointment == null || !UserOwnsAppointment(appointment))
                {
                    return NotFound();
                }

                appointment.Title = model.Title;
                appointment.Date = model.Date;
                appointment.Description = model.Description;

                _context.Update(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Appointment/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null || !UserOwnsAppointment(appointment))
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null || !UserOwnsAppointment(appointment))
            {
                return NotFound();
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        // Helper Method to Check Ownership
        private bool UserOwnsAppointment(Appointment appointment)
        {
            return appointment.UserId == _userManager.GetUserId(User);
        }
    }
}
