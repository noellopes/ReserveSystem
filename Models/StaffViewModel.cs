namespace ReserveSystem.Models
{
    public class StaffViewModel
    {
        public IEnumerable<Staff> Staffs { get; set; }
        public string SearchName { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
