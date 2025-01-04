using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TypeOfSchedule
    {
        public int TypeOfScheduleId { get; set; }

        [Required(ErrorMessage = "TypeOfScheduleName is required.")]
        [StringLength(100, ErrorMessage = "TypeOfScheduleName must be 100 chars max.")]
        public required string TypeOfScheduleName { get; set; }

        [Required(ErrorMessage = "TypeOfScheduleDescription is required.")]
        [StringLength(500, ErrorMessage = "TypeOfScheduleDescription must be 500 chars max.")]
        public required string TypeOfScheduleDescription { get; set; }

        public ICollection<Schedules> ? schedules { get; set; }

    }
}
