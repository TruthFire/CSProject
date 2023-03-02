using System.ComponentModel.DataAnnotations;

namespace CS_ProjectApp.Models
{
    public class CreateEventForm
    {
        [Required]
        [StringLength(128, ErrorMessage = "Name length can't be more than 128.")]
        public string EventName { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string type { get; set; }
        [Required]
        public DateTime eventStart { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public double ticketPrice { get; set; }
        [Required]
        public int availableTickets { get; set; }
        [Required]
        [Url]
        public string image { get; set; }
        [Required]
        public string organizer { get; set; }

    }
}
