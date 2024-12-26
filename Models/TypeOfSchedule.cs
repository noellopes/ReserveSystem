namespace ReserveSystem.Models
{
    public class TypeOfSchedule
    {
        public int TypeOfScheduleId { get; set; }
        public string TypeOfScheduleName { get; set; }
        public string JobDescription { get; set; }
        public ICollection<Schedules> schedules { get; set; }
    }
}
