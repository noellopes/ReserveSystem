namespace ReserveSystem.Models
{
    public class SchedulesViewModel
    {
        public IEnumerable<Schedules> Schedules { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchName { get; set; }
    }
}
