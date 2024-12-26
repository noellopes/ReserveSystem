namespace ReserveSystem.Models
{
    public class Cleaning_Schedule
    {
        public int CleaningScheduleId { get; set; } 
        public int RoomBookingId { get; set; }
        public int ClientId { get; set; }
        public int StaffId { get; set; }

        public DateTime DateServices { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool CleaningDone { get; set; }
    }
}
