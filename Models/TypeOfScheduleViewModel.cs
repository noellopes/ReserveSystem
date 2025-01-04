namespace ReserveSystem.Models
{
    public class TypeOfScheduleViewModel
    {
        public IEnumerable<TypeOfSchedule> TypeOfSchedules { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string SearchTypeOfScheduleName { get; set; }
        public string SearchTypeOfScheduleDescription { get; set; }
    }
}
