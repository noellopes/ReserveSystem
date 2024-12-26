namespace ReserveSystem.Models
{
    public class Schedules
    {
        public int SchedulesId { get; set; }
        public DateTime StartShiftTime { get; set; }
        public DateTime EndShiftTime { get; set; }
        public bool isPrecense { get; set; }
        public bool isAvailable { get; set; }

        public int StaffId { get; set; }
        public Staff staff { get; set; }

        public int TypeOfScheduleId { get; set; }
        public TypeOfSchedule typeOfSchedule { get; set; }
    }
}
