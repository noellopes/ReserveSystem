using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Events
    {
        [Key]
        public int event_id { get; set; }

        [Required(ErrorMessage ="Please introduce a name for the event")]
        [StringLength(25)]
        public string nameEv { get; set; }

        [Required(ErrorMessage = "Please introduce the date in which the event starts")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "Please introduce the date in which the event ends")]
        public DateTime endDate { get; set; }

        [Required(ErrorMessage = "Please introduce the fee for the event")]
        public float fee { get; set; }

        [Required]
        public bool anual { get; set; }

        [Required]
        public bool municipal { get; set; }

        [Required]
        public bool national { get; set; }

        public bool inUse { get; set; }

    }
}
