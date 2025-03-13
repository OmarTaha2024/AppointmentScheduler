using System.ComponentModel.DataAnnotations;

namespace AppointmentScheduler.ViewModels
{
    public class AppointmentViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title cannot be more than 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be more than 500 characters")]
        public string Description { get; set; }
    }
}
