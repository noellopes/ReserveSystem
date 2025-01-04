using System;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Schedules
    {
        public int SchedulesId { get; set; }

        [Required(ErrorMessage = "StartShiftTime is required.")]
        [DataType(DataType.Time, ErrorMessage = "StartShiftTime is not a valid time.")]
        public TimeSpan StartShiftTime { get; set; }

        [Required(ErrorMessage = "EndShiftTime is required.")]
        [DataType(DataType.Time, ErrorMessage = "EndShiftTime is not a valid time.")]
        [Compare("StartShiftTime", ErrorMessage = "EndShiftTime must be later than StartShiftTime.")]
        public TimeSpan EndShiftTime { get; set; }

        [Required(ErrorMessage = "isPrecense is required.")]
        public bool isPrecense { get; set; }

        [Required(ErrorMessage = "isAvailable is required.")]
        public bool isAvailable { get; set; }

        [Required(ErrorMessage = "StaffId is required.")]
        public int StaffId { get; set; }
        public Staff? staff { get; set; }

        [Required(ErrorMessage = "TypeOfScheduleId is required.")]
        public int TypeOfScheduleId { get; set; }
        public TypeOfSchedule? typeOfSchedule { get; set; }
    }
}