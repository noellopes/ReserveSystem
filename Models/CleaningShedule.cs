namespace ReserveSystem.Models
{
    public class CleaningShedule
    {
        public int CleaningSheduleId { get; set; }
        public DateTime DateServices { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public int CleaningId { get; set; }
        public Cleaning cleaning { get; set; }

        public int StaffId { get; set; }
        public Staff staff { get; set; }

        public int RoomBookingId { get; set; }
        public RoomBooking roomBooking { get; set; }
    }
}
