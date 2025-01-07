namespace ReserveSystem.Models
{
    public class JobsViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public string SearchJobName { get; set; }
        public string SearchJobDescription { get; set; }
    }
}
