using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Schedules
    {
        public int SchedulesId { get; set; }

        [Required(ErrorMessage = "StartShiftTime is required.")]
        public TimeSpan StartShiftTime { get; set; }

        [Required(ErrorMessage = "EndShiftTime is required.")]
        public TimeSpan EndShiftTime { get; set; }

        [Required(ErrorMessage = "isPrecense is required.")]
        public bool isPrecense { get; set; }

        [Required(ErrorMessage = "isAvailable is required.")]
        public bool isAvailable { get; set; }

        public int StaffId { get; set; }
        public Staff? staff { get; set; }

        public int TypeOfScheduleId { get; set; }
        public TypeOfSchedule? typeOfSchedule { get; set; }
    }
}
