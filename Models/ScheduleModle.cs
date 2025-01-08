using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        public int ScheduleId { get; set; }

        [Required]
        [ForeignKey("StaffId")]
        [Display(Name = "Staff ID")]
        public int StaffId { get; set; }

        public StaffModel? Staff { get; set; }

        [Required]
        [ForeignKey("TypeOfSheduleId")]
        [Display(Name = "Type of Schedule ID")]
        public TypeOfSchedule? TypeOfShedule { get; set; }
        public int TypeOfSheduleId { get; set; }

        [Required]
        [DataType (DataType.Date)]
        public DateOnly Date { get; set; }

        [Required]
        [Display(Name = "Start Shift Time")]
        public DateTime StartShiftTime { get; set; }

        [Required]
        [Display(Name = "End Shift Time")]
        public DateTime EndShiftTime { get; set; }

        public bool Presence { get; set; }

        public bool IsValidShiftTime()
        {
            return EndShiftTime > StartShiftTime;
        }
    }
}
