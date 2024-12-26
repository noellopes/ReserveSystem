using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Cleaning_Schedule
    {
        public int CleaningScheduleId { get; set; } 
        public int RoomBookingId { get; set; }
        public int ClientId { get; set; }
        public int StaffId { get; set; }

        [Required(ErrorMessage = "DateServices is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid format for DateServices.")]
        public DateTime DateServices { get; set; }

        [Required(ErrorMessage = "StartTime is required.")]
        [DataType(DataType.Time, ErrorMessage = "Invalid format for StartTime.")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "EndTime is required.")]
        [DataType(DataType.Time, ErrorMessage = "Invalid format for EndTime.")]

        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "CleaningDone is required.")]
        public bool CleaningDone { get; set; }
    }
}
