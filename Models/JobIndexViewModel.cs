namespace ReserveSystem.Models
{
    public class JobIndexViewModel
    {
        public List<JobModel> Jobs { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}
