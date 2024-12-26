using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TypeOfSchedule
    {
        public int TypeOfScheduleId { get; set; }

        [Required(ErrorMessage = "TypeOfScheduleName is required.")]
        [StringLength(100, ErrorMessage = "TypeOfScheduleName must be 100 chars max.")]
        public string TypeOfScheduleName { get; set; }

        [Required(ErrorMessage = "JobDescription is required.")]
        [StringLength(500, ErrorMessage = "JobDescription must be 500 chars max.")]
        public string JobDescription { get; set; }

        public ICollection<Schedules> schedules { get; set; }

    }
}
