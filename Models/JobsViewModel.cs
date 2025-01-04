namespace ReserveSystem.Models
{
    public class JobsViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string SearchJobName { get; set; }
        public string SearchJobDescription { get; set; }
    }
}
