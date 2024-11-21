using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Events
    {
        [Key]
        public int event_id { get; set; }

        [Required]
        [StringLength(25)]
        public string nameEv { get; set; }

        [Required]
        public DateTime startDate { get; set; }

        [Required]
        public DateTime endDate { get; set; }

        [Required]
        public float fee { get; set; }

        [Required]
        public bool anual { get; set; }

        [Required]
        public bool municipal { get; set; }

        [Required]
        public bool national { get; set; }

    }
}
